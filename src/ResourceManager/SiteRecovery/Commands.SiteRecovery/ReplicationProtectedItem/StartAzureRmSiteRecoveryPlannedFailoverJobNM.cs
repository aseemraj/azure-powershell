﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Portal.RecoveryServices.Models.Common;
using Microsoft.Azure.Management.SiteRecovery.Models;
using System.Collections.Generic;
using System.IO;

namespace Microsoft.Azure.Commands.SiteRecovery
{
    /// <summary>
    /// Used to initiate a failover operation.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Start, "AzureRmSiteRecoveryPlannedFailoverJobNM", DefaultParameterSetName = ASRParameterSets.ByPEObject)]
    [OutputType(typeof(ASRJob))]
    public class StartAzureRmSiteRecoveryPlannedFailoverJobNM : SiteRecoveryCmdletBase
    {
        #region local parameters

        /// <summary>
        /// Gets or sets Name of the Protection Container.
        /// </summary>
        public string protectionContainerName;

        /// <summary>
        /// Gets or sets Name of the Fabric.
        /// </summary>
        public string fabricName;

        /// <summary>
        /// Primary Kek Cert pfx file.
        /// </summary>
        string primaryKekCertpfx = null;

        /// <summary>
        /// Secondary Kek Cert pfx file.
        /// </summary>
        string secondaryKekCertpfx = null;

        #endregion local parameters

        #region Parameters

        /// <summary>
        /// Gets or sets Recovery Plan object.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByRPObject, Mandatory = true, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRRecoveryPlan RecoveryPlan { get; set; }

        /// <summary>
        /// Gets or sets Replication Protected Item.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByPEObject, Mandatory = true, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRReplicationProtectedItem ReplicationProtectedItem { get; set; }

        /// <summary>
        /// Gets or sets Failover direction for the protected Item.
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateSet(Constants.PrimaryToRecovery, Constants.RecoveryToPrimary)]
        public string Direction { get; set; }

        /// <summary>
        /// Gets or sets the Optimize value.
        /// </summary>
        [Parameter]
        [ValidateSet(Constants.ForDowntime, Constants.ForSynchronization)]
        public string Optimize { get; set; }

        /// <summary>
        /// Gets or sets Data encryption certificate file path for failover of Protected Item.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        public string DataEncryptionPrimaryCertFile { get; set; }

        /// <summary>
        /// Gets or sets Data encryption certificate file path for failover of Protected Item.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        public string DataEncryptionSecondaryCertFile { get; set; }

        #endregion Parameters

        /// <summary>
        /// ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

            if (!string.IsNullOrEmpty(this.DataEncryptionPrimaryCertFile))
            {
                byte[] certBytesPrimary = File.ReadAllBytes(this.DataEncryptionPrimaryCertFile);
                primaryKekCertpfx = Convert.ToBase64String(certBytesPrimary);
            }

            if (!string.IsNullOrEmpty(this.DataEncryptionSecondaryCertFile))
            {
                byte[] certBytesSecondary = File.ReadAllBytes(this.DataEncryptionSecondaryCertFile);
                secondaryKekCertpfx = Convert.ToBase64String(certBytesSecondary);
            }

            switch (this.ParameterSetName)
            {
                case ASRParameterSets.ByPEObject:
                    this.protectionContainerName = 
                        Utilities.GetValueFromArmId(this.ReplicationProtectedItem.ID, ARMResourceTypeConstants.ReplicationProtectionContainers);
                    this.fabricName = Utilities.GetValueFromArmId(this.ReplicationProtectedItem.ID, ARMResourceTypeConstants.ReplicationFabrics);
                    this.StartPEPlannedFailover();
                    break;
                case ASRParameterSets.ByRPObject:
                    this.StartRpPlannedFailover();
                    break;
            }
        }

        /// <summary>
        /// Starts PE Planned failover.
        /// </summary>
        private void StartPEPlannedFailover()
        {
            var plannedFailoverInputProperties = new PlannedFailoverInputProperties()
            {
                FailoverDirection = this.Direction,
                ProviderSpecificDetails = new ProviderSpecificFailoverInput()
            };

            var input = new PlannedFailoverInput()
            {
                Properties = plannedFailoverInputProperties
            };

            if (0 == string.Compare(
                this.ReplicationProtectedItem.ReplicationProvider,
                Constants.HyperVReplicaAzure,
                StringComparison.OrdinalIgnoreCase))
            {
                if (this.Direction == Constants.PrimaryToRecovery)
                {
                    var failoverInput = new HyperVReplicaAzureFailoverProviderInput()
                    {
                        PrimaryKekCertificatePfx = primaryKekCertpfx,
                        SecondaryKekCertificatePfx = secondaryKekCertpfx,
                        VaultLocation = this.GetCurrentVaultLocation()
                    };
                    input.Properties.ProviderSpecificDetails = failoverInput;
                }
                else
                {
                    var failbackInput = new HyperVReplicaAzureFailbackProviderInput()
                    {
                        DataSyncOption = this.Optimize == Constants.ForDowntime ? Constants.ForDowntime : Constants.ForSynchronization,
                        RecoveryVmCreationOption = "CreateVmIfNotFound" //CreateVmIfNotFound | NoAction
                    };
                    input.Properties.ProviderSpecificDetails = failbackInput;
                }
            }

            LongRunningOperationResponse response =
                RecoveryServicesClient.StartAzureSiteRecoveryPlannedFailover(
                this.fabricName,
                this.protectionContainerName,
                this.ReplicationProtectedItem.Name,
                input);

            JobResponse jobResponse =
                RecoveryServicesClient
                .GetAzureSiteRecoveryJobDetails(PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

            WriteObject(new ASRJob(jobResponse.Job));
        }

        /// <summary>
        /// Starts RP Planned failover.
        /// </summary>
        private void StartRpPlannedFailover()
        {
            // Refresh RP Object
            var rp = RecoveryServicesClient.GetAzureSiteRecoveryRecoveryPlan(this.RecoveryPlan.Name);

            var recoveryPlanPlannedFailoverInputProperties = new RecoveryPlanPlannedFailoverInputProperties()
            {
                FailoverDirection = this.Direction,
                ProviderSpecificDetails = new List<RecoveryPlanProviderSpecificFailoverInput>()
            };

            foreach (string replicationProvider in rp.RecoveryPlan.Properties.ReplicationProviders)
            {
                if (0 == string.Compare(
                    replicationProvider,
                    Constants.HyperVReplicaAzure,
                    StringComparison.OrdinalIgnoreCase))
                {
                    if (this.Direction == Constants.PrimaryToRecovery)
                    {
                        var recoveryPlanHyperVReplicaAzureFailoverInput = new RecoveryPlanHyperVReplicaAzureFailoverInput()
                        {
                            InstanceType = replicationProvider,
                            PrimaryKekCertificatePfx = primaryKekCertpfx,
                            SecondaryKekCertificatePfx = secondaryKekCertpfx,
                            VaultLocation = this.GetCurrentVaultLocation()
                        };
                        recoveryPlanPlannedFailoverInputProperties.ProviderSpecificDetails.Add(recoveryPlanHyperVReplicaAzureFailoverInput);
                    }
                    else
                    {
                        var recoveryPlanHyperVReplicaAzureFailbackInput = new RecoveryPlanHyperVReplicaAzureFailbackInput()
                        {
                            InstanceType = replicationProvider + "Failback",
                            DataSyncOption = this.Optimize == Constants.ForDowntime ? Constants.ForDowntime : Constants.ForSynchronization,
                            RecoveryVmCreationOption = "CreateVmIfNotFound" //CreateVmIfNotFound | NoAction
                        };
                        recoveryPlanPlannedFailoverInputProperties.ProviderSpecificDetails.Add(recoveryPlanHyperVReplicaAzureFailbackInput);
                    }
                }
            }

            var recoveryPlanPlannedFailoverInput = new RecoveryPlanPlannedFailoverInput()
            {
                Properties = recoveryPlanPlannedFailoverInputProperties
            };

            LongRunningOperationResponse response = RecoveryServicesClient.StartAzureSiteRecoveryPlannedFailover(
                this.RecoveryPlan.Name,
                recoveryPlanPlannedFailoverInput);

            JobResponse jobResponse =
                RecoveryServicesClient
                .GetAzureSiteRecoveryJobDetails(PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

            WriteObject(new ASRJob(jobResponse.Job));
        }
    }
}
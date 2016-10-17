// ----------------------------------------------------------------------------------
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

using Microsoft.Azure.Management.SiteRecovery.Models;
using Microsoft.Azure.Portal.RecoveryServices.Models.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.Serialization;

namespace Microsoft.Azure.Commands.SiteRecovery
{
    /// <summary>
    /// Azure Site Recovery Vault Settings.
    /// </summary>
    [SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Keeping all related objects together.")]
    public class ASRVaultSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ASRVaultSettings" /> class.
        /// </summary>
        public ASRVaultSettings()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ASRVaultSettings" /> class
        /// </summary>
        /// <param name="asrVaultCreds">Vault credentails</param>
        public ASRVaultSettings(ASRVaultCreds asrVaultCreds)
        {
            this.ResourceName = asrVaultCreds.ResourceName;
            this.ResourceGroupName = asrVaultCreds.ResourceGroupName;
            this.ResourceNamespace = asrVaultCreds.ResourceNamespace;
            this.ResouceType = asrVaultCreds.ARMResourceType;
        }

        #region Properties
        /// <summary>
        /// Gets or sets Resource Name.
        /// </summary>
        public string ResourceName { get; set; }

        /// <summary>
        /// Gets or sets Resource Group Name.
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets Resource Provider Namespace.
        /// </summary>
        public string ResourceNamespace { get; set; }

        /// <summary>
        /// Gets or sets Resource Type.
        /// </summary>
        public string ResouceType { get; set; }
        #endregion Properties
    }

    
    /// <summary>
    /// Azure Site Recovery Site object.
    /// </summary>
    public class ASRFabric
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ASRSite" /> class.
        /// </summary>
        public ASRFabric()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ASRSite" /> class.
        /// </summary>
        /// <param name="site">Hydra site object.</param>
        public ASRFabric(Fabric fabric)
        {
            this.Name = fabric.Name;
            this.FriendlyName = fabric.Properties.FriendlyName;
            this.ID = fabric.Id;
            //this.Type = (fabric.Properties.CustomDetails as AzureFabricSpecificDetails).Location;
            this.SiteIdentifier = fabric.Properties.InternalIdentifier;
        }

        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets display name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets friendly name.
        /// </summary>
        public string FriendlyName { get; set; }

        /// <summary>
        /// Gets or sets ID.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// Gets or sets site type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets site SiteIdentifier.
        /// </summary>
        public string SiteIdentifier { get; set; }

        #endregion
    }


    /// <summary>
    /// ASRGroupTaskDetails of the Task.
    /// </summary>
    public class ASRGroupTaskDetails
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ASRGroupTaskDetails" /> class.
        /// </summary>
        public ASRGroupTaskDetails()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ASRGroupTaskDetails" /> class.
        /// </summary>
        /// <param name="task">Task details to load values from.</param>
        public ASRGroupTaskDetails(GroupTaskDetails groupTaskDetails)
        {
            this.Type = groupTaskDetails.InstanceType;
            ChildTasks = new List<ASRTaskBase>();
            if (groupTaskDetails.ChildTasks != null)
            {
                ChildTasks = groupTaskDetails.ChildTasks.Select(ct => new ASRTaskBase()).ToList();
            }
        }

        /// <summary>
        /// Gets or sets ASRGroupTaskDetails Type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Child Tasks.
        /// </summary>
        List<ASRTaskBase> ChildTasks { get; set; }
    }

    /// <summary>
    /// ASRTaskBase.
    /// </summary>
    public class ASRTaskBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ASRTaskBase" /> class.
        /// </summary>
        public ASRTaskBase()
        {
        }
        /*
        /// <summary>
        /// Initializes a new instance of the <see cref="ASRTaskBase" /> class.
        /// </summary>
        /// <param name="task">Base task details to load values from.</param>
        public ASRTaskBase(TaskBase taskBase)
        {
            this.ID = taskBase.ID;
            this.Name = taskBase.TaskFriendlyName;
            if (taskBase.EndTime != null)
            {
                this.EndTime = taskBase.EndTime.ToLocalTime();
            }

            if (taskBase.StartTime != null)
            {
                this.StartTime = taskBase.StartTime.ToLocalTime();
            }

            this.State = taskBase.State;
            this.StateDescription = taskBase.StateDescription;
        }
        */

        /// <summary>
        /// Gets or sets the task name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Job ID.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// Gets or sets the Status.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the State description, which tells the exact internal state.
        /// </summary>
        public string StateDescription { get; set; }

        /// <summary>
        /// Gets or sets the start time.
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Gets or sets the end time.
        /// </summary>
        public DateTime EndTime { get; set; }
    }

    /// <summary>
    /// Task of the Job.
    /// </summary>
    public class ASRTask
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ASRTask" /> class.
        /// </summary>
        public ASRTask()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ASRTask" /> class.
        /// </summary>
        /// <param name="task">Task details to load values from.</param>
        public ASRTask(STask task)
        {
            this.ID = task.TaskId;
            if (task.EndTime != null)
            {
                this.EndTime = task.EndTime;
            }
            this.Name = task.FriendlyName;
            if (task.StartTime != null)
            {
                this.StartTime = task.StartTime;
            }
            this.State = task.State;
            this.StateDescription = task.StateDescription;
            if (task.GroupTaskCustomDetails != null)
            {
                this.GroupTaskDetails = new ASRGroupTaskDetails(task.GroupTaskCustomDetails);
            }
        }

        /// <summary>
        /// Gets or sets the task name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Job ID.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// Gets or sets the Status.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the State description, which tells the exact internal state.
        /// </summary>
        public string StateDescription { get; set; }

        /// <summary>
        /// Gets or sets the start time.
        /// </summary>
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// Gets or sets the end time.
        /// </summary>
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// Gets or sets the GroupTaskDetails
        /// </summary>
        public ASRGroupTaskDetails GroupTaskDetails { get; set; }
    }

    /// <summary>
    /// Azure Site Recovery Job.
    /// </summary>
    public class ASRJob
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ASRJob" /> class.
        /// </summary>
        public ASRJob()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ASRJob" /> class with required parameters.
        /// </summary>
        /// <param name="job">ASR Job object</param>
        public ASRJob(Job job)
        {
            this.ID = job.Id;
            this.Type = job.Type;
            this.JobType = job.Properties.ScenarioName;
            this.DisplayName = job.Properties.FriendlyName;
            this.ClientRequestId = job.Properties.ActivityId;
            this.State = job.Properties.State;
            this.StateDescription = job.Properties.StateDescription;
            this.Name = job.Name;
            this.TargetObjectId = job.Properties.TargetObjectId;
            this.TargetObjectName = job.Properties.TargetObjectName;
            if (job.Properties.EndTime.HasValue)
                this.EndTime = job.Properties.EndTime.Value.ToLocalTime();
            if (job.Properties.StartTime.HasValue)
                this.StartTime = job.Properties.StartTime.Value.ToLocalTime();
            if (job.Properties.AllowedActions != null && job.Properties.AllowedActions.Count > 0)
            {
                this.AllowedActions = new List<string>();
                foreach (var action in job.Properties.AllowedActions)
                {
                    this.AllowedActions.Add(action);
                }
            }

            if (!string.IsNullOrEmpty(job.Properties.TargetObjectId))
            {
                this.TargetObjectType = job.Properties.TargetInstanceType;
            }

            this.Tasks = new List<ASRTask>();
            foreach (var task in job.Properties.Tasks)
            {
                this.Tasks.Add(new ASRTask(task));
            }

            this.Errors = new List<ASRErrorDetails>();

            foreach (var error in job.Properties.Errors)
            {
                ASRErrorDetails errorDetails = new ASRErrorDetails();
                errorDetails.TaskId = error.TaskId;
                errorDetails.ServiceErrorDetails = new ASRServiceError();
                errorDetails.ProviderErrorDetails = new ASRProviderError();
                this.Errors.Add(errorDetails);
            }
        }

        #region Properties
        /// <summary>
        /// Gets or sets Job display name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Job ID.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// Gets or sets type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets Job display name.
        /// </summary>
        public string JobType { get; set; }

        /// <summary>
        /// Gets or sets Job display name.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets Activity ID.
        /// </summary>
        public string ClientRequestId { get; set; }

        /// <summary>
        /// Gets or sets State of the Job.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Gets or sets StateDescription of the Job.
        /// </summary>
        public string StateDescription { get; set; }

        /// <summary>
        /// Gets or sets Start timestamp.
        /// </summary>
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// Gets or sets End timestamp.
        /// </summary>
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// Gets or sets TargetObjectId.
        /// </summary>
        public string TargetObjectId { get; set; }

        /// <summary>
        /// Gets or sets TargetObjectType.
        /// </summary>
        public string TargetObjectType { get; set; }

        /// <summary>
        /// Gets or sets End timestamp.
        /// </summary>
        public string TargetObjectName { get; set; }

        /// <summary>
        /// Gets or sets list of allowed actions.
        /// </summary>
        public List<string> AllowedActions { get; set; }

        /// <summary>
        /// Gets or sets list of tasks.
        /// </summary>
        public List<ASRTask> Tasks { get; set; }

        /// <summary>
        /// Gets or sets list of Errors.
        /// </summary>
        public List<ASRErrorDetails> Errors { get; set; }
        #endregion
    }


    /// <summary>
    /// Azure Site Recovery Vault properties.
    /// </summary>
    public class ASRVaultProperties
    {
        #region Properties

        /// <summary>
        /// Gets or sets Provisioning State.
        /// </summary>
        public string ProvisioningState { get; set; }

        #endregion
    }

    /// <summary>
    /// This class contains the error details per object.
    /// </summary>
    public class ASRErrorDetails
    {
        /// <summary>
        /// Gets or sets the Service error details.
        /// </summary>
        public ASRServiceError ServiceErrorDetails { get; set; }

        /// <summary>
        /// Gets or sets the Provider error details.
        /// </summary>
        public ASRProviderError ProviderErrorDetails { get; set; }

        /// <summary>
        /// Gets or sets the Id of the task.
        /// </summary>
        public string TaskId { get; set; }
    }

    /// <summary>
    /// This class contains the ASR error details per object.
    /// </summary>
    public class ASRServiceError : Error
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ASRServiceError" /> class with required parameters.
        /// </summary>
        public ASRServiceError()
        {
        }
    }

    /// <summary>
    /// Class to define the output of the vault settings file generation.
    /// </summary>
    public class VaultSettingsFilePath
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="VaultSettingsFilePath" /> class
        /// </summary>
        public VaultSettingsFilePath()
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the path of generated credential file.
        /// </summary>
        public string FilePath { get; set; }

        #endregion
    }

    /// <summary>
    /// Class to define the output object for the vault operations.
    /// </summary>
    public class VaultOperationOutput
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="VaultOperationOutput" /> class
        /// </summary>
        public VaultOperationOutput()
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the operation tracking id of the operation performed.
        /// </summary>
        public string Response { get; set; }

        #endregion
    }

    /// <summary>
    /// This class contains the provider error details per object.
    /// </summary>
    public class ASRProviderError
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ASRProviderError" /> class with required parameters.
        /// </summary>
        public ASRProviderError()
        {
        }


        /// <summary>
        /// Gets or sets the Error code.
        /// </summary>
        public int ErrorCode { get; set; }

        /// <summary>
        /// Gets or sets the Error message
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Gets or sets the Provider error Id
        /// </summary>
        public string ErrorId { get; set; }

        /// <summary>
        /// Gets or sets the Time of the error creation.
        /// </summary>
        public DateTime CreationTimeUtc { get; set; }
    }

    /// <summary>
    /// Represents Azure site recovery storage classification.
    /// </summary>
    public class ASRStorageClassification
    {
        /// <summary>
        /// Gets or sets Storage classification ARM Id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets Storage classification ARM name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Storage classification friendly name.
        /// </summary>
        public string FriendlyName { get; set; }
    }

}
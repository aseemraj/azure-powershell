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

using AutoMapper;
using Microsoft.Azure.Management.SiteRecovery;
using Microsoft.Azure.Management.SiteRecovery.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.SiteRecovery
{
    /// <summary>
    /// Recovery services convenience client.
    /// </summary>
    public partial class PSRecoveryServicesClient
    {
        /// <summary>
        /// Retrieves Replicated Protected Item.
        /// </summary>
        /// <param name="protectionContainerName">Protection Container Name</param>
        /// <returns>Protection entity list response</returns>
        public List<ReplicationProtectedItem> GetAzureSiteRecoveryReplicationProtectedItem(string fabricName,
            string protectionContainerName)
        {
            var pages = this.GetSiteRecoveryClient().ReplicationProtectedItems.ListByProtectionContainer(fabricName, protectionContainerName);
            return Utilities.IpageToList(pages);
        }

        /// <summary>
        /// Retrieves Protected Items.
        /// </summary>
        /// <param name="protectionContainerName">Recovery Plan Name</param>
        /// <param name="sourceFabricName">Source Fabric Name</param>
        /// <returns>Protection entity list response</returns>
        public List<ReplicationProtectedItem> GetAzureSiteRecoveryReplicationProtectedItemInRP(string recoveryPlanName)
        {
            /*
            ReplicationProtectedItemListResponse output = new ReplicationProtectedItemListResponse();
            List<ReplicationProtectedItem> replicationProtectedItems = new List<ReplicationProtectedItem>();

            var protectedItemsQueryParameter = new ProtectedItemsQueryParameter()
            {
                RecoveryPlanName = recoveryPlanName
            };
            ReplicationProtectedItemListResponse response = this
                .GetSiteRecoveryClient()
                .ReplicationProtectedItem.ListAll(null, protectedItemsQueryParameter, this.GetRequestHeaders());
            replicationProtectedItems.AddRange(response.ReplicationProtectedItems);
            while (response.NextLink != null)
            {
                response = this
                    .GetSiteRecoveryClient()
                    .ReplicationProtectedItem.ListAllNext(response.NextLink, this.GetRequestHeaders());
                replicationProtectedItems.AddRange(response.ReplicationProtectedItems);
            }

            output.ReplicationProtectedItems = replicationProtectedItems;
            return output;
            */

            return new List<ReplicationProtectedItem>();
        }

        /// <summary>
        /// Retrieves Replicated Protected Item.
        /// </summary>
        /// <param name="protectionContainerName">Protection Container Name</param>
        /// <param name="replicatedProtectedItemName">Virtual Machine Name</param>
        /// <returns>Replicated Protected Item response</returns>
        public ReplicationProtectedItem GetAzureSiteRecoveryReplicationProtectedItem(string fabricName,
            string protectionContainerName,
            string replicatedProtectedItemName)
        {
            return this.GetSiteRecoveryClient().ReplicationProtectedItems.Get(fabricName, protectionContainerName, replicatedProtectedItemName);
        }

        /// <summary>
        /// Creates Replicated Protected Item.
        /// </summary>
        /// <param name="protectionContainerName">Protection Container ID</param>
        /// <param name="replicationProtectedItemName">Virtual Machine ID or Replication group Id</param>
        /// <param name="input">Enable protection input.</param>
        /// <returns>Job response</returns>
        public PSSiteRecoveryLongRunningOperation EnableProtection(string fabricName,
            string protectionContainerName,
            string replicationProtectedItemName,
            EnableProtectionInput input)
        {
            var op = this.GetSiteRecoveryClient().ReplicationProtectedItems.BeginCreateWithHttpMessagesAsync(fabricName, protectionContainerName, replicationProtectedItemName, input).GetAwaiter().GetResult();
            var result = Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }

        /// <summary>
        /// Removes Replicated Protected Item.
        /// </summary>
        /// <param name="protectionContainerName">Protection Container ID</param>
        /// <param name="replicationProtectedItemName">Virtual Machine ID or Replication group Id</param>
        /// <param name="input">Disable protection input.</param>
        /// <returns>Job response</returns>
        public PSSiteRecoveryLongRunningOperation DisableProtection(string fabricName,
            string protectionContainerName,
            string replicationProtectedItemName,
            DisableProtectionInput input)
        {
            var op = this.GetSiteRecoveryClient().ReplicationProtectedItems.BeginDeleteWithHttpMessagesAsync(fabricName, protectionContainerName, replicationProtectedItemName, input).GetAwaiter().GetResult();
            var result = Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }

        /// <summary>
        /// Purges Replicated Protected Item.
        /// </summary>
        /// <param name="protectionContainerName">Protection Container ID</param>
        /// <param name="replicationProtectedItemName">Virtual Machine ID or Replication group Id</param>
        /// <returns>Job response</returns>
        public PSSiteRecoveryLongRunningOperation PurgeProtection(string fabricName,
            string protectionContainerName,
            string replicationProtectedItemName)
        {
            var op = this.GetSiteRecoveryClient().ReplicationProtectedItems.BeginPurgeWithHttpMessagesAsync(fabricName, protectionContainerName, replicationProtectedItemName).GetAwaiter().GetResult();
            var result = Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }

        /// <summary>
        /// Starts Planned Failover
        /// </summary>
        /// <param name="fabricName">Fabric Name</param>
        /// <param name="protectionContainerName">Protection Container Name</param>
        /// <param name="replicationProtectedItemName">Replication Protected Itenm</param>
        /// <param name="input">Input for Planned Failover</param>
        /// <returns>Job Response</returns>
        public PSSiteRecoveryLongRunningOperation StartAzureSiteRecoveryPlannedFailover(string fabricName,
            string protectionContainerName,
            string replicationProtectedItemName,
            PlannedFailoverInput input)
        {
            var op = this.GetSiteRecoveryClient().ReplicationProtectedItems.BeginPlannedFailoverWithHttpMessagesAsync(fabricName, protectionContainerName, replicationProtectedItemName, input).GetAwaiter().GetResult();
            var result = Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }

        /// <summary>
        /// Starts Unplanned Failover
        /// </summary>
        /// <param name="fabricName">Fabric Name</param>
        /// <param name="protectionContainerName">Protection Conatiner Name</param>
        /// <param name="replicationProtectedItemName">Replication Protected Item</param>
        /// <param name="input">Input for Unplanned failover</param>
        /// <returns>Job Response</returns>
        public PSSiteRecoveryLongRunningOperation StartAzureSiteRecoveryUnplannedFailover(string fabricName,
            string protectionContainerName,
            string replicationProtectedItemName,
            UnplannedFailoverInput input)
        {
            var op = this.GetSiteRecoveryClient().ReplicationProtectedItems.BeginUnplannedFailoverWithHttpMessagesAsync(fabricName, protectionContainerName, replicationProtectedItemName, input).GetAwaiter().GetResult();
            var result = Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }

        /// <summary>
        /// Starts Test Failover
        /// </summary>
        /// <param name="fabricName">Fabric Name</param>
        /// <param name="protectionContainerName">Protection Conatiner Name</param>
        /// <param name="replicationProtectedItemName">Replication Protected Item</param>
        /// <param name="input">Input for Test failover</param>
        /// <returns>Job Response</returns>
        public PSSiteRecoveryLongRunningOperation StartAzureSiteRecoveryTestFailover(string fabricName,
            string protectionContainerName,
            string replicationProtectedItemName,
            TestFailoverInput input)
        {
            var op = this.GetSiteRecoveryClient().ReplicationProtectedItems.BeginTestFailoverWithHttpMessagesAsync(fabricName, protectionContainerName, replicationProtectedItemName, input).GetAwaiter().GetResult();
            var result = Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }

        /// <summary>
        /// Start applying Recovery Point.
        /// </summary>
        /// <param name="fabricName">Fabric Name.</param>
        /// <param name="protectionContainerName">Protection Conatiner Name.</param>
        /// <param name="replicationProtectedItemName">Replication Protected Item.</param>
        /// <param name="input">Input for applying recovery point.</param>
        /// <returns>Job Response</returns>
        public PSSiteRecoveryLongRunningOperation StartAzureSiteRecoveryApplyRecoveryPoint(
            string fabricName,
            string protectionContainerName,
            string replicationProtectedItemName,
            ApplyRecoveryPointInput input)
        {
            var op = this.GetSiteRecoveryClient().ReplicationProtectedItems.BeginApplyRecoveryPointWithHttpMessagesAsync(fabricName, protectionContainerName, replicationProtectedItemName, input).GetAwaiter().GetResult();
            var result = Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }

        /// <summary>
        /// Starts Commit Failover
        /// </summary>
        /// <param name="fabricName">Fabric Name</param>
        /// <param name="protectionContainerName">Protection Conatiner Name</param>
        /// <param name="replicationProtectedItemName">Replication Protected Item</param>
        /// <returns>Job Response</returns>
        public PSSiteRecoveryLongRunningOperation StartAzureSiteRecoveryCommitFailover(string fabricName,
            string protectionContainerName,
            string replicationProtectedItemName)
        {
            var op = this.GetSiteRecoveryClient().ReplicationProtectedItems.BeginFailoverCommitWithHttpMessagesAsync(fabricName, protectionContainerName, replicationProtectedItemName).GetAwaiter().GetResult();
            var result = Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }

        /// <summary>
        /// Re-protects the Azure Site Recovery protection entity.
        /// </summary>
        /// <param name="fabricName">Fabric Name</param>
        /// <param name="protectionContainerName">Protection Conatiner Name</param>
        /// <param name="replicationProtectedItemName">Replication Protected Item</param>
        /// <param name="input">Input for Reprotect</param>
        /// <returns>Job Response</returns>
        public PSSiteRecoveryLongRunningOperation StartAzureSiteRecoveryReprotection(string fabricName,
            string protectionContainerName,
            string replicationProtectedItemName,
            ReverseReplicationInput input)
        {
            var op = this.GetSiteRecoveryClient().ReplicationProtectedItems.BeginReprotectWithHttpMessagesAsync(fabricName, protectionContainerName, replicationProtectedItemName, input).GetAwaiter().GetResult();
            var result = Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }

        /// <summary>
        /// Write Protection Entities
        /// </summary>
        /// <param name="protectableItems">List of protectable items</param>
        internal List<T> FetchProtectionEntitiesData<T>(IList<ProtectableItem> protectableItems, string protectionContainerId, string protectionContainerName)
        {
            List<ASRProtectionEntity> asrProtectionEntityList = new List<ASRProtectionEntity>();
            Dictionary<string, Policy> policyCache = new Dictionary<string, Policy>();
            Dictionary<string, ReplicationProtectedItem> protectedItemCache = new Dictionary<string, ReplicationProtectedItem>();

            // Check even if an single item is protected then we will get all the protecteditems & policies.
            if (protectableItems.Select(p => 0 == string.Compare(p.Properties.ProtectionStatus, "protected", StringComparison.OrdinalIgnoreCase)) != null)
            {
                // Get all the protected items for the container.
                List<ReplicationProtectedItem> ReplicationProtectedItemListResponse =
                    this.GetAzureSiteRecoveryReplicationProtectedItem(
                    Utilities.GetValueFromArmId(protectionContainerId, ARMResourceTypeConstants.ReplicationFabrics),
                    protectionContainerName);

                // Fill all protected items in dictionary for quick access.
                foreach (ReplicationProtectedItem protectedItem in ReplicationProtectedItemListResponse)
                {
                    protectedItemCache.Add(protectedItem.Name.ToLower(), protectedItem);
                }

                // Get all policies and fill up the dictionary once for quick access.
                List<Policy> policyListResponse = this.GetAzureSiteRecoveryPolicy();
                foreach (Policy policy in policyListResponse)
                {
                    policyCache.Add(policy.Name.ToLower(), policy);
                }
            }

            List<T> entities = new List<T>();
            // Fill up powershell entity with all the data.
            foreach (ProtectableItem protectableItem in protectableItems)
            {
                if (0 == string.Compare(protectableItem.Properties.ProtectionStatus, "protected", StringComparison.OrdinalIgnoreCase))
                {
                    string protectedItemName = Utilities.GetValueFromArmId(
                        protectableItem.Properties.ReplicationProtectedItemId, ARMResourceTypeConstants.ReplicationProtectedItems).ToLower();
                    ReplicationProtectedItem protectedItem = protectedItemCache[protectedItemName];

                    string policyName = Utilities.GetValueFromArmId(protectedItem.Properties.PolicyId, ARMResourceTypeConstants.ReplicationPolicies).ToLower();
                    Policy asrPolicy = policyCache[policyName];

                    if (typeof(T) == typeof(ASRVirtualMachine))
                    {
                        entities.Add((T)Convert.ChangeType(new ASRVirtualMachine(protectableItem, protectedItem, asrPolicy), typeof(T)));
                    }
                    else
                    {
                        entities.Add((T)Convert.ChangeType(new ASRProtectionEntity(protectableItem, protectedItem, asrPolicy), typeof(T)));
                    }
                }
                else
                {
                    if (typeof(T) == typeof(ASRVirtualMachine))
                    {
                        entities.Add((T)Convert.ChangeType(new ASRVirtualMachine(protectableItem), typeof(T)));
                    }
                    else
                    {
                        entities.Add((T)Convert.ChangeType(new ASRProtectionEntity(protectableItem), typeof(T)));
                    }

                }
            }

            asrProtectionEntityList.Sort((x, y) => x.FriendlyName.CompareTo(y.FriendlyName));
            return entities;
        }

        /// <summary>
        /// Write Protection Entity
        /// </summary>
        /// <param name="protectableItem"></param>
        internal T FetchProtectionEntityData<T>(ProtectableItem protectableItem, string protectionContainerId, string protectionContainerName)
        {
            ReplicationProtectedItem replicationProtectedItemResponse = null;
            if (!String.IsNullOrEmpty(protectableItem.Properties.ReplicationProtectedItemId))
            {
                replicationProtectedItemResponse = this.GetAzureSiteRecoveryReplicationProtectedItem(
                    Utilities.GetValueFromArmId(protectionContainerId, ARMResourceTypeConstants.ReplicationFabrics),
                    protectionContainerName,
                    Utilities.GetValueFromArmId(protectableItem.Properties.ReplicationProtectedItemId, ARMResourceTypeConstants.ReplicationProtectedItems));
            }

            if (replicationProtectedItemResponse != null && replicationProtectedItemResponse != null)
            {
                Policy policyResponse = this.GetAzureSiteRecoveryPolicy(Utilities.GetValueFromArmId(
                    replicationProtectedItemResponse.Properties.PolicyId, ARMResourceTypeConstants.ReplicationPolicies));
                if (typeof(T) == typeof(ASRVirtualMachine))
                {
                    var pe = new ASRVirtualMachine(protectableItem, replicationProtectedItemResponse, policyResponse);
                    return (T)Convert.ChangeType(pe, typeof(T));
                }
                else
                {
                    var pe = new ASRProtectionEntity(protectableItem, replicationProtectedItemResponse, policyResponse);
                    return (T)Convert.ChangeType(pe, typeof(T));
                }

            }
            else
            {
                if (typeof(T) == typeof(ASRVirtualMachine))
                {
                    var pe = new ASRVirtualMachine(protectableItem);
                    return (T)Convert.ChangeType(pe, typeof(T));
                }
                else
                {
                    var pe = new ASRProtectionEntity(protectableItem);
                    return (T)Convert.ChangeType(pe, typeof(T));
                }
            }
        }

    }
}
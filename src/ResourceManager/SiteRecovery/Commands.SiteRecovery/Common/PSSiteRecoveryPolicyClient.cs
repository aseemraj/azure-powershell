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

using AutoMapper;
using Microsoft.Azure.Management.SiteRecovery;
using Microsoft.Azure.Management.SiteRecovery.Models;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.SiteRecovery
{
    /// <summary>
    /// Recovery services convenience client.
    /// </summary>
    public partial class PSRecoveryServicesClient
    {
        /// <summary>
        /// Gets Azure Site Recovery Policy.
        /// </summary>
        /// <returns>Policy list response</returns>
        public List<Policy> GetAzureSiteRecoveryPolicy()
        {
            var policyPages = this.GetSiteRecoveryClient().PolicyController.EnumeratePolicies();
            return Utilities.IpageToList(policyPages);
        }

        /// <summary>
        /// Gets Azure Site Recovery Policy given the ID.
        /// </summary>
        /// <param name="PolicyId">Policy ID</param>
        /// <returns>Policy response</returns>
        public Policy GetAzureSiteRecoveryPolicy(
            string PolicyId)
        {
            return this.GetSiteRecoveryClient().PolicyController.GetPolicy(
                PolicyId);
        }

        /// <summary>
        /// Creates Azure Site Recovery Policy.
        /// </summary>
        /// <param name="policyName">Policy name</param>
        /// <param name="CreatePolicyInput">Policy Input</param>
        /// <returns>Long operation response</returns>
        public PSSiteRecoveryLongRunningOperation CreatePolicy(string policyName,
            CreatePolicyInput input)
        {
            var op = this.GetSiteRecoveryClient().PolicyController.CreatePolicyWithHttpMessagesAsync(policyName,
                input).GetAwaiter().GetResult();
            var result = Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }

        /// <summary>
        /// Update Azure Site Recovery Policy.
        /// </summary>
        /// <param name="UpdatePolicyInput">Policy Input</param>
        /// <param name="policyName">Policy Name</param>
        /// <returns>Long operation response</returns>
        public PSSiteRecoveryLongRunningOperation UpdatePolicy(string policyName, UpdatePolicyInput input)
        {
            var op = this.GetSiteRecoveryClient().PolicyController.UpdatePolicyWithHttpMessagesAsync(policyName,
                input).GetAwaiter().GetResult();
            var result = Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }

        /// <summary>
        /// Deletes Azure Site Recovery Policy.
        /// </summary>
        /// <param name="createAndAssociatePolicyInput">Policy Input</param>
        /// <returns>Long operation response</returns>
        public PSSiteRecoveryLongRunningOperation DeletePolicy(string policyName)
        {
            var op = this.GetSiteRecoveryClient().PolicyController.DeletePolicyWithHttpMessagesAsync(policyName).GetAwaiter().GetResult();
            var result = Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }
    }
}
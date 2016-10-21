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
        /// Gets Azure Site Recovery Plans.
        /// </summary>
        /// <returns></returns>
        public List<RecoveryPlan> GetAzureSiteRecoveryRecoveryPlan()
        {
            var pages = this.GetSiteRecoveryClient().RecoveryPlansController.EnumerateRecoveryPlans();
            return Utilities.IpageToList(pages);
        }

        /// <summary>
        /// Gets Azure Site Recovery Recovery Plan.
        /// </summary>
        /// <param name="recoveryPlanName">Recovery Plan Name</param>
        /// <returns>Job response</returns>
        public RecoveryPlan GetAzureSiteRecoveryRecoveryPlan(string recoveryPlanName)
        {
            return this.GetSiteRecoveryClient().RecoveryPlansController.GetRecoveryPlan(recoveryPlanName);
        }

        /// <summary>
        /// Starts Azure Site Recovery Commit failover.
        /// </summary>
        /// <param name="recoveryPlanName">Recovery Plan Name</param>
        /// <returns>Job response</returns>
        public PSSiteRecoveryLongRunningOperation StartAzureSiteRecoveryCommitFailover(string recoveryPlanName)
        {
            var op = this.GetSiteRecoveryClient().RecoveryPlansController.RecoveryPlanFailoverCommitWithHttpMessagesAsync(recoveryPlanName).GetAwaiter().GetResult();
            var result = Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }

        /// <summary>
        /// Reprotect Recovery Plan
        /// </summary>
        /// <param name="recoveryPlanName">Recovery Plan Name</param>
        /// <returns>Job response</returns>
        public PSSiteRecoveryLongRunningOperation UpdateAzureSiteRecoveryProtection(string recoveryPlanName)
        {
            var op = this.GetSiteRecoveryClient().RecoveryPlansController.RecoveryPlanReprotectWithHttpMessagesAsync(recoveryPlanName).GetAwaiter().GetResult();
            var result = Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }

        /// <summary>
        /// Starts Azure Site Recovery Planned failover.
        /// </summary>
        /// <param name="recoveryPlanName">Recovery Plan Name</param>
        /// <param name="input">Recovery Plan Planned Failover Input</param>
        /// <returns>Job response</returns>
        public PSSiteRecoveryLongRunningOperation StartAzureSiteRecoveryPlannedFailover(string recoveryPlanName, RecoveryPlanPlannedFailoverInput input)
        {
            var op = this.GetSiteRecoveryClient().RecoveryPlansController.RecoveryPlanPlannedFailoverWithHttpMessagesAsync(recoveryPlanName, input).GetAwaiter().GetResult();
            var result = Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }

        /// <summary>
        /// Starts Azure Site Recovery Unplanned failover.
        /// </summary>
        /// <param name="recoveryPlanName">Recovery Plan Name</param>
        /// <param name="input">Recovery Plan Unplanned Failover Input</param>
        /// <returns>Job response</returns>
        public PSSiteRecoveryLongRunningOperation StartAzureSiteRecoveryUnplannedFailover(string recoveryPlanName, RecoveryPlanUnplannedFailoverInput input)
        {
            var op = this.GetSiteRecoveryClient().RecoveryPlansController.RecoveryPlanUnplannedFailoverWithHttpMessagesAsync(recoveryPlanName, input).GetAwaiter().GetResult();
            var result = Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }

        /// <summary>
        /// Starts Azure Site Recovery test failover.
        /// </summary>
        /// <param name="recoveryPlanName">Recovery Plan Name</param>
        /// <param name="input">Recovery Plan Test Failover Input</param>
        /// <returns>Job response</returns>
        public PSSiteRecoveryLongRunningOperation StartAzureSiteRecoveryTestFailover(string recoveryPlanName, RecoveryPlanTestFailoverInput input)
        {
            var op = this.GetSiteRecoveryClient().RecoveryPlansController.RecoveryPlanTestFailoverWithHttpMessagesAsync(recoveryPlanName, input).GetAwaiter().GetResult();
            var result = Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }

        /// <summary>
        /// Remove Azure Site Recovery recovery plan.
        /// </summary>
        /// <param name="recoveryPlanName">Recovery Plan Name</param>
        /// <returns>Job response</returns>
        public PSSiteRecoveryLongRunningOperation RemoveAzureSiteRecoveryRecoveryPlan(string recoveryPlanName)
        {
            var op = this.GetSiteRecoveryClient().RecoveryPlansController.DeleteRecoveryPlanWithHttpMessagesAsync(recoveryPlanName).GetAwaiter().GetResult();
            var result = Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }

        /// <summary>
        /// Starts Creating Recovery Plan.
        /// </summary>
        /// <param name="recoveryPlanName">Recovery Plan Name</param>
        /// <param name="input">Create Recovery Plan Input</param>
        /// <returns>Job response</returns>
        public PSSiteRecoveryLongRunningOperation CreateAzureSiteRecoveryRecoveryPlan(string recoveryPlanName, CreateRecoveryPlanInput input)
        {
            var op = this.GetSiteRecoveryClient().RecoveryPlansController.CreateRecoveryPlanWithHttpMessagesAsync(recoveryPlanName, input).GetAwaiter().GetResult();
            var result = Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }

        /// <summary>
        /// Update Azure Site Recovery Recovery Plan.
        /// </summary>
        /// <param name="recoveryPlanName">Recovery Plan Name</param>
        /// <param name="input">Update Recovery Plan Input</param>
        /// <returns>Job response</returns>
        public PSSiteRecoveryLongRunningOperation UpdateAzureSiteRecoveryRecoveryPlan(string recoveryPlanName, UpdateRecoveryPlanInput input)
        {
            var op = this.GetSiteRecoveryClient().RecoveryPlansController.UpdateRecoveryPlanWithHttpMessagesAsync(recoveryPlanName, input).GetAwaiter().GetResult();
            var result = Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }
    }
}
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

using Microsoft.Azure.Management.SiteRecovery;
using Microsoft.Azure.Management.SiteRecovery.Models;
using Microsoft.Rest.Azure.OData;

namespace Microsoft.Azure.Commands.SiteRecovery
{
    /// <summary>
    /// Recovery services convenience client.
    /// </summary>
    public partial class PSRecoveryServicesClient
    {
        
        /// <summary>
        /// Gets Azure Site Recovery Job details.
        /// </summary>
        /// <param name="jobName">Job ID</param>
        /// <returns>Job response</returns>
        public Job GetAzureSiteRecoveryJobDetails(Common.Authentication.Models.AzureContext context, string jobName)
        {
            return this.GetSiteRecoveryClient(context).JobsController.GetJob(jobName);
        }
        

        /// <summary>
        /// Get Azure Site Recovery Job.
        /// </summary>
        /// <returns>Job list response</returns>
        public JobCollection GetAzureSiteRecoveryJob(Common.Authentication.Models.AzureContext context, ODataQuery<JobQueryParameter> odataQuery)
        {
            return this.GetSiteRecoveryClient(context).JobsController.EnumerateJobs(odataQuery);
        }

        /*
        /// <summary>
        /// Resumes Azure Site Recovery Job.
        /// </summary>
        /// <param name="jobName">Job ID</param>
        /// <param name="resumeJobParams">Resume Job parameters</param>
        /// <returns>Long running operation response</returns>
        public LongRunningOperationResponse ResumeAzureSiteRecoveryJob(
            string jobName,
            ResumeJobParams resumeJobParams)
        {
            return this.GetSiteRecoveryClient().Jobs.BeginResuming(jobName, resumeJobParams, this.GetRequestHeaders());
        }

        /// <summary>
        /// Restart Azure Site Recovery Job.
        /// </summary>
        /// <param name="jobName">Job Name</param>
        /// <returns>Long running operation response</returns>
        public PSSiteRecoveryLongRunningOperation RestartAzureSiteRecoveryJob(
            string jobName)
        {
            return this.GetSiteRecoveryClient().Jobs.BeginRestarting(jobName, this.GetRequestHeaders());
        }

        /// <summary>
        /// Cancel Azure Site Recovery Job.
        /// </summary>
        /// <param name="jobName">Job Name</param>
        /// <returns>Long running operation response</returns>
        public PSSiteRecoveryLongRunningOperation CancelAzureSiteRecoveryJob(
            string jobName)
        {
            return this.GetSiteRecoveryClient().Jobs.BeginCancelling(jobName, this.GetRequestHeaders());
        }
        */
    }
}
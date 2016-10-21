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
using Microsoft.Rest.Azure.OData;
using System.Collections.Generic;

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
        public Job GetAzureSiteRecoveryJobDetails(string jobName)
        {
            return this.GetSiteRecoveryClient().JobsController.GetJob(jobName);
        }

        /// <summary>
        /// Get Azure Site Recovery Job.
        /// </summary>
        /// <returns>Job list response</returns>
        public List<Job> GetAzureSiteRecoveryJob(JobQueryParameter jqp)
        {
            ODataQuery<JobQueryParameter> odataQuery = new ODataQuery<JobQueryParameter>(jqp.ToQueryString().ToString());
            var jobPages = this.GetSiteRecoveryClient().JobsController.EnumerateJobs();

            return Utilities.IpageToList(jobPages);
        }

        /// <summary>
        /// Resumes Azure Site Recovery Job.
        /// </summary>
        /// <param name="jobName">Job ID</param>
        /// <param name="resumeJobParams">Resume Job parameters</param>
        /// <returns>Long running operation response</returns>
        public PSSiteRecoveryLongRunningOperation ResumeAzureSiteRecoveryJob(
            string jobName,
            ResumeJobParams resumeJobParams)
        {/*
            var op = this.GetSiteRecoveryClient().JobsController(jobName, resumeJobParams).GetAwaiter().GetResult();
            var result = Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
            */
            return new PSSiteRecoveryLongRunningOperation();
        }

        /// <summary>
        /// Restart Azure Site Recovery Job.
        /// </summary>
        /// <param name="jobName">Job Name</param>
        /// <returns>Long running operation response</returns>
        public PSSiteRecoveryLongRunningOperation RestartAzureSiteRecoveryJob(
            string jobName)
        {
            var op = this.GetSiteRecoveryClient().JobsController.RestartJobWithHttpMessagesAsync(jobName).GetAwaiter().GetResult();
            var result = Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }

        /// <summary>
        /// Cancel Azure Site Recovery Job.
        /// </summary>
        /// <param name="jobName">Job Name</param>
        /// <returns>Long running operation response</returns>
        public PSSiteRecoveryLongRunningOperation CancelAzureSiteRecoveryJob(
            string jobName)
        {
            var op = this.GetSiteRecoveryClient().JobsController.CancelJobWithHttpMessagesAsync(jobName).GetAwaiter().GetResult();
            var result = Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }
    }
}
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
using Microsoft.Azure.Portal.RecoveryServices.Models.Common;

namespace Microsoft.Azure.Commands.SiteRecovery
{
    /// <summary>
    /// Recovery services convenience client.
    /// </summary>
    public partial class PSRecoveryServicesClient
    {
        /// <summary>
        /// Gets Azure Site Recovery Fabrics.
        /// </summary>
        /// <param name="shouldSignRequest">Boolean indicating if the request should be signed ACIK</param>
        /// <returns>Server list response</returns>
        public FabricCollection GetAzureSiteRecoveryFabric(Common.Authentication.Models.AzureContext context, bool shouldSignRequest = true)
        {
            return this.GetSiteRecoveryClient(context).FabricsController.EnumerateFabrics();
        }

        /// <summary>
        /// Gets Azure Site Recovery Fabrics.
        /// </summary>
        /// <param name="fabricName">Server ID</param>
        /// <returns>Server response</returns>
        public Fabric GetAzureSiteRecoveryFabric(Common.Authentication.Models.AzureContext context, string fabricName)
        {
            return this.GetSiteRecoveryClient(context).FabricsController.GetFabric(fabricName);
        }


        /// <summary>
        /// Creates Azure Site Recovery Fabric.
        /// </summary>
        /// <param name="createAndAssociatePolicyInput">Policy Input</param>
        /// <returns>Long operation response</returns>
        public PSSiteRecoveryLongRunningOperation CreateAzureSiteRecoveryFabric(Common.Authentication.Models.AzureContext context, string fabricName, FabricCreationInput input)
        {
            var op =  this.GetSiteRecoveryClient(context).FabricsController.CreateFabricWithHttpMessagesAsync(fabricName, input).GetAwaiter().GetResult();
            var result = Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }

        /*
         
        /// <summary>
        /// Deletes Azure Site Recovery Fabric.
        /// </summary>
        /// <param name="DeleteAzureSiteRecoveryFabric">Fabric Input</param>
        /// <returns>Long operation response</returns>
        public LongRunningOperationResponse DeleteAzureSiteRecoveryFabric(string fabricName)
        {
            return this.GetSiteRecoveryClient().Fabrics.BeginDeleting(fabricName,
                this.GetRequestHeaders());
        }

        /// <summary>
        /// Purge Azure Site Recovery Fabric.
        /// </summary>
        /// <param name="fabricName">Fabric name</param>
        /// <returns>Long operation response</returns>
        public LongRunningOperationResponse PurgeAzureSiteRecoveryFabric(string fabricName)
        {
            return this.GetSiteRecoveryClient().Fabrics.BeginPurging(fabricName,
                this.GetRequestHeaders());
        }
        */
    }
}
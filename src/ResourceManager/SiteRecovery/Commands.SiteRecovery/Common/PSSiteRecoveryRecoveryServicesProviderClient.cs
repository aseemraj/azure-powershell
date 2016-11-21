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
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.SiteRecovery
{
    /// <summary>
    /// Recovery services convenience client.
    /// </summary>
    public partial class PSRecoveryServicesClient
    {
        /// <summary>
        /// Gets Azure Site Recovery Providers.
        /// </summary>
        /// <param name="fabricId">Fabric ID</param>
        /// <returns>Recovery Services Provider list response</returns>
        public List<RecoveryServicesProvider> GetAzureSiteRecoveryProvider(string fabricId)
        {
            var pages = this.GetSiteRecoveryClient().RecoveryServicesProvider.ListByFabric(fabricId);
            return Utilities.IpageToList(pages);
        }

        /// <summary>
        /// Gets Azure Site Recovery Providers.
        /// </summary>
        /// <param name="fabricId">Fabric ID</param>
        /// <param name="providerId">Provider ID</param>
        /// <returns>Provider response</returns>
        public RecoveryServicesProvider GetAzureSiteRecoveryProvider(string fabricId, string providerId)
        {
            return this.GetSiteRecoveryClient().RecoveryServicesProvider.Get(fabricId, providerId);
        }


        /// <summary>
        /// Remove Azure Site Recovery Providers.
        /// </summary>
        /// <param name="fabricId">Fabric ID</param>
        /// <param name="providerId">Provider ID</param>
        /// <returns>Provider response</returns>
        public PSSiteRecoveryLongRunningOperation RemoveAzureSiteRecoveryProvider(string fabricId, string providerId)
        {
            var op = this.GetSiteRecoveryClient().RecoveryServicesProvider.BeginDeleteWithHttpMessagesAsync(fabricId, providerId).GetAwaiter().GetResult();
            var result = Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }

        /// <summary>
        /// Purge Azure Site Recovery Providers.
        /// </summary>
        /// <param name="fabricId">Fabric ID</param>
        /// <param name="providerId">Provider ID</param>
        /// <returns>Provider response</returns>
        public PSSiteRecoveryLongRunningOperation PurgeAzureSiteRecoveryProvider(string fabricId, string providerId)
        {
            var op = this.GetSiteRecoveryClient().RecoveryServicesProvider.BeginPurgeWithHttpMessagesAsync(fabricId, providerId).GetAwaiter().GetResult();
            var result = Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }

        /// <summary>
        /// Refresh Azure Site Recovery Provider.
        /// </summary>
        /// <param name="fabricId">Fabric ID</param>
        /// <param name="providerId">Provider ID</param>
        /// <returns>Operation response</returns>
        public PSSiteRecoveryLongRunningOperation RefreshAzureSiteRecoveryProvider(string fabricId, string providerId)
        {
            var op = this.GetSiteRecoveryClient().RecoveryServicesProvider.BeginRefreshProviderWithHttpMessagesAsync(fabricId, providerId).GetAwaiter().GetResult();
            var result = Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }
    }
}
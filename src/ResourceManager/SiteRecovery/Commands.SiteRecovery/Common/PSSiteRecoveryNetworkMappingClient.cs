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
using System.Diagnostics.CodeAnalysis;

namespace Microsoft.Azure.Commands.SiteRecovery
{
    /// <summary>
    /// Recovery services convenience client.
    /// </summary>
    [SuppressMessage(
        "Microsoft.StyleCop.CSharp.MaintainabilityRules",
        "SA1402:FileMayOnlyContainASingleClass",
        Justification = "Keeping all contracts together.")]
    public partial class PSRecoveryServicesClient
    {
        /// <summary>
        /// Gets all Azure Site Recovery Network mappings.
        /// </summary>
        /// <returns>Network mappings list response</returns>
        public List<NetworkMapping> GetAzureSiteRecoveryNetworkMappings()
        {
            var networkMappingPages = this.GetSiteRecoveryClient()
                .NetworkMappingsController
                .EnumerateAllNetworkMappings();
            return Utilities.IpageToList(networkMappingPages);
        }

        /// <summary>
        /// Creates a new Azure Site Recovery Network mapping.
        /// </summary>
        /// <param name="primaryFabricName">Primary fabric name</param>
        /// <param name="primaryNetworkName">Primary network name</param>
        /// <param name="mappingName">Mapping name</param>
        /// <param name="recoveryFabricName">Recovery fabric name</param>
        /// <param name="recoveryNetworkId">Recovery network id</param>
        /// <returns>Long running operation response</returns>
        public PSSiteRecoveryLongRunningOperation NewAzureSiteRecoveryNetworkMapping(
            string primaryFabricName,
            string primaryNetworkName,
            string mappingName,
            string recoveryFabricName,
            string recoveryNetworkId)
        {
            CreateNetworkMappingInput input = new CreateNetworkMappingInput();
            input.RecoveryFabricName = recoveryFabricName;
            input.RecoveryNetworkId = recoveryNetworkId;

            var op = this.GetSiteRecoveryClient().
                NetworkMappingsController
                .CreateNetworkMappingWithHttpMessagesAsync(
                primaryFabricName,
                primaryNetworkName,
                mappingName,
                input).GetAwaiter().GetResult();
            var result = Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }

        /// <summary>
        /// Removes Azure Site Recovery Network Mapping.
        /// </summary>
        /// <param name="primaryFabricName">Primary fabric name</param>
        /// <param name="primaryNetworkName">Primary network name</param>
        /// <param name="mappingName">mapping name</param>
        /// <returns>Long running operation response</returns>
        public PSSiteRecoveryLongRunningOperation RemoveAzureSiteRecoveryNetworkMapping(
            string primaryFabricName,
            string primaryNetworkName,
            string mappingName)
        {
            var op = this.GetSiteRecoveryClient().
                NetworkMappingsController.
                DeleteNetworkMappingWithHttpMessagesAsync(
                primaryFabricName,
                primaryNetworkName,
                mappingName).GetAwaiter().GetResult();
            var result = Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }
    }
}
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
        /// Gets Azure Site Recovery Protection Container.
        /// </summary>
        /// <returns>Protection Container list response</returns>
        public List<ProtectionContainer> GetAzureSiteRecoveryProtectionContainer()
        {
            var pages = this.GetSiteRecoveryClient().ProtectionContainersController.EnumerateAllProtectionContainers();
            return Utilities.IpageToList(pages);
        }

        /// <summary>
        /// Gets Azure Site Recovery Protection Container.
        /// </summary>
        /// <returns>Protection Container list response</returns>
        public List<ProtectionContainer> GetAzureSiteRecoveryProtectionContainer(string fabricName)
        {
            var pages = this.GetSiteRecoveryClient().ProtectionContainersController.EnumerateProtectionContainers(fabricName);
            return Utilities.IpageToList(pages);
        }

        /// <summary>
        /// Gets Azure Site Recovery Protection Container.
        /// </summary>
        /// <param name="protectionContainerName">Protection Container ID</param>
        /// <returns>Protection Container response</returns>
        public ProtectionContainer GetAzureSiteRecoveryProtectionContainer(string fabricName,
            string protectionContainerName)
        {
            return this.GetSiteRecoveryClient().ProtectionContainersController.GetProtectionContainer(fabricName, protectionContainerName);
        }

        /// <summary>
        /// Gets Azure Site Recovery Protection Container Mapping. 
        /// </summary>
        /// <param name="fabricName">Fabric Name</param>
        /// <param name="protectionContainerName">Protection Container Name</param>
        /// <returns></returns>
        public List<ProtectionContainerMapping> GetAzureSiteRecoveryProtectionContainerMapping(string fabricName,
            string protectionContainerName)
        {
            var pages = this.GetSiteRecoveryClient().ProtectionContainerMappingsController.EnumerateProtectionContainerMappings(fabricName, protectionContainerName);
            return Utilities.IpageToList(pages);
        }

        /// <summary>
        /// Gets Azure Site Recovery Protection Container Mapping. 
        /// </summary>
        /// <param name="fabricName">Fabric Name</param>
        /// <param name="protectionContainerName">Protection Container Name</param>
        /// <param name="mappingName">Mapping Name</param>
        /// <returns></returns>
        public ProtectionContainerMapping GetAzureSiteRecoveryProtectionContainerMapping(string fabricName,
            string protectionContainerName, string mappingName)
        {
            return this.GetSiteRecoveryClient().ProtectionContainerMappingsController.GetProtectionContainerMapping(fabricName, protectionContainerName, mappingName);
        }

        /// <summary>
        /// Pair Cloud
        /// </summary>
        /// <param name="fabricName">Fabric Name</param>
        /// <param name="protectionContainerName">Protection Container Input</param>
        /// <param name="mappingName">Mapping Name</param>
        /// <param name="input">Pairing input</param>
        /// <returns></returns>
        public PSSiteRecoveryLongRunningOperation ConfigureProtection(string fabricName,
            string protectionContainerName, string mappingName, CreateProtectionContainerMappingInput input)
        {
            var op = this.GetSiteRecoveryClient().ProtectionContainerMappingsController.CreateProtectionContainerMappingWithHttpMessagesAsync(fabricName, protectionContainerName, mappingName, input).GetAwaiter().GetResult();
            var result = Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }

        /// <summary>
        /// UnPair Cloud
        /// </summary>
        /// <param name="fabricName">Fabric Name</param>
        /// <param name="protectionContainerName">Protection Container Input</param>
        /// <param name="mappingName">Mapping Name</param>
        /// <param name="input">UnPairing input</param>
        /// <returns></returns>
        public PSSiteRecoveryLongRunningOperation UnConfigureProtection(string fabricName,
            string protectionContainerName, string mappingName, RemoveProtectionContainerMappingInput input)
        {
            var op = this.GetSiteRecoveryClient().ProtectionContainerMappingsController.RemoveProtectionContainerMappingWithHttpMessagesAsync(fabricName, protectionContainerName, mappingName, input).GetAwaiter().GetResult();
            var result = Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }

        /// <summary>
        /// Purge Cloud Mapping
        /// </summary>
        /// <param name="fabricName">Fabric Name</param>
        /// <param name="protectionContainerName">Protection Container Input</param>
        /// <param name="mappingName">Mapping Name</param>
        /// <returns></returns>
        public PSSiteRecoveryLongRunningOperation PurgeCloudMapping(string fabricName,
            string protectionContainerName, string mappingName)
        {
            var op = this.GetSiteRecoveryClient().ProtectionContainerMappingsController.PurgeProtectionContainerMappingWithHttpMessagesAsync(fabricName, protectionContainerName, mappingName).GetAwaiter().GetResult();
            var result = Mapper.Map<PSSiteRecoveryLongRunningOperation>(op);
            return result;
        }
    }
}
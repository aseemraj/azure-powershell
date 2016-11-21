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
        /// Retrieves Protectable Items.
        /// </summary>
        /// <param name="protectionContainerName">Protection Container Name</param>
        /// <returns>Protection entity list response</returns>
        public List<ProtectableItem> GetAzureSiteRecoveryProtectableItem(string fabricName,
            string protectionContainerName)
        {
            var pages = this.GetSiteRecoveryClient().ProtectableItems.ListByProtectionContainer(fabricName, protectionContainerName);
            return Utilities.IpageToList(pages);
        }

        /// <summary>
        /// Retrieves Protectable Item.
        /// </summary>
        /// <param name="protectionContainerName">Protection Container Name</param>
        /// <param name="replicatedProtectedItemName">Virtual Machine Name</param>
        /// <returns>Replicated Protected Item response</returns>
        public ProtectableItem GetAzureSiteRecoveryProtectableItem(string fabricName,
            string protectionContainerName,
            string replicatedProtectedItemName)
        {
            return this.GetSiteRecoveryClient().ProtectableItems.Get(fabricName, protectionContainerName, replicatedProtectedItemName);
        }
    }
}
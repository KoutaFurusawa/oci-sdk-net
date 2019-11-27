using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Identity.Request
{
    /// <summary>
    /// GetIdentityProvider request
    /// </summary>
    public class GetIdentityProviderRequest
    {
        /// <summary>
        /// The OCID of the identity provider.
        /// <para>Required: yes</para>
        /// </summary>
        public string IdentityProviderId { get; set; }
    }
}

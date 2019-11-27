using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Identity.Model
{
    /// <summary>
    /// UpdateSaml2IdentityProviderDetails
    /// </summary>
    public class UpdateSaml2IdentityProviderDetails : UpdateIdentityProviderDetails
    {
        /// <summary>
        /// Defined tags for this resource. Each key is predefined and scoped to a namespace.
        /// <para>Required: no</para>
        /// </summary>
        public string MetadataUrl { get; set; }

        /// <summary>
        /// The XML that contains the information required for federating.
        /// <para>Required: no</para>
        /// </summary>
        public string Metadata { get; set; }

        /// <summary>
        /// Extra name value pairs associated with this identity provider.
        /// <para>Required: no</para>
        /// </summary>
        public object FreeformAttributes { get; set; }

        /// <summary>
        /// When set to true, the service provider expects the SAML assertion to be encrypted by the identity provider, 
        /// using the service provider's encryption key. In this case, the service provider is Oracle Cloud Infrastructure 
        /// Authentication service.
        /// <para>Required: no</para>
        /// </summary>
        public bool? EncryptAssertion { get; set; }

        /// <summary>
        /// If set to true, when the user is redirected to the identity provider, the identity provider forces the user 
        /// to provide credentials and re-authenticate, even if there is an active login session.
        /// <para>Required: no</para>
        /// </summary>
        public bool? ForceAuthentication { get; set; }

        /// <summary>
        /// Authentication contexts requested when sending a SAML request to the identity provider.
        /// <para>Required: no</para>
        /// </summary>
        public List<string> AuthnContextClassRefs { get; set; }
    }
}

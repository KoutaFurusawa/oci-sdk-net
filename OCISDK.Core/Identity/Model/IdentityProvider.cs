using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Identity.Model
{
    /// <summary>
    /// The resulting base object when you add an identity provider to your tenancy. 
    /// A Saml2IdentityProvider is a specific type of IdentityProvider that supports the SAML 2.0 protocol. 
    /// Each IdentityProvider object has its own OCID. For more information, see Identity Providers and Federation.
    /// 
    /// The resulting base object when you add an identity provider to your tenancy. 
    /// A Saml2IdentityProvider is a specific type of IdentityProvider that supports the SAML 2.0 protocol. 
    /// Each IdentityProvider object has its own OCID. For more information, see Identity Providers and Federation.
    /// 
    /// Warning: Oracle recommends that you avoid using any confidential information when you supply string values using the API.
    /// </summary>
    public class IdentityProvider
    {
        /// <summary>
        /// The OCID of the IdentityProvider.
        /// <para>Required: yes</para>
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The OCID of the tenancy containing the IdentityProvider.
        /// <para>Required: yes</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// The name you assign to the IdentityProvider during creation. The name must be unique across all IdentityProvider objects in 
        /// the tenancy and cannot be changed. This is the name federated users see when choosing which identity provider to use when 
        /// signing in to the Oracle Cloud Infrastructure Console.
        /// <para>Required: yes</para>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The identity provider service or product. Supported identity providers are Oracle Identity Cloud Service (IDCS) and 
        /// Microsoft Active Directory Federation Services (ADFS).
        /// <para>Required: yes</para>
        /// </summary>
        public string ProductType { get; set; }

        /// <summary>
        /// Date and time the IdentityProvider was created, in the format defined by RFC3339.
        /// <para>Required: yes</para>
        /// </summary>
        public string TimeCreated { get; set; }

        /// <summary>
        /// The current state. After creating an IdentityProvider, make sure its lifecycleState changes from CREATING to ACTIVE before using it.
        /// <para>Required: yes</para>
        /// </summary>
        public string LifecycleState { get; set; }

        /// <summary>
        /// The detailed status of INACTIVE lifecycleState.
        /// <para>Required: no</para>
        /// </summary>
        public string InactiveStatus { get; set; }

        /// <summary>
        /// The protocol used for federation. Allowed value: SAML2.
        /// <para>Required: yes</para>
        /// </summary>
        public string Protocol { get; set; }

        /// <summary>
        /// Free-form tags for this resource. 
        /// Each tag is a simple key-value pair with no predefined name, type, or namespace. 
        /// </summary>
        public IDictionary<string, string> FreeformTags { get; set; }

        /// <summary>
        /// Defined tags for this resource. Each key is predefined and scoped to a namespace. 
        /// </summary>
        public IDictionary<string, IDictionary<string, string>> DefinedTags { get; set; }
    }
}

using OCISDK.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Identity.Model
{
    /// <summary>
    /// This resource has one or more subtypes based on the value of the protocol attribute:CreateSaml2IdentityProviderDetails
    /// </summary>
    public class CreateIdentityProviderDetails
    {
        /// <summary>
        /// The OCID of your tenancy.
        /// <para>Required: yes</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// The name you assign to the IdentityProvider during creation. 
        /// The name must be unique across all IdentityProvider objects in the tenancy and cannot be changed.
        /// <para>Required: yes</para>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description you assign to the IdentityProvider during creation. Does not have to be unique, and it's changeable.
        /// <para>Required: yes</para>
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The identity provider service or product. Supported identity providers are Oracle Identity Cloud Service (IDCS) and Microsoft Active Directory Federation Services (ADFS).
        /// <para>Required: yes</para>
        /// </summary>
        public ProductTypeParam ProductType { get; set; }

        /// <summary>
        /// ProductType ExpandableEnum
        /// </summary>
        public class ProductTypeParam : ExpandableEnum<ProductTypeParam>
        {
            /// <summary>
            /// parse
            /// </summary>
            /// <param name="value"></param>
            public ProductTypeParam(string value) : base(value) { }

            /// <summary>
            /// parse
            /// </summary>
            /// <param name="value"></param>
            public static implicit operator ProductTypeParam(string value)
            {
                return Parse(value);
            }

            /// <summary>
            /// ASC
            /// </summary>
            public static readonly ProductTypeParam IDCS = new ProductTypeParam("IDCS");

            /// <summary>
            /// DESC
            /// </summary>
            public static readonly ProductTypeParam ADFS = new ProductTypeParam("ADFS");
        }

        /// <summary>
        /// The protocol used for federation.
        /// </summary>
        public ProtocolParam Protocol { get; set; }

        /// <summary>
        /// Protocol ExpandableEnum
        /// </summary>
        public class ProtocolParam : ExpandableEnum<ProtocolParam>
        {
            /// <summary>
            /// parse
            /// </summary>
            /// <param name="value"></param>
            public ProtocolParam(string value) : base(value) { }

            /// <summary>
            /// parse
            /// </summary>
            /// <param name="value"></param>
            public static implicit operator ProtocolParam(string value)
            {
                return Parse(value);
            }

            /// <summary>
            /// SAML2
            /// </summary>
            public static readonly ProtocolParam SAML2 = new ProtocolParam("SAML2");

            /// <summary>
            /// ADFS
            /// </summary>
            public static readonly ProtocolParam ADFS = new ProtocolParam("ADFS");
        }

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

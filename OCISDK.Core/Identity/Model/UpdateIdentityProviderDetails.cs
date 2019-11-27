using OCISDK.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Identity.Model
{
    /// <summary>
    /// This resource has one or more subtypes based on the value of the protocol attribute:UpdateSaml2IdentityProviderDetails
    /// </summary>
    public class UpdateIdentityProviderDetails
    {
        /// <summary>
        /// The protocol used for federation.
        /// <para>Required: yes</para>
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
        }

        /// <summary>
        /// The description you assign to the IdentityProvider. Does not have to be unique, and it's changeable.
        /// <para>Required: no</para>
        /// </summary>
        public string Description { get; set; }

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

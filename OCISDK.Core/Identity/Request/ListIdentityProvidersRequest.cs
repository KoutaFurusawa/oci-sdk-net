using OCISDK.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Identity.Request
{
    /// <summary>
    /// ListIdentityProviders request
    /// </summary>
    public class ListIdentityProvidersRequest
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
        /// The OCID of the compartment (remember that the tenancy is simply the root compartment).
        /// <para>Required: yes</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 512</para>
        /// </summary>
        public string Page { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 1000</para>
        /// </summary>
        public int? Limit { get; set; }

        /// <summary>
        /// option query
        /// </summary>
        /// <returns></returns>
        public string GetOptionQuery()
        {
            var sb = new StringBuilder();

            sb.Append($"protocol={Protocol}");

            sb.Append($"&compartmentId={CompartmentId}");
            
            if (!string.IsNullOrEmpty(Page))
            {
                sb.Append($"&page={Page}");
            }
            if (this.Limit.HasValue)
            {
                sb.Append($"&limit={Limit.Value}");
            }

            return sb.ToString();
        }
    }
}

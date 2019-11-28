using OCISDK.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Model.VirtualNetwork
{
    /// <summary>
    /// CreateVirtualCircuitDetails
    /// </summary>
    public class CreateVirtualCircuitDetails
    {
        /// <summary>
        /// The provisioned data rate of the connection. To get a list of the available bandwidth levels (that is, shapes), 
        /// see ListFastConnectProviderServiceVirtualCircuitBandwidthShapes.
        /// <para>Required: no</para>
        /// </summary>
        public string BandwidthShapeName { get; set; }

        /// <summary>
        /// The OCID of the compartment containing the virtual circuit.
        /// <para>Required: yes</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// An array of mappings, each containing properties for a cross-connect or cross-connect group that is associated with this virtual circuit.
        /// <para>Required: no</para>
        /// </summary>
        public List<CrossConnectMapping> CrossConnectMappings { get; set; }

        /// <summary>
        /// The BGP ASN of the network at the other end of the BGP session from Oracle. If the session is between the customer's edge router and Oracle, 
        /// the value is the customer's ASN. If the BGP session is between the provider's edge router and Oracle, the value is the provider's ASN.
        /// </summary>
        public int? CustomerBgpAsn { get; set; }

        /// <summary>
        /// A user-friendly name. Does not have to be unique, and it's changeable. Avoid entering confidential information.
        /// <para>Required: no</para>
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The OCID of the customer's dynamic routing gateway (DRG) that this virtual circuit uses. Applicable only to private virtual circuits.
        /// <para>Required: no</para>
        /// </summary>
        public string GatewayId { get; set; }
        
        /// <summary>
        /// Deprecated. Instead use providerServiceId.
        /// <para>Required: no</para>
        /// </summary>
        public string ProviderName { get; set; }

        /// <summary>
        /// The OCID of the service offered by the provider (if the customer is connecting via a provider).
        /// <para>Required: no</para>
        /// </summary>
        public string ProviderServiceId { get; set; }

        /// <summary>
        /// The service key name offered by the provider (if the customer is connecting via a provider).
        /// <para>Required: no</para>
        /// </summary>
        public string ProviderServiceKeyName { get; set; }

        /// <summary>
        /// Deprecated. Instead use providerServiceId.
        /// <para>Required: no</para>
        /// </summary>
        public string ProviderServiceName { get; set; }
        
        /// <summary>
        /// For a public virtual circuit. The public IP prefixes (CIDRs) the customer wants to advertise across the connection. 
        /// Each prefix must be /31 or less specific.
        /// <para>Required: no</para>
        /// </summary>
        public List<CreateVirtualCircuitPublicPrefixDetails> PublicPrefixes { get; set; }
        
        /// <summary>
        /// The Oracle Cloud Infrastructure region where this virtual circuit is located.
        /// <para>Required: no</para>
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// Whether the virtual circuit supports private or public peering. For more information, see FastConnect Overview.
        /// <para>Required: yes</para>
        /// </summary>
        public TypeParam Type { get; set; }
        
        /// <summary>
        /// Type ExpandableEnum
        /// </summary>
        public class TypeParam : ExpandableEnum<TypeParam>
        {
            /// <summary>
            /// Type ExpandableEnum
            /// </summary>
            /// <param name="value"></param>
            public TypeParam(string value) : base(value) { }

            /// <summary>
            /// parse
            /// </summary>
            /// <param name="value"></param>
            public static implicit operator TypeParam(string value)
            {
                return Parse(value);
            }

            /// <summary>
            /// PUBLIC
            /// </summary>
            public static readonly TypeParam PUBLIC = new TypeParam("PUBLIC");

            /// <summary>
            /// PRIVATE
            /// </summary>
            public static readonly TypeParam PRIVATE = new TypeParam("PRIVATE");
        }
        
        /// <summary>
        /// Free-form tags for this resource. Each tag is a simple key-value pair with no predefined name, type, or namespace. 
        /// For more information, see Resource Tags.
        /// <para>Required: no</para>
        /// </summary>
        public IDictionary<string, string> FreeformTags { get; set; }

        /// <summary>
        /// Defined tags for this resource. Each key is predefined and scoped to a namespace. 
        /// For more information, see Resource Tags.
        /// <para>Required: no</para>
        /// </summary>
        public IDictionary<string, IDictionary<string, string>> DefinedTags { get; set; }
    }
}

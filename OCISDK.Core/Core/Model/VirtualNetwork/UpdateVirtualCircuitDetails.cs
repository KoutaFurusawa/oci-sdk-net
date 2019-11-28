using OCISDK.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Model.VirtualNetwork
{
    /// <summary>
    /// UpdateVirtualCircuitDetails
    /// </summary>
    public class UpdateVirtualCircuitDetails
    {
        /// <summary>
        /// The provisioned data rate of the connection. To get a list of the available bandwidth levels 
        /// (that is, shapes), see ListFastConnectProviderVirtualCircuitBandwidthShapes. 
        /// To be updated only by the customer who owns the virtual circuit.
        /// <para>Required: no</para>
        /// </summary>
        public string BandwidthShapeName { get; set; }

        /// <summary>
        /// An array of mappings, each containing properties for a cross-connect or cross-connect group associated with this virtual circuit.
        /// The customer and provider can update different properties in the mapping depending on the situation. See the description of the CrossConnectMapping.
        /// <para>Required: no</para>
        /// </summary>
        public List<CrossConnectMapping> CrossConnectMappings { get; set; }

        /// <summary>
        /// The BGP ASN of the network at the other end of the BGP session from Oracle.
        /// If the BGP session is from the customer's edge router to Oracle, the required value is the customer's ASN, and it can be updated only by the customer.
        /// If the BGP session is from the provider's edge router to Oracle, the required value is the provider's ASN, and it can be updated only by the provider.
        /// <para>Required: no</para>
        /// </summary>
        public int? CustomerBgpAsn { get; set; }

        /// <summary>
        /// A user-friendly name. Does not have to be unique. Avoid entering confidential information.
        /// To be updated only by the customer who owns the virtual circuit.
        /// <para>Required: no</para>
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The OCID of the dynamic routing gateway (DRG) that this private virtual circuit uses.
        /// To be updated only by the customer who owns the virtual circuit.
        /// <para>Required: no</para>
        /// </summary>
        public string GatewayId { get; set; }

        /// <summary>
        /// The provider's state in relation to this virtual circuit. Relevant only if the customer is using FastConnect via a provider. 
        /// ACTIVE means the provider has provisioned the virtual circuit from their end. INACTIVE means the provider has not yet provisioned 
        /// the virtual circuit, or has de-provisioned it.
        /// <para>Required: no</para>
        /// </summary>
        public ProviderStateParam ProviderState { get; set; }

        /// <summary>
        /// Type ExpandableEnum
        /// </summary>
        public class ProviderStateParam : ExpandableEnum<ProviderStateParam>
        {
            /// <summary>
            /// ProviderState ExpandableEnum
            /// </summary>
            /// <param name="value"></param>
            public ProviderStateParam(string value) : base(value) { }

            /// <summary>
            /// parse
            /// </summary>
            /// <param name="value"></param>
            public static implicit operator ProviderStateParam(string value)
            {
                return Parse(value);
            }

            /// <summary>
            /// ACTIVE
            /// </summary>
            public static readonly ProviderStateParam ACTIVE = new ProviderStateParam("ACTIVE");

            /// <summary>
            /// INACTIVE
            /// </summary>
            public static readonly ProviderStateParam INACTIVE = new ProviderStateParam("INACTIVE");
        }

        /// <summary>
        /// The service key name offered by the provider (if the customer is connecting via a provider).
        /// <para>Required: no</para>
        /// </summary>
        public string ProviderServiceKeyName { get; set; }

        /// <summary>
        /// Provider-supplied reference information about this virtual circuit. Relevant only if the customer is using FastConnect via a provider.
        /// <para>Required: no</para>
        /// </summary>
        public string ReferenceComment { get; set; }
    }
}

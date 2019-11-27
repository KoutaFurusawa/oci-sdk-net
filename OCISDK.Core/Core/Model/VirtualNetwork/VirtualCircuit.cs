using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Model.VirtualNetwork
{
    /// <summary>
    /// For use with Oracle Cloud Infrastructure FastConnect.
    /// 
    /// A virtual circuit is an isolated network path that runs over one or more physical network connections to provide a single, 
    /// logical connection between the edge router on the customer's existing network and Oracle Cloud Infrastructure. Private virtual 
    /// circuits support private peering, and public virtual circuits support public peering. For more information, see FastConnect Overview.
    /// 
    /// Each virtual circuit is made up of information shared between a customer, Oracle, and a provider (if the customer is using 
    /// FastConnect via a provider). Who fills in a given property of a virtual circuit depends on whether the BGP session related to 
    /// that virtual circuit goes from the customer's edge router to Oracle, or from the provider's edge router to Oracle. Also, in the case 
    /// where the customer is using a provider, values for some of the properties may not be present immediately, but may get filled in as 
    /// the provider and Oracle each do their part to provision the virtual circuit.
    /// 
    /// To use any of the API operations, you must be authorized in an IAM policy. If you're not authorized, talk to an administrator. 
    /// If you're an administrator who needs to write policies to give users access, see Getting Started with Policies.
    /// 
    /// Warning: Oracle recommends that you avoid using any confidential information when you supply string values using the API.
    /// </summary>
    public class VirtualCircuit
    {
        /// <summary>
        /// The provisioned data rate of the connection. To get a list of the available bandwidth levels (that is, shapes), 
        /// see ListFastConnectProviderServiceVirtualCircuitBandwidthShapes.
        /// <para>Required: no</para>
        /// </summary>
        public string BandwidthShapeName { get; set; }

        /// <summary>
        /// Deprecated. Instead use the information in FastConnectProviderService.
        /// <para>Required: no</para>
        /// </summary>
        public string BgpManagement { get; set; }

        /// <summary>
        /// The state of the BGP session associated with the virtual circuit.
        /// <para>Required: no</para>
        /// </summary>
        public string BgpSessionState { get; set; }

        /// <summary>
        /// The OCID of the compartment containing the virtual circuit.
        /// <para>Required: no</para>
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
        /// The virtual circuit's Oracle ID (OCID).
        /// <para>Required: no</para>
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The virtual circuit's current state. For information about the different states, see FastConnect Overview.
        /// <para>Required: no</para>
        /// </summary>
        public string LifecycleState { get; set; }

        /// <summary>
        /// The Oracle BGP ASN.
        /// <para>Required: no</para>
        /// </summary>
        public int? OracleBgpAsn { get; set; }

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
        /// The provider's state in relation to this virtual circuit (if the customer is connecting via a provider). 
        /// ACTIVE means the provider has provisioned the virtual circuit from their end. INACTIVE means the provider 
        /// has not yet provisioned the virtual circuit, or has de-provisioned it.
        /// <para>Required: no</para>
        /// </summary>
        public string ProviderState { get; set; }

        /// <summary>
        /// For a public virtual circuit. The public IP prefixes (CIDRs) the customer wants to advertise across the connection. 
        /// Each prefix must be /31 or less specific.
        /// <para>Required: no</para>
        /// </summary>
        public List<string> PublicPrefixes { get; set; }

        /// <summary>
        /// Provider-supplied reference information about this virtual circuit (if the customer is connecting via a provider).
        /// <para>Required: no</para>
        /// </summary>
        public string ReferenceComment { get; set; }

        /// <summary>
        /// The Oracle Cloud Infrastructure region where this virtual circuit is located.
        /// <para>Required: no</para>
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// Provider service type.
        /// <para>Required: no</para>
        /// </summary>
        public string ServiceType { get; set; }

        /// <summary>
        /// The date and time the virtual circuit was created, in the format defined by RFC3339.
        /// <para>Required: no</para>
        /// </summary>
        public string TimeCreated { get; set; }

        /// <summary>
        /// Whether the virtual circuit supports private or public peering. For more information, see FastConnect Overview.
        /// <para>Required: no</para>
        /// </summary>
        public string Type { get; set; }

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

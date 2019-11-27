using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Model.VirtualNetwork
{
    /// <summary>
    /// For use with Oracle Cloud Infrastructure FastConnect. Each VirtualCircuit runs on one or more cross-connects 
    /// or cross-connect groups. A CrossConnectMapping contains the properties for an individual cross-connect or 
    /// cross-connect group associated with a given virtual circuit.
    /// 
    /// The mapping includes information about the cross-connect or cross-connect group, the VLAN, and the BGP 
    /// peering session.
    /// 
    /// If you're a customer who is colocated with Oracle, that means you own both the virtual circuit and the 
    /// physical connection it runs on (cross-connect or cross-connect group), so you specify all the information in
    /// the mapping. There's one exception: for a public virtual circuit, Oracle specifies the BGP IPv4 addresses.
    /// 
    /// If you're a provider, then you own the physical connection that the customer's virtual circuit runs on, so you 
    /// contribute information about the cross-connect or cross-connect group and VLAN.
    /// 
    /// Who specifies the BGP peering information in the case of customer connection via provider? If the BGP 
    /// session goes from Oracle to the provider's edge router, then the provider also specifies the BGP peering 
    /// information. If the BGP session instead goes from Oracle to the customer's edge router, then the customer 
    /// specifies the BGP peering information. There's one exception: for a public virtual circuit, Oracle specifies the BGP 
    /// IPv4 addresses.
    /// 
    /// Every CrossConnectMapping must have BGP IPv4 peering addresses. BGP IPv6 peering addresses are 
    /// optional. If BGP IPv6 addresses are provided, the customer can exchange IPv6 routes with Oracle.
    /// </summary>
    public class CrossConnectMapping
    {
        /// <summary>
        /// The key for BGP MD5 authentication. Only applicable if your system requires MD5 authentication. 
        /// If empty or not set (null), that means you don't use BGP MD5 authentication.
        /// <para>Required: no</para>
        /// </summary>
        public string BgpMd5AuthKey { get; set; }

        /// <summary>
        /// The OCID of the cross-connect or cross-connect group for this mapping. Specified by the owner of 
        /// the cross-connect or cross-connect group (the customer if the customer is colocated with Oracle, or 
        /// the provider if the customer is connecting via provider).
        /// <para>Required: no</para>
        /// </summary>
        public string CrossConnectOrCrossConnectGroupId { get; set; }

        /// <summary>
        /// The BGP IPv4 address for the router on the other end of the BGP session from Oracle. Specified by 
        /// the owner of that router. If the session goes from Oracle to a customer, this is the BGP IPv4 address of 
        /// the customer's edge router. If the session goes from Oracle to a provider, this is the BGP IPv4 address of 
        /// the provider's edge router. Must use a /30 or /31 subnet mask.
        /// <para>Required: no</para>
        /// </summary>
        public string CustomerBgpPeeringIp { get; set; }

        /// <summary>
        /// The IPv4 address for Oracle's end of the BGP session. Must use a /30 or /31 subnet mask. If the session goes 
        /// from Oracle to a customer's edge router, the customer specifies this information. If the session goes from 
        /// Oracle to a provider's edge router, the provider specifies this.
        /// <para>Required: no</para>
        /// </summary>
        public string OracleBgpPeeringIp { get; set; }

        /// <summary>
        /// The BGP IPv6 address for the router on the other end of the BGP session from Oracle. Specified by the owner of 
        /// that router. If the session goes from Oracle to a customer, this is the BGP IPv6 address of the customer's edge 
        /// router. If the session goes from Oracle to a provider, this is the BGP IPv6 address of the provider's edge router. 
        /// Only subnet masks from /64 up to /127 are allowed.
        /// <para>Required: no</para>
        /// </summary>
        public string CustomerBgpPeeringIpv6 { get; set; }

        /// <summary>
        /// The IPv6 address for Oracle's end of the BGP session. Only subnet masks from /64 up to /127 are allowed. 
        /// If the session goes from Oracle to a customer's edge router, the customer specifies this information. 
        /// If the session goes from Oracle to a provider's edge router, the provider specifies this.
        /// <para>Required: no</para>
        /// </summary>
        public string OracleBgpPeeringIpv6 { get; set; }

        /// <summary>
        /// The number of the specific VLAN (on the cross-connect or cross-connect group) that is assigned to this virtual circuit. 
        /// Specified by the owner of the cross-connect or cross-connect group (the customer if the customer is colocated with Oracle, 
        /// or the provider if the customer is connecting via provider).
        /// <para>Required: no</para>
        /// </summary>
        public int? Vlan { get; set; }
    }
}

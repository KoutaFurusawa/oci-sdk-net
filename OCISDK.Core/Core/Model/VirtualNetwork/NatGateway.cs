using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Model.VirtualNetwork
{
    /// <summary>
    /// A NAT (Network Address Translation) gateway, which represents a router that lets instances without public IPs contact 
    /// the public internet without exposing the instance to inbound internet traffic. For more information, see NAT Gateway.
    /// 
    /// To use any of the API operations, you must be authorized in an IAM policy. If you are not authorized, talk to an administrator. 
    /// If you are an administrator who needs to write policies to give users access, see Getting Started with Policies.
    /// 
    /// Warning: Oracle recommends that you avoid using any confidential information when you supply string values using the API.
    /// </summary>
    public class NatGateway
    {
        /// <summary>
        /// Whether the NAT gateway blocks traffic through it. The default is false.
        /// <para>Required: yes</para>
        /// <para>Default: false</para>
        /// </summary>
        public bool BlockTraffic { get; set; }

        /// <summary>
        /// The OCID of the compartment that contains the NAT gateway.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// A user-friendly name. Does not have to be unique, and it's changeable. Avoid entering confidential information.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The OCID of the NAT gateway.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The NAT gateway's current state.
        /// <para>Required: yes</para>
        /// </summary>
        public string LifecycleState { get; set; }

        /// <summary>
        /// The IP address associated with the NAT gateway.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string NatIp { get; set; }

        /// <summary>
        /// The date and time the NAT gateway was created, in the format defined by RFC3339.
        /// <para>Required: yes</para>
        /// </summary>
        public string TimeCreated { get; set; }

        /// <summary>
        /// The OCID of the VCN the NAT gateway belongs to.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string VcnId { get; set; }

        /// <summary>
        /// Free-form tags for this resource. Each tag is a simple key-value pair with no predefined name, type, or namespace. For more information, see Resource Tags.
        /// <para>Required: no</para>
        /// </summary>
        public IDictionary<string, string> FreeformTags { get; set; }

        /// <summary>
        /// A user-friendly name. Does not have to be unique, and it's changeable. Avoid entering confidential information.
        /// <para>Required: no</para>
        /// </summary>
        public IDictionary<string, IDictionary<string, string>> DefinedTags { get; set; }
    }
}

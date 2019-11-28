using System.Collections.Generic;

namespace OCISDK.Core.Core.Model.VirtualNetwork
{
    /// <summary>
    /// DhcpOptions Reference
    /// A set of DHCP options. Used by the VCN to automatically provide configuration 
    /// information to the instances when they boot up. There are two options you can set:
    /// 
    /// * DhcpDnsOption: Lets you specify how DNS (hostname resolution) is handled in the subnets in your VCN.
    /// * DhcpSearchDomainOption: Lets you specify a search domain name to use for DNS queries.
    /// 
    /// For more information, see DNS in Your Virtual Cloud Network and DHCP Options.
    /// 
    /// Warning: Oracle recommends that you avoid using any confidential information when you supply string values using the API.
    /// 
    /// author: koutaro furusawa
    /// </summary>
    public class DhcpOptions
    {
        /// <summary>
        /// Oracle ID (OCID) for the set of DHCP options.
        /// <para>Required: yes</para>
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The OCID of the compartment containing the set of DHCP options.
        /// <para>Required: yes</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// The OCID of the VCN the set of DHCP options belongs to.
        /// <para>Required: yes</para>
        /// </summary>
        public string VcnId { get; set; }

        /// <summary>
        /// A user-friendly name. Does not have to be unique, and it's changeable. Avoid entering confidential information.
        /// <para>Required: no</para>
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The current state of the set of DHCP options.
        /// <para>Required: yes</para>
        /// </summary>
        public string LifecycleState { get; set; }

        /// <summary>
        /// Date and time the set of DHCP options was created, in the format defined by RFC3339.
        /// <para>Required: yes</para>
        /// </summary>
        public string TimeCreated { get; set; }

        /// <summary>
        /// The collection of individual DHCP options.
        /// <para>Required: yes</para>
        /// </summary>
        public List<DhcpOption> Options { get; set; }

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

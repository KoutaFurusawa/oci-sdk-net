using System.Collections.Generic;

namespace OCISDK.Core.Core.Model.VirtualNetwork
{
    /// <summary>
    /// SecurityList Reference
    /// A set of virtual firewall rules for your VCN. Security lists are configured at the subnet level, 
    /// but the rules are applied to the ingress and egress traffic for the individual instances in the subnet. 
    /// The rules can be stateful or stateless. For more information, see Security Lists.
    /// 
    /// Warning: Oracle recommends that you avoid using any confidential information when you supply string values using the API.
    /// 
    /// author: koutaro furusawa
    /// </summary>

    public class SecurityList
    {
        /// <summary>
        /// The security list's Oracle Cloud ID (OCID).
        /// <para>Required: yes</para>
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The OCID of the compartment containing the security list.
        /// <para>Required: yes</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// The OCID of the VCN the security list belongs to.
        /// <para>Required: yes</para>
        /// </summary>
        public string VcnId { get; set; }

        /// <summary>
        /// A user-friendly name. Does not have to be unique, and it's changeable. Avoid entering confidential information.
        /// <para>Required: yes</para>
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The security list's current state.
        /// <para>Required: yes</para>
        /// </summary>
        public string LifecycleState { get; set; }

        /// <summary>
        /// The date and time the security list was created, in the format defined by RFC3339.
        /// <para>Required: yes</para>
        /// </summary>
        public string TimeCreated { get; set; }

        /// <summary>
        /// Rules for allowing egress IP packets.
        /// <para>Required: yes</para>
        /// </summary>
        public List<EgressSecurityRule> EgressSecurityRules { get; set; }

        /// <summary>
        /// Rules for allowing ingress IP packets.
        /// <para>Required: yes</para>
        /// </summary>
        public List<IngressSecurityRule> IngressSecurityRules { get; set; }

        /// <summary>
        /// Free-form tags for this resource. Each tag is a simple key-value pair with no predefined name, type, or namespace. For more information, see Resource Tags.
        /// <para>Required: no</para>
        /// </summary>
        public IDictionary<string, string> FreeformTags { get; set; }

        /// <summary>
        /// Defined tags for this resource. Each key is predefined and scoped to a namespace. For more information, see Resource Tags.
        /// <para>Required: no</para>
        /// </summary>
        public IDictionary<string, IDictionary<string, string>> DefinedTags { get; set; }
    }
}

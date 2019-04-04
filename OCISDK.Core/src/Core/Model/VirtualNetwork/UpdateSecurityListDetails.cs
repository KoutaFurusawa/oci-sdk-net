/// <summary>
/// UpdateSecurityListDetails Reference
/// 
/// author: koutaro furusawa
/// </summary>


using System.Collections.Generic;

namespace OCISDK.Core.src.Core.Model.VirtualNetwork
{
    public class UpdateSecurityListDetails
    {
        /// <summary>
        /// A user-friendly name. Does not have to be unique, and it's changeable.
        /// Avoid entering confidential information.
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string DisplayName { get; set; }

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
        /// Free-form tags for this resource.
        /// Each tag is a simple key-value pair with no predefined name, type, or namespace.
        /// For more information, see Resource Tags.
        /// <para>Required: no</para>
        /// </summary>
        public IDictionary<string, string> FreeformTags { get; set; }

        /// <summary>
        /// Defined tags for this resource.
        /// Each key is predefined and scoped to a namespace.
        /// For more information, see Resource Tags.
        /// <para>Required: no</para>
        /// </summary>
        public IDictionary<string, IDictionary<string, string>> DefinedTags { get; set; }
    }
}

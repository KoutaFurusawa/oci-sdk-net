/// <summary>
/// UpdateSubnetDetails Reference
/// 
/// author: koutaro furusawa
/// </summary>

using System.Collections.Generic;

namespace OCISDK.Core.src.Core.Model.VirtualNetwork
{
    public class UpdateSubnetDetails
    {
        /// <summary>
        /// The OCID of the set of DHCP options that the subnet uses.
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string DhcpOptionsId { get; set; }

        /// <summary>
        /// A user-friendly name. Does not have to be unique, and it's changeable.
        /// Avoid entering confidential information.
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The OCID of the route table that the subnet uses.
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string RouteTableId { get; set; }

        /// <summary>
        /// The OCIDs of the security list or lists that the subnet uses. 
        /// Remember that security lists are associated with the subnet, but the rules are applied to 
        /// the individual VNICs in the subnet.
        /// <para>Required: no</para>
        /// </summary>
        public List<string> SecurityListIds { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public IDictionary<string, string> FreeformTags { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public IDictionary<string, IDictionary<string, string>> DefinedTags { get; set; }
    }
}

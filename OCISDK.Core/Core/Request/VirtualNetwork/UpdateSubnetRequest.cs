using OCISDK.Core.Core.Model.VirtualNetwork;

namespace OCISDK.Core.Core.Request.VirtualNetwork
{
    /// <summary>
    /// UpdateSubnet Request
    /// </summary>
    public class UpdateSubnetRequest
    {
        /// <summary>
        /// The OCID of the subnet.
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string SubnetId { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// <para>if-match header parameter</para>
        /// </summary>
        public string IfMatch { get; set; }

        /// <summary>
        /// The request body must contain a single UpdateSubnetDetails resource.
        /// </summary>
        public UpdateSubnetDetails UpdateSubnetDetails { get; set; }
    }
}

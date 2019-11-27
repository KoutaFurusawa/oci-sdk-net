namespace OCISDK.Core.Core.Request.VirtualNetwork
{
    /// <summary>
    /// DeleteSubnet Request
    /// </summary>
    public class DeleteSubnetRequest
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
    }
}

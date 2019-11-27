using OCISDK.Core.Core.Model.VirtualNetwork;

namespace OCISDK.Core.Core.Request.VirtualNetwork
{
    /// <summary>
    /// UpdateVnic Request
    /// </summary>
    public class UpdateVnicRequest
    {
        /// <summary>
        /// The OCID of the VNIC.
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string VnicId { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// <para>if-match header parameter</para>
        /// </summary>
        public string IfMatch { get; set; }

        /// <summary>
        /// The request body must contain a single UpdateVnicDetails resource.
        /// </summary>
        public UpdateVnicDetails UpdateVnicDetails { get; set; }
    }
}

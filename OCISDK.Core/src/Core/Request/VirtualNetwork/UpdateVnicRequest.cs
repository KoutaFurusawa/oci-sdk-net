/// <summary>
/// UpdateVnicRequest class
/// 
/// author: koutaro furusawa
/// </summary>

using OCISDK.Core.src.Core.Model.VirtualNetwork;

namespace OCISDK.Core.src.Core.Request.VirtualNetwork
{
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

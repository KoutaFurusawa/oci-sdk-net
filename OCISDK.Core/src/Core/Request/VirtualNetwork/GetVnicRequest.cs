/// <summary>
/// GetVnicRequest class
/// 
/// author: koutaro furusawa
/// </summary>

namespace OCISDK.Core.src.Core.Request.VirtualNetwork
{
    public class GetVnicRequest
    {
        /// <summary>
        /// The OCID of the VNIC.
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string VnicId { get; set; }
    }
}

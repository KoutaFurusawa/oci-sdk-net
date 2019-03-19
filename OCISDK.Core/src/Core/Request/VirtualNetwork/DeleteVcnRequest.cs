/// <summary>
/// DeleteVcnRequest class
/// 
/// author: koutaro furusawa
/// </summary>

namespace OCISDK.Core.src.Core.Request.VirtualNetwork
{
    public class DeleteVcnRequest
    {
        /// <summary>
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string VcnId { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// <para>if-match header parameter</para>
        /// </summary>
        public string IfMatch { get; set; }
    }
}

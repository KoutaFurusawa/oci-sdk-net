/// <summary>
/// GetVcnRequest class
/// 
/// author: koutaro furusawa
/// </summary>

namespace OCISDK.Core.src.Core.Request.VirtualNetwork
{
    public class GetVcnRequest
    {
        /// <summary>
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string VcnId { get; set; }
    }
}

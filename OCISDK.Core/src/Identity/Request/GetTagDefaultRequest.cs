/// <summary>
/// Retrieves the specified tag default.
/// 
/// author: koutaro furusawa
/// </summary>

namespace OCISDK.Core.src.Identity.Request
{
    public class GetTagDefaultRequest
    {
        /// <summary>
        /// The OCID of the tag default.
        /// <para>Required: yes</para>
        /// </summary>
        public string TagDefaultId { get; set; }
    }
}

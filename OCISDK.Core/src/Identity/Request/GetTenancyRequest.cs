/// <summary>
/// GetTenancy Request
/// 
/// author: koutaro furusawa
/// </summary>

namespace OCISDK.Core.src.Identity.Request
{
    public class GetTenancyRequest
    {
        /// <summary>
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string TenancyId { get; set; }
    }
}

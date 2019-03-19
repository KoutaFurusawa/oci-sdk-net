/// <summary>
/// GetCompartment Request
/// 
/// author: koutaro furusawa
/// </summary>

namespace OCISDK.Core.src.Identity.Request
{
    public class GetCompartmentRequest
    {
        /// <summary>
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string CompartmentId { get; set; }

    }
}

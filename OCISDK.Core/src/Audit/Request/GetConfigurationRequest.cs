/// <summary>
/// GetConfiguration Request
/// 
/// author: koutaro furusawa
/// </summary>

namespace OCISDK.Core.src.Audit.Request
{
    public class GetConfigurationRequest
    {
        /// <summary>
        /// ID of the root compartment (tenancy)
        /// <para>Required: yes</para>
        /// </summary>
        public string CompartmentId { get; set; }
    }
}

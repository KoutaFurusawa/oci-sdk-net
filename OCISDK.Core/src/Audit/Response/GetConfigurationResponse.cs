using OCISDK.Core.src.Audit.Model;

namespace OCISDK.Core.src.Audit.Response
{
    /// <summary>
    /// GetConfiguration Response
    /// </summary>
    public class GetConfigurationResponse
    {
        /// <summary>
        /// The response body will contain a single Configuration resource.
        /// </summary>
        public Configuration Configuration { get; set; }
    }
}

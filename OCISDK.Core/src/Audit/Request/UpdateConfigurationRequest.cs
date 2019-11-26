
using OCISDK.Core.src.Audit.Model;

namespace OCISDK.Core.src.Audit.Request
{
    /// <summary>
    /// UpdateConfiguration Request
    /// </summary>
    public class UpdateConfigurationRequest
    {
        /// <summary>
        /// The OCID of the compartment.
        /// <para>Required: yes</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// The request body must contain a single UpdateConfigurationDetails resource.
        /// </summary>
        public UpdateConfigurationDetails updateConfigurationDetails { get; set; }
    }
}

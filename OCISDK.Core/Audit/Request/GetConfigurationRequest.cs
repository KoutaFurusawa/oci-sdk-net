namespace OCISDK.Core.Audit.Request
{
    /// <summary>
    /// GetConfiguration Request
    /// </summary>
    public class GetConfigurationRequest
    {
        /// <summary>
        /// ID of the root compartment (tenancy)
        /// <para>Required: yes</para>
        /// </summary>
        public string CompartmentId { get; set; }
    }
}

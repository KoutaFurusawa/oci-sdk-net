namespace OCISDK.Core.Core.Request.Compute
{
    /// <summary>
    /// GetInstanceDefaultCredentials Request
    /// </summary>
    public class GetInstanceDefaultCredentialsRequest
    {
        /// <summary>
        /// The OCID of the instance.
        /// <para>Required: yes</para>
        /// </summary>
        public string InstanceId { get; set; }
    }
}
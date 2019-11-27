namespace OCISDK.Core.Core.Request.Compute
{
    /// <summary>
    /// GetInstance Request
    /// </summary>
    public class GetInstanceRequest
    {
        /// <summary>
        /// The OCID of the instance.
        /// <para>Required: yes</para>
        /// </summary>
        public string InstanceId { get; set; }
    }
}

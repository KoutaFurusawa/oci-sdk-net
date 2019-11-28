namespace OCISDK.Core.Core.Request.Compute
{
    /// <summary>
    /// TerminateInstance Request
    /// </summary>
    public class TerminateInstanceRequest
    {
        /// <summary>
        /// The OCID of the instance.
        /// <para>Required: yes</para>
        /// </summary>
        public string InstanceId { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// <para>if-match header parameter</para>
        /// </summary>
        public string IfMatch { get; set; }

        /// <summary>
        /// Specifies whether to delete or preserve the boot volume when terminating an instance. 
        /// The default value is false.
        /// </summary>
        public bool PreserveBootVolume { get; set; }
    }
}

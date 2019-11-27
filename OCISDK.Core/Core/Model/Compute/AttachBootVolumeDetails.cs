namespace OCISDK.Core.Core.Model.Compute
{
    /// <summary>
    /// AttachBootVolumeDetails
    /// </summary>
    public class AttachBootVolumeDetails
    {
        /// <summary>
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string BootVolumeId { get; set; }

        /// <summary>
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string InstanceId { get; set; }

        /// <summary>
        /// A user-friendly name. Does not have to be unique, and it cannot be changed. 
        /// Avoid entering confidential information.
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string DisplayName { get; set; }
    }
}

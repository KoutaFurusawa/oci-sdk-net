namespace OCISDK.Core.Core.Model.Compute
{
    /// <summary>
    /// BootVolumeAttachment Reference
    /// Represents an attachment between a boot volume and an instance.
    /// 
    /// Warning: Oracle recommends that you avoid using any confidential 
    /// information when you supply string values using the API.
    /// </summary>
    public class BootVolumeAttachment
    {
        /// <summary>
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string AvailabilityDomain { get; set; }

        /// <summary>
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string BootVolumeId { get; set; }

        /// <summary>
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string InstanceId { get; set; }

        /// <summary>
        /// The current state of a boot volume.
        /// <para>Allowed values are:
        /// PROVISIONING
        /// RESTORING
        /// AVAILABLE
        /// TERMINATING
        /// TERMINATED
        /// FAULTY</para>
        /// </summary>
        public string LifecycleState { get; set; }

        /// <summary>
        /// The date and time the instance was created, in the format defined by RFC3339.
        /// </summary>
        public string TimeCreated { get; set; }

        /// <summary>
        /// Whether in-transit encryption for the boot volume's paravirtualized attachment is enabled or not.
        /// </summary>
        public bool IsPvEncryptionInTransitEnabled { get; set; }
    }
}

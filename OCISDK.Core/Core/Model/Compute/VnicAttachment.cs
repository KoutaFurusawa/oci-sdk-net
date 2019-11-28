namespace OCISDK.Core.Core.Model.Compute
{
    /// <summary>
    /// VnicAttachment Reference
    /// Represents an attachment between a VNIC and an instance. For more information, see Virtual Network Interface Cards (VNICs).
    /// 
    /// Warning: Oracle recommends that you avoid using any confidential information when you supply string values using the API.
    /// </summary>
    public class VnicAttachment
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
        /// <para>Required: no</para>
        /// <para>Minimum: 0</para>
        /// <para>Maximum: 31</para>
        /// </summary>
        public int NicIndex { get; set; }

        /// <summary>
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string SubnetId { get; set; }

        /// <summary>
        /// The date and time the instance was created, in the format defined by RFC3339.
        /// </summary>
        public string TimeCreated { get; set; }

        /// <summary>
        /// The Oracle-assigned VLAN tag of the attached VNIC. 
        /// Available after the attachment process is complete.
        /// </summary>
        public int VlanTag { get; set; }

        /// <summary>
        /// The OCID of the VNIC. Available after the attachment process is complete.
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string VnicId { get; set; }
    }
}

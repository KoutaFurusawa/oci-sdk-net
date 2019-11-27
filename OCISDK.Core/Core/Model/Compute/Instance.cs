using System.Collections.Generic;

namespace OCISDK.Core.Core.Model.Compute
{
    /// <summary>
    /// Instance Reference
    /// A compute host. The image used to launch the instance determines its operating system and other software. 
    /// The shape specified during the launch process determines the number of CPUs and memory allocated to the instance. 
    /// For more information, see Overview of the Compute Service.
    /// 
    /// Warning: Oracle recommends that you avoid using any confidential information when you supply string values using the API.
    /// 
    /// author: koutaro furusawa
    /// </summary>
    public class Instance
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
        /// A user-friendly name. Does not have to be unique, and it's changeable.
        /// Avoid entering confidential information.
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public object ExtendedMetadata { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string FaultDomain { get; set; }

        /// <summary>
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string ImageId { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 10240</para>
        /// </summary>
        public string IpxeScript { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public string LaunchMode { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public LaunchOptions LaunchOptions { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public string LifecycleState { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public object Metadata { get; set; }

        /// <summary>
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string Shape { get; set; }

        /// <summary>
        /// Details for creating an instance
        /// <para>Required: no</para>
        /// </summary>
        public InstanceSourceDetails SourceDetails { get; set; }

        /// <summary>
        /// The date and time the instance was created, in the format defined by RFC3339.
        /// </summary>
        public string TimeCreated { get; set; }

        /// <summary>
        /// The date and time the instance is expected to be stopped / started, in the format defined by RFC3339.
        /// After that time if instance hasn't been rebooted, Oracle will reboot the instance within 24 hours of the due time.
        /// Regardless of how the instance was stopped, the flag will be reset to empty as soon as instance reaches Stopped state.
        /// </summary>
        public string TimeMaintenanceRebootDue { get; set; }

        /// <summary>
        /// System tags for this resource. Each key is predefined and scoped to a namespace. 
        /// For more information, see Resource Tags. System tags can be viewed by users, but can only be created by the system.
        /// <para>Required: no</para>
        /// </summary>
        public IDictionary<string, IDictionary<string, string>> SystemTags { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public IDictionary<string, string> FreeformTags { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public IDictionary<string, IDictionary<string, string>> DefinedTags { get; set; }
    }
}

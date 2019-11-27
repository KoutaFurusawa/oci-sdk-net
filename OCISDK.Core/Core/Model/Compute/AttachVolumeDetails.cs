using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Model.Compute
{
    /// <summary>
    /// This resource has one or more subtypes based on the value of the type attribute:
    /// </summary>
    public class AttachVolumeDetails
    {
        /// <summary>
        /// The device name.
        /// <para>Required: no</para>
        /// <para>Min Length: 3, Max Length: 100</para>
        /// </summary>
        public string Device { get; set; }

        /// <summary>
        /// A user-friendly name. Does not have to be unique, and it cannot be changed. Avoid entering confidential information.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The OCID of the instance.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string InstanceId { get; set; }

        /// <summary>
        /// Whether the attachment was created in read-only mode.
        /// <para>Required: no</para>
        /// </summary>
        public bool? IsReadOnly { get; set; }

        /// <summary>
        /// The type of volume. The only supported value are "iscsi" and "paravirtualized".
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The OCID of the volume.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string VolumeId { get; set; }

        /// <summary>
        /// Whether to use CHAP authentication for the volume attachment. Defaults to false.
        /// <para>Required: no</para>
        /// </summary>
        public bool? UseChap { get; set; }

        /// <summary>
        /// Whether to enable in-transit encryption for the data volume's paravirtualized attachment. The default value is false.
        /// <para>Required: no</para>
        /// </summary>
        public bool? IsPvEncryptionInTransitEnabled { get; set; }
    }
}

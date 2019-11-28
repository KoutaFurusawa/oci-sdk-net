using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Model.Compute
{
    /// <summary>
    /// A base object for all types of attachments between a storage volume and an instance. 
    /// For specific details about iSCSI attachments, see IScsiVolumeAttachment Reference.
    /// 
    /// For general information about volume attachments, see Overview of Block Volume Storage.
    /// 
    /// Warning: Oracle recommends that you avoid using any confidential information when you supply string values using the API.
    /// This resource has one or more subtypes based on the value of the attachmentType attribute:
    /// </summary>
    public class VolumeAttachment
    {
        /// <summary>
        /// The type of volume attachment.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string AttachmentType { get; set; }

        /// <summary>
        /// The availability domain of an instance.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string AvailabilityDomain { get; set; }

        /// <summary>
        /// The OCID of the compartment.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string CompartmentId { get; set; }

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
        /// The OCID of the volume attachment.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The OCID of the instance the volume is attached to.
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
        /// The current state of the volume attachment.
        /// <para>Required: yes</para>
        /// </summary>
        public string LifecycleState { get; set; }

        /// <summary>
        /// The date and time the volume was created, in the format defined by RFC3339.
        /// <para>Required: yes</para>
        /// </summary>
        public string TimeCreated { get; set; }

        /// <summary>
        /// The OCID of the volume.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string VolumeId { get; set; }

        /// <summary>
        /// Whether in-transit encryption for the data volume's paravirtualized attachment is enabled or not.
        /// <para>Required: no</para>
        /// </summary>
        public bool? IsPvEncryptionInTransitEnabled { get; set; }

        /// <summary>
        /// The Challenge-Handshake-Authentication-Protocol (CHAP) secret valid for the associated CHAP user name. (Also called the "CHAP password".)
        /// <para>Required: no</para>
        /// <para>IScsiVolume only</para>
        /// </summary>
        public string ChapSecret { get; set; }

        /// <summary>
        /// The volume's system-generated Challenge-Handshake-Authentication-Protocol (CHAP) user name.
        /// <para>Required: no</para>
        /// <para>IScsiVolume only</para>
        /// </summary>
        public string ChapUsername { get; set; }

        /// <summary>
        /// The volume's iSCSI IP address.
        /// <para>Required: yes</para>
        /// <para>IScsiVolume only</para>
        /// </summary>
        public string Ipv4 { get; set; }

        /// <summary>
        /// The target volume's iSCSI Qualified Name in the format defined by RFC 3720.
        /// <para>Required: yes</para>
        /// <para>IScsiVolume only</para>
        /// </summary>
        public string Iqn { get; set; }

        /// <summary>
        /// The volume's iSCSI port.
        /// <para>Required: yes</para>
        /// <para>IScsiVolume only</para>
        /// </summary>
        public int? Port { get; set; }
    }
}

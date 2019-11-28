using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Model.Blockstorage
{
    /// <summary>
    /// A policy for automatically creating volume backups according to a recurring schedule. 
    /// Has a set of one or more schedules that control when and how backups are created.
    /// 
    /// Warning: Oracle recommends that you avoid using any confidential information when you supply string values using the API.
    /// </summary>
    public class VolumeBackupPolicy
    {
        /// <summary>
        /// A user-friendly name for the volume backup policy. Does not have to be unique and it's changeable. 
        /// Avoid entering confidential information.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The OCID of the volume backup policy.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The collection of schedules that this policy will apply.
        /// <para>Required: yes</para>
        /// </summary>
        public List<VolumeBackupSchedule> Schedules { get; set; }

        /// <summary>
        /// The date and time the volume backup policy was created. Format defined by RFC3339.
        /// <para>Required: yes</para>
        /// </summary>
        public string TimeCreated { get; set; }
    }
}

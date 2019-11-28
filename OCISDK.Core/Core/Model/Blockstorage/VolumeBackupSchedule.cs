using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Model.Blockstorage
{
    /// <summary>
    /// Defines a chronological recurrence pattern for creating scheduled backups at a particular periodicity.
    /// </summary>
    public class VolumeBackupSchedule
    {
        /// <summary>
        /// The type of backup to create.
        /// <para>Required: yes</para>
        /// </summary>
        public string BackupType { get; set; }

        /// <summary>
        /// The number of seconds that the backup time should be shifted from the default interval boundaries specified 
        /// by the period. Backup time = Frequency start time + Offset.
        /// <para>Required: no</para>
        /// </summary>
        public int? OffsetSeconds { get; set; }

        /// <summary>
        /// How often the backup should occur.
        /// <para>Required: yes</para>
        /// </summary>
        public string Period { get; set; }

        /// <summary>
        /// How long, in seconds, backups created by this schedule should be kept until being automatically deleted.
        /// <para>Required: yes</para>
        /// <para>Minimum: 3600</para>
        /// </summary>
        public int RetentionSeconds { get; set; }
    }
}

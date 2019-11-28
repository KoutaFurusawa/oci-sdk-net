using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Database.Model
{
    /// <summary>
    /// Backup Options To use any of the API operations, you must be authorized in an IAM policy. 
    /// If you're not authorized, talk to an administrator. 
    /// If you're an administrator who needs to write policies to give users access, see Getting Started with Policies.
    /// </summary>
    public class DbBackupConfig
    {
        /// <summary>
        /// If set to true, configures automatic backups. 
        /// If you previously used RMAN or dbcli to configure backups and then you switch to using the Console or the API for backups, 
        /// a new backup configuration is created and associated with your database. 
        /// This means that you can no longer rely on your previously configured unmanaged backups to work.
        /// <para>Required: no</para>
        /// </summary>
        public bool? AutoBackupEnabled { get; set; }

        /// <summary>
        /// Number of days between the current and the earliest point of recoverability covered by automatic backups. 
        /// This value applies to automatic backups only. After a new automatic backup has been created, Oracle removes old automatic backups that are created before the window. 
        /// When the value is updated, it is applied to all existing automatic backups.
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 60</para>
        /// </summary>
        public int? RecoveryWindowInDays { get; set; }
    }
}

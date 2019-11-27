using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace OCISDK.Core.Database.Model
{
    /// <summary>
    /// Note that a valid dbSystemId value must be supplied for the CreateDbHomeWithDbSystemIdFromBackup API operation to successfully complete.
    /// </summary>
    public class CreateDbHomeWithDbSystemIdFromBackupDetails
    {
        /// <summary>
        /// The OCID of the DB system.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string DbSystemId { get; set; }

        /// <summary>
        /// The user-provided name of the database home.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The source of database: NONE for creating a new database. DB_BACKUP for creating a new database by restoring from a database backup.
        /// <para>Required: no</para>
        /// </summary>
        protected readonly string Source = "DB_BACKUP";
        
        /// <summary>
        /// Note that a valid dbSystemId value must be supplied for the CreateDbHomeWithDbSystemIdFromBackup API operation to successfully complete.
        /// </summary>
        public CreateDatabaseFromBackupDetails Database { get; set; }
    }
}

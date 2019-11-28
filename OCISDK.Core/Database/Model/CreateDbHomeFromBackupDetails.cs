using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Database.Model
{
    /// <summary>
    /// Details for creating a database home if you are creating a database by restoring from a database backup.
    /// 
    /// Warning: Oracle recommends that you avoid using any confidential information when you supply string values using the API.
    /// </summary>
    public class CreateDbHomeFromBackupDetails
    {
        /// <summary>
        /// <para>Required: yes</para>
        /// </summary>
        public CreateDatabaseFromBackupDetails database { get; set; }

        /// <summary>
        /// The user-provided name of the database home.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string DisplayName { get; set; }
    }
}

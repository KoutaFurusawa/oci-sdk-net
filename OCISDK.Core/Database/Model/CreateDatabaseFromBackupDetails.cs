using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Database.Model
{
    /// <summary>
    /// CreateDatabaseFromBackupDetails
    /// </summary>
    public class CreateDatabaseFromBackupDetails
    {
        /// <summary>
        /// A strong password for SYS, SYSTEM, PDB Admin and TDE Wallet. 
        /// The password must be at least nine characters and contain at least two uppercase, two lowercase, two numbers, and two special characters. 
        /// The special characters must be _, #, or -.
        /// <para>Required: yes</para>
        /// <para>Min Length: 9, Max Length: 255</para>
        /// </summary>
        public string AdminPassword { get; set; }

        /// <summary>
        /// The backup OCID.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string BackupId { get; set; }

        /// <summary>
        /// The password to open the TDE wallet.
        /// <para>Required: yes</para>
        /// <para>Min Length: 8, Max Length: 255</para>
        /// </summary>
        public string BackupTDEPassword { get; set; }

        /// <summary>
        /// The display name of the database to be created from the backup. 
        /// It must begin with an alphabetic character and can contain a maximum of eight alphanumeric characters. 
        /// Special characters are not permitted.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 8</para>
        /// </summary>
        public string DbName { get; set; }
    }
}

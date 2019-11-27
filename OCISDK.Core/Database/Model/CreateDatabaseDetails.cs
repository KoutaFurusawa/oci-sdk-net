using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Database.Model
{
    /// <summary>
    /// Details for creating a database.
    /// 
    /// Warning: Oracle recommends that you avoid using any confidential information when you supply string values using the API.
    /// </summary>
    public class CreateDatabaseDetails
    {
        /// <summary>
        /// A strong password for SYS, SYSTEM, and PDB Admin. 
        /// The password must be at least nine characters and contain at least two uppercase, two lowercase, two numbers, and two special characters. 
        /// The special characters must be _, #, or -.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string AdminPassword { get; set; }

        /// <summary>
        /// The character set for the database. The default is AL32UTF8. Allowed values are:
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string CharacterSet { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public DbBackupConfig DbBackupConfig { get; set; }

        /// <summary>
        /// The database name. The name must begin with an alphabetic character and can contain a maximum of eight alphanumeric characters. Special characters are not permitted.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 8</para>
        /// </summary>
        public string DbName { get; set; }

        /// <summary>
        /// The database workload type.
        /// <para>Required: no</para>
        /// </summary>
        public string DbWorkload { get; set; }

        /// <summary>
        /// The national character set for the database. The default is AL16UTF16. Allowed values are: AL16UTF16 or UTF8.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string NcharacterSet { get; set; }

        /// <summary>
        /// The name of the pluggable database. 
        /// The name must begin with an alphabetic character and can contain a maximum of eight alphanumeric characters. 
        /// Special characters are not permitted. Pluggable database should not be same as database name.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string PdbName { get; set; }

        /// <summary>
        /// Free-form tags for this resource. Each tag is a simple key-value pair with no predefined name, type, or namespace. 
        /// For more information, see Resource Tags.
        /// <para>Required: no</para>
        /// </summary>
        public IDictionary<string, string> FreeformTags { get; set; }

        /// <summary>
        /// Defined tags for this resource. Each key is predefined and scoped to a namespace. 
        /// For more information, see Resource Tags.
        /// <para>Required: no</para>
        /// </summary>
        public IDictionary<string, IDictionary<string, string>> DefinedTags { get; set; }
    }
}

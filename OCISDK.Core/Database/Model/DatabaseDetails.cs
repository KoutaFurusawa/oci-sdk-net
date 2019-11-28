using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Database.Model
{
    /// <summary>
    /// An Oracle Database on a bare metal or virtual machine DB system. For more information, see Bare Metal and Virtual Machine DB Systems.
    /// 
    /// To use any of the API operations, you must be authorized in an IAM policy. If you're not authorized, talk to an administrator. 
    /// If you're an administrator who needs to write policies to give users access, see Getting Started with Policies.
    /// 
    /// Warning: Oracle recommends that you avoid using any confidential information when you supply string values using the API.
    /// </summary>
    public class DatabaseDetails
    {
        /// <summary>
        /// The character set for the database.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string CharacterSet { get; set; }

        /// <summary>
        /// The OCID of the compartment.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// The Connection strings used to connect to the Oracle Database.
        /// <para>Required: no</para>
        /// </summary>
        public DatabaseConnectionStrings ConnectionStrings { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public DbBackupConfig DbBackupConfig { get; set; }

        /// <summary>
        /// The OCID of the database home.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string DbHomeId { get; set; }

        /// <summary>
        /// The database name.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string DbName { get; set; }

        /// <summary>
        /// A system-generated name for the database to ensure uniqueness within an Oracle Data Guard group (a primary database and its standby databases). 
        /// The unique name cannot be changed.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 30</para>
        /// </summary>
        public string DbUniqueName { get; set; }

        /// <summary>
        /// The database workload type.
        /// <para>Required: no</para>
        /// </summary>
        public string DbWorkload { get; set; }

        /// <summary>
        /// The OCID of the database.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Additional information about the current lifecycleState.
        /// <para>Required: no</para>
        /// </summary>
        public string LifecycleDetails { get; set; }

        /// <summary>
        /// The current state of the database.
        /// <para>Required: yes</para>
        /// </summary>
        public string LifecycleState { get; set; }

        /// <summary>
        /// The national character set for the database.
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
        /// The date and time the database was created.
        /// <para>Required: no</para>
        /// </summary>
        public string TimeCreated { get; set; }

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

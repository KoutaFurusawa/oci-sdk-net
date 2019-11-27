using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Database.Model
{
    /// <summary>
    /// A directory where Oracle Database software is installed. 
    /// A bare metal DB system can have multiple database homes and each database home can run a different supported version of Oracle Database. 
    /// A virtual machine DB system can have only one database home. For more information, see Bare Metal and Virtual Machine DB Systems.
    /// </summary>
    public class DbHomeDetails
    {
        /// <summary>
        /// The OCID of the compartment.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// The OCID of the DB system.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string DbSystemId { get; set; }

        /// <summary>
        /// The Oracle Database version.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string DbVersion { get; set; }

        /// <summary>
        /// The user-provided name for the database home. The name does not need to be unique.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The OCID of the database home.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The OCID of the last patch history. This value is updated as soon as a patch operation is started.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string LastPatchHistoryEntryId { get; set; }

        /// <summary>
        /// The current state of the database home.
        /// <para>Required: yes</para>
        /// </summary>
        public string LifecycleState { get; set; }

        /// <summary>
        /// The date and time the database home was created.
        /// <para>Required: no</para>
        /// </summary>
        public string TimeCreated { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Database.Model
{
    /// <summary>
    /// A server where Oracle Database software is running.
    /// 
    /// To use any of the API operations, you must be authorized in an IAM policy. 
    /// If you're not authorized, talk to an administrator. 
    /// If you're an administrator who needs to write policies to give users access, see Getting Started with Policies.
    /// 
    /// Warning: Oracle recommends that you avoid using any confidential information when you supply string values using the API.
    /// </summary>
    public class DbNodeDetails
    {
        /// <summary>
        /// The OCID of the backup VNIC.
        /// <para>Required: no</para>
        /// </summary>
        public string BackupVnicId { get; set; }

        /// <summary>
        /// The OCID of the DB system.
        /// <para>Required: yes</para>
        /// </summary>
        public string DbSystemId { get; set; }

        /// <summary>
        /// The name of the Fault Domain the instance is contained in.
        /// </summary>
        public string FaultDomain { get; set; }

        /// <summary>
        /// The host name for the database node.
        /// <para>Required: no</para>
        /// </summary>
        public string Hostname { get; set; }

        /// <summary>
        /// The OCID of the database node.
        /// <para>Required: yes</para>
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The current state of the database node.
        /// <para>Required: yes</para>
        /// </summary>
        public string LifecycleState { get; set; }

        /// <summary>
        /// The size (in GB) of the block storage volume allocation for the DB system. This attribute applies only for virtual machine DB systems.
        /// <para>Required: no</para>
        /// </summary>
        public int? SoftwareStorageSizeInGB { get; set; }

        /// <summary>
        /// The date and time that the database node was created.
        /// <para>Required: yes</para>
        /// </summary>
        public string TimeCreated { get; set; }

        /// <summary>
        /// The OCID of the VNIC.
        /// <para>Required: yes</para>
        /// </summary>
        public string VnicId { get; set; }
    }
}

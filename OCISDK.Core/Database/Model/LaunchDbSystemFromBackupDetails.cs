using OCISDK.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace OCISDK.Core.Database.Model
{
    /// <summary>
    /// Used for creating a new DB system from a database backup.
    /// </summary>
    public class LaunchDbSystemFromBackupDetails
    {
        /// <summary>
        /// The name of the availability domain that the DB system is located in.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string AvailabilityDomain { get; set; }

        /// <summary>
        /// A list of the OCIDs of the network security groups (NSGs) that the backup network of this DB system belongs to. 
        /// Setting this to an empty array after the list is created removes the resource from all NSGs. 
        /// For more information about NSGs, see Security Rules. Applicable only to Exadata DB systems.
        /// <para>Required: no</para>
        /// </summary>
        public string BackupNetworkNsgIds { get; set; }

        /// <summary>
        /// The OCID of the backup network subnet the DB system is associated with. Applicable only to Exadata DB systems.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string BackupSubnetId { get; set; }

        /// <summary>
        /// The cluster name for Exadata and 2-node RAC virtual machine DB systems. 
        /// The cluster name must begin with an an alphabetic character, and may contain hyphens (-). 
        /// Underscores (_) are not permitted. The cluster name can be no longer than 11 characters and is not case sensitive.
        /// <para>Required: no</para>
        /// </summary>
        public string ClusterName { get; set; }

        /// <summary>
        /// The OCID of the compartment.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// The number of CPU cores enabled on the DB system.
        /// <para>Required: yes</para>
        /// </summary>
        public string CpuCoreCount { get; set; }

        /// <summary>
        /// The percentage assigned to DATA storage (user data and database files). 
        /// The remaining percentage is assigned to RECO storage (database redo logs, archive logs, and recovery manager backups). 
        /// Accepted values are 40 and 80. The default is 80 percent assigned to DATA storage. Not applicable for virtual machine DB systems.
        /// <para>Required: no</para>
        /// </summary>
        public int? DataStoragePercentage { get; set; }

        /// <summary>
        /// The user-friendly name for the DB system. The name does not have to be unique.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The domain name for the DB system.
        /// <para>Required: no</para>
        /// </summary>
        public string Domain { get; set; }

        /// <summary>
        /// List of the Fault Domains in which this DB system is provisioned.
        /// <para>Required: no</para>
        /// <para>Max Length: 255</para>
        /// </summary>
        public List<string> FaultDomains { get; set; }

        /// <summary>
        /// The hostname for the DB system.
        /// <para>Required: yes</para>
        /// </summary>
        public string Hostname { get; set; }

        /// <summary>
        /// Size (in GB) of the initial data volume that will be created and attached to a virtual machine DB system.
        /// You can scale up storage after provisioning, as needed.
        /// Note that the total storage size attached will be more than the amount you specify to allow for REDO/RECO space and software volume.
        /// <para>Required: no</para>
        /// <para>Minimum: 2</para>
        /// </summary>
        public int? InitialDataStorageSizeInGB { get; set; }

        /// <summary>
        /// The number of nodes in the DB system. For RAC DB systems, the value is greater than 1.
        /// <para>Required: no</para>
        /// </summary>
        public int? NodeCount { get; set; }

        /// <summary>
        /// A list of the OCIDs of the network security groups (NSGs) that this DB system belongs to. 
        /// Setting this to an empty array after the list is created removes the resource from all NSGs. 
        /// For more information about NSGs, see Security Rules.
        /// <para>Required: no</para>
        /// <para>Max Length: 255</para>
        /// <para>Max Items: 5</para>
        /// </summary>
        public List<string> NsgIds { get; set; }

        /// <summary>
        /// The shape of the DB system. The shape determines resources to allocate to the DB system.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string Shape { get; set; }

        /// <summary>
        /// The source of the database: NONE for creating a new database. DB_BACKUP for creating a new database by restoring from a backup.
        /// The default is NONE.
        /// <para>Required: no</para>
        /// </summary>
        public readonly string Source = "DB_BACKUP";

        /// <summary>
        /// True, if Sparse Diskgroup is configured for Exadata dbsystem, False, if Sparse diskgroup was not configured.
        /// <para>Required: no</para>
        /// </summary>
        public bool? SparseDiskgroup { get; set; }

        /// <summary>
        /// The public key portion of one or more key pairs used for SSH access to the DB system.
        /// <para>Required: yes</para>
        /// <para>Max Length: 1024</para>
        /// </summary>
        public List<string> SshPublicKeys { get; set; }

        /// <summary>
        /// The OCID of the subnet the DB system is associated with.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string SubnetId { get; set; }

        /// <summary>
        /// The time zone of the DB system. For details, see DB System Time Zones.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string TimeZone { get; set; }

        /// <summary>
        /// The Oracle Database Edition that applies to all the databases on the DB system.
        /// Exadata DB systems and 2-node RAC DB systems require ENTERPRISE_EDITION_EXTREME_PERFORMANCE.
        /// <para>Required: yes</para>
        /// </summary>
        public DatabaseEditionParam DatabaseEdition { get; set; }
        
        /// <summary>
        /// DatabaseEditionParam ExpandableEnum
        /// </summary>
        public class DatabaseEditionParam : ExpandableEnum<DatabaseEditionParam>
        {
            /// <summary>
            /// DatabaseEditionParam ExpandableEnum
            /// </summary>
            /// <param name="value"></param>
            public DatabaseEditionParam(string value) : base(value) { }

            /// <summary>
            /// parase
            /// </summary>
            /// <param name="value"></param>
            public static implicit operator DatabaseEditionParam(string value)
            {
                return Parse(value);
            }

            /// <summary>
            /// STANDARD_EDITION
            /// </summary>
            public static readonly DatabaseEditionParam STANDARD_EDITION = new DatabaseEditionParam("STANDARD_EDITION");

            /// <summary>
            /// ENTERPRISE_EDITION
            /// </summary>
            public static readonly DatabaseEditionParam ENTERPRISE_EDITION = new DatabaseEditionParam("ENTERPRISE_EDITION");

            /// <summary>
            /// ENTERPRISE_EDITION_HIGH_PERFORMANCE
            /// </summary>
            public static readonly DatabaseEditionParam ENTERPRISE_EDITION_HIGH_PERFORMANCE = new DatabaseEditionParam("ENTERPRISE_EDITION_HIGH_PERFORMANCE");

            /// <summary>
            /// ENTERPRISE_EDITION_EXTREME_PERFORMANCE
            /// </summary>
            public static readonly DatabaseEditionParam ENTERPRISE_EDITION_EXTREME_PERFORMANCE = new DatabaseEditionParam("ENTERPRISE_EDITION_EXTREME_PERFORMANCE");
        }

        /// <summary>
        /// <para>Required: yes</para>
        /// </summary>
        public CreateDbHomeFromBackupDetails DbHome { get; set; }

        /// <summary>
        /// The type of redundancy configured for the DB system. Normal is 2-way redundancy, recommended for test and development systems. 
        /// High is 3-way redundancy, recommended for production systems.
        /// <para>Required: no</para>
        /// </summary>
        public DiskRedundancyParam DiskRedundancy { get; set; }
        
        /// <summary>
        /// DiskRedundancy ExpandableEnum
        /// </summary>
        public class DiskRedundancyParam : ExpandableEnum<DiskRedundancyParam>
        {
            /// <summary>
            /// DiskRedundancy ExpandableEnum
            /// </summary>
            /// <param name="value"></param>
            public DiskRedundancyParam(string value) : base(value) { }

            /// <summary>
            /// parase
            /// </summary>
            /// <param name="value"></param>
            public static implicit operator DiskRedundancyParam(string value)
            {
                return Parse(value);
            }

            /// <summary>
            /// STANDARD_EDITION
            /// </summary>
            public static readonly DiskRedundancyParam HIGH = new DiskRedundancyParam("HIGH");

            /// <summary>
            /// ENTERPRISE_EDITION
            /// </summary>
            public static readonly DiskRedundancyParam NORMAL = new DiskRedundancyParam("NORMAL");
        }

        /// <summary>
        /// The Oracle license model that applies to all the databases on the DB system. 
        /// The default is LICENSE_INCLUDED.
        /// <para>Required: no</para>
        /// </summary>
        public LicenseModelParam LicenseModel { get; set; }
        
        /// <summary>
        /// LicenseModel ExpandableEnum
        /// </summary>
        public class LicenseModelParam : ExpandableEnum<LicenseModelParam>
        {
            /// <summary>
            /// LicenseModel ExpandableEnum
            /// </summary>
            /// <param name="value"></param>
            public LicenseModelParam(string value) : base(value) { }

            /// <summary>
            /// parase
            /// </summary>
            /// <param name="value"></param>
            public static implicit operator LicenseModelParam(string value)
            {
                return Parse(value);
            }

            /// <summary>
            /// STANDARD_EDITION
            /// </summary>
            public static readonly LicenseModelParam LICENSE_INCLUDED = new LicenseModelParam("LICENSE_INCLUDED");

            /// <summary>
            /// ENTERPRISE_EDITION
            /// </summary>
            public static readonly LicenseModelParam BRING_YOUR_OWN_LICENSE = new LicenseModelParam("BRING_YOUR_OWN_LICENSE");
        }

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

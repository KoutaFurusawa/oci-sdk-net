using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Database.Model
{
    /// <summary>
    /// The Database Service supports several types of DB systems, ranging in size, price, and performance. For details about each type of system, see:
    /// 
    /// * Exadata DB Systems
    /// * Bare Metal and Virtual Machine DB Systems
    /// 
    /// To use any of the API operations, you must be authorized in an IAM policy. 
    /// If you are not authorized, talk to an administrator. 
    /// If you are an administrator who needs to write policies to give users access, see Getting Started with Policies.
    /// 
    /// For information about access control and compartments, see Overview of the Identity Service.
    /// For information about availability domains, see Regions and Availability Domains.
    /// 
    /// To get a list of availability domains, use the ListAvailabilityDomains operation in the Identity Service API.
    /// 
    /// Warning: Oracle recommends that you avoid using any confidential information when you supply string values using the API.
    /// </summary>
    public class DbSystemSummary
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
        /// <para>Max Items: 5</para>
        /// </summary>
        public List<string> BackupNetworkNsgIds { get; set; }

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
        /// The data storage size, in gigabytes, that is currently available to the DB system. Applies only for virtual machine DB systems.
        /// <para>Required: no</para>
        /// </summary>
        public int? DataStorageSizeInGBs { get; set; }

        /// <summary>
        /// The Oracle Database edition that applies to all the databases on the DB system.
        /// <para>Required: yes</para>
        /// </summary>
        public string DatabaseEdition { get; set; }

        /// <summary>
        /// The type of redundancy configured for the DB system. NORMAL is 2-way redundancy. HIGH is 3-way redundancy.
        /// <para>Required: no</para>
        /// </summary>
        public string DiskRedundancy { get; set; }

        /// <summary>
        /// The user-friendly name for the DB system. The name does not have to be unique.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The domain name for the DB system.
        /// <para>Required: yes</para>
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
        /// The OCID of the DB system.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public ExadataIormConfigDetails IormConfigCache { get; set; }

        /// <summary>
        /// The OCID of the last patch history. This value is updated as soon as a patch operation starts.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string LastPatchHistoryEntryId { get; set; }

        /// <summary>
        /// The Oracle license model that applies to all the databases on the DB system. The default is LICENSE_INCLUDED.
        /// <para>Required: no</para>
        /// </summary>
        public string LicenseModel { get; set; }

        /// <summary>
        /// Additional information about the current lifecycleState.
        /// <para>Required: no</para>
        /// </summary>
        public string LifecycleDetails { get; set; }

        /// <summary>
        /// The current state of the DB system.
        /// <para>Required: yes</para>
        /// </summary>
        public string LifecycleState { get; set; }

        /// <summary>
        /// The port number configured for the listener on the DB system.
        /// <para>Required: no</para>
        /// </summary>
        public int? ListenerPort { get; set; }

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
        /// The RECO/REDO storage size, in gigabytes, that is currently allocated to the DB system. Applies only for virtual machine DB systems.
        /// <para>Required: no</para>
        /// </summary>
        public int? RecoStorageSizeInGB { get; set; }

        /// <summary>
        /// The OCID of the DNS record for the SCAN IP addresses that are associated with the DB system.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string ScanDnsRecordId { get; set; }

        /// <summary>
        /// The OCID of the Single Client Access Name (SCAN) IP addresses associated with the DB system. 
        /// SCAN IP addresses are typically used for load balancing and are not assigned to any interface. 
        /// Oracle Clusterware directs the requests to the appropriate nodes in the cluster.
        /// 
        /// Note: For a single-node DB system, this list is empty.
        /// <para>Required: no</para>
        /// <para>Max Length: 255</para>
        /// </summary>
        public List<string> ScanIpIds { get; set; }

        /// <summary>
        /// The shape of the DB system. The shape determines resources to allocate to the DB system.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string Shape { get; set; }

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
        /// The date and time the DB system was created.
        /// <para>Required: no</para>
        /// </summary>
        public string TimeCreated { get; set; }

        /// <summary>
        /// The time zone of the DB system. For details, see DB System Time Zones.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string TimeZone { get; set; }

        /// <summary>
        /// The Oracle Database version of the DB system.
        /// <para>Required: no</para>
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// The OCID of the virtual IP (VIP) addresses associated with the DB system. 
        /// The Cluster Ready Services (CRS) creates and maintains one VIP address for each node in the DB system to enable failover. 
        /// If one node fails, the VIP is reassigned to another active node in the cluster.
        /// <para>Required: no</para>
        /// <para>Max Length: 255</para>
        /// </summary>
        public List<string> VipIds { get; set; }

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

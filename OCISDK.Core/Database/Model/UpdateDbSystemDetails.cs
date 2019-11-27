using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Database.Model
{
    /// <summary>
    /// Describes the parameters for updating the DB system.
    /// 
    /// Warning: Oracle recommends that you avoid using any confidential information when you supply string values using the API.
    /// </summary>
    public class UpdateDbSystemDetails
    {
        /// <summary>
        /// A list of the OCIDs of the network security groups (NSGs) that the backup network of this DB system belongs to. 
        /// Setting this to an empty array after the list is created removes the resource from all NSGs. 
        /// For more information about NSGs, see Security Rules. Applicable only to Exadata DB systems.
        /// <para>Required: no</para>
        /// <para>Max Items: 5</para>
        /// </summary>
        public List<string> BackupNetworkNsgIds { get; set; }

        /// <summary>
        /// The new number of CPU cores to set for the DB system. Not applicable for virtual machine DB systems.
        /// <para>Required: no</para>
        /// <para>Minimum: 1</para>
        /// </summary>
        public int? CpuCoreCount { get; set; }

        /// <summary>
        /// The size, in gigabytes, to scale the attached storage up to for this virtual machine DB system. 
        /// This value must be greater than current storage size. 
        /// Note that the resulting total storage size attached will be greater than the amount requested to allow for REDO/RECO space and software volume.
        /// Applies only to virtual machine DB systems.
        /// </summary>
        public int? DataStorageSizeInGBs { get; set; }

        /// <summary>
        /// A list of the OCIDs of the network security groups (NSGs) that this DB system belongs to. 
        /// Setting this to an empty array after the list is created removes the resource from all NSGs. 
        /// For more information about NSGs, see Security Rules.
        /// <para>Required: no</para>
        /// <para>Max Items: 5</para>
        /// </summary>
        public List<string> NsgIds { get; set; }

        /// <summary>
        /// The public key portion of the key pair to use for SSH access to the DB system. 
        /// Multiple public keys can be provided. The length of the combined keys cannot exceed 40,000 characters.
        /// </summary>
        public List<string> SshPublicKeys { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public PatchDetails Version { get; set; }

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

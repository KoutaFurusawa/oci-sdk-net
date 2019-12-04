using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.FileStorage.Model
{
    /// <summary>
    /// Summary information for a file system.
    /// </summary>
    public class FileSystemSummary
    {
        /// <summary>
        /// The availability domain the file system is in. May be unset as a blank or NULL value.
        /// <para>Required: no</para>
        /// </summary>
        public string AvailabilityDomain { get; set; }

        /// <summary>
        /// The number of bytes consumed by the file system, including any snapshots. This number reflects the metered size of the file 
        /// system and is updated asynchronously with respect to updates to the file system.
        /// <para>Required: yes</para>
        /// </summary>
        public long MeteredBytes { get; set; }

        /// <summary>
        /// The OCID of the compartment that contains the file system.
        /// <para>Required: yes</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// A user-friendly name. It does not have to be unique, and it is changeable. Avoid entering confidential information.
        /// <para>Required: yes</para>
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The OCID of the file system.
        /// <para>Required: yes</para>
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The current state of the file system.
        /// <para>Required: yes</para>
        /// </summary>
        public string LifecycleState { get; set; }

        /// <summary>
        /// The date and time the file system was created, expressed in RFC 3339 timestamp format.
        /// <para>Required: yes</para>
        /// </summary>
        public string TimeCreated { get; set; }

        /// <summary>
        /// The OCID of the KMS key which is the master encryption key for the file system.
        /// <para>Required: no</para>
        /// </summary>
        public string KmsKeyId { get; set; }

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

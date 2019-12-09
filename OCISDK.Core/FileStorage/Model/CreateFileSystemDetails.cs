using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.FileStorage.Model
{
    /// <summary>
    /// Details for creating the file system.
    /// </summary>
    public class CreateFileSystemDetails
    {
        /// <summary>
        /// The availability domain the file system is in. May be unset as a blank or NULL value.
        /// <para>Required: yes</para>
        /// </summary>
        public string AvailabilityDomain { get; set; }
        
        /// <summary>
        /// The OCID of the compartment that contains the file system.
        /// <para>Required: yes</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// A user-friendly name. It does not have to be unique, and it is changeable. Avoid entering confidential information.
        /// <para>Required: no</para>
        /// </summary>
        public string DisplayName { get; set; }
        
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

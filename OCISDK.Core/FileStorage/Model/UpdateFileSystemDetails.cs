using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.FileStorage.Model
{
    /// <summary>
    /// Details for updating the file system.
    /// </summary>
    public class UpdateFileSystemDetails
    {
        /// <summary>
        /// A user-friendly name. It does not have to be unique, and it is changeable. Avoid entering confidential information.
        /// <para>Required: no</para>
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The OCID of the Key Management master encryption key to associate with the specified file system. If this value is empty, 
        /// the Update operation will remove the associated key, if there is one, from the file system. (The file system will continue 
        /// to be encrypted, but with an encryption key managed by Oracle.)
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

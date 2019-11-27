using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Database.Model
{
    /// <summary>
    /// UpdateDatabaseDetails
    /// </summary>
    public class UpdateDatabaseDetails
    {
        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public DbBackupConfig DbBackupConfig { get; set; }

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

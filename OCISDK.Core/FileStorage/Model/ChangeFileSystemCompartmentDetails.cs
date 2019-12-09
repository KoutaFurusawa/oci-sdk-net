using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.FileStorage.Model
{
    /// <summary>
    /// Details for changing the compartment.
    /// </summary>
    public class ChangeFileSystemCompartmentDetails
    {
        /// <summary>
        /// The OCID of the compartment to move the file system to.
        /// <para>Required: yes</para>
        /// </summary>
        public string CompartmentId { get; set; }
    }
}

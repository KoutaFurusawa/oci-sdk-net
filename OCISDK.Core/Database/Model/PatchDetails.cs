using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Database.Model
{
    /// <summary>
    /// The details about what actions to perform and using what patch to the specified target. 
    /// This is part of an update request that is applied to a version field on the target such as DB system, database home, etc.
    /// </summary>
    public class PatchDetails
    {
        /// <summary>
        /// The action to perform on the patch.
        /// <para>Required: no</para>
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        /// The OCID of the patch.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string PatchId { get; set; }
    }
}

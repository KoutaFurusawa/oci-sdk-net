using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Identity.Model
{
    /// <summary>
    /// Collection of resource-types supported by a compartment bulk action.
    /// </summary>
    public class BulkActionResourceTypeCollection
    {
        /// <summary>
        /// Collection of the resource-types supported by a compartment bulk action.
        /// <para>Required: yes</para>
        /// </summary>
        public List<BulkActionResourceType> Items { get; set; }
    }
}

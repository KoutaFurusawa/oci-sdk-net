using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.SupportManagement.Model
{
    /// <summary>
    /// Details about the subcategory associated with the support ticket.
    /// </summary>
    public class SubCategoryDetails
    {
        /// <summary>
        /// The name of the subcategory. For example, Backup Count or Custom Image Count.
        /// <para>Required: no</para>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Unique identifier for the subcategory.
        /// <para>Required: no</para>
        /// </summary>
        public string SubCategoryKey { get; set; }
    }
}

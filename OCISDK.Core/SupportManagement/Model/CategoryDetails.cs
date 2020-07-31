using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.SupportManagement.Model
{
    /// <summary>
    /// Details about the category associated with the support ticket.
    /// </summary>
    public class CategoryDetails
    {
        /// <summary>
        /// Unique identifier for the category.
        /// <para>Required: no</para>
        /// </summary>
        public string CategoryKey { get; set; }

        /// <summary>
        /// The name of the category. For example, Compute or Identity.
        /// <para>Required: no</para>
        /// </summary>
        public string Name { get; set; }
    }
}

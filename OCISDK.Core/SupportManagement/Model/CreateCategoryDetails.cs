using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.SupportManagement.Model
{
    /// <summary>
    /// Details for creating the category of the support ticket.
    /// </summary>
    public class CreateCategoryDetails
    {
        /// <summary>
        /// Unique identifier for the category.
        /// <para>Required: no</para>
        /// </summary>
        public string CategoryKey { get; set; }
    }
}

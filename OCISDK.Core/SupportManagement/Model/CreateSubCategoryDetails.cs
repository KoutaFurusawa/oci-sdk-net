using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.SupportManagement.Model
{
    /// <summary>
    /// Details for creating the subcategory of the support ticket.
    /// </summary>
    public class CreateSubCategoryDetails
    {
        /// <summary>
        /// Unique identifier for the subcategory.
        /// <para>Required: no</para>
        /// </summary>
        public string SubCategoryKey { get; set; }
    }
}

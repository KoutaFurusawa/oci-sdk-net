using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.SupportManagement.Model
{
    /// <summary>
    /// Details for creating the item.
    /// </summary>
    public class CreateItemDetails
    {
        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public CreateCategoryDetails Category { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public CreateIssueTypeDetails IssueType { get; set; }

        /// <summary>
        /// The display name of the item.
        /// <para>Required: no</para>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// <para>Required: no</para>        /// </summary>
        public CreateSubCategoryDetails SubCategory { get; set; }

        /// <summary>
        /// The type of the item.
        /// </summary>
        public string Type { get; set; }
    }
}

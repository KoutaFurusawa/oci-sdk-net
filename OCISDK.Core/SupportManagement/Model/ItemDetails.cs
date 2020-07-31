using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.SupportManagement.Model
{
    /// <summary>
    /// Details about the item object.
    /// </summary>
    public class ItemDetails
    {
        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public CategoryDetails Category { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public IssueTypeDetails IssueType { get; set; }

        /// <summary>
        /// Unique identifier for the item.
        /// <para>Required: yes</para>
        /// </summary>
        public string ItemKey { get; set; }

        /// <summary>
        /// The display name of the item.
        /// <para>Required: no</para>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public SubCategoryDetails SubCategory { get; set; }

        /// <summary>
        /// The type of the support request.
        /// <para>Required: no</para>
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The person who updates the activity on the support ticket.
        /// <para>Required: no</para>
        /// </summary>
        public string ActivityAuthor { get; set; }

        /// <summary>
        /// The type of activity occuring on the support ticket.
        /// <para>Required: no</para>
        /// </summary>
        public string ActivityType { get; set; }

        /// <summary>
        /// Comments added with the activity on the support ticket.
        /// <para>Required: no</para>
        /// </summary>
        public string Comments { get; set; }

        /// <summary>
        /// The time when the activity was created, in milliseconds since epoch time.
        /// <para>Required: no</para>
        /// </summary>
        public int? TimeCreated { get; set; }

        /// <summary>
        /// The time when the activity was updated, in milliseconds since epoch time.
        /// <para>Required: no</para>
        /// </summary>
        public int? TimeUpdated { get; set; }

        /// <summary>
        /// The currently available limit of the resource.
        /// <para>Required: no</para>
        /// </summary>
        public int? CurrentLimit { get; set; }

        /// <summary>
        /// The current usage of the resource.
        /// <para>Required: no</para>
        /// </summary>
        public int? CurrentUsage { get; set; }

        /// <summary>
        /// The status of the request.
        /// <para>Required: no</para>
        /// </summary>
        public string LimitStatus { get; set; }

        /// <summary>
        /// The requested limit for the resource.
        /// <para>Required: no</para>
        /// </summary>
        public int? RequestedLimit { get; set; }
    }
}

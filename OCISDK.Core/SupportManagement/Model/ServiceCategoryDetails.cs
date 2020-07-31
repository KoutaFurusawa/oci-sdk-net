using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.SupportManagement.Model
{
    /// <summary>
    /// Information about the incident classifier.
    /// </summary>
    public class ServiceCategoryDetails
    {
        /// <summary>
        /// The text describing the classifier.
        /// <para>Required: no</para>
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The list of issues.
        /// <para>Required: no</para>
        /// </summary>
        public List<IssueTypeDetails> IssueTypeList { get; set; }

        /// <summary>
        /// The unique ID that identifies a classifier.
        /// <para>Required: no</para>
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// The label for the classifier.
        /// <para>Required: no</para>
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// The unique ID for the limit.
        /// <para>Required: no</para>
        /// </summary>
        public string LimitId { get; set; }

        /// <summary>
        /// The name of the classifier.
        /// <para>Required: no</para>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The scope of the incident.
        /// <para>Required: no</para>
        /// </summary>
        public string Scope { get; set; }

        /// <summary>
        /// The unit to use to measure the service category or resource.
        /// <para>Required: no</para>
        /// </summary>
        public string Unit { get; set; }
    }
}

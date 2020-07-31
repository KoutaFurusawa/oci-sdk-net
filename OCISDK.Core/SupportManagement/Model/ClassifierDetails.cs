using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.SupportManagement.Model
{
    /// <summary>
    /// Details about the incident classifier object.
    /// </summary>
    public class ClassifierDetails
    {
        /// <summary>
        /// The description of the classifier.
        /// <para>Required: no</para>
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Unique identifier of the classifier.
        /// <para>Required: no</para>
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The list of issues.
        /// <para>Required: no</para>
        /// </summary>
        public List<IssueTypeDetails> IssueTypeList { get; set; }

        /// <summary>
        /// The label associated with the classifier.
        /// <para>Required: no</para>
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// The display name of the classifier.
        /// <para>Required: no</para>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The scope of the service category or resource.
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

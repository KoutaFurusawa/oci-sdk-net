using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.SupportManagement.Model
{
    /// <summary>
    /// Details about the incident type object.
    /// </summary>
    public class IncidentTypeDetails
    {
        /// <summary>
        /// The list of classifiers.
        /// <para>Required: no</para>
        /// </summary>
        public List<ClassifierDetails> ClassifierList { get; set; }

        /// <summary>
        /// The description of the incident type.
        /// <para>Required: no</para>
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Unique identifier for the incident type.
        /// <para>Required: no</para>
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The label associated with the incident type.
        /// <para>Required: no</para>
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// The name of the incident type.
        /// <para>Required: no</para>
        /// </summary>
        public string Name { get; set; }
    }
}

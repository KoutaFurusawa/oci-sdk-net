using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Search.Model
{
    /// <summary>
    /// ResourceSummary
    /// </summary>
    public class ResourceSummary
    {
        /// <summary>
        /// The resource type name.
        /// <para>Required: yes</para>
        /// </summary>
        public string ResourceType { get; set; }

        /// <summary>
        /// The unique identifier for this particular resource, usually an OCID.
        /// <para>Required: yes</para>
        /// </summary>
        public string Identifier { get; set; }

        /// <summary>
        /// The OCID of the compartment that contains this resource.
        /// <para>Required: yes</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// The time this resource was created.
        /// <para>Required: no</para>
        /// </summary>
        public string TimeCreated { get; set; }

        /// <summary>
        /// The display name (or name) of this resource, if one exists.
        /// <para>Required: no</para>
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The availability domain this resource is located in, if applicable.
        /// <para>Required: no</para>
        /// </summary>
        public string AvailabilityDomain { get; set; }

        /// <summary>
        /// The lifecycle state of this resource, if applicable.
        /// <para>Required: no</para>
        /// </summary>
        public string LifecycleState { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public IDictionary<string, string> FreeformTags { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public IDictionary<string, IDictionary<string, string>> DefinedTags { get; set; }

        /// <summary>
        /// Contains search context, such as highlighting, for found resources.
        /// <para>Required: no</para>
        /// </summary>
        public SearchContext SearchContext { get; set; }
    }
}

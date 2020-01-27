using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Notification.Model
{
    /// <summary>
    /// The configuration details for creating the topic.
    /// </summary>
    public class CreateTopicDetails
    {
        /// <summary>
        /// The name of the topic being created. The topic name must be unique across the tenancy. Avoid entering confidential information.
        /// <para>Required: yes</para>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The OCID of the compartment to create the topic in.
        /// <para>Required: yes</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// The description of the topic being created. Avoid entering confidential information.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Free-form tags for this resource. Each tag is a simple key-value pair with no predefined name, type, or namespace. For more information, see Resource Tags.
        /// <para>Required: no</para>
        /// </summary>
        public IDictionary<string, string> FreeformTags { get; set; }

        /// <summary>
        /// Defined tags for this resource. Each key is predefined and scoped to a namespace. For more information, see Resource Tags.
        /// <para>Required: no</para>
        /// </summary>
        public IDictionary<string, IDictionary<string, string>> DefinedTags { get; set; }
    }
}

using System.Collections.Generic;

namespace OCISDK.Core.Identity.Model
{
    /// <summary>
    /// TagNamespace
    /// </summary>
    public class TagNamespace
    {
        /// <summary>
        /// The OCID of the tag namespace.
        /// <para>Required: yes</para>
        /// <para>Minimum: 1</para>
        /// <para>Maximum: 100</para>
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The OCID of the compartment that contains the tag namespace.
        /// <para>Required: yes</para>
        /// <para>Minimum: 1</para>
        /// <para>Maximum: 100</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// The name of the tag namespace. 
        /// It must be unique across all tag namespaces in the tenancy and cannot be changed.
        /// <para>Required: yes</para>
        /// <para>Minimum: 1</para>
        /// <para>Maximum: 100</para>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description you assign to the tag namespace.
        /// <para>Required: yes</para>
        /// <para>Minimum: 1</para>
        /// <para>Maximum: 400</para>
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Whether the tag namespace is retired. 
        /// See Retiring Key Definitions and Namespace Definitions.
        /// <para>Required: yes</para>
        /// </summary>
        public bool IsRetired { get; set; }

        /// <summary>
        /// Free-form tags for this resource. 
        /// Each tag is a simple key-value pair with no predefined name, type, or namespace. 
        /// </summary>
        public IDictionary<string, string> FreeformTags { get; set; }

        /// <summary>
        /// Defined tags for this resource. Each key is predefined and scoped to a namespace. 
        /// </summary>
        public IDictionary<string, IDictionary<string, string>> DefinedTags { get; set; }
    }
}

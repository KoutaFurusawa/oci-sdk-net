using System.Collections.Generic;

namespace OCISDK.Core.Identity.Model
{
    /// <summary>
    /// UpdateTagNamespaceDetails
    /// </summary>
    public class UpdateTagNamespaceDetails
    {

        /// <summary>
        /// The description you assign to the compartment during creation.
        /// Does not have to be unique, and it's changeable.
        /// <para>Required: no</para>
        /// <para>Minimum: 1</para>
        /// <para>Maximum: 400</para>
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Whether the tag namespace is retired. See Retiring Key Definitions and Namespace Definitions.
        /// <para>Required: no</para>
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


using System.Collections.Generic;

namespace OCISDK.Core.Identity.Model
{
    /// <summary>
    /// CreateCompartmentDetails Reference
    /// </summary>
    public class CreateCompartmentDetails
    {
        /// <summary>
        /// The OCID of the parent compartment containing the compartment.
        /// <para>Required: yes</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// The name you assign to the compartment during creation.
        /// The name must be unique across all compartments in the parent compartment.
        /// Avoid entering confidential information.
        /// <para>Required: yes</para>
        /// <para>Minimum: 1</para>
        /// <para>Maximum: 100</para>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description you assign to the compartment during creation.
        /// Does not have to be unique, and it's changeable.
        /// <para>Required: yes</para>
        /// <para>Minimum: 1</para>
        /// <para>Maximum: 400</para>
        /// </summary>
        public string Description { get; set; }

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

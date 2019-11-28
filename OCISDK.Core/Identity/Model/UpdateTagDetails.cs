using System.Collections.Generic;


namespace OCISDK.Core.Identity.Model
{
    /// <summary>
    /// UpdateTagDetails
    /// </summary>
    public class UpdateTagDetails
    {
        /// <summary>
        /// The description you assign to the tag during creation.
        /// <para>Required: no</para>
        /// <para>Minimum: 1</para>
        /// <para>Maximum: 400</para>
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Whether the tag is retired. See Retiring Key Definitions and Namespace Definitions.
        /// <para>Required: no</para>
        /// </summary>
        public bool IsRetired { get; set; }

        /// <summary>
        /// Indicates whether the tag is enabled for cost tracking.
        /// <para>Required: no</para>
        /// </summary>
        public bool IsCostTracking { get; set; }

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

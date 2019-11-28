using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.DNS.Model
{
    /// <summary>
    /// UpdateZoneDetails
    /// </summary>
    public class UpdateZoneDetails
    {
        /// <summary>
        /// External master servers for the zone. externalMasters becomes a required parameter when the zoneType value is SECONDARY.
        /// <para>Required: no</para>
        /// </summary>
        public List<ExternalMasterDetails> ExternalMasters { get; set; }

        /// <summary>
        /// Free-form tags for this resource. Each tag is a simple key-value pair with no predefined name, type, or namespace. 
        /// For more information, see Resource Tags.
        /// <para>Required: no</para>
        /// </summary>
        public IDictionary<string, string> FreeformTags { get; set; }

        /// <summary>
        /// Defined tags for this resource. Each key is predefined and scoped to a namespace. 
        /// For more information, see Resource Tags.
        /// <para>Required: no</para>
        /// </summary>
        public IDictionary<string, IDictionary<string, string>> DefinedTags { get; set; }
    }
}

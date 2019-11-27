using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.DNS.Model
{
    /// <summary>
    /// The body for defining a new zone.
    /// 
    /// Warning: Oracle recommends that you avoid using any confidential information when you supply string values using the API.
    /// </summary>
    public class CreateZoneDetails
    {
        /// <summary>
        /// The name of the zone.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 254</para>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The type of the zone. Must be either PRIMARY or SECONDARY.
        /// <para>Required: yes</para>
        /// </summary>
        public string ZoneType { get; set; }

        /// <summary>
        /// The OCID of the compartment containing the zone.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string CompartmentId { get; set; }

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

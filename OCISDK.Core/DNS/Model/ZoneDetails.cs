using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.DNS.Model
{
    /// <summary>
    /// A DNS zone.
    /// 
    /// Warning: Oracle recommends that you avoid using any confidential information when you supply string values using the API.
    /// </summary>
    public class ZoneDetails
    {
        /// <summary>
        /// The name of the zone.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 254</para>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The type of the zone. Must be either PRIMARY or SECONDARY.
        /// <para>Required: no</para>
        /// </summary>
        public string ZoneType { get; set; }

        /// <summary>
        /// The OCID of the compartment containing the zone.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// External master servers for the zone. externalMasters becomes a required parameter when the zoneType value is SECONDARY.
        /// <para>Required: no</para>
        /// </summary>
        public List<ExternalMasterDetails> ExternalMasters { get; set; }

        /// <summary>
        /// The canonical absolute URL of the resource.
        /// <para>Required: no</para>
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// The OCID of the zone.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The date and time the resource was created in "YYYY-MM-ddThh:mmZ" format with a Z offset, as defined by RFC 3339.
        /// <para>Required: no</para>
        /// </summary>
        public string TimeCreated { get; set; }

        /// <summary>
        /// Version is the never-repeating, totally-orderable, version of the zone, from which the serial field of the zone's SOA record is derived.
        /// <para>Required: no</para>
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// The current serial of the zone. As seen in the zone's SOA record.
        /// <para>Required: no</para>
        /// </summary>
        public int? Serial { get; set; }

        /// <summary>
        /// The current state of the zone resource.
        /// <para>Required: no</para>
        /// </summary>
        public string LifecycleState { get; set; }

        /// <summary>
        /// The authoritative nameservers for the zone.
        /// <para>Required: no</para>
        /// </summary>
        public List<NameserverDetails> Nameservers { get; set; }

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

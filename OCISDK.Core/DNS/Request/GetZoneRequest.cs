using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.DNS.Request
{
    /// <summary>
    /// GetZone Request
    /// </summary>
    public class GetZoneRequest
    {
        /// <summary>
        /// The If-None-Match header field makes the request method conditional on the absence of any current representation of 
        /// the target resource, when the field-value is *, or having a selected representation with an entity-tag that does not 
        /// match any of those listed in the field-value.
        /// <para>Required: no</para>
        /// </summary>
        public string IfNoneMatch { get; set; }

        /// <summary>
        /// The If-Modified-Since header field makes a GET or HEAD request method conditional on the selected representation's 
        /// modification date being more recent than the date provided in the field-value. Transfer of the selected representation's 
        /// data is avoided if that data has not changed.
        /// <para>Required: no</para>
        /// </summary>
        public string IfModifiedSince { get; set; }

        /// <summary>
        /// The name or OCID of the target zone.
        /// <para>Required: yes</para>
        /// </summary>
        public string ZoneNameOrId { get; set; }

        /// <summary>
        /// The OCID of the compartment the resource belongs to.
        /// <para>Required: no</para>
        /// </summary>
        public string CompartmentId { get; set; }
    }
}

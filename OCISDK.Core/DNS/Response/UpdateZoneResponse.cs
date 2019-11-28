using OCISDK.Core.DNS.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.DNS.Response
{
    /// <summary>
    /// UpdateZone Response
    /// </summary>
    public class UpdateZoneResponse
    {
        /// <summary>
        /// The current version of the zone, ending with a representation-specific suffix. 
        /// This value may be used in If-Match and If-None-Match headers for later requests of the same resource.
        /// </summary>
        public string ETag { get; set; }

        /// <summary>
        /// Unique Oracle-assigned identifier for the request. 
        /// If you need to contact Oracle about a particular request, please provide the request ID.
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// The response body will contain a single Zone resource.
        /// </summary>
        public ZoneDetails Zone { get; set; }
    }
}

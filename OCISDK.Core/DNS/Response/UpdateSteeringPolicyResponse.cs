using OCISDK.Core.DNS.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.DNS.Response
{
    /// <summary>
    /// UpdateSteeringPolicy Response
    /// </summary>
    public class UpdateSteeringPolicyResponse
    {
        /// <summary>
        /// Unique Oracle-assigned identifier for the request. 
        /// If you need to contact Oracle about a particular request, please provide the request ID.
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// The current version of the zone, ending with a representation-specific suffix. 
        /// This value may be used in If-Match and If-None-Match headers for later requests of the same resource.
        /// </summary>
        public string ETag { get; set; }

        /// <summary>
        /// The response body will contain a single SteeringPolicy resource.
        /// </summary>
        public SteeringPolicyDetails SteeringPolicy { get; set; }
    }
}

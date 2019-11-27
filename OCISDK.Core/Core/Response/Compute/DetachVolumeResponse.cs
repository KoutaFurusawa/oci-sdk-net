using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Response.Compute
{
    /// <summary>
    /// DetachVolume Response
    /// </summary>
    public class DetachVolumeResponse
    {
        /// <summary>
        /// Unique Oracle-assigned identifier for the request. 
        /// If you need to contact Oracle about a particular request, 
        /// please provide the request ID.
        /// </summary>
        public string OpcRequestId { get; set; }
    }
}

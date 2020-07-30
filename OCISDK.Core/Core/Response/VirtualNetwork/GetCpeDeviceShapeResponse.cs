using OCISDK.Core.Core.Model.VirtualNetwork;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Response.VirtualNetwork
{
    /// <summary>
    /// GetCpeDeviceShape response
    /// </summary>
    public class GetCpeDeviceShapeResponse
    {
        /// <summary>
        /// Unique Oracle-assigned identifier for the request. 
        /// If you need to contact Oracle about a particular request, please provide the request ID.
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// The response body will contain a single CpeDeviceShapeDetail resource.
        /// </summary>
        public CpeDeviceShapeDetail CpeDeviceShapeDetail { get; set; }
    }
}

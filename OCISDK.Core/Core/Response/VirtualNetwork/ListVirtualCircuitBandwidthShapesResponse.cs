﻿using OCISDK.Core.Core.Model.VirtualNetwork;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Response.VirtualNetwork
{
    /// <summary>
    /// ListVirtualCircuitBandwidthShapes response
    /// </summary>
    public class ListVirtualCircuitBandwidthShapesResponse
    {
        /// <summary>
        /// Unique Oracle-assigned identifier for the request.
        /// If you need to contact Oracle about a particular request,
        /// please provide the request ID.
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// For list pagination.
        /// When this header appears in the response, additional pages of results remain.
        /// For important details about how pagination works
        /// </summary>
        public string OpcNextPage { get; set; }

        /// <summary>
        /// The response body will contain an array of VirtualCircuitBandwidthShape resources.
        /// </summary>
        public List<VirtualCircuitBandwidthShape> Items { get; set; }
    }
}

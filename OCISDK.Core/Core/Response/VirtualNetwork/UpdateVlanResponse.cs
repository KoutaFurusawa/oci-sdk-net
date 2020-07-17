﻿using OCISDK.Core.Core.Model.VirtualNetwork;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Response.VirtualNetwork
{
    /// <summary>
    /// UpdateVlan response
    /// </summary>
    public class UpdateVlanResponse
    {
        /// <summary>
        /// For optimistic concurrency control.See if-match.
        /// </summary>
        public string ETag { get; set; }

        /// <summary>
        /// Unique Oracle-assigned identifier for the request. If you need to contact 
        /// Oracle about a particular request, please provide the request ID.
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// The response body will contain a single Vlan resource.
        /// </summary>
        public VlanDetails Vlan { get; set; }
    }
}
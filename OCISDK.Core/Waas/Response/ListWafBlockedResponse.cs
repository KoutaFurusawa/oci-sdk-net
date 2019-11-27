﻿using System;
using System.Collections.Generic;
using System.Text;
using OCISDK.Core.Waas.Model;

namespace OCISDK.Core.Waas.Response
{
    /// <summary>
    /// ListWafBlockedRequests Response
    /// </summary>
    public class ListWafBlockedRequestsResponse
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
        /// The response body will contain an array of WafBlockedRequest resources.
        /// </summary>
        public List<WafBlockedRequest> Items { get; set; }
    }
}

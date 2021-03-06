﻿using OCISDK.Core.SupportManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.SupportManagement.Response
{
    /// <summary>
    /// ListIncidentResourceTypes response
    /// </summary>
    public class ListIncidentResourceTypesResponse
    {
        /// <summary>
        /// The entity tag that allows optimistic concurrency control. For more information, see REST APIs.
        /// </summary>
        public string ETag { get; set; }

        /// <summary>
        /// For list pagination. When this header appears in the response, additional pages of results remain.
        /// For important details about how pagination works, see List Pagination.
        /// </summary>
        public string OpcNextPage { get; set; }

        /// <summary>
        /// Unique Oracle-assigned identifier for the request.
        /// If you need to contact Oracle about a particular request, please provide the request ID.
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// The response body will contain an array of IncidentResourceType resources.
        /// </summary>
        public List<IncidentResourceType> Items { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;
using OCISDK.Core.NoSQL.Model;

namespace OCISDK.Core.NoSQL.Response
{
    /// <summary>
    /// ListIndexes response
    /// </summary>
    public class ListIndexesResponse
    {
        /// <summary>
        /// For pagination of a list of items. When paging through a list, if this header appears in the response, 
        /// then a partial list might have been returned. Include this value as the page parameter for the subsequent 
        /// GET request to get the next batch of items.
        /// </summary>
        public string OpcNextPage { get; set; }

        /// <summary>
        /// Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// The response body will contain a single IndexCollection resource.
        /// </summary>
        public IndexCollection IndexCollection { get; set; }
    }
}

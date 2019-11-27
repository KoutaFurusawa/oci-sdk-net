using OCISDK.Core.Search.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Search.Request
{
    /// <summary>
    /// SearchResources Request
    /// </summary>
    public class SearchResourcesRequest
    {
        /// <summary>
        /// The maximum number of items to return. The value must be between 1 and 1000.
        /// <para>Required: no</para>
        /// </summary>
        public int? Limit { get; set; }

        /// <summary>
        /// The page at which to start retrieving results.
        /// <para>Required: yes</para>
        /// </summary>
        public string Page { get; set; }

        /// <summary>
        /// The unique Oracle-assigned identifier for the request.
        /// If you need to contact Oracle about a particular request, please provide the complete request ID.
        /// <para>Required: no</para>
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// The request body must contain a single SearchDetails resource.
        /// </summary>
        public SearchDetails SearchDetails { get; set; }
    }
}

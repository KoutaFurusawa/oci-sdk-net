using OCISDK.Core.Identity.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Identity.Response
{
    /// <summary>
    /// ListIdentityProviders response
    /// </summary>
    public class ListIdentityProvidersResponse
    {
        /// <summary>
        /// Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// For pagination of a list of items. When paging through a list, 
        /// if this header appears in the response, 
        /// then a partial list might have been returned. 
        /// Include this value as the page parameter for the subsequent GET request to get the next batch of items.
        /// </summary>
        public string OpcNextPage { get; set; }

        /// <summary>
        /// The response body will contain an array of IdentityProvider resources.
        /// </summary>
        public List<IdentityProvider> Items { get; set; }
    }
}

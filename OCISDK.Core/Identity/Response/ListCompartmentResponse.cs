using OCISDK.Core.Identity.Model;
using System.Collections.Generic;

namespace OCISDK.Core.Identity.Response
{
    /// <summary>
    /// ListCompartment Response
    /// </summary>

    public class ListCompartmentResponse
    {
        /// <summary>
        /// response header parameter opcRequestId
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
        /// single Compartment resource.
        /// </summary>
        public List<Compartment> Items { get; set; } 
    }
}

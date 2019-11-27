using OCISDK.Core.Database.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace OCISDK.Core.Database.Response
{
    /// <summary>
    /// ListDbSystemShapes Response
    /// </summary>
    public class ListDbSystemShapesResponse
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
        /// The response body will contain an array of DbSystemShapeSummary resources.
        /// </summary>
        public List<DbSystemShapeSummary> Items { get; set; }
    }
}
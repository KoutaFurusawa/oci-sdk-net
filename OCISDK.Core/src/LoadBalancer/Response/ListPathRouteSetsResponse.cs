using OCISDK.Core.src.LoadBalancer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.src.LoadBalancer.Response
{
    /// <summary>
    /// ListPathRouteSets Response
    /// </summary>
    public class ListPathRouteSetsResponse
    {/// <summary>
     /// Unique Oracle-assigned identifier for the request. 
     /// If you need to contact Oracle about a particular request, please provide the request ID.
     /// </summary>
        public string OpcRequestId { get; set; }

        public List<PathRouteSetDetails> Items { get; set; }
    }
}

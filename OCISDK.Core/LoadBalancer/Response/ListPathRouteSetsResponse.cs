using OCISDK.Core.LoadBalancer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.LoadBalancer.Response
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

        /// <summary>
        /// arrary PathRouteSetDetails
        /// </summary>
        public List<PathRouteSetDetails> Items { get; set; }
    }
}

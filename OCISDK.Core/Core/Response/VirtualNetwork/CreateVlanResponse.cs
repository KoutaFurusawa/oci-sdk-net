using OCISDK.Core.Core.Model.VirtualNetwork;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Response.VirtualNetwork
{
    /// <summary>
    /// CreateVlan response
    /// </summary>
    public class CreateVlanResponse
    {
        /// <summary>
        /// response header parameter ETag
        /// </summary>
        public string ETag { get; set; }

        /// <summary>
        /// response header parameter opcRequestId
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// The response body will contain a single Vlan resource.
        /// </summary>
        public VlanDetails Vlan { get; set; }
    }
}

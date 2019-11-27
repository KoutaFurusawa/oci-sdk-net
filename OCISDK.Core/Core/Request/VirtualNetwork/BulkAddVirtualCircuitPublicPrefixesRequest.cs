using OCISDK.Core.Core.Model.VirtualNetwork;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Request.VirtualNetwork
{
    /// <summary>
    /// BulkAddVirtualCircuitPublicPrefixes request
    /// </summary>
    public class BulkAddVirtualCircuitPublicPrefixesRequest
    {
        /// <summary>
        /// The OCID of the virtual circuit.
        /// <para>Required: yes</para>
        /// </summary>
        public string VirtualCircuitId { get; set; }

        /// <summary>
        /// The request body must contain a single BulkAddVirtualCircuitPublicPrefixesDetails resource.
        /// </summary>
        public BulkAddVirtualCircuitPublicPrefixesDetails BulkAddVirtualCircuitPublicPrefixesDetails { get; set; }
    }
}

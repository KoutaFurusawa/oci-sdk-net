using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Model.VirtualNetwork
{
    /// <summary>
    /// BulkDeleteVirtualCircuitPublicPrefixesDetails
    /// </summary>
    public class BulkDeleteVirtualCircuitPublicPrefixesDetails
    {
        /// <summary>
        /// 
        /// </summary>
        public List<DeleteVirtualCircuitPublicPrefixDetails> PublicPrefixes { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Model.VirtualNetwork
{
    /// <summary>
    /// BulkAddVirtualCircuitPublicPrefixesDetails
    /// </summary>
    public class BulkAddVirtualCircuitPublicPrefixesDetails
    {
        /// <summary>
        /// The public IP prefixes (CIDRs) to add to the public virtual circuit.
        /// <para>Required: yes</para>
        /// <para>Minimum: 0, Maximum: 50</para>
        /// /// </summary>
        public List<CreateVirtualCircuitPublicPrefixDetails> PublicPrefixes { get; set; }
    }
}

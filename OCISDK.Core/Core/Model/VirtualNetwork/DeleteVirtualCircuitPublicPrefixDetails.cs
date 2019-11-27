using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Model.VirtualNetwork
{
    /// <summary>
    /// DeleteVirtualCircuitPublicPrefixDetails
    /// </summary>
    public class DeleteVirtualCircuitPublicPrefixDetails
    {
        /// <summary>
        /// An individual public IP prefix (CIDR) to remove from the public virtual circuit.
        /// <para>Required: yes</para>
        /// <para>Minimum: 0, Maximum: 50</para>
        /// /// </summary>
        public List<CreateVirtualCircuitPublicPrefixDetails> PublicPrefixes { get; set; }
    }
}

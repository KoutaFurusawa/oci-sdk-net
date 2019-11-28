using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Model.VirtualNetwork
{
    /// <summary>
    /// CreateVirtualCircuitPublicPrefixDetails
    /// </summary>
    public class CreateVirtualCircuitPublicPrefixDetails
    {
        /// <summary>
        /// An individual public IP prefix (CIDR) to add to the public virtual circuit. Must be /31 or less specific.
        /// <para>Required: yes</para>
        /// <para>Min Length: 9, Max Length: 50</para>
        /// </summary>
        public string CidrBlock { get; set; }
    }
}

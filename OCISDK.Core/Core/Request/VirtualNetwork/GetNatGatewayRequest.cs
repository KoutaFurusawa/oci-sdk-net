using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Request.VirtualNetwork
{
    /// <summary>
    /// GetNatGateway request
    /// </summary>
    public class GetNatGatewayRequest
    {
        /// <summary>
        /// The NAT gateway's OCID.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string NatGatewayId { get; set; }
    }
}

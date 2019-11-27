﻿using OCISDK.Core.Core.Model.VirtualNetwork;

namespace OCISDK.Core.Core.Request.VirtualNetwork
{
    /// <summary>
    /// UpdateInternetGateway Request
    /// </summary>
    public class UpdateInternetGatewayRequest
    {
        /// <summary>
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string IgId { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// <para>if-match header parameter</para>
        /// </summary>
        public string IfMatch { get; set; }

        /// <summary>
        /// The request body must contain a single UpdateInternetGatewayDetails resource.
        /// </summary>
        public UpdateInternetGatewayDetails UpdateInternetGatewayDetails { get; set; }
    }
}

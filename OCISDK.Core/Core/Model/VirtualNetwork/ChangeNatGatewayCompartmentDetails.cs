﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Model.VirtualNetwork
{
    /// <summary>
    /// The configuration details for the move operation.
    /// </summary>
    public class ChangeNatGatewayCompartmentDetails
    {
        /// <summary>
        /// The OCID of the compartment to move the NAT gateway to.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string CompartmentId { get; set; }
    }
}

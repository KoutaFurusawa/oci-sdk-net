﻿namespace OCISDK.Core.Core.Model.VirtualNetwork
{
    /// <summary>
    /// Optional object to specify ports for a TCP rule.
    /// If you specify TCP as the protocol but omit this object, then all ports are allowed.
    /// </summary>
    public class TcpOption
    {
        /// <summary>
        /// An inclusive range of allowed destination ports. Use the same number for the min and max to indicate a single port. Defaults to all ports if not specified.
        /// <para>Required: no</para>
        /// </summary>
        public PortRange DestinationPortRange { get; set; }

        /// <summary>
        /// An inclusive range of allowed source ports. Use the same number for the min and max to indicate a single port. Defaults to all ports if not specified.
        /// <para>Required: no</para>
        /// </summary>
        public PortRange SourcePortRange { get; set; }
    }
}

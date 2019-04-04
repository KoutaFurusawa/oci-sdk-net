﻿/// <summary>
/// UdpOption Reference
/// 
/// author: koutaro furusawa
/// </summary>


namespace OCISDK.Core.src.Core.Model.VirtualNetwork
{
    /// <summary>
    /// Optional object to specify ports for a UDP rule.
    /// If you specify UDP as the protocol but omit this object, then all ports are allowed.
    /// </summary>
    public class UdpOption
    {
        public virtual PortRange DestinationPortRange { get; set; }
        
        public virtual PortRange SourcePortRange { get; set; }
    }
}

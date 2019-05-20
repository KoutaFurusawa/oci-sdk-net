/// <summary>
/// EgressSecurityRule Reference
/// 
/// author: koutaro furusawa
/// </summary>


namespace OCISDK.Core.src.Core.Model.VirtualNetwork
{
    /// <summary>
    /// A rule for allowing outbound IP packets.
    /// </summary>
    public class EgressSecurityRule
    {
        public string Destination { get; set; }
        
        public string DestinationType { get; set; }
        
        public IcmpOption IcmpOptions { get; set; }
        
        public bool IsStateless { get; set; }
        
        public string Protocol { get; set; }
        
        public TcpOption TcpOptions { get; set; }
        
        public UdpOption UdpOptions { get; set; }
    }
}

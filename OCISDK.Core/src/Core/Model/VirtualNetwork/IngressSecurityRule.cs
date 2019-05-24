/// <summary>
/// IngressSecurityRule Reference
/// 
/// author: koutaro furusawa
/// </summary>


namespace OCISDK.Core.src.Core.Model.VirtualNetwork
{
    /// <summary>
    /// A rule for allowing inbound IP packets.
    /// </summary>
    public class IngressSecurityRule
    {
        public IcmpOption IcmpOptions { get; set; }
        
        public bool? IsStateless { get; set; }
        
        public string Protocol { get; set; }
        
        public string Source { get; set; }
        
        public string SourceType { get; set; }
        
        public TcpOption TcpOptions { get; set; }
        
        public UdpOption UdpOptions { get; set; }
    }
}

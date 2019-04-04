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
        public virtual string Destination { get; set; }
        
        public virtual string DestinationType { get; set; }
        
        public virtual IcmpOption IcmpOptions { get; set; }
        
        public virtual bool IsStateless { get; set; }
        
        public virtual string Protocol { get; set; }
        
        public virtual TcpOption TcpOptions { get; set; }
        
        public virtual UdpOption UdpOptions { get; set; }
    }
}

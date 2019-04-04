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
        public virtual IcmpOption IcmpOptions { get; set; }
        
        public virtual bool IsStateless { get; set; }
        
        public virtual string Protocol { get; set; }
        
        public virtual string Source { get; set; }
        
        public virtual string SourceType { get; set; }
        
        public virtual TcpOption TcpOptions { get; set; }
        
        public virtual UdpOption UdpOptions { get; set; }
    }
}

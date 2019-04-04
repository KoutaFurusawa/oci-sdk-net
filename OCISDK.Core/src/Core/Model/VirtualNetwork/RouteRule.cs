/// <summary>
/// RouteRule Reference
/// 
/// author: koutaro furusawa
/// </summary>



namespace OCISDK.Core.src.Core.Model.VirtualNetwork
{
    /// <summary>
    /// A mapping between a destination IP address range and a virtual device to route matching packets to (a target).
    /// </summary>
    public class RouteRule
    {
        public string CidrBlock { get; set; }
        
        public string Destination { get; set; }
        
        public string DestinationType { get; set; }
        
        public string NetworkEntityId { get; set; }
    }
}

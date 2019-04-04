/// <summary>
/// Vcn Reference
/// A virtual cloud network (VCN). For more information, see Overview of the Networking Service.
/// 
/// Warning: Oracle recommends that you avoid using any confidential information when you supply string values using the API.
/// 
/// author: koutaro furusawa
/// </summary>
using System.Collections.Generic;


namespace OCISDK.Core.src.Core.Model.VirtualNetwork
{
    /// <summary>
    /// A virtual cloud network (VCN). For more information, see
    /// [Overview of the Networking Service](https://docs.us-phoenix-1.oraclecloud.com/Content/Network/Concepts/overview.htm).
    /// </summary>
    public class Vcn
    {
        public string Id { get; set; }
        
        public string CidrBlock { get; set; }
        
        public string CompartmentId { get; set; }
        
        public string DefaultDhcpOptionsId { get; set; }
        
        public string DefaultRouteTableId { get; set; }
        
        public string DefaultSecurityListId { get; set; }
        
        public string DisplayName { get; set; }
        
        public string DnsLabel { get; set; }
        
        public string LifecycleState { get; set; }
        
        public string TimeCreated { get; set; }
        
        public string VcnDomainName { get; set; }
        
        public IDictionary<string, string> FreeformTags { get; set; }
        
        public IDictionary<string, IDictionary<string, string>> DefinedTags { get; set; }
    }
}

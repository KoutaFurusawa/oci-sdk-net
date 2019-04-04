/// <summary>
/// DhcpOptions Reference
/// A set of DHCP options. Used by the VCN to automatically provide configuration 
/// information to the instances when they boot up. There are two options you can set:
/// 
/// * DhcpDnsOption: Lets you specify how DNS (hostname resolution) is handled in the subnets in your VCN.
/// * DhcpSearchDomainOption: Lets you specify a search domain name to use for DNS queries.
/// 
/// For more information, see DNS in Your Virtual Cloud Network and DHCP Options.
/// 
/// Warning: Oracle recommends that you avoid using any confidential information when you supply string values using the API.
/// 
/// author: koutaro furusawa
/// </summary>

using System.Collections.Generic;


namespace OCISDK.Core.src.Core.Model.VirtualNetwork
{
    public class DhcpOptions
    {
        public string Id { get; set; }
        
        public string CompartmentId { get; set; }
        
        public string VcnId { get; set; }
        
        public string DisplayName { get; set; }
        
        public string LifecycleState { get; set; }
        
        public string TimeCreated { get; set; }
        
        public List<DhcpOption> Options { get; set; }
        
        public IDictionary<string, string> FreeformTags { get; set; }
        
        public IDictionary<string, IDictionary<string, string>> DefinedTags { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.LoadBalancer.Model
{
    /// <summary>
    /// An object representing an updated list of network security groups (NSGs) that overwrites the existing list of NSGs.
    /// 
    /// * If the load balancer has no NSGs configured, it uses the NSGs in this list.
    /// * If the load balancer has a list of NSGs configured, this list replaces the existing list
    /// * If the load balancer has a list of NSGs configured and this list is empty, the operation removes all of the load balancer's NSG associations.
    /// </summary>
    public class UpdateNetworkSecurityGroupsDetails
    {
        /// <summary>
        /// An array of NSG OCIDs associated with the load balancer.
        /// 
        /// During the load balancer's creation, the service adds the new load balancer to the specified NSGs.
        /// 
        /// The benefits of associating the load balancer with NSGs include:
        /// * NSGs define network security rules to govern ingress and egress traffic for the load balancer.
        /// * The network security rules of other resources can reference the NSGs associated with the load balancer to ensure access. The OCID of an NSG associated with the load balancer.
        /// </summary>
        public List<string> NetworkSecurityGroupIds { get; set; }
    }
}

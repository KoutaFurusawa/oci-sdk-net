using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.LoadBalancer.Model
{
    /// <summary>
    /// The configuration details for creating a load balancer.
    /// 
    /// Warning: Oracle recommends that you avoid using any confidential information when you supply string values using the API.
    /// </summary>
    public class CreateLoadBalancerDetails
    {
        /// <summary>
        /// The OCID of the compartment containing the load balancer.
        /// <para>Required: yes</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// A user-friendly name. It does not have to be unique, and it is changeable.
        /// <para>Required: yes</para>
        /// </summary>
        public string DisplayName { get; set; }
        
        /// <summary>
        /// A template that determines the total pre-provisioned bandwidth (ingress plus egress). 
        /// To get a list of available shapes, use the ListShapes operation.
        /// <para>Required: yes</para>
        /// </summary>
        public string ShapeName { get; set; }

        /// <summary>
        /// Whether the load balancer has a VCN-local (private) IP address.
        /// 
        /// If "true", the service assigns a private IP address to the load balancer.
        /// 
        /// If "false", the service assigns a public IP address to the load balancer.
        /// 
        /// A public load balancer is accessible from the internet, depending on your VCN's security list rules.
        /// For more information about public and private load balancers, see How Load Balancing Works.
        /// <para>Required: no</para>
        /// </summary>
        public bool? IsPrivate { get; set; }

        /// <summary>
        /// A mapping of strings to Listener objects.
        /// <para>Required: no</para>
        /// </summary>
        public object Listeners { get; set; }

        /// <summary>
        /// A mapping of strings to Hostname objects.
        /// <para>Required: no</para>
        /// </summary>
        public object Hostnames { get; set; }

        /// <summary>
        /// A mapping of strings to BackendSet objects.
        /// <para>Required: no</para>
        /// </summary>
        public object BackendSets { get; set; }

        /// <summary>
        /// An array of NSG OCIDs associated with the load balancer.
        /// 
        /// During the load balancer's creation, the service adds the new load balancer to the specified NSGs.
        /// <para>Required: no</para>
        /// </summary>
        public List<string> NetworkSecurityGroupIds { get; set; }

        /// <summary>
        /// An array of subnet OCIDs.
        /// <para>Required: yes</para>
        /// </summary>
        public List<string> SubnetIds { get; set; }

        /// <summary>
        /// A mapping of strings to Certificate objects.
        /// <para>Required: no</para>
        /// </summary>
        public object Certificates { get; set; }

        /// <summary>
        /// A mapping of strings to PathRouteSet objects.
        /// <para>Required: no</para>
        /// </summary>
        public object PathRouteSets { get; set; }
        
        /// <summary>
        /// A mapping of strings to RuleSet objects.
        /// <para>Required: no</para>
        /// </summary>
        public object RuleSets { get; set; }

        /// <summary>
        /// Free-form tags for this resource. Each tag is a simple key-value pair with no predefined name, type, or namespace. 
        /// For more information, see Resource Tags.
        /// <para>Required: no</para>
        /// </summary>
        public IDictionary<string, string> FreeformTags { get; set; }

        /// <summary>
        /// Defined tags for this resource. Each key is predefined and scoped to a namespace. 
        /// For more information, see Resource Tags.
        /// <para>Required: no</para>
        /// </summary>
        public IDictionary<string, IDictionary<string, string>> DefinedTags { get; set; }
    }
}

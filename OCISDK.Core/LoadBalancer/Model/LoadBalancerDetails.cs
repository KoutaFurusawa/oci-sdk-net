using OCISDK.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.LoadBalancer.Model
{
    /// <summary>
    /// The properties that define a load balancer. For more information, see Managing a Load Balancer.
    /// 
    /// To use any of the API operations, you must be authorized in an IAM policy. If you're not authorized, talk to an administrator. 
    /// If you're an administrator who needs to write policies to give users access, see Getting Started with Policies.
    /// 
    /// For information about endpoints and signing API requests, see About the API. 
    /// For information about available SDKs and tools, see SDKS and Other Tools.
    /// </summary>
    public class LoadBalancerDetails
    {
        /// <summary>
        /// The OCID of the load balancer.
        /// <para>Required: yes</para>
        /// </summary>
        public string Id { get; set; }

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
        /// The current state of the load balancer.
        /// <para>Required: yes</para>
        /// </summary>
        public string LifecycleState { get; set; }

        /// <summary>
        /// The date and time the load balancer was created, in the format defined by RFC3339.
        /// <para>Required: yes</para>
        /// </summary>
        public string TimeCreated { get; set; }

        /// <summary>
        /// An array of IP addresses.
        /// <para>Required: no</para>
        /// </summary>
        public List<IpAddressDetails> IpAddresses { get; set; }

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
        /// An array of subnet OCIDs.
        /// <para>Required: no</para>
        /// </summary>
        public List<string> SubnetIds { get; set; }

        /// <summary>
        /// An array of NSG OCIDs associated with the load balancer.
        /// 
        /// During the load balancer's creation, the service adds the new load balancer to the specified NSGs.
        /// <para>Required: no</para>
        /// </summary>
        public List<string> NetworkSecurityGroupIds { get; set; }

        /// <summary>
        /// A mapping of strings to Listener objects.
        /// <para>Required: no</para>
        /// </summary>
        public Dictionary<string, ListenerDetails> Listeners { get; set; }

        /// <summary>
        /// A mapping of strings to Hostname objects.
        /// <para>Required: no</para>
        /// </summary>
        public Dictionary<string, HostnameDetails> Hostnames { get; set; }

        /// <summary>
        /// A mapping of strings to Certificate objects.
        /// <para>Required: no</para>
        /// </summary>
        public Dictionary<string, CertificateDetails> Certificates { get; set; }

        /// <summary>
        /// A mapping of strings to BackendSet objects.
        /// <para>Required: no</para>
        /// </summary>
        public Dictionary<string, BackendSetDetails> BackendSets { get; set; }

        /// <summary>
        /// A mapping of strings to PathRouteSet objects.
        /// <para>Required: no</para>
        /// </summary>
        public Dictionary<string, PathRouteSetDetails> PathRouteSets { get; set; }

        /// <summary>
        /// A mapping of strings to RuleSet objects.
        /// <para>Required: no</para>
        /// </summary>
        public Dictionary<string, RuleSetDetails> RuleSets { get; set; }

        /// <summary>
        /// System tags for this resource. Each key is predefined and scoped to a namespace. 
        /// For more information, see Resource Tags. System tags can be viewed by users, but can only be created by the system.
        /// <para>Required: no</para>
        /// </summary>
        public IDictionary<string, IDictionary<string, string>> SystemTags { get; set; }

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

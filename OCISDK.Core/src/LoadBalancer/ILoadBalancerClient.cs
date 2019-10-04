using OCISDK.Core.src.LoadBalancer.Request;
using OCISDK.Core.src.LoadBalancer.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.src.LoadBalancer
{
    /// <summary>
    /// LoadBalancer Client interface
    /// </summary>
    public interface ILoadBalancerClient
    {
        /// <summary>
        /// Lists all load balancers in the specified compartment.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ListLoadBalancersResponse ListLoadBalancers(ListLoadBalancersRequest request);

        /// <summary>
        /// Gets the specified load balancer's configuration information.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        GetLoadBalancerResponse GetLoadBalancer(GetLoadBalancerRequest request);

        /// <summary>
        /// Creates a new load balancer in the specified compartment. 
        /// For general information about load balancers, see Overview of the Load Balancing Service.
        /// 
        /// For the purposes of access control, you must provide the OCID of the compartment where you want 
        /// the load balancer to reside. Notice that the load balancer doesn't have to be in the same compartment 
        /// as the VCN or backend set. If you're not sure which compartment to use, put the load balancer in 
        /// the same compartment as the VCN. 
        /// For information about access control and compartments, see Overview of the IAM Service.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        CreateLoadBalancerResponse CreateLoadBalancer(CreateLoadBalancerRequest request);

        /// <summary>
        /// Updates a load balancer's configuration.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        UpdateLoadBalancerResponse UpdateLoadBalancer(UpdateLoadBalancerRequest request);

        /// <summary>
        /// Stops a load balancer and removes it from service.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        DeleteLoadBalancerResponse DeleteLoadBalancer(DeleteLoadBalancerRequest request);
    }
}

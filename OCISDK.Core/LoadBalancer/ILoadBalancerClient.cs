using OCISDK.Core.LoadBalancer.Request;
using OCISDK.Core.LoadBalancer.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.LoadBalancer
{
    /// <summary>
    /// LoadBalancer Client interface
    /// </summary>
    public interface ILoadBalancerClient : IClientSetting
    {
        /// <summary>
        /// Lists the backend servers for a given load balancer and backend set.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ListBackendsResponse ListBackends(ListBackendsRequest request);

        /// <summary>
        /// Lists all backend sets associated with a given load balancer.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ListBackendSetsResponse ListBackendSets(ListBackendSetsRequest request);

        /// <summary>
        /// Lists all SSL certificates bundles associated with a given load balancer.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ListCertificatesResponse ListCertificates(ListCertificatesRequest request);

        /// <summary>
        /// Lists all hostname resources associated with the specified load balancer.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ListHostnamesResponse ListHostnames(ListHostnamesRequest request);

        /// <summary>
        /// Lists all of the rules from all of the rule sets associated with the specified listener.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ListListenerRulesResponse ListListenerRules(ListListenerRulesRequest request);

        /// <summary>
        /// Lists all load balancers in the specified compartment.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ListLoadBalancersResponse ListLoadBalancers(ListLoadBalancersRequest request);

        /// <summary>
        /// Lists the summary health statuses for all load balancers in the specified compartment.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ListLoadBalancerHealthsResponse ListLoadBalancerHealths(ListLoadBalancerHealthsRequest request);

        /// <summary>
        /// Lists the available load balancer policies.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ListLoadBalancerPoliciesResponse ListLoadBalancerPolicies(ListLoadBalancerPoliciesRequest request);

        /// <summary>
        /// Lists all supported traffic protocols.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ListLoadBalancerProtocolsResponse ListLoadBalancerProtocols(ListLoadBalancerProtocolsRequest request);

        /// <summary>
        /// Gets the health status for the specified load balancer.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ListLoadBalancerShapesResponse ListLoadBalancerShapes(ListLoadBalancerShapesRequest request);

        /// <summary>
        /// Lists all path route sets associated with the specified load balancer.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ListPathRouteSetsResponse ListPathRouteSets(ListPathRouteSetsRequest request);

        /// <summary>
        /// Lists all rule sets associated with the specified load balancer.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ListRuleSetsResponse ListRuleSets(ListRuleSetsRequest request);

        /// <summary>
        /// Lists the work requests for a given load balancer.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ListWorkRequestsResponse ListWorkRequests(ListWorkRequestsRequest request);

        /// <summary>
        /// Gets the specified backend server's configuration information.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        GetBackendResponse GetBackend(GetBackendRequest request);

        /// <summary>
        /// Gets the specified backend set's configuration information.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        GetBackendSetResponse GetBackendSet(GetBackendSetRequest request);

        /// <summary>
        /// Gets the health status for the specified backend set.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        GetBackendSetHealthResponse GetBackendSetHealth(GetBackendSetHealthRequest request);

        /// <summary>
        /// Gets the current health status of the specified backend server.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        GetBackendHealthResponse GetBackendHealth(GetBackendHealthRequest request);

        /// <summary>
        /// Gets the health check policy information for a given load balancer and backend set.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        GetHealthCheckerResponse GetHealthChecker(GetHealthCheckerRequest request);

        /// <summary>
        /// Gets the specified hostname resource's configuration information.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        GetHostnameResponse GetHostname(GetHostnameRequest request);

        /// <summary>
        /// Gets the specified load balancer's configuration information.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        GetLoadBalancerResponse GetLoadBalancer(GetLoadBalancerRequest request);

        /// <summary>
        /// Gets the health status for the specified load balancer.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        GetLoadBalancerHealthResponse GetLoadBalancerHealth(GetLoadBalancerHealthRequest request);

        /// <summary>
        /// Gets the details of a work request.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        GetWorkRequestResponse GetWorkRequest(GetWorkRequestRequest request);

        /// <summary>
        /// Adds a backend server to a backend set.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        CreateBackendResponse CreateBackend(CreateBackendRequest request);

        /// <summary>
        /// Gets the specified path route set's configuration information.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        GetPathRouteSetResponse GetPathRouteSet(GetPathRouteSetRequest request);

        /// <summary>
        /// Gets the specified set of rules.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        GetRuleSetResponse GetRuleSet(GetRuleSetRequest request);

        /// <summary>
        /// Adds a backend set to a load balancer.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        CreateBackendSetResponse CreateBackendSet(CreateBackendSetRequest request);

        /// <summary>
        /// Creates an asynchronous request to add an SSL certificate bundle.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        CreateCertificateResponse CreateCertificate(CreateCertificateRequest request);

        /// <summary>
        /// Adds a hostname resource to the specified load balancer. For more information, see Managing Request Routing.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        CreateHostnameResponse CreateHostname(CreateHostnameRequest request);

        /// <summary>
        /// Adds a listener to a load balancer.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        CreateListenerResponse CreateListener(CreateListenerRequest request);

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
        /// Adds a path route set to a load balancer. For more information, see Managing Request Routing.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        CreatePathRouteSetResponse CreatePathRouteSet(CreatePathRouteSetRequest request);

        /// <summary>
        /// Creates a new rule set associated with the specified load balancer. For more information, see Managing Rule Sets.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        CreateRuleSetResponse CreateRuleSet(CreateRuleSetRequest request);

        /// <summary>
        /// Updates the configuration of a backend server within the specified backend set.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        UpdateBackendResponse UpdateBackend(UpdateBackendRequest request);

        /// <summary>
        /// Updates a backend set.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        UpdateBackendSetResponse UpdateBackendSet(UpdateBackendSetRequest request);

        /// <summary>
        /// Updates the health check policy for a given load balancer and backend set.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        UpdateHealthCheckerResponse UpdateHealthChecker(UpdateHealthCheckerRequest request);

        /// <summary>
        /// Overwrites an existing hostname resource on the specified load balancer. Use this operation to change a virtual hostname.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        UpdateHostnameResponse UpdateHostname(UpdateHostnameRequest request);

        /// <summary>
        /// Updates a listener for a given load balancer.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        UpdateListenerResponse UpdateListener(UpdateListenerRequest request);

        /// <summary>
        /// Updates a load balancer's configuration.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        UpdateLoadBalancerResponse UpdateLoadBalancer(UpdateLoadBalancerRequest request);

        /// <summary>
        /// Updates the network security groups associated with the specified load balancer.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        UpdateNetworkSecurityGroupsResponse UpdateNetworkSecurityGroups(UpdateNetworkSecurityGroupsRequest request);

        /// <summary>
        /// Overwrites an existing path route set on the specified load balancer. Use this operation to add, delete, or alter path route rules in a path route set.
        /// 
        /// To add a new path route rule to a path route set, the pathRoutes in the UpdatePathRouteSetDetails object must include both the new path route rule to 
        /// add and the existing path route rules to retain.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        UpdatePathRouteSetResponse UpdatePathRouteSet(UpdatePathRouteSetRequest request);

        /// <summary>
        /// Overwrites an existing set of rules on the specified load balancer. Use this operation to add or alter the rules in a rule set.
        /// 
        /// To add a new rule to a set, the body must include both the new rule to add and the existing rules to retain.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        UpdateRuleSetResponse UpdateRuleSet(UpdateRuleSetRequest request);

        /// <summary>
        /// Moves a load balancer into a different compartment within the same tenancy.
        /// For information about moving resources between compartments, see Moving Resources to a Different Compartment.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ChangeLoadBalancerCompartmentResponse ChangeLoadBalancerCompartment(ChangeLoadBalancerCompartmentRequest request);

        /// <summary>
        /// Removes a backend server from a given load balancer and backend set.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        DeleteBackendResponse DeleteBackend(DeleteBackendRequest request);

        /// <summary>
        /// Deletes the specified backend set. Note that deleting a backend set removes its backend servers from the load balancer.
        /// 
        /// Before you can delete a backend set, you must remove it from any active listeners.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        DeleteBackendSetResponse DeleteBackendSet(DeleteBackendSetRequest request);

        /// <summary>
        /// Deletes an SSL certificate bundle from a load balancer.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        DeleteCertificateResponse DeleteCertificate(DeleteCertificateRequest request);

        /// <summary>
        /// Deletes a hostname resource from the specified load balancer.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        DeleteHostnameResponse DeleteHostname(DeleteHostnameRequest request);

        /// <summary>
        /// Deletes a listener from a load balancer.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        DeleteListenerResponse DeleteListener(DeleteListenerRequest request);

        /// <summary>
        /// Stops a load balancer and removes it from service.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        DeleteLoadBalancerResponse DeleteLoadBalancer(DeleteLoadBalancerRequest request);

        /// <summary>
        /// Deletes a path route set from the specified load balancer.
        /// 
        /// To delete a path route rule from a path route set, use the UpdatePathRouteSet operation.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        DeletePathRouteSetResponse DeletePathRouteSet(DeletePathRouteSetRequest request);

        /// <summary>
        /// Deletes a rule set from the specified load balancer.
        /// To delete a rule from a rule set, use the UpdateRuleSet operation.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        DeleteRuleSetResponse DeleteRuleSet(DeleteRuleSetRequest request);
    }
}

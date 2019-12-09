using OCISDK.Core.LoadBalancer.Request;
using OCISDK.Core.LoadBalancer.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OCISDK.Core.LoadBalancer
{
    /// <summary>
    /// LoadBalancer Client interface
    /// </summary>
    public interface ILoadBalancerClientAsync : IClientSetting
    {
        /// <summary>
        /// Lists the backend servers for a given load balancer and backend set.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ListBackendsResponse> ListBackends(ListBackendsRequest request);

        /// <summary>
        /// Lists all backend sets associated with a given load balancer.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ListBackendSetsResponse> ListBackendSets(ListBackendSetsRequest request);

        /// <summary>
        /// Lists all SSL certificates bundles associated with a given load balancer.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ListCertificatesResponse> ListCertificates(ListCertificatesRequest request);

        /// <summary>
        /// Lists all hostname resources associated with the specified load balancer.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ListHostnamesResponse> ListHostnames(ListHostnamesRequest request);

        /// <summary>
        /// Lists all of the rules from all of the rule sets associated with the specified listener.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ListListenerRulesResponse> ListListenerRules(ListListenerRulesRequest request);

        /// <summary>
        /// Lists all load balancers in the specified compartment.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ListLoadBalancersResponse> ListLoadBalancers(ListLoadBalancersRequest request);

        /// <summary>
        /// Lists the summary health statuses for all load balancers in the specified compartment.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ListLoadBalancerHealthsResponse> ListLoadBalancerHealths(ListLoadBalancerHealthsRequest request);

        /// <summary>
        /// Lists the available load balancer policies.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ListLoadBalancerPoliciesResponse> ListLoadBalancerPolicies(ListLoadBalancerPoliciesRequest request);

        /// <summary>
        /// Lists all supported traffic protocols.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ListLoadBalancerProtocolsResponse> ListLoadBalancerProtocols(ListLoadBalancerProtocolsRequest request);

        /// <summary>
        /// Gets the health status for the specified load balancer.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ListLoadBalancerShapesResponse> ListLoadBalancerShapes(ListLoadBalancerShapesRequest request);

        /// <summary>
        /// Lists all path route sets associated with the specified load balancer.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ListPathRouteSetsResponse> ListPathRouteSets(ListPathRouteSetsRequest request);

        /// <summary>
        /// Lists all rule sets associated with the specified load balancer.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ListRuleSetsResponse> ListRuleSets(ListRuleSetsRequest request);

        /// <summary>
        /// Lists the work requests for a given load balancer.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ListWorkRequestsResponse> ListWorkRequests(ListWorkRequestsRequest request);

        /// <summary>
        /// Gets the specified backend server's configuration information.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<GetBackendResponse> GetBackend(GetBackendRequest request);

        /// <summary>
        /// Gets the specified backend set's configuration information.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<GetBackendSetResponse> GetBackendSet(GetBackendSetRequest request);

        /// <summary>
        /// Gets the health status for the specified backend set.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<GetBackendSetHealthResponse> GetBackendSetHealth(GetBackendSetHealthRequest request);

        /// <summary>
        /// Gets the current health status of the specified backend server.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<GetBackendHealthResponse> GetBackendHealth(GetBackendHealthRequest request);

        /// <summary>
        /// Gets the health check policy information for a given load balancer and backend set.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<GetHealthCheckerResponse> GetHealthChecker(GetHealthCheckerRequest request);

        /// <summary>
        /// Gets the specified hostname resource's configuration information.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<GetHostnameResponse> GetHostname(GetHostnameRequest request);

        /// <summary>
        /// Gets the specified load balancer's configuration information.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<GetLoadBalancerResponse> GetLoadBalancer(GetLoadBalancerRequest request);

        /// <summary>
        /// Gets the health status for the specified load balancer.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<GetLoadBalancerHealthResponse> GetLoadBalancerHealth(GetLoadBalancerHealthRequest request);

        /// <summary>
        /// Gets the details of a work request.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<GetWorkRequestResponse> GetWorkRequest(GetWorkRequestRequest request);

        /// <summary>
        /// Adds a backend server to a backend set.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<CreateBackendResponse> CreateBackend(CreateBackendRequest request);

        /// <summary>
        /// Gets the specified path route set's configuration information.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<GetPathRouteSetResponse> GetPathRouteSet(GetPathRouteSetRequest request);

        /// <summary>
        /// Gets the specified set of rules.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<GetRuleSetResponse> GetRuleSet(GetRuleSetRequest request);

        /// <summary>
        /// Adds a backend set to a load balancer.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<CreateBackendSetResponse> CreateBackendSet(CreateBackendSetRequest request);

        /// <summary>
        /// Creates an asynchronous request to add an SSL certificate bundle.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<CreateCertificateResponse> CreateCertificate(CreateCertificateRequest request);

        /// <summary>
        /// Adds a hostname resource to the specified load balancer. For more information, see Managing Request Routing.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<CreateHostnameResponse> CreateHostname(CreateHostnameRequest request);

        /// <summary>
        /// Adds a listener to a load balancer.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<CreateListenerResponse> CreateListener(CreateListenerRequest request);

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
        Task<CreateLoadBalancerResponse> CreateLoadBalancer(CreateLoadBalancerRequest request);

        /// <summary>
        /// Adds a path route set to a load balancer. For more information, see Managing Request Routing.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<CreatePathRouteSetResponse> CreatePathRouteSet(CreatePathRouteSetRequest request);

        /// <summary>
        /// Creates a new rule set associated with the specified load balancer. For more information, see Managing Rule Sets.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<CreateRuleSetResponse> CreateRuleSet(CreateRuleSetRequest request);

        /// <summary>
        /// Updates the configuration of a backend server within the specified backend set.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<UpdateBackendResponse> UpdateBackend(UpdateBackendRequest request);

        /// <summary>
        /// Updates a backend set.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<UpdateBackendSetResponse> UpdateBackendSet(UpdateBackendSetRequest request);

        /// <summary>
        /// Updates the health check policy for a given load balancer and backend set.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<UpdateHealthCheckerResponse> UpdateHealthChecker(UpdateHealthCheckerRequest request);

        /// <summary>
        /// Overwrites an existing hostname resource on the specified load balancer. Use this operation to change a virtual hostname.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<UpdateHostnameResponse> UpdateHostname(UpdateHostnameRequest request);

        /// <summary>
        /// Updates a listener for a given load balancer.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<UpdateListenerResponse> UpdateListener(UpdateListenerRequest request);

        /// <summary>
        /// Updates a load balancer's configuration.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<UpdateLoadBalancerResponse> UpdateLoadBalancer(UpdateLoadBalancerRequest request);

        /// <summary>
        /// Updates the network security groups associated with the specified load balancer.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<UpdateNetworkSecurityGroupsResponse> UpdateNetworkSecurityGroups(UpdateNetworkSecurityGroupsRequest request);

        /// <summary>
        /// Overwrites an existing path route set on the specified load balancer. Use this operation to add, delete, or alter path route rules in a path route set.
        /// 
        /// To add a new path route rule to a path route set, the pathRoutes in the UpdatePathRouteSetDetails object must include both the new path route rule to 
        /// add and the existing path route rules to retain.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<UpdatePathRouteSetResponse> UpdatePathRouteSet(UpdatePathRouteSetRequest request);

        /// <summary>
        /// Overwrites an existing set of rules on the specified load balancer. Use this operation to add or alter the rules in a rule set.
        /// 
        /// To add a new rule to a set, the body must include both the new rule to add and the existing rules to retain.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<UpdateRuleSetResponse> UpdateRuleSet(UpdateRuleSetRequest request);

        /// <summary>
        /// Moves a load balancer into a different compartment within the same tenancy.
        /// For information about moving resources between compartments, see Moving Resources to a Different Compartment.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ChangeLoadBalancerCompartmentResponse> ChangeLoadBalancerCompartment(ChangeLoadBalancerCompartmentRequest request);

        /// <summary>
        /// Removes a backend server from a given load balancer and backend set.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<DeleteBackendResponse> DeleteBackend(DeleteBackendRequest request);

        /// <summary>
        /// Deletes the specified backend set. Note that deleting a backend set removes its backend servers from the load balancer.
        /// 
        /// Before you can delete a backend set, you must remove it from any active listeners.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<DeleteBackendSetResponse> DeleteBackendSet(DeleteBackendSetRequest request);

        /// <summary>
        /// Deletes an SSL certificate bundle from a load balancer.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<DeleteCertificateResponse> DeleteCertificate(DeleteCertificateRequest request);

        /// <summary>
        /// Deletes a hostname resource from the specified load balancer.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<DeleteHostnameResponse> DeleteHostname(DeleteHostnameRequest request);

        /// <summary>
        /// Deletes a listener from a load balancer.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<DeleteListenerResponse> DeleteListener(DeleteListenerRequest request);

        /// <summary>
        /// Stops a load balancer and removes it from service.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<DeleteLoadBalancerResponse> DeleteLoadBalancer(DeleteLoadBalancerRequest request);

        /// <summary>
        /// Deletes a path route set from the specified load balancer.
        /// 
        /// To delete a path route rule from a path route set, use the UpdatePathRouteSet operation.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<DeletePathRouteSetResponse> DeletePathRouteSet(DeletePathRouteSetRequest request);

        /// <summary>
        /// Deletes a rule set from the specified load balancer.
        /// To delete a rule from a rule set, use the UpdateRuleSet operation.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<DeleteRuleSetResponse> DeleteRuleSet(DeleteRuleSetRequest request);
    }
}

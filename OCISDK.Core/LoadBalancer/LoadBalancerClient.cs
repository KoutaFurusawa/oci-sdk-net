using OCISDK.Core.Common;
using OCISDK.Core.LoadBalancer.Model;
using OCISDK.Core.LoadBalancer.Request;
using OCISDK.Core.LoadBalancer.Response;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OCISDK.Core.LoadBalancer
{
    /// <summary>
    /// LoadBalancerClient
    /// </summary>
    public class LoadBalancerClient : ServiceClient, ILoadBalancerClient
    {
        private readonly string DatabaseServiceName = "load_balancing";

        /// <summary>
        /// Constructer
        /// </summary>
        public LoadBalancerClient(ClientConfig config) : base(config)
        {
            ServiceName = DatabaseServiceName;
        }

        /// <summary>
        /// Constructer
        /// </summary>
        public LoadBalancerClient(ClientConfig config, OciSigner ociSigner) : base(config, ociSigner)
        {
            ServiceName = DatabaseServiceName;
        }

        /// <summary>
        /// Constructer
        /// </summary>
        public LoadBalancerClient(ClientConfigStream config) : base(config)
        {
            ServiceName = DatabaseServiceName;
        }

        /// <summary>
        /// Constructer
        /// </summary>
        public LoadBalancerClient(ClientConfigStream config, OciSigner ociSigner) : base(config, ociSigner)
        {
            ServiceName = DatabaseServiceName;
        }
        
        /// <summary>
        /// Lists the backend servers for a given load balancer and backend set.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ListBackendsResponse ListBackends(ListBackendsRequest request)
        {
            var uri = new Uri($"{GetEndPoint(LoadBalancerServices.LoadBalancers, this.Region)}/{request.LoadBalancerId}/backendSets/{request.BackendSetName}/backends");

            var webResponse = this.RestClient.Get(uri, new HttpRequestHeaderParam { OpcRequestId = request.OpcRequestId });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListBackendsResponse()
                {
                    Items = this.JsonSerializer.Deserialize<List<BackendDetails>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Lists all backend sets associated with a given load balancer.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ListBackendSetsResponse ListBackendSets(ListBackendSetsRequest request)
        {
            var uri = new Uri($"{GetEndPoint(LoadBalancerServices.LoadBalancers, this.Region)}/{request.LoadBalancerId}/backendSets");

            var webResponse = this.RestClient.Get(uri, new HttpRequestHeaderParam { OpcRequestId = request.OpcRequestId });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListBackendSetsResponse()
                {
                    Items = this.JsonSerializer.Deserialize<List<BackendSetDetails>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Lists all SSL certificates bundles associated with a given load balancer.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ListCertificatesResponse ListCertificates(ListCertificatesRequest request)
        {
            var uri = new Uri($"{GetEndPoint(LoadBalancerServices.LoadBalancers, this.Region)}/{request.LoadBalancerId}/certificates");

            var webResponse = this.RestClient.Get(uri, new HttpRequestHeaderParam { OpcRequestId = request.OpcRequestId });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListCertificatesResponse()
                {
                    Items = this.JsonSerializer.Deserialize<List<CertificateDetails>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Lists all hostname resources associated with the specified load balancer.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ListHostnamesResponse ListHostnames(ListHostnamesRequest request)
        {
            var uri = new Uri($"{GetEndPoint(LoadBalancerServices.LoadBalancers, this.Region)}/{request.LoadBalancerId}/hostnames");

            var webResponse = this.RestClient.Get(uri, new HttpRequestHeaderParam { OpcRequestId = request.OpcRequestId });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListHostnamesResponse()
                {
                    Items = this.JsonSerializer.Deserialize<List<HostnameDetails>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Lists all of the rules from all of the rule sets associated with the specified listener.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ListListenerRulesResponse ListListenerRules(ListListenerRulesRequest request)
        {
            var uri = new Uri($"{GetEndPoint(LoadBalancerServices.LoadBalancers, this.Region)}/{request.LoadBalancerId}/listeners/{request.ListenerName}/rules");

            var webResponse = this.RestClient.Get(uri, new HttpRequestHeaderParam { OpcRequestId = request.OpcRequestId });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListListenerRulesResponse()
                {
                    Items = this.JsonSerializer.Deserialize<List<ListenerRuleSummary>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Lists all load balancers in the specified compartment.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ListLoadBalancersResponse ListLoadBalancers(ListLoadBalancersRequest request)
        {
            var uriStr = $"{GetEndPoint(LoadBalancerServices.LoadBalancers, this.Region)}";

            if (!string.IsNullOrEmpty(request.GetOptionQuery()))
            {
                uriStr = $"{uriStr}?{request.GetOptionQuery()}";
            }

            var uri = new Uri(uriStr);
            
            var webResponse = this.RestClient.Get(uri, new HttpRequestHeaderParam { OpcRequestId = request.OpcRequestId });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListLoadBalancersResponse()
                {
                    Items = this.JsonSerializer.Deserialize<List<LoadBalancerDetails>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
        }

        /// <summary>
        /// Lists the summary health statuses for all load balancers in the specified compartment.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ListLoadBalancerHealthsResponse ListLoadBalancerHealths(ListLoadBalancerHealthsRequest request)
        {
            var uriStr = $"{GetEndPoint(LoadBalancerServices.LoadBalancerHealths, this.Region)}";

            if (!string.IsNullOrEmpty(request.GetOptionQuery()))
            {
                uriStr = $"{uriStr}?{request.GetOptionQuery()}";
            }

            var uri = new Uri(uriStr);
            
            var webResponse = this.RestClient.Get(uri, new HttpRequestHeaderParam { OpcRequestId = request.OpcRequestId });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListLoadBalancerHealthsResponse()
                {
                    Items = this.JsonSerializer.Deserialize<List<LoadBalancerHealthSummary>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
        }

        /// <summary>
        /// Lists the available load balancer policies.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ListLoadBalancerPoliciesResponse ListLoadBalancerPolicies(ListLoadBalancerPoliciesRequest request)
        {
            var uriStr = $"{GetEndPoint(LoadBalancerServices.LoadBalancerPolicies, this.Region)}";

            if (!string.IsNullOrEmpty(request.GetOptionQuery()))
            {
                uriStr = $"{uriStr}?{request.GetOptionQuery()}";
            }

            var uri = new Uri(uriStr);

            var webResponse = this.RestClient.Get(uri, new HttpRequestHeaderParam { OpcRequestId = request.OpcRequestId });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListLoadBalancerPoliciesResponse()
                {
                    Items = this.JsonSerializer.Deserialize<List<LoadBalancerPolicyDetails>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
        }

        /// <summary>
        /// Lists all supported traffic protocols.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ListLoadBalancerProtocolsResponse ListLoadBalancerProtocols(ListLoadBalancerProtocolsRequest request)
        {
            var uriStr = $"{GetEndPoint(LoadBalancerServices.LoadBalancerProtocols, this.Region)}";

            if (!string.IsNullOrEmpty(request.GetOptionQuery()))
            {
                uriStr = $"{uriStr}?{request.GetOptionQuery()}";
            }

            var uri = new Uri(uriStr);
            
            var webResponse = this.RestClient.Get(uri, new HttpRequestHeaderParam { OpcRequestId = request.OpcRequestId });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListLoadBalancerProtocolsResponse()
                {
                    Items = this.JsonSerializer.Deserialize<List<LoadBalancerProtocolDetails>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
        }

        /// <summary>
        /// Gets the health status for the specified load balancer.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ListLoadBalancerShapesResponse ListLoadBalancerShapes(ListLoadBalancerShapesRequest request)
        {
            var uriStr = $"{GetEndPoint(LoadBalancerServices.LoadBalancerShapes, this.Region)}";

            if (!string.IsNullOrEmpty(request.GetOptionQuery()))
            {
                uriStr = $"{uriStr}?{request.GetOptionQuery()}";
            }

            var uri = new Uri(uriStr);

            var webResponse = this.RestClient.Get(uri, new HttpRequestHeaderParam { OpcRequestId = request.OpcRequestId });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListLoadBalancerShapesResponse()
                {
                    Items = this.JsonSerializer.Deserialize<List<LoadBalancerShapeDetails>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
        }

        /// <summary>
        /// Lists all path route sets associated with the specified load balancer.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ListPathRouteSetsResponse ListPathRouteSets(ListPathRouteSetsRequest request)
        {
            var uri = new Uri($"{GetEndPoint(LoadBalancerServices.LoadBalancers, this.Region)}/{request.LoadBalancerId}/pathRouteSets");

            var webResponse = this.RestClient.Get(uri, new HttpRequestHeaderParam { OpcRequestId = request.OpcRequestId });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListPathRouteSetsResponse()
                {
                    Items = this.JsonSerializer.Deserialize<List<PathRouteSetDetails>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Lists all rule sets associated with the specified load balancer.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ListRuleSetsResponse ListRuleSets(ListRuleSetsRequest request)
        {
            var uri = new Uri($"{GetEndPoint(LoadBalancerServices.LoadBalancerShapes, this.Region)}/{request.LoadBalancerId}/ruleSets");

            var webResponse = this.RestClient.Get(uri, new HttpRequestHeaderParam { OpcRequestId = request.OpcRequestId });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListRuleSetsResponse()
                {
                    Items = this.JsonSerializer.Deserialize<List<RuleSetDetails>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Lists the work requests for a given load balancer.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ListWorkRequestsResponse ListWorkRequests(ListWorkRequestsRequest request)
        {
            var uriStr = $"{GetEndPoint(LoadBalancerServices.LoadBalancers, this.Region)}/{request.LoadBalancerId}/workRequests";

            if (!string.IsNullOrEmpty(request.GetOptionQuery())) {
                uriStr = $"{uriStr}?{request.GetOptionQuery()}";
            }

            var uri = new Uri(uriStr);

            var webResponse = this.RestClient.Get(uri, new HttpRequestHeaderParam { OpcRequestId = request.OpcRequestId });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListWorkRequestsResponse()
                {
                    Items = this.JsonSerializer.Deserialize<List<WorkRequest>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
        }

        /// <summary>
        /// Gets the specified backend server's configuration information.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public GetBackendResponse GetBackend(GetBackendRequest request)
        {
            var uri = new Uri($"{GetEndPoint(LoadBalancerServices.LoadBalancers, this.Region)}/{request.LoadBalancerId}/backendSets/{request.BackendSetName}/backends/{request.BackendName}");

            var webResponse = this.RestClient.Get(uri, new HttpRequestHeaderParam { OpcRequestId = request.OpcRequestId });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new GetBackendResponse()
                {
                    Backend = this.JsonSerializer.Deserialize<BackendDetails>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Gets the specified backend set's configuration information.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public GetBackendSetResponse GetBackendSet(GetBackendSetRequest request)
        {
            var uri = new Uri($"{GetEndPoint(LoadBalancerServices.LoadBalancers, this.Region)}/{request.LoadBalancerId}/backendSets/{request.BackendSetName}");

            var webResponse = this.RestClient.Get(uri, new HttpRequestHeaderParam { OpcRequestId = request.OpcRequestId });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new GetBackendSetResponse()
                {
                    BackendSet = this.JsonSerializer.Deserialize<BackendSetDetails>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Gets the health status for the specified backend set.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public GetBackendSetHealthResponse GetBackendSetHealth(GetBackendSetHealthRequest request)
        {
            var uri = new Uri($"{GetEndPoint(LoadBalancerServices.LoadBalancers, this.Region)}/{request.LoadBalancerId}/backendSets/{request.BackendSetName}/health");

            var webResponse = this.RestClient.Get(uri, new HttpRequestHeaderParam { OpcRequestId = request.OpcRequestId });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new GetBackendSetHealthResponse()
                {
                    BackendSetHealth = this.JsonSerializer.Deserialize<BackendSetHealth>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Gets the current health status of the specified backend server.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public GetBackendHealthResponse GetBackendHealth(GetBackendHealthRequest request)
        {
            var uri = new Uri($"{GetEndPoint(LoadBalancerServices.LoadBalancers, this.Region)}/{request.LoadBalancerId}/backendSets/{request.BackendSetName}/backends/{request.BackendName}/health");

            var webResponse = this.RestClient.Get(uri, new HttpRequestHeaderParam { OpcRequestId = request.OpcRequestId });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new GetBackendHealthResponse()
                {
                    BackendHealth = this.JsonSerializer.Deserialize<BackendHealth>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Gets the health check policy information for a given load balancer and backend set.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public GetHealthCheckerResponse GetHealthChecker(GetHealthCheckerRequest request)
        {
            var uri = new Uri($"{GetEndPoint(LoadBalancerServices.LoadBalancers, this.Region)}/{request.LoadBalancerId}/backendSets/{request.BackendSetName}/healthChecker");

            var webResponse = this.RestClient.Get(uri, new HttpRequestHeaderParam { OpcRequestId = request.OpcRequestId });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new GetHealthCheckerResponse()
                {
                    HealthChecker = this.JsonSerializer.Deserialize<HealthChecker>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Gets the specified hostname resource's configuration information.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public GetHostnameResponse GetHostname(GetHostnameRequest request)
        {
            var uri = new Uri($"{GetEndPoint(LoadBalancerServices.LoadBalancers, this.Region)}/{request.LoadBalancerId}/hostnames/{request.Name}");

            var webResponse = this.RestClient.Get(uri, new HttpRequestHeaderParam { OpcRequestId = request.OpcRequestId });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new GetHostnameResponse()
                {
                    Hostname = this.JsonSerializer.Deserialize<HostnameDetails>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Gets the specified load balancer's configuration information.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public GetLoadBalancerResponse GetLoadBalancer(GetLoadBalancerRequest request)
        {
            var uri = new Uri($"{GetEndPoint(LoadBalancerServices.LoadBalancers, this.Region)}/{request.LoadBalancerId}");

            var webResponse = this.RestClient.Get(uri, new HttpRequestHeaderParam { OpcRequestId = request.OpcRequestId });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new GetLoadBalancerResponse()
                {
                    LoadBalancer = this.JsonSerializer.Deserialize<LoadBalancerDetails>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Gets the health status for the specified load balancer.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public GetLoadBalancerHealthResponse GetLoadBalancerHealth(GetLoadBalancerHealthRequest request)
        {
            var uri = new Uri($"{GetEndPoint(LoadBalancerServices.LoadBalancers, this.Region)}/{request.LoadBalancerId}/health");

            var webResponse = this.RestClient.Get(uri, new HttpRequestHeaderParam { OpcRequestId = request.OpcRequestId });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new GetLoadBalancerHealthResponse()
                {
                    LoadBalancerHealth = this.JsonSerializer.Deserialize<LoadBalancerHealth>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Gets the details of a work request.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public GetWorkRequestResponse GetWorkRequest(GetWorkRequestRequest request)
        {
            var uri = new Uri($"{GetEndPoint(LoadBalancerServices.LoadBalancerWorkRequests, this.Region)}/{request.WorkRequestId}");

            var webResponse = this.RestClient.Get(uri, new HttpRequestHeaderParam { OpcRequestId = request.OpcRequestId });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new GetWorkRequestResponse()
                {
                    WorkRequest = this.JsonSerializer.Deserialize<WorkRequest>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Adds a backend server to a backend set.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public CreateBackendResponse CreateBackend(CreateBackendRequest request)
        {
            var uri = new Uri($"{GetEndPoint(LoadBalancerServices.LoadBalancers, this.Region)}/{request.LoadBalancerId}/backendSets/{request.BackendSetName}/backends");

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                OpcRetryToken = request.OpcRetryToken,
                OpcRequestId = request.OpcRequestId
            };
            var webResponse = this.RestClient.Post(uri, request.CreateBackendDetails, httpRequestHeaderParam);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new CreateBackendResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcWorkRequestId = webResponse.Headers.Get("opc-work-request-id")
                };
            }
        }

        /// <summary>
        /// Gets the specified path route set's configuration information.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public GetPathRouteSetResponse GetPathRouteSet(GetPathRouteSetRequest request)
        {
            var uri = new Uri($"{GetEndPoint(LoadBalancerServices.LoadBalancers, this.Region)}/{request.LoadBalancerId}/pathRouteSets/{request.PathRouteSetName}");

            var webResponse = this.RestClient.Get(uri, new HttpRequestHeaderParam { OpcRequestId = request.OpcRequestId });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new GetPathRouteSetResponse()
                {
                    PathRouteSet = this.JsonSerializer.Deserialize<PathRouteSetDetails>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Gets the specified set of rules.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public GetRuleSetResponse GetRuleSet(GetRuleSetRequest request)
        {
            var uri = new Uri($"{GetEndPoint(LoadBalancerServices.LoadBalancers, this.Region)}/{request.LoadBalancerId}/ruleSets/{request.RuleSetName}");

            var webResponse = this.RestClient.Get(uri, new HttpRequestHeaderParam { OpcRequestId = request.OpcRequestId });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new GetRuleSetResponse()
                {
                    RuleSet = this.JsonSerializer.Deserialize<RuleSetDetails>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Adds a backend set to a load balancer.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public CreateBackendSetResponse CreateBackendSet(CreateBackendSetRequest request)
        {
            var uri = new Uri($"{GetEndPoint(LoadBalancerServices.LoadBalancers, this.Region)}/{request.LoadBalancerId}/backendSets");

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                OpcRetryToken = request.OpcRetryToken,
                OpcRequestId = request.OpcRequestId
            };
            var webResponse = this.RestClient.Post(uri, request.CreateBackendSetDetails, httpRequestHeaderParam);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new CreateBackendSetResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcWorkRequestId = webResponse.Headers.Get("opc-work-request-id")
                };
            }
        }

        /// <summary>
        /// Creates an asynchronous request to add an SSL certificate bundle.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public CreateCertificateResponse CreateCertificate(CreateCertificateRequest request)
        {
            var uri = new Uri($"{GetEndPoint(LoadBalancerServices.LoadBalancers, this.Region)}/{request.LoadBalancerId}/certificates");

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                OpcRetryToken = request.OpcRetryToken,
                OpcRequestId = request.OpcRequestId
            };
            var webResponse = this.RestClient.Post(uri, request.CreateCertificateDetails, httpRequestHeaderParam);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new CreateCertificateResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcWorkRequestId = webResponse.Headers.Get("opc-work-request-id")
                };
            }
        }

        /// <summary>
        /// Adds a hostname resource to the specified load balancer. For more information, see Managing Request Routing.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public CreateHostnameResponse CreateHostname(CreateHostnameRequest request)
        {
            var uri = new Uri($"{GetEndPoint(LoadBalancerServices.LoadBalancers, this.Region)}/{request.LoadBalancerId}/hostnames");

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                OpcRetryToken = request.OpcRetryToken,
                OpcRequestId = request.OpcRequestId
            };
            var webResponse = this.RestClient.Post(uri, request.CreateHostnameDetails, httpRequestHeaderParam);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new CreateHostnameResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcWorkRequestId = webResponse.Headers.Get("opc-work-request-id")
                };
            }
        }

        /// <summary>
        /// Adds a listener to a load balancer.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public CreateListenerResponse CreateListener(CreateListenerRequest request)
        {
            var uri = new Uri($"{GetEndPoint(LoadBalancerServices.LoadBalancers, this.Region)}/{request.LoadBalancerId}/listeners");

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                OpcRetryToken = request.OpcRetryToken,
                OpcRequestId = request.OpcRequestId
            };
            var webResponse = this.RestClient.Post(uri, request.CreateListenerDetails, httpRequestHeaderParam);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new CreateListenerResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcWorkRequestId = webResponse.Headers.Get("opc-work-request-id")
                };
            }
        }

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
        public CreateLoadBalancerResponse CreateLoadBalancer(CreateLoadBalancerRequest request)
        {
            var uri = new Uri($"{GetEndPoint(LoadBalancerServices.LoadBalancers, this.Region)}");

            var httpRequestHeaderParam = new HttpRequestHeaderParam() {
                OpcRetryToken = request.OpcRetryToken,
                OpcRequestId = request.OpcRequestId
            };
            var webResponse = this.RestClient.Post(uri, request.CreateLoadBalancerDetails, httpRequestHeaderParam);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new CreateLoadBalancerResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcWorkRequestId = webResponse.Headers.Get("opc-work-request-id")
                };
            }
        }

        /// <summary>
        /// Adds a path route set to a load balancer. For more information, see Managing Request Routing.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public CreatePathRouteSetResponse CreatePathRouteSet(CreatePathRouteSetRequest request)
        {
            var uri = new Uri($"{GetEndPoint(LoadBalancerServices.LoadBalancers, this.Region)}/{request.LoadBalancerId}/pathRouteSets");

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                OpcRetryToken = request.OpcRetryToken,
                OpcRequestId = request.OpcRequestId
            };
            var webResponse = this.RestClient.Post(uri, request.CreatePathRouteSetDetails, httpRequestHeaderParam);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new CreatePathRouteSetResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcWorkRequestId = webResponse.Headers.Get("opc-work-request-id")
                };
            }
        }

        /// <summary>
        /// Creates a new rule set associated with the specified load balancer. For more information, see Managing Rule Sets.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public CreateRuleSetResponse CreateRuleSet(CreateRuleSetRequest request)
        {
            var uri = new Uri($"{GetEndPoint(LoadBalancerServices.LoadBalancers, this.Region)}/{request.LoadBalancerId}/ruleSets");
            
            var webResponse = this.RestClient.Post(uri, request.CreateRuleSetDetails, new HttpRequestHeaderParam() { OpcRequestId = request.OpcRequestId });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new CreateRuleSetResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcWorkRequestId = webResponse.Headers.Get("opc-work-request-id")
                };
            }
        }

        /// <summary>
        /// Updates the configuration of a backend server within the specified backend set.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public UpdateBackendResponse UpdateBackend(UpdateBackendRequest request)
        {
            var uri = new Uri($"{GetEndPoint(LoadBalancerServices.LoadBalancers, this.Region)}/{request.LoadBalancerId}/backendSets/{request.BackendSetName}/backends/{request.BackendName}");

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                OpcRetryToken = request.OpcRetryToken,
                OpcRequestId = request.OpcRequestId
            };
            var webResponse = this.RestClient.Put(uri, request.UpdateBackendDetails, httpRequestHeaderParam);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new UpdateBackendResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcWorkRequestId = webResponse.Headers.Get("opc-work-request-id")
                };
            }
        }

        /// <summary>
        /// Updates a backend set.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public UpdateBackendSetResponse UpdateBackendSet(UpdateBackendSetRequest request)
        {
            var uri = new Uri($"{GetEndPoint(LoadBalancerServices.LoadBalancers, this.Region)}/{request.LoadBalancerId}/backendSets/{request.BackendSetName}");

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                OpcRetryToken = request.OpcRetryToken,
                OpcRequestId = request.OpcRequestId
            };
            var webResponse = this.RestClient.Put(uri, request.UpdateBackendSetDetails, httpRequestHeaderParam);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new UpdateBackendSetResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcWorkRequestId = webResponse.Headers.Get("opc-work-request-id")
                };
            }
        }

        /// <summary>
        /// Updates the health check policy for a given load balancer and backend set.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public UpdateHealthCheckerResponse UpdateHealthChecker(UpdateHealthCheckerRequest request)
        {
            var uri = new Uri($"{GetEndPoint(LoadBalancerServices.LoadBalancers, this.Region)}/{request.LoadBalancerId}/backendSets/{request.BackendSetName}/healthChecker");

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                OpcRetryToken = request.OpcRetryToken,
                OpcRequestId = request.OpcRequestId
            };
            var webResponse = this.RestClient.Put(uri, request.UpdateHealthCheckerDetails, httpRequestHeaderParam);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new UpdateHealthCheckerResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcWorkRequestId = webResponse.Headers.Get("opc-work-request-id")
                };
            }
        }

        /// <summary>
        /// Overwrites an existing hostname resource on the specified load balancer. Use this operation to change a virtual hostname.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public UpdateHostnameResponse UpdateHostname(UpdateHostnameRequest request)
        {
            var uri = new Uri($"{GetEndPoint(LoadBalancerServices.LoadBalancers, this.Region)}/{request.LoadBalancerId}/hostnames/{request.Name}");
            
            var webResponse = this.RestClient.Put(uri, request.UpdateHostnameDetails, new HttpRequestHeaderParam() { OpcRequestId = request.OpcRequestId });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new UpdateHostnameResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcWorkRequestId = webResponse.Headers.Get("opc-work-request-id")
                };
            }
        }

        /// <summary>
        /// Updates a listener for a given load balancer.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public UpdateListenerResponse UpdateListener(UpdateListenerRequest request)
        {
            var uri = new Uri($"{GetEndPoint(LoadBalancerServices.LoadBalancers, this.Region)}/{request.LoadBalancerId}/listeners/{request.ListenerName}");

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                OpcRetryToken = request.OpcRetryToken,
                OpcRequestId = request.OpcRequestId
            };
            var webResponse = this.RestClient.Put(uri, request.UpdateListenerDetails, httpRequestHeaderParam);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new UpdateListenerResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcWorkRequestId = webResponse.Headers.Get("opc-work-request-id")
                };
            }
        }

        /// <summary>
        /// Updates a load balancer's configuration.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public UpdateLoadBalancerResponse UpdateLoadBalancer(UpdateLoadBalancerRequest request)
        {
            var uriStr = $"{GetEndPoint(LoadBalancerServices.LoadBalancers, this.Region)}/{request.LoadBalancerId}";
            
            var uri = new Uri(uriStr);

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                OpcRetryToken = request.OpcRetryToken,
                OpcRequestId = request.OpcRequestId
            };
            var webResponse = this.RestClient.Put(uri, request.UpdateLoadBalancerDetails, httpRequestHeaderParam);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new UpdateLoadBalancerResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcWorkRequestId = webResponse.Headers.Get("opc-work-request-id")
                };
            }
        }

        /// <summary>
        /// Updates the network security groups associated with the specified load balancer.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public UpdateNetworkSecurityGroupsResponse UpdateNetworkSecurityGroups(UpdateNetworkSecurityGroupsRequest request)
        {
            var uriStr = $"{GetEndPoint(LoadBalancerServices.LoadBalancers, this.Region)}/{request.LoadBalancerId}/networkSecurityGroups";

            var uri = new Uri(uriStr);

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                OpcRetryToken = request.OpcRetryToken,
                OpcRequestId = request.OpcRequestId
            };
            var webResponse = this.RestClient.Put(uri, request.UpdateNetworkSecurityGroupsDetails, httpRequestHeaderParam);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new UpdateNetworkSecurityGroupsResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcWorkRequestId = webResponse.Headers.Get("opc-work-request-id")
                };
            }
        }

        /// <summary>
        /// Overwrites an existing path route set on the specified load balancer. Use this operation to add, delete, or alter path route rules in a path route set.
        /// 
        /// To add a new path route rule to a path route set, the pathRoutes in the UpdatePathRouteSetDetails object must include both the new path route rule to 
        /// add and the existing path route rules to retain.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public UpdatePathRouteSetResponse UpdatePathRouteSet(UpdatePathRouteSetRequest request)
        {
            var uriStr = $"{GetEndPoint(LoadBalancerServices.LoadBalancers, this.Region)}/{request.LoadBalancerId}/pathRouteSets/{request.PathRouteSetName}";

            var uri = new Uri(uriStr);

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                OpcRetryToken = request.OpcRetryToken,
                OpcRequestId = request.OpcRequestId
            };
            var webResponse = this.RestClient.Put(uri, request.UpdatePathRouteSetDetails, httpRequestHeaderParam);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new UpdatePathRouteSetResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcWorkRequestId = webResponse.Headers.Get("opc-work-request-id")
                };
            }
        }

        /// <summary>
        /// Overwrites an existing set of rules on the specified load balancer. Use this operation to add or alter the rules in a rule set.
        /// 
        /// To add a new rule to a set, the body must include both the new rule to add and the existing rules to retain.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public UpdateRuleSetResponse UpdateRuleSet(UpdateRuleSetRequest request)
        {
            var uriStr = $"{GetEndPoint(LoadBalancerServices.LoadBalancers, this.Region)}/{request.LoadBalancerId}/ruleSets/{request.RuleSetName}";

            var uri = new Uri(uriStr);
            
            var webResponse = this.RestClient.Put(uri, request.UpdateRuleSetDetails, new HttpRequestHeaderParam() { OpcRequestId = request.OpcRequestId });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new UpdateRuleSetResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcWorkRequestId = webResponse.Headers.Get("opc-work-request-id")
                };
            }
        }

        /// <summary>
        /// Moves a load balancer into a different compartment within the same tenancy.
        /// For information about moving resources between compartments, see Moving Resources to a Different Compartment.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ChangeLoadBalancerCompartmentResponse ChangeLoadBalancerCompartment(ChangeLoadBalancerCompartmentRequest request)
        {
            var uri = new Uri($"{GetEndPoint(LoadBalancerServices.LoadBalancers, this.Region)}/{request.LoadBalancerId}/changeCompartment");

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                OpcRetryToken = request.OpcRetryToken,
                OpcRequestId = request.OpcRequestId,
                IfMatch = request.IfMatch
            };
            var webResponse = this.RestClient.Post(uri, request.ChangeLoadBalancerCompartmentDetails, httpRequestHeaderParam);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ChangeLoadBalancerCompartmentResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcWorkRequestId = webResponse.Headers.Get("opc-work-request-id")
                };
            }
        }

        /// <summary>
        /// Removes a backend server from a given load balancer and backend set.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public DeleteBackendResponse DeleteBackend(DeleteBackendRequest request)
        {
            var uriStr = $"{GetEndPoint(LoadBalancerServices.LoadBalancers, this.Region)}/{request.LoadBalancerId}/backendSets/{request.BackendSetName}/backends/{request.BackendName}";

            var uri = new Uri(uriStr);

            var webResponse = this.RestClient.Delete(uri, new HttpRequestHeaderParam() { OpcRequestId = request.OpcRequestId });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new DeleteBackendResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcWorkRequestId = webResponse.Headers.Get("opc-work-request-id")
                };
            }
        }

        /// <summary>
        /// Deletes the specified backend set. Note that deleting a backend set removes its backend servers from the load balancer.
        /// 
        /// Before you can delete a backend set, you must remove it from any active listeners.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public DeleteBackendSetResponse DeleteBackendSet(DeleteBackendSetRequest request)
        {
            var uriStr = $"{GetEndPoint(LoadBalancerServices.LoadBalancers, this.Region)}/{request.LoadBalancerId}/backendSets/{request.BackendSetName}";

            var uri = new Uri(uriStr);

            var webResponse = this.RestClient.Delete(uri, new HttpRequestHeaderParam() { OpcRequestId = request.OpcRequestId });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new DeleteBackendSetResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcWorkRequestId = webResponse.Headers.Get("opc-work-request-id")
                };
            }
        }

        /// <summary>
        /// Deletes an SSL certificate bundle from a load balancer.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public DeleteCertificateResponse DeleteCertificate(DeleteCertificateRequest request)
        {
            var uriStr = $"{GetEndPoint(LoadBalancerServices.LoadBalancers, this.Region)}/{request.LoadBalancerId}/certificates/{request.CertificateName}";

            var uri = new Uri(uriStr);

            var webResponse = this.RestClient.Delete(uri, new HttpRequestHeaderParam() { OpcRequestId = request.OpcRequestId });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new DeleteCertificateResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcWorkRequestId = webResponse.Headers.Get("opc-work-request-id")
                };
            }
        }

        /// <summary>
        /// Deletes a hostname resource from the specified load balancer.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public DeleteHostnameResponse DeleteHostname(DeleteHostnameRequest request)
        {
            var uriStr = $"{GetEndPoint(LoadBalancerServices.LoadBalancers, this.Region)}/{request.LoadBalancerId}/hostnames/{request.Name}";

            var uri = new Uri(uriStr);

            var webResponse = this.RestClient.Delete(uri, new HttpRequestHeaderParam() { OpcRequestId = request.OpcRequestId });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new DeleteHostnameResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcWorkRequestId = webResponse.Headers.Get("opc-work-request-id")
                };
            }
        }

        /// <summary>
        /// Deletes a listener from a load balancer.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public DeleteListenerResponse DeleteListener(DeleteListenerRequest request)
        {
            var uriStr = $"{GetEndPoint(LoadBalancerServices.LoadBalancers, this.Region)}/{request.LoadBalancerId}/listeners/{request.ListenerName}";

            var uri = new Uri(uriStr);

            var webResponse = this.RestClient.Delete(uri, new HttpRequestHeaderParam() { OpcRequestId = request.OpcRequestId });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new DeleteListenerResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcWorkRequestId = webResponse.Headers.Get("opc-work-request-id")
                };
            }
        }

        /// <summary>
        /// Stops a load balancer and removes it from service.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public DeleteLoadBalancerResponse DeleteLoadBalancer(DeleteLoadBalancerRequest request)
        {
            var uriStr = $"{GetEndPoint(LoadBalancerServices.LoadBalancers, this.Region)}/{request.LoadBalancerId}";

            var uri = new Uri(uriStr);

            var webResponse = this.RestClient.Delete(uri, new HttpRequestHeaderParam() { OpcRequestId = request.OpcRequestId });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new DeleteLoadBalancerResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcWorkRequestId = webResponse.Headers.Get("opc-work-request-id")
                };
            }
        }

        /// <summary>
        /// Deletes a path route set from the specified load balancer.
        /// 
        /// To delete a path route rule from a path route set, use the UpdatePathRouteSet operation.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public DeletePathRouteSetResponse DeletePathRouteSet(DeletePathRouteSetRequest request)
        {
            var uriStr = $"{GetEndPoint(LoadBalancerServices.LoadBalancers, this.Region)}/{request.LoadBalancerId}/pathRouteSets/{request.PathRouteSetName}";

            var uri = new Uri(uriStr);

            var webResponse = this.RestClient.Delete(uri, new HttpRequestHeaderParam() { OpcRequestId = request.OpcRequestId });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new DeletePathRouteSetResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcWorkRequestId = webResponse.Headers.Get("opc-work-request-id")
                };
            }
        }

        /// <summary>
        /// Deletes a rule set from the specified load balancer.
        /// To delete a rule from a rule set, use the UpdateRuleSet operation.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public DeleteRuleSetResponse DeleteRuleSet(DeleteRuleSetRequest request)
        {
            var uriStr = $"{GetEndPoint(LoadBalancerServices.LoadBalancers, this.Region)}/{request.LoadBalancerId}/ruleSets/{request.RuleSetName}";

            var uri = new Uri(uriStr);

            var webResponse = this.RestClient.Delete(uri, new HttpRequestHeaderParam() { OpcRequestId = request.OpcRequestId });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new DeleteRuleSetResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcWorkRequestId = webResponse.Headers.Get("opc-work-request-id")
                };
            }
        }
    }
}

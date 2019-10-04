using OCISDK.Core.src.LoadBalancer.Model;
using OCISDK.Core.src.LoadBalancer.Request;
using OCISDK.Core.src.LoadBalancer.Response;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OCISDK.Core.src.LoadBalancer
{
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

        public LoadBalancerClient(ClientConfig config, OciSigner ociSigner) : base(config, ociSigner)
        {
            ServiceName = DatabaseServiceName;
        }

        public LoadBalancerClient(ClientConfigStream config) : base(config)
        {
            ServiceName = DatabaseServiceName;
        }

        public LoadBalancerClient(ClientConfigStream config, OciSigner ociSigner) : base(config, ociSigner)
        {
            ServiceName = DatabaseServiceName;
        }

        /// <summary>
        /// setter Region
        /// </summary>
        /// <param name="region"></param>
        public void SetRegion(string region)
        {
            Region = region;
        }

        /// <summary>
        /// getter region
        /// </summary>
        /// <returns></returns>
        public string GetRegion()
        {
            return Region;
        }

        /// <summary>
        /// Lists all load balancers in the specified compartment.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ListLoadBalancersResponse ListLoadBalancers(ListLoadBalancersRequest request)
        {
            var uri = new Uri($"{GetEndPoint(LoadBalancerServices.LoadBalancers, this.Region)}?{request.GetOptionQuery()}");

            var webResponse = this.RestClient.Get(uri, request.OpcRequestId);

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
        /// Gets the specified load balancer's configuration information.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public GetLoadBalancerResponse GetLoadBalancer(GetLoadBalancerRequest request)
        {
            var uri = new Uri($"{GetEndPoint(LoadBalancerServices.LoadBalancers, this.Region)}/{request.LoadBalancerId}");

            var webResponse = this.RestClient.Get(uri, request.OpcRequestId);

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

            var webResponse = this.RestClient.Post(uri, request.CreateLoadBalancerDetails, request.OpcRetryToken, request.OpcRequestId);

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
        /// Updates a load balancer's configuration.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public UpdateLoadBalancerResponse UpdateLoadBalancer(UpdateLoadBalancerRequest request)
        {
            var uriStr = $"{GetEndPoint(LoadBalancerServices.LoadBalancers, this.Region)}/{request.LoadBalancerId}";
            
            var uri = new Uri(uriStr);

            var webResponse = this.RestClient.Put(uri, request.UpdateLoadBalancerDetails, "", request.OpcRetryToken, request.OpcRequestId, "");

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
        /// Stops a load balancer and removes it from service.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public DeleteLoadBalancerResponse DeleteLoadBalancer(DeleteLoadBalancerRequest request)
        {
            var uriStr = $"{GetEndPoint(LoadBalancerServices.LoadBalancers, this.Region)}/{request.LoadBalancerId}";

            var uri = new Uri(uriStr);

            var webResponse = this.RestClient.Delete(uri, "", null, "", "", request.OpcRequestId);

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
    }
}

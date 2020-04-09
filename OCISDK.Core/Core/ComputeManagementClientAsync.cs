using OCISDK.Core.Common;
using OCISDK.Core.Core.Model.ComputeManagement;
using OCISDK.Core.Core.Request.ComputeManagement;
using OCISDK.Core.Core.Response.ComputeManagement;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace OCISDK.Core.Core
{
    /// <summary>
    /// ComputeManagement Client
    /// </summary>
    public class ComputeManagementClientAsync : ServiceClient, IComputeManagementClientAsync
    {
        /// <summary>
        /// Constructer
        /// </summary>
        public ComputeManagementClientAsync(ClientConfig config) : base(config)
        {
            ServiceName = CoreServices.CoreServiceName;
        }

        /// <summary>
        /// Constructer
        /// </summary>
        public ComputeManagementClientAsync(ClientConfig config, IOciSigner ociSigner) : base(config, ociSigner)
        {
            ServiceName = CoreServices.CoreServiceName;
        }

        /// <summary>
        /// Constructer
        /// </summary>
        public ComputeManagementClientAsync(ClientConfigStream config) : base(config)
        {
            ServiceName = CoreServices.CoreServiceName;
        }

        /// <summary>
        /// Constructer
        /// </summary>
        public ComputeManagementClientAsync(ClientConfigStream config, IOciSigner ociSigner) : base(config, ociSigner)
        {
            ServiceName = CoreServices.CoreServiceName;
        }

        /// <summary>
        /// Moves a cluster network into a different compartment within the same tenancy. For information about 
        /// moving resources between compartments, see Moving Resources to a Different Compartment.
        /// 
        /// When you move a cluster network to a different compartment, associated resources such as the instances 
        /// in the cluster network, boot volumes, and VNICs are not moved.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ChangeClusterNetworkCompartmentResponse> ChangeClusterNetworkCompartment(ChangeClusterNetworkCompartmentRequest request)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.ClusterNetworks, this.Region)}/{request.ClusterNetworkId}/actions/changeCompartment");

            var headers = new HttpRequestHeaderParam {
                IfMatch = request.IfMatch,
                OpcRequestId = request.OpcRequestId,
                OpcRetryToken = request.OpcRetryToken
            };
            using (var webResponse = await this.RestClientAsync.Post(uri, request.ChangeClusterNetworkCompartmentDetails, headers))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ChangeClusterNetworkCompartmentResponse()
                {
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Creates a cluster network. For more information about cluster networks, see Managing Cluster Networks.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CreateClusterNetworkResponse> CreateClusterNetwork(CreateClusterNetworkRequest request)
        {
            var uri = new Uri(GetEndPoint(CoreServices.ClusterNetworks, this.Region));

            using (var webResponse = await this.RestClientAsync.Post(uri, request.CreateClusterNetworkDetails, new HttpRequestHeaderParam { OpcRetryToken = request.OpcRetryToken }))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new CreateClusterNetworkResponse()
                {
                    ClusterNetwork = JsonSerializer.Deserialize<ClusterNetwork>(response),
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcWorkRequestId = webResponse.Headers.Get("opc-work-request-id")
                };
            }
        }

        /// <summary>
        /// Updates the specified cluster network. The OCID of the cluster network remains the same.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<UpdateClusterNetworkResponse> UpdateClusterNetwork(UpdateClusterNetworkRequest request)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.ClusterNetworks, this.Region)}/{request.ClusterNetworkId}");

            var headers = new HttpRequestHeaderParam()
            {
                IfMatch = request.IfMatch,
                OpcRetryToken = request.OpcRetryToken
            };
            using (var webResponse = await this.RestClientAsync.Put(uri, request.UpdateClusterNetworkDetails, headers))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new UpdateClusterNetworkResponse()
                {
                    ClusterNetwork = JsonSerializer.Deserialize<ClusterNetwork>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    ETag = webResponse.Headers.Get("ETag")
                };
            }
        }

        /// <summary>
        /// Gets information about the specified cluster network.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<GetClusterNetworkResponse> GetClusterNetwork(GetClusterNetworkRequest request)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.ClusterNetworks, this.Region)}/{request.ClusterNetworkId}");

            using (var webResponse = await this.RestClientAsync.Get(uri))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new GetClusterNetworkResponse()
                {
                    ClusterNetwork = JsonSerializer.Deserialize<ClusterNetwork>(response),
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Lists the cluster networks in the specified compartment.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ListClusterNetworksResponse> ListClusterNetworks(ListClusterNetworksRequest request)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.ClusterNetworks, this.Region)}?{request.GetOptionQuery()}");

            using (var webResponse = await this.RestClientAsync.Get(uri))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListClusterNetworksResponse()
                {
                    Items = JsonSerializer.Deserialize<List<ClusterNetworkSummary>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
        }

        /// <summary>
        /// Lists the instances in the specified cluster network.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ListClusterNetworkInstancesResponse> ListClusterNetworkInstances(ListClusterNetworkInstancesRequest request)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.ClusterNetworks, this.Region)}/{request.ClusterNetworkId}/instances?{request.GetOptionQuery()}");

            using (var webResponse = await this.RestClientAsync.Get(uri))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListClusterNetworkInstancesResponse()
                {
                    Items = JsonSerializer.Deserialize<List<InstanceSummary>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
        }

        /// <summary>
        /// Terminates the specified cluster network.
        /// 
        /// When you delete a cluster network, all of its resources are permanently deleted, including associated instances and instance pools.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<TerminateClusterNetworkResponse> TerminateClusterNetwork(TerminateClusterNetworkRequest request)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.ClusterNetworks, this.Region)}/{request.ClusterNetworkId}");

            using (var webResponse = await this.RestClientAsync.Delete(uri, new HttpRequestHeaderParam() { IfMatch = request.IfMatch }))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new TerminateClusterNetworkResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcWorkRequestId = webResponse.Headers.Get("opc-work-request-id")
                };
            }
        }
    }
}

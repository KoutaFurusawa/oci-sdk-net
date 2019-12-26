using OCISDK.Core.Common;
using OCISDK.Core.Core.Model.ComputeManagement;
using OCISDK.Core.Core.Request.ComputeManagement;
using OCISDK.Core.Core.Response.ComputeManagement;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OCISDK.Core.Core
{
    /// <summary>
    /// ComputeManagement Client
    /// </summary>
    public class ComputeManagementClient : ServiceClient, IComputeManagementClient
    {
        private readonly string ComputeManagementServiceName = "core";

        /// <summary>
        /// Constructer
        /// </summary>
        public ComputeManagementClient(ClientConfig config) : base(config)
        {
            ServiceName = ComputeManagementServiceName;
        }

        /// <summary>
        /// Constructer
        /// </summary>
        public ComputeManagementClient(ClientConfig config, OciSigner ociSigner) : base(config, ociSigner)
        {
            ServiceName = ComputeManagementServiceName;
        }

        /// <summary>
        /// Constructer
        /// </summary>
        public ComputeManagementClient(ClientConfigStream config) : base(config)
        {
            ServiceName = ComputeManagementServiceName;
        }

        /// <summary>
        /// Constructer
        /// </summary>
        public ComputeManagementClient(ClientConfigStream config, OciSigner ociSigner) : base(config, ociSigner)
        {
            ServiceName = ComputeManagementServiceName;
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
        public ChangeClusterNetworkCompartmentResponse ChangeClusterNetworkCompartment(ChangeClusterNetworkCompartmentRequest request)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.ClusterNetworks, this.Region)}/{request.ClusterNetworkId}/actions/changeCompartment");

            var headers = new HttpRequestHeaderParam {
                IfMatch = request.IfMatch,
                OpcRequestId = request.OpcRequestId,
                OpcRetryToken = request.OpcRetryToken
            };
            var webResponse = this.RestClient.Post(uri, request.ChangeClusterNetworkCompartmentDetails, headers);

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
        public CreateClusterNetworkResponse CreateClusterNetwork(CreateClusterNetworkRequest request)
        {
            var uri = new Uri(GetEndPoint(CoreServices.ClusterNetworks, this.Region));

            var webResponse = this.RestClient.Post(uri, request.CreateClusterNetworkDetails, new HttpRequestHeaderParam { OpcRetryToken = request.OpcRetryToken });

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
        public UpdateClusterNetworkResponse UpdateClusterNetwork(UpdateClusterNetworkRequest request)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.ClusterNetworks, this.Region)}/{request.ClusterNetworkId}");

            var headers = new HttpRequestHeaderParam() {
                IfMatch = request.IfMatch,
                OpcRetryToken = request.OpcRetryToken
            };
            var webResponse = this.RestClient.Put(uri, request.UpdateClusterNetworkDetails, headers);

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
        public GetClusterNetworkResponse GetClusterNetwork(GetClusterNetworkRequest request)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.ClusterNetworks, this.Region)}/{request.ClusterNetworkId}");

            var webResponse = this.RestClient.Get(uri);

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
        public ListClusterNetworksResponse ListClusterNetworks(ListClusterNetworksRequest request)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.ClusterNetworks, this.Region)}?{request.GetOptionQuery()}");

            var webResponse = this.RestClient.Get(uri);

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
        public ListClusterNetworkInstancesResponse ListClusterNetworkInstances(ListClusterNetworkInstancesRequest request)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.ClusterNetworks, this.Region)}/{request.ClusterNetworkId}/instances?{request.GetOptionQuery()}");

            var webResponse = this.RestClient.Get(uri);

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
        public TerminateClusterNetworkResponse TerminateClusterNetwork(TerminateClusterNetworkRequest request)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.ClusterNetworks, this.Region)}/{request.ClusterNetworkId}");

            var webResponse = this.RestClient.Delete(uri, new HttpRequestHeaderParam() { IfMatch = request.IfMatch });

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

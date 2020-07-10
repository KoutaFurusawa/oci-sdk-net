using OCISDK.Core.Common;
using OCISDK.Core.Usage.Model;
using OCISDK.Core.Usage.Request;
using OCISDK.Core.Usage.Response;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace OCISDK.Core.Usage
{
    /// <summary>
    /// Usage service client
    /// </summary>
    public class UsageClient : ServiceClient, IUsageClient
    {
        private readonly string UsageServiceName = "usageapi";

        /// <summary>
        /// Constructer
        /// </summary>
        public UsageClient(ClientConfig config) : base(config)
        {
            ServiceName = UsageServiceName;
        }

        /// <summary>
        /// Constructer
        /// </summary>
        public UsageClient(ClientConfig config, IOciSigner ociSigner) : base(config, ociSigner)
        {
            ServiceName = UsageServiceName;
        }

        /// <summary>
        /// Constructer
        /// </summary>
        public UsageClient(ClientConfigStream config) : base(config)
        {
            ServiceName = UsageServiceName;
        }

        /// <summary>
        /// Constructer
        /// </summary>
        public UsageClient(ClientConfigStream config, IOciSigner ociSigner) : base(config, ociSigner)
        {
            ServiceName = UsageServiceName;
        }

        /// <summary>
        /// Returns the configurations list for the UI drop-down list.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public RequestSummarizedConfigurationsResponse RequestSummarizedConfigurations(RequestSummarizedConfigurationsRequest request)
        {
            var uriStr = $"{GetEndPoint(UsageServices.Configuration, this.Region)}?{request.TenantId}";
            var uri = new Uri(uriStr);

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                OpcRequestId = request.OpcRequestId,
            };
            using (var webResponse = this.RestClient.Get(uri, httpRequestHeaderParam))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new RequestSummarizedConfigurationsResponse()
                {
                    ConfigurationAggregation = this.JsonSerializer.Deserialize<ConfigurationAggregation>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Returns the configurations list for the UI drop-down list.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<RequestSummarizedConfigurationsResponse> RequestSummarizedConfigurationsAsync(RequestSummarizedConfigurationsRequest request)
        {
            var uriStr = $"{GetEndPoint(UsageServices.Configuration, this.Region)}?{request.TenantId}";
            var uri = new Uri(uriStr);

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                OpcRequestId = request.OpcRequestId,
            };
            using (var webResponse = await this.RestClientAsync.Get(uri, httpRequestHeaderParam))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

                return new RequestSummarizedConfigurationsResponse()
                {
                    ConfigurationAggregation = this.JsonSerializer.Deserialize<ConfigurationAggregation>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Returns usage for the given account.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public RequestSummarizedUsagesResponse RequestSummarizedUsages(RequestSummarizedUsagesRequest request)
        {
            var uriStr = $"{GetEndPoint(UsageServices.Usage, this.Region)}";
            var options = request.GetOptions();
            if (!string.IsNullOrEmpty(options))
            {
                uriStr = uriStr + "?" + options;
            }

            var uri = new Uri(uriStr);

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                OpcRequestId = request.OpcRequestId,
            };
            using (var webResponse = this.RestClient.Post(uri, request.RequestSummarizedUsagesDetails, httpRequestHeaderParam))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new RequestSummarizedUsagesResponse()
                {
                    UsageAggregation = this.JsonSerializer.Deserialize<UsageAggregation>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
        }

        /// <summary>
        /// Returns usage for the given account.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<RequestSummarizedUsagesResponse> RequestSummarizedUsagesAsync(RequestSummarizedUsagesRequest request)
        {
            var uriStr = $"{GetEndPoint(UsageServices.Usage, this.Region)}";
            var options = request.GetOptions();
            if (!string.IsNullOrEmpty(options))
            {
                uriStr = uriStr + "?" + options;
            }

            var uri = new Uri(uriStr);

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                OpcRequestId = request.OpcRequestId,
            };
            using (var webResponse = await this.RestClientAsync.Post(uri, request.RequestSummarizedUsagesDetails, httpRequestHeaderParam))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

                return new RequestSummarizedUsagesResponse()
                {
                    UsageAggregation = this.JsonSerializer.Deserialize<UsageAggregation>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
        }
    }
}

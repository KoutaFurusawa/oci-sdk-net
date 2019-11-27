using OCISDK.Core.Common;
using OCISDK.Core.Search.Model;
using OCISDK.Core.Search.Request;
using OCISDK.Core.Search.Response;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OCISDK.Core.Search
{
    /// <summary>
    /// SearchClient
    /// </summary>
    public class SearchClient : ServiceClient, ISearchClient
    {
        private readonly string SearchServiceName = "search";

        /// <summary>
        /// Constructer
        /// </summary>
        public SearchClient(ClientConfig config) : base(config)
        {
            ServiceName = SearchServiceName;
        }

        /// <summary>
        /// Constructer
        /// </summary>
        public SearchClient(ClientConfig config, OciSigner ociSigner) : base(config, ociSigner)
        {
            ServiceName = SearchServiceName;
        }

        /// <summary>
        /// Constructer
        /// </summary>
        public SearchClient(ClientConfigStream config) : base(config)
        {
            ServiceName = SearchServiceName;
        }

        /// <summary>
        /// Constructer
        /// </summary>
        public SearchClient(ClientConfigStream config, OciSigner ociSigner) : base(config, ociSigner)
        {
            ServiceName = SearchServiceName;
        }

        /// <summary>
        /// Queries any and all compartments in the tenancy to find resources that match the specified criteria.
        /// Results include resources that you have permission to view and can span different resource types.
        /// You can also sort results based on a specified resource attribute.
        /// </summary>
        /// <param name="searchResourcesRequest"></param>
        /// <returns></returns>
        public SearchResourcesResponse SearchResources(SearchResourcesRequest searchResourcesRequest)
        {
            var uri = new Uri(GetEndPoint(SearchServices.RESOURCES, this.Region));

            var webResponse = this.RestClient.Post(uri, searchResourcesRequest.SearchDetails, new HttpRequestHeaderParam() { OpcRequestId = searchResourcesRequest.OpcRequestId });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new SearchResourcesResponse()
                {
                    ResourceSummaryCollection = JsonSerializer.Deserialize<ResourceSummaryCollection>(response),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }
    }
}

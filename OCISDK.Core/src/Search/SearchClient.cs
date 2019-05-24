using OCISDK.Core.src.Common;
using OCISDK.Core.src.Search.Model;
using OCISDK.Core.src.Search.Request;
using OCISDK.Core.src.Search.Response;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OCISDK.Core.src.Search
{
    public class SearchClient : ServiceClient, ISearchClient
    {
        private RestClient RestClient { get; set; }

        /// <summary>
        /// Constructer
        /// </summary>
        public SearchClient(ClientConfig config) : base(config)
        {
            ServiceName = "search";

            Config = config;

            var signer = new Signer(
                config.TenancyId,
                config.UserId,
                config.Fingerprint,
                config.PrivateKeyPath,
                config.PrivateKeyPassphrase);

            JsonSerializer = new JsonDefaultSerializer();

            this.RestClient = new RestClient()
            {
                Signer = signer,
                Config = config,
                JsonSerializer = JsonSerializer
            };

            // default region setting
            if (string.IsNullOrEmpty(config.HomeRegion))
            {
                // set ashburn if no default region found
                Region = Regions.US_ASHBURN_1;
            }
            else
            {
                // home region
                Region = config.HomeRegion;
            }
        }

        public SearchClient(ClientConfig config, RestClient restClient) : base(config)
        {
            ServiceName = "search";

            Config = config;

            RestClient = restClient;

            // default region ashburn
            Region = Regions.US_ASHBURN_1;
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

            var webResponse = this.RestClient.Post(uri, searchResourcesRequest.SearchDetails, searchResourcesRequest.OpcRequestId);

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

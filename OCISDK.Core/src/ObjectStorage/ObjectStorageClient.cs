using OCISDK.Core.src.Common;
using OCISDK.Core.src.ObjectStorage.Model;
using OCISDK.Core.src.ObjectStorage.Request;
using OCISDK.Core.src.ObjectStorage.Response;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OCISDK.Core.src.ObjectStorage
{
    public class ObjectStorageClient : ServiceClient, IObjectStorageClient
    {
        private RestClient RestClient { get; set; }

        /// <summary>
        /// Constructer
        /// </summary>
        public ObjectStorageClient(ClientConfig config) : base(config)
        {
            ServiceName = "object_storage";

            Config = config;

            var signer = new Signer(
                config.TenancyId,
                config.UserId,
                config.Fingerprint,
                config.PrivateKeyPath,
                config.PrivateKeyPassphrase);

            JsonSerializer = new JsonDefaultSerializer();

            RestClient = new RestClient()
            {
                Signer = signer,
                Config = config,
                JsonSerializer = JsonSerializer
            };

            // default region ashburn
            Region = Regions.US_ASHBURN_1;
        }

        public ObjectStorageClient(ClientConfig config, RestClient restClient) : base(config)
        {
            ServiceName = "object_storage";

            Config = config;

            RestClient = restClient;

            // default region ashburn
            Region = Regions.US_ASHBURN_1;
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
        /// Gets the current representation of the given bucket in the given Object Storage namespace.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public GetBucketResponse GetBucket(GetBucketRequest request)
        {
            var uri = new Uri($"{GetEndPointNoneVersion(ObjectStorageServices.Namespace, this.Region)}/{request.NamespaceName}/b/{request.BucketName}/");

            var webResponse = this.RestClient.GetIfMatch(uri, request.IfMatch, request.IfNoneMatch, request.OpcClientRequestId, request.Fields);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new GetBucketResponse()
                {
                    Bucket = JsonSerializer.Deserialize<Bucket>(response),
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcClientRequestId = webResponse.Headers.Get("opc-client-request-id")
                };
            }
        }
    }
}

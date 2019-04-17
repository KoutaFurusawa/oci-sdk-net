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
        /// Each Oracle Cloud Infrastructure tenant is assigned one unique and uneditable Object Storage namespace.
        /// The namespace is a system-generated string assigned during account creation. For some older tenancies, 
        /// the namespace string may be the tenancy name in all lower-case letters. You cannot edit a namespace.
        ///GetNamespace returns the name of the Object Storage namespace for the user making the request.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public string GetNamespace(GetNamespaceRequest request)
        {
            var uri = new Uri($"{GetEndPointNoneVersion(ObjectStorageServices.Namespace, this.Region)}/");

            var webResponse = this.RestClient.GetIfMatch(uri, request.OpcClientRequestId);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return JsonSerializer.Deserialize<string>(response);
            }
        }

        /// <summary>
        /// Gets the metadata for the Object Storage namespace, which contains defaultS3CompartmentId and defaultSwiftCompartmentId.
        /// Any user with the NAMESPACE_READ permission will be able to see the current metadata. 
        /// If you are not authorized, talk to an administrator. If you are an administrator who needs to write policies to give users access, 
        /// see Getting Started with Policies.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public GetNamespaceMetadataResponse GetNamespaceMetadata(GetNamespaceMetadataRequest request)
        {
            var uri = new Uri($"{GetEndPointNoneVersion(ObjectStorageServices.Namespace, this.Region)}/{request.NamespaceName}");

            var webResponse = this.RestClient.GetIfMatch(uri, request.OpcClientRequestId);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new GetNamespaceMetadataResponse()
                {
                    NamespaceMetadata = JsonSerializer.Deserialize<NamespaceMetadata>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcClientRequestId = webResponse.Headers.Get("opc-client-request-id")
                };
            }
        }

        /// <summary>
        /// Gets the current representation of the given bucket in the given Object Storage namespace.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public GetBucketResponse GetBucket(GetBucketRequest request)
        {
            var uri = new Uri($"{GetEndPointNoneVersion(ObjectStorageServices.Bucket(request.NamespaceName), this.Region)}/{request.BucketName}/");

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

        /// <summary>
        /// Gets the metadata and body of an object.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public GetObjectResponse GetObject(GetObjectRequest request)
        {
            var uri = new Uri($"{GetEndPointNoneVersion(ObjectStorageServices.Object(request.NamespaceName, request.BucketName), this.Region)}/{request.ObjectName}");

            var webResponse = this.RestClient.GetIfMatch(uri, request.IfMatch, request.IfNoneMatch, request.OpcClientRequestId, null, request.Range);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader;

                var contentRange = webResponse.Headers.Get("content-range");
                var opcMeta = webResponse.Headers.Get("opc-meta-*");
                
                return new GetObjectResponse()
                {
                    FileURL = uri.ToString(),
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcClientRequestId = webResponse.Headers.Get("opc-client-request-id"),
                    ArchivalState = webResponse.Headers.Get("archival-state"),
                    ContentType = webResponse.Headers.Get("content-type"),
                    ContentLanguage = webResponse.Headers.Get("content-language"),
                    ContentEncoding = webResponse.Headers.Get("content-encoding"),
                    ContentLength = long.Parse(webResponse.Headers.Get("content-length")),
                    ContentMd5 = webResponse.Headers.Get("content-md5"),
                    LastModified = webResponse.Headers.Get("last-modified"),
                    OpcMultipartMd5 = webResponse.Headers.Get("opc-multipart-md5"),
                    TimeOfArchival = webResponse.Headers.Get("time-of-archival")
                };
            }
        }

        /// <summary>
        /// Download Object
        /// </summary>
        /// <param name="request"></param>
        /// <param name="savePath"></param>
        public void DownloadObject(GetObjectRequest request, string savePath)
        {
            var uri = new Uri($"{GetEndPointNoneVersion(ObjectStorageServices.Object(request.NamespaceName, request.BucketName), this.Region)}/{request.ObjectName}");

            var webResponse = this.RestClient.GetIfMatch(uri, request.IfMatch, request.IfNoneMatch, request.OpcClientRequestId, null, request.Range);

            using (var stream = webResponse.GetResponseStream())
            {
                FileStream fs = new FileStream(savePath, FileMode.Create, FileAccess.Write);
                byte[] readData = new byte[1024];
                while(true)
                {
                    int readSize = stream.Read(readData, 0, readData.Length);
                    if (readSize == 0)
                    {
                        break;
                    }
                    fs.Write(readData, 0, readSize);
                }
                fs.Close();
            }
        }

        /// <summary>
        /// Gets a list of all BucketSummary items in a compartment. A BucketSummary contains only summary fields for the bucket and does not 
        /// contain fields like the user-defined metadata.
        /// To use this and other API operations, you must be authorized in an IAM policy. If you are not authorized, talk to an administrator. 
        /// If you are an administrator who needs to write policies to give users access, see Getting Started with Policies.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ListBucketsResponse ListBuckets(ListBucketsRequest request)
        {
            var uri = new Uri($"{GetEndPointNoneVersion(ObjectStorageServices.Bucket(request.NamespaceName), this.Region)}?{request.GetOptionQuery()}");

            var webResponse = this.RestClient.GetIfMatch(uri, request.OpcClientRequestId);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListBucketsResponse()
                {
                    Items = JsonSerializer.Deserialize<List<BucketSummary>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcClientRequestId = webResponse.Headers.Get("opc-client-request-id")
                };
            }
        }

        /// <summary>
        /// To use this and other API operations, you must be authorized in an IAM policy. If you are not authorized, talk to an administrator. 
        /// If you are an administrator who needs to write policies to give users access, see Getting Started with Policies.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ListObjectsResponse ListObjects(ListObjectsRequest request)
        {
            var uri = new Uri($"{GetEndPointNoneVersion(ObjectStorageServices.Object(request.NamespaceName, request.BucketName), this.Region)}?{request.GetOptionQuery()}");

            var webResponse = this.RestClient.GetIfMatch(uri, request.OpcClientRequestId);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListObjectsResponse()
                {
                    ListObjects = JsonSerializer.Deserialize<ListObjectDetails>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcClientRequestId = webResponse.Headers.Get("opc-client-request-id")
                };
            }
        }
    }
}

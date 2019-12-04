using OCISDK.Core.Common;
using OCISDK.Core.ObjectStorage.Model;
using OCISDK.Core.ObjectStorage.Request;
using OCISDK.Core.ObjectStorage.Response;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace OCISDK.Core.ObjectStorage
{
    /// <summary>
    /// ObjectStorageClientAsync
    /// </summary>
    public class ObjectStorageClientAsync : ServiceClient, IObjectStorageClientAsync
    {
        private readonly string ObjectStorageServiceName = "object_storage";

        /// <summary>
        /// Constructer
        /// </summary>
        public ObjectStorageClientAsync(ClientConfig config) : base(config)
        {
            ServiceName = ObjectStorageServiceName;
        }

        /// <summary>
        /// Constructer
        /// </summary>
        public ObjectStorageClientAsync(ClientConfig config, OciSigner ociSigner) : base(config, ociSigner)
        {
            ServiceName = ObjectStorageServiceName;
        }

        /// <summary>
        /// Constructer
        /// </summary>
        public ObjectStorageClientAsync(ClientConfigStream config) : base(config)
        {
            ServiceName = ObjectStorageServiceName;
        }

        /// <summary>
        /// Constructer
        /// </summary>
        public ObjectStorageClientAsync(ClientConfigStream config, OciSigner ociSigner) : base(config, ociSigner)
        {
            ServiceName = ObjectStorageServiceName;
        }
        
        /// <summary>
        /// Each Oracle Cloud Infrastructure tenant is assigned one unique and uneditable Object Storage namespace.
        /// The namespace is a system-generated string assigned during account creation. For some older tenancies, 
        /// the namespace string may be the tenancy name in all lower-case letters. You cannot edit a namespace.
        ///GetNamespace returns the name of the Object Storage namespace for the user making the request.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<string> GetNamespace(GetNamespaceRequest request)
        {
            var uri = new Uri($"{GetEndPointNoneVersion(ObjectStorageServices.Namespace, this.Region)}/");

            var webResponse = await this.RestClientAsync.Get(uri, new HttpRequestHeaderParam(){ OpcClientRequestId = request.OpcClientRequestId });

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
        public async Task<GetNamespaceMetadataResponse> GetNamespaceMetadata(GetNamespaceMetadataRequest request)
        {
            var uri = new Uri($"{GetEndPointNoneVersion(ObjectStorageServices.Namespace, this.Region)}/{request.NamespaceName}");

            var webResponse = await this.RestClientAsync.Get(uri, new HttpRequestHeaderParam() { OpcClientRequestId = request.OpcClientRequestId });

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
        public async Task<GetBucketResponse> GetBucket(GetBucketRequest request)
        {
            var uri = new Uri($"{GetEndPointNoneVersion(ObjectStorageServices.Bucket(request.NamespaceName), this.Region)}/{request.BucketName}/");

            var httpRequestHeaderParam = new HttpRequestHeaderParam() {
                IfMatch = request.IfMatch,
                IfNoneMatch = request.IfNoneMatch,
                OpcClientRequestId = request.OpcClientRequestId
            };
            var webResponse = await this.RestClientAsync.Get(uri, httpRequestHeaderParam, request.Fields);

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
        /// Efficiently checks to see if a bucket exists and gets the current entity tag (ETag) for the bucket.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<HeadBucketResponse> HeadBucket(HeadBucketRequest request)
        {
            var uri = new Uri($"{GetEndPointNoneVersion(ObjectStorageServices.Bucket(request.NamespaceName, request.BucketName), this.Region)}");

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                IfMatch = request.IfMatch,
                IfNoneMatch = request.IfNoneMatch,
                OpcClientRequestId = request.OpcClientRequestId
            };
            var webResponse = await this.RestClientAsync.Head(uri, httpRequestHeaderParam);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                return new HeadBucketResponse()
                {
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
        public async Task<GetObjectResponse> GetObject(GetObjectRequest request)
        {
            var uri = new Uri($"{GetEndPointNoneVersion(ObjectStorageServices.Object(request.NamespaceName, request.BucketName), this.Region)}/{request.ObjectName}");

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                IfMatch = request.IfMatch,
                IfNoneMatch = request.IfNoneMatch,
                OpcClientRequestId = request.OpcClientRequestId,
                Range = request.Range
            };
            var webResponse = await this.RestClientAsync.Get(uri, httpRequestHeaderParam);

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
        /// <param name="filename"></param>
        public async Task DownloadObject(GetObjectRequest request, string savePath, string filename)
        {
            var uri = new Uri($"{GetEndPointNoneVersion(ObjectStorageServices.Object(request.NamespaceName, request.BucketName), this.Region)}/{request.ObjectName}");

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                IfMatch = request.IfMatch,
                IfNoneMatch = request.IfNoneMatch,
                OpcClientRequestId = request.OpcClientRequestId,
                Range = request.Range
            };
            var webResponse = await this.RestClientAsync.Get(uri, httpRequestHeaderParam);

            using (var stream = webResponse.GetResponseStream())
            using (var fs = new FileStream($"{savePath}/{filename}", FileMode.Create, FileAccess.Write))
            {
                byte[] readData = new byte[1024];
                while (true)
                {
                    int readSize = stream.Read(readData, 0, readData.Length);
                    if (readSize == 0)
                    {
                        break;
                    }
                    fs.Write(readData, 0, readSize);
                }
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
        public async Task<ListBucketsResponse> ListBuckets(ListBucketsRequest request)
        {
            var uri = new Uri($"{GetEndPointNoneVersion(ObjectStorageServices.Bucket(request.NamespaceName), this.Region)}?{request.GetOptionQuery()}");

            var webResponse = await this.RestClientAsync.Get(uri, new HttpRequestHeaderParam() { OpcClientRequestId = request.OpcClientRequestId });

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
        public async Task<ListObjectsResponse> ListObjects(ListObjectsRequest request)
        {
            var uri = new Uri($"{GetEndPointNoneVersion(ObjectStorageServices.Object(request.NamespaceName, request.BucketName), this.Region)}?{request.GetOptionQuery()}");

            var webResponse = await this.RestClientAsync.Get(uri, new HttpRequestHeaderParam() { OpcClientRequestId = request.OpcClientRequestId });

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

        /// <summary>
        /// Creates a bucket in the given namespace with a bucket name and optional user-defined metadata. Avoid entering confidential information in bucket names.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CreateBucketResponse> CreateBucket(CreateBucketRequest request)
        {
            var uri = new Uri(GetEndPointNoneVersion(ObjectStorageServices.Bucket(request.NamespaceName), this.Region));

            var webResponse = await this.RestClientAsync.Post(uri, request.CreateBucketDetails, new HttpRequestHeaderParam() { OpcClientRequestId = request.OpcClientRequestId });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new CreateBucketResponse()
                {
                    Bucket = JsonSerializer.Deserialize<Bucket>(response),
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcClientRequestId = webResponse.Headers.Get("opc-client-request-id"),
                    Location = webResponse.Headers.Get("Location")
                };
            }
        }

        /// <summary>
        /// By default, buckets created using the Amazon S3 Compatibility API or the Swift API are created in the root compartment of the Oracle Cloud Infrastructure tenancy.
        /// 
        /// You can change the default Swift/Amazon S3 compartmentId designation to a different compartmentId. 
        /// All subsequent bucket creations will use the new default compartment, but no previously created buckets will be modified. 
        /// A user must have OBJECTSTORAGE_NAMESPACE_UPDATE permission to make changes to the default compartments for Amazon S3 and Swift.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<UpdateNamespaceMetadataResponse> UpdateNamespaceMetadata(UpdateNamespaceMetadataRequest request)
        {
            var uri = new Uri($"{GetEndPointNoneVersion(ObjectStorageServices.Namespace, this.Region)}/{request.NamespaceName}");

            var webResponse = await this.RestClientAsync.Post(uri, request.UpdateNamespaceMetadataDetails, new HttpRequestHeaderParam() { OpcClientRequestId = request.OpcClientRequestId });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new UpdateNamespaceMetadataResponse()
                {
                    NamespaceMetadata = JsonSerializer.Deserialize<NamespaceMetadata>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcClientRequestId = webResponse.Headers.Get("opc-client-request-id")
                };
            }
        }

        /// <summary>
        /// Performs a partial or full update of a bucket's user-defined metadata.
        /// 
        /// Use UpdateBucket to move a bucket from one compartment to another within the same tenancy. 
        /// Supply the compartmentID of the compartment that you want to move the bucket to. 
        /// For more information about moving resources between compartments, see Moving Resources to a Different Compartment.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<UpdateBucketResponse> UpdateBucket(UpdateBucketRequest request)
        {
            var uri = new Uri(GetEndPointNoneVersion(ObjectStorageServices.Bucket(request.NamespaceName, request.BucketName), this.Region));

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                IfMatch = request.IfMatch,
                OpcClientRequestId = request.OpcClientRequestId
            };
            var webResponse = await this.RestClientAsync.Post(uri, request.UpdateBucketDetails, httpRequestHeaderParam);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new UpdateBucketResponse()
                {
                    Bucket = JsonSerializer.Deserialize<Bucket>(response),
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcClientRequestId = webResponse.Headers.Get("opc-client-request-id")
                };
            }
        }

        /// <summary>
        /// Deletes a bucket if the bucket is already empty. 
        /// If the bucket is not empty, use DeleteObject first. 
        /// In addition, you cannot delete a bucket that has a multipart upload in progress or a pre-authenticated request associated with that bucket.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<DeleteBucketResponse> DeleteBucket(DeleteBucketRequest request)
        {
            var uri = new Uri(GetEndPointNoneVersion(ObjectStorageServices.Bucket(request.NamespaceName, request.BucketName), this.Region));

            var webResponse = await this.RestClientAsync.Delete(uri, new HttpRequestHeaderParam() { IfMatch = request.IfMatch });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new DeleteBucketResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcClientRequestId = webResponse.Headers.Get("opc-client-request-id")
                };
            }
        }
    }
}

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
        /// Gets the object lifecycle policy for the bucket.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<GetObjectLifecyclePolicyResponse> GetObjectLifecyclePolicy(GetObjectLifecyclePolicyRequest request)
        {
            var uri = new Uri($"{GetEndPointNoneVersion(ObjectStorageServices.Bucket(request.NamespaceName, request.BucketName), this.Region)}/l");

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                OpcClientRequestId = request.OpcClientRequestId
            };
            var webResponse = await this.RestClientAsync.Get(uri, httpRequestHeaderParam);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new GetObjectLifecyclePolicyResponse()
                {
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcClientRequestId = webResponse.Headers.Get("opc-client-request-id"),
                    ObjectLifecyclePolicy = JsonSerializer.Deserialize<ObjectLifecyclePolicyDetails>(response)
                };
            }
        }

        /// <summary>
        /// Gets the pre-authenticated request for the bucket.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<GetPreauthenticatedRequestResponse> GetPreauthenticatedRequest(GetPreauthenticatedRequestRequest request)
        {
            var uri = new Uri($"{GetEndPointNoneVersion(ObjectStorageServices.Bucket(request.NamespaceName, request.BucketName), this.Region)}/p/{request.ParId}");

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                OpcClientRequestId = request.OpcClientRequestId
            };
            var webResponse = await this.RestClientAsync.Get(uri, httpRequestHeaderParam);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new GetPreauthenticatedRequestResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcClientRequestId = webResponse.Headers.Get("opc-client-request-id"),
                    PreauthenticatedRequestSummary = JsonSerializer.Deserialize<PreauthenticatedRequestSummary>(response)
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
        /// Lists the parts of an in-progress multipart upload.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ListMultipartUploadPartsResponse> ListMultipartUploadParts(ListMultipartUploadPartsRequest request)
        {
            var uri = new Uri($"{GetEndPointNoneVersion(ObjectStorageServices.Bucket(request.NamespaceName, request.BucketName), this.Region)}/u/{request.ObjectName}?{request.GetOptionQuery()}");

            var webResponse = await this.RestClientAsync.Get(uri, new HttpRequestHeaderParam { OpcClientRequestId = request.OpcClientRequestId });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListMultipartUploadPartsResponse()
                {
                    Items = JsonSerializer.Deserialize<List<MultipartUploadPartSummary>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcClientRequestId = webResponse.Headers.Get("opc-client-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
        }

        /// <summary>
        /// Lists all of the in-progress multipart uploads for the given bucket in the given Object Storage namespace.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ListMultipartUploadsResponse> ListMultipartUploads(ListMultipartUploadsRequest request)
        {
            var uriStr = $"{GetEndPointNoneVersion(ObjectStorageServices.Bucket(request.NamespaceName, request.BucketName), this.Region)}/u";
            var optional = request.GetOptionQuery();
            if (!string.IsNullOrEmpty(optional))
            {
                uriStr = $"{uriStr}?{optional}";
            }

            var uri = new Uri(uriStr);

            var webResponse = await this.RestClientAsync.Get(uri, new HttpRequestHeaderParam { OpcClientRequestId = request.OpcClientRequestId });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListMultipartUploadsResponse()
                {
                    Items = JsonSerializer.Deserialize<List<MultipartUploadDetails>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcClientRequestId = webResponse.Headers.Get("opc-client-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
        }

        /// <summary>
        /// Lists pre-authenticated requests for the bucket.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ListPreauthenticatedRequestsResponse> ListPreauthenticatedRequests(ListPreauthenticatedRequestsRequest request)
        {
            var uriStr = $"{GetEndPointNoneVersion(ObjectStorageServices.Object(request.NamespaceName, request.BucketName), this.Region)}/p";
            var optional = request.GetOptionQuery();
            if (!string.IsNullOrEmpty(optional))
            {
                uriStr = $"{uriStr}?{optional}";
            }

            var uri = new Uri(uriStr);

            var webResponse = await this.RestClientAsync.Get(uri, new HttpRequestHeaderParam { OpcClientRequestId = request.OpcClientRequestId });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListPreauthenticatedRequestsResponse()
                {
                    Items = JsonSerializer.Deserialize<List<PreauthenticatedRequestSummary>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcClientRequestId = webResponse.Headers.Get("opc-client-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
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
        /// Rename an object in the given Object Storage namespace.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<RenameObjectResponse> RenameObject(RenameObjectRequest request)
        {
            var uri = new Uri($"{GetEndPointNoneVersion(ObjectStorageServices.Bucket(request.NamespaceName, request.BucketName), this.Region)}/actions/renameObject");

            var webResponse = await this.RestClientAsync.Post(uri, request.RenameObjectDetails, new HttpRequestHeaderParam() { OpcClientRequestId = request.OpcClientRequestId });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new RenameObjectResponse()
                {
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcClientRequestId = webResponse.Headers.Get("opc-client-request-id"),
                    LastModified = webResponse.Headers.Get("last-modified")
                };
            }
        }

        /// <summary>
        /// Restores one or more objects specified by the objectName parameter. By default objects will be restored for 24 hours. Duration can be configured using the hours parameter.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<RestoreObjectsResponse> RestoreObjects(RestoreObjectsRequest request)
        {
            var uri = new Uri($"{GetEndPointNoneVersion(ObjectStorageServices.Bucket(request.NamespaceName, request.BucketName), this.Region)}/actions/restoreObjects");

            var webResponse = await this.RestClientAsync.Post(uri, request.RestoreObjectsDetails, new HttpRequestHeaderParam() { OpcClientRequestId = request.OpcClientRequestId });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new RestoreObjectsResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcClientRequestId = webResponse.Headers.Get("opc-client-request-id")
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
        /// Creates a new object or overwrites an existing object with the same name. The maximum object size allowed by PutObject is 50 GiB.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<PutObjectResponse> PutObject(PutObjectRequest request)
        {
            var uri = new Uri($"{GetEndPointNoneVersion(ObjectStorageServices.Object(request.NamespaceName, request.BucketName), this.Region)}/{request.ObjectName}");

            HttpRequestHeaderParam HttpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                IfMatch = request.IfMatch,
                IfNoneMatch = request.IfNoneMatch,
                Expect = request.Expect,
                ContentLength = request.ContentLength,
                ContentMD5 = request.ContentMD5,
                OpcClientRequestId = request.OpcClientRequestId,
                ContentType = request.ContentType,
                ContentLanguage = request.ContentLanguage,
                ContentEncoding = request.ContentEncoding,
                ContentDisposition = request.ContentDisposition,
                CacheControl = request.CacheControl,
                OpcMeta = request.OpcMeta
            };
            var webResponse = await this.RestClientAsync.Put(uri, request.UploadPartBody, HttpRequestHeaderParam);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new PutObjectResponse()
                {
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcClientRequestId = webResponse.Headers.Get("opc-client-request-id"),
                    OpcContentMd5 = webResponse.Headers.Get("opc-content-md5"),
                    LastModified = webResponse.Headers.Get("last-modified")
                };
            }
        }

        /// <summary>
        /// Uploads a single part of a multipart upload.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<UploadPartResponse> UploadPart(UploadPartRequest request)
        {
            var uri = new Uri(
                $"{GetEndPointNoneVersion(ObjectStorageServices.Bucket(request.NamespaceName, request.BucketName), this.Region)}/u/{request.ObjectName}?" +
                $"uploadId={request.UploadId}&uploadPartNum={request.UploadPartNum}");

            HttpRequestHeaderParam HttpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                IfMatch = request.IfMatch,
                OpcClientRequestId = request.OpcClientRequestId
            };
            var webResponse = await this.RestClientAsync.Put(uri, request.UploadPartBody, HttpRequestHeaderParam);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new UploadPartResponse()
                {
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcClientRequestId = webResponse.Headers.Get("opc-client-request-id"),
                    OpcContentMd5 = webResponse.Headers.Get("opc-content-md5")
                };
            }
        }

        /// <summary>
        /// Creates or replaces the object lifecycle policy for the bucket.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<PutObjectLifecyclePolicyResponse> PutObjectLifecyclePolicy(PutObjectLifecyclePolicyRequest request)
        {
            var uri = new Uri(
                $"{GetEndPointNoneVersion(ObjectStorageServices.Bucket(request.NamespaceName, request.BucketName), this.Region)}/l");

            HttpRequestHeaderParam HttpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                IfMatch = request.IfMatch,
                IfNoneMatch = request.IfNoneMatch,
                OpcClientRequestId = request.OpcClientRequestId
            };
            var webResponse = await this.RestClientAsync.Put(uri, request.PutObjectLifecyclePolicyDetails, HttpRequestHeaderParam);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new PutObjectLifecyclePolicyResponse()
                {
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcClientRequestId = webResponse.Headers.Get("opc-client-request-id")
                };
            }
        }

        /// <summary>
        /// Re-encrypts the unique data encryption key that encrypts each object written to the bucket by using the most recent version of the master encryption key assigned to the bucket.
        /// (All data encryption keys are encrypted by a master encryption key. Master encryption keys are assigned to buckets and managed by Oracle by default, but you can assign a key that 
        /// you created and control through the Oracle Cloud Infrastructure Key Management service.) The kmsKeyId property of the bucket determines which master encryption key is assigned to the 
        /// bucket. If you assigned a different Key Management master encryption key to the bucket, you can call this API to re-encrypt all data encryption keys with the newly assigned key. 
        /// Similarly, you might want to re-encrypt all data encryption keys if the assigned key has been rotated to a new key version since objects were last added to the bucket. If you call this 
        /// API and there is no kmsKeyId associated with the bucket, the call will fail.
        /// 
        /// Calling this API starts a work request task to re-encrypt the data encryption key of all objects in the bucket. Only objects created before the time of the API call will be re-encrypted. 
        /// The call can take a long time, depending on how many objects are in the bucket and how big they are. This API returns a work request ID that you can use to retrieve the status of the 
        /// work request task.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ReencryptBucketResponse> ReencryptBucket(ReencryptBucketRequest request)
        {
            var uri = new Uri($"{GetEndPointNoneVersion(ObjectStorageServices.Bucket(request.NamespaceName, request.BucketName), this.Region)}/actions/reencrypt");

            HttpRequestHeaderParam HttpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                OpcClientRequestId = request.OpcClientRequestId
            };
            var webResponse = await this.RestClientAsync.Post(uri, null, HttpRequestHeaderParam);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ReencryptBucketResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcWorkRequestId = webResponse.Headers.Get("opc-work-request-id"),
                    OpcClientRequestId = webResponse.Headers.Get("opc-client-request-id")
                };
            }
        }

        /// <summary>
        /// Starts a new multipart upload to a specific object in the given bucket in the given namespace.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CreateMultipartUploadResponse> CreateMultipartUpload(CreateMultipartUploadRequest request)
        {
            var uri = new Uri($"{GetEndPointNoneVersion(ObjectStorageServices.Bucket(request.NamespaceName, request.BucketName), this.Region)}/u");

            HttpRequestHeaderParam HttpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                IfMatch = request.IfMatch,
                IfNoneMatch = request.IfNoneMatch,
                OpcClientRequestId = request.OpcClientRequestId
            };
            var webResponse = await this.RestClientAsync.Post(uri, request.CreateMultipartUploadDetails, HttpRequestHeaderParam);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new CreateMultipartUploadResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcClientRequestId = webResponse.Headers.Get("opc-client-request-id"),
                    Location = webResponse.Headers.Get("Location")
                };
            }
        }

        /// <summary>
        /// Commits a multipart upload, which involves checking part numbers and entity tags (ETags) of the parts, to create an aggregate object.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CommitMultipartUploadResponse> CommitMultipartUpload(CommitMultipartUploadRequest request)
        {
            var uri = new Uri($"{GetEndPointNoneVersion(ObjectStorageServices.Bucket(request.NamespaceName, request.BucketName), this.Region)}/u/{request.ObjectName}?uploadId={request.UploadId}");

            HttpRequestHeaderParam HttpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                IfMatch = request.IfMatch,
                IfNoneMatch = request.IfNoneMatch,
                OpcClientRequestId = request.OpcClientRequestId
            };
            var webResponse = await this.RestClientAsync.Post(uri, request.CommitMultipartUploadDetails, HttpRequestHeaderParam);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new CommitMultipartUploadResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcMultipartMd5 = webResponse.Headers.Get("opc-multipart-md5"),
                    OpcClientRequestId = webResponse.Headers.Get("opc-client-request-id"),
                    ETag = webResponse.Headers.Get("ETag"),
                    LastModified = webResponse.Headers.Get("last-modified")
                };
            }
        }

        /// <summary>
        /// Creates a pre-authenticated request specific to the bucket.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CreatePreauthenticatedRequestResponse> CreatePreauthenticatedRequest(CreatePreauthenticatedRequestRequest request)
        {
            var uri = new Uri($"{GetEndPointNoneVersion(ObjectStorageServices.Bucket(request.NamespaceName, request.BucketName), this.Region)}/p");

            HttpRequestHeaderParam HttpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                OpcClientRequestId = request.OpcClientRequestId
            };
            var webResponse = await this.RestClientAsync.Post(uri, request.CreatePreauthenticatedRequestDetails, HttpRequestHeaderParam);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new CreatePreauthenticatedRequestResponse()
                {
                    PreauthenticatedRequest = JsonSerializer.Deserialize<PreauthenticatedRequestDetails>(response),
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

        /// <summary>
        /// Deletes an object.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<DeleteObjectResponse> DeleteObject(DeleteObjectRequest request)
        {
            var uri = new Uri($"{GetEndPointNoneVersion(ObjectStorageServices.Object(request.NamespaceName, request.BucketName), this.Region)}/{request.ObjectName}");

            var headers = new HttpRequestHeaderParam()
            {
                IfMatch = request.IfMatch,
                OpcClientRequestId = request.OpcClientRequestId
            };

            var webResponse = await this.RestClientAsync.Delete(uri, headers);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new DeleteObjectResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcClientRequestId = webResponse.Headers.Get("opc-client-request-id"),
                    LastModified = webResponse.Headers.Get("last-modified")
                };
            }
        }

        /// <summary>
        /// Deletes the object lifecycle policy for the bucket.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<DeleteObjectLifecyclePolicyResponse> DeleteObjectLifecyclePolicy(DeleteObjectLifecyclePolicyRequest request)
        {
            var uri = new Uri($"{GetEndPointNoneVersion(ObjectStorageServices.Bucket(request.NamespaceName, request.BucketName), this.Region)}/l");

            var headers = new HttpRequestHeaderParam()
            {
                IfMatch = request.IfMatch,
                OpcClientRequestId = request.OpcClientRequestId
            };

            var webResponse = await this.RestClientAsync.Delete(uri, headers);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new DeleteObjectLifecyclePolicyResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcClientRequestId = webResponse.Headers.Get("opc-client-request-id")
                };
            }
        }

        /// <summary>
        /// Deletes the pre-authenticated request for the bucket.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<DeletePreauthenticatedRequestResponse> DeletePreauthenticatedRequest(DeletePreauthenticatedRequestRequest request)
        {
            var uri = new Uri($"{GetEndPointNoneVersion(ObjectStorageServices.Bucket(request.NamespaceName, request.BucketName), this.Region)}/p{request.ParId}");

            var headers = new HttpRequestHeaderParam()
            {
                OpcClientRequestId = request.OpcClientRequestId
            };

            var webResponse = await this.RestClientAsync.Delete(uri, headers);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new DeletePreauthenticatedRequestResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcClientRequestId = webResponse.Headers.Get("opc-client-request-id")
                };
            }
        }

        /// <summary>
        /// Aborts an in-progress multipart upload and deletes all parts that have been uploaded.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<AbortMultipartUploadResponse> AbortMultipartUpload(AbortMultipartUploadRequest request)
        {
            var uri = new Uri($"{GetEndPointNoneVersion(ObjectStorageServices.Bucket(request.NamespaceName, request.BucketName), this.Region)}/u/{request.ObjectName}?uploadId={request.UploadId}");

            var webResponse = await this.RestClientAsync.Delete(uri, new HttpRequestHeaderParam() { OpcClientRequestId = request.OpcClientRequestId });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new AbortMultipartUploadResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcClientRequestId = webResponse.Headers.Get("opc-client-request-id")
                };
            }
        }
    }
}

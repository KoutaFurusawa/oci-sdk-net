using OCISDK.Core.Common;
using OCISDK.Core.ObjectStorage.IO;
using OCISDK.Core.ObjectStorage.Model;
using OCISDK.Core.ObjectStorage.Request;
using OCISDK.Core.ObjectStorage.Response;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace OCISDK.Core.ObjectStorage
{
    /// <summary>
    /// ObjectStorageClient
    /// </summary>
    public class ObjectStorageClient : ServiceClient, IObjectStorageClient
    {
        private readonly string ObjectStorageServiceName = "object_storage";

        /// <summary>
        /// Constructer
        /// </summary>
        public ObjectStorageClient(ClientConfig config) : base(config)
        {
            ServiceName = ObjectStorageServiceName;
        }

        /// <summary>
        /// Constructer
        /// </summary>
        public ObjectStorageClient(ClientConfig config, IOciSigner ociSigner) : base(config, ociSigner)
        {
            ServiceName = ObjectStorageServiceName;
        }

        /// <summary>
        /// Constructer
        /// </summary>
        public ObjectStorageClient(ClientConfigStream config) : base(config)
        {
            ServiceName = ObjectStorageServiceName;
        }

        /// <summary>
        /// Constructer
        /// </summary>
        public ObjectStorageClient(ClientConfigStream config, IOciSigner ociSigner) : base(config, ociSigner)
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
        public string GetNamespace(GetNamespaceRequest request)
        {
            var uri = new Uri($"{GetEndPointNoneVersion(ObjectStorageServices.Namespace, this.Region)}/");

            using (var webResponse = this.RestClient.Get(uri, new HttpRequestHeaderParam { OpcClientRequestId = request.OpcClientRequestId }))
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

            using (var webResponse = this.RestClient.Get(uri, new HttpRequestHeaderParam { OpcClientRequestId = request.OpcClientRequestId }))
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

            var httpRequestHeaderParam = new HttpRequestHeaderParam() {
                IfMatch = request.IfMatch,
                IfNoneMatch = request.IfNoneMatch,
                OpcClientRequestId = request.OpcClientRequestId
            };
            using (var webResponse = this.RestClient.Get(uri, httpRequestHeaderParam, request.Fields))
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
        public HeadBucketResponse HeadBucket(HeadBucketRequest request)
        {
            var uri = new Uri($"{GetEndPointNoneVersion(ObjectStorageServices.Bucket(request.NamespaceName, request.BucketName), this.Region)}");

            var httpRequestHeaderParam = new HttpRequestHeaderParam() {
                IfMatch = request.IfMatch,
                IfNoneMatch = request.IfNoneMatch,
                OpcClientRequestId = request.OpcClientRequestId
            };
            using (var webResponse = this.RestClient.Head(uri, httpRequestHeaderParam))
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
        /// Gets the user-defined metadata and entity tag (ETag) for an object.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public HeadObjectResponse HeadObject(HeadObjectRequest request)
        {
            var uri = new Uri($"{GetEndPointNoneVersion(ObjectStorageServices.Object(request.NamespaceName, request.BucketName), this.Region)}/{request.ObjectName}");

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                IfMatch = request.IfMatch,
                IfNoneMatch = request.IfNoneMatch,
                OpcClientRequestId = request.OpcClientRequestId
            };
            using (var webResponse = this.RestClient.Head(uri, httpRequestHeaderParam))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                return new HeadObjectResponse()
                {
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
                    TimeOfArchival = webResponse.Headers.Get("time-of-archival"),
                    CacheControl = webResponse.Headers.Get("cache-control"),
                    ContentDisposition = webResponse.Headers.Get("content-disposition")
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

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                IfMatch = request.IfMatch,
                IfNoneMatch = request.IfNoneMatch,
                OpcClientRequestId = request.OpcClientRequestId,
                Range = request.Range
            };
            using (var webResponse = this.RestClient.Get(uri, httpRequestHeaderParam))
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
        public GetObjectLifecyclePolicyResponse GetObjectLifecyclePolicy(GetObjectLifecyclePolicyRequest request)
        {
            var uri = new Uri($"{GetEndPointNoneVersion(ObjectStorageServices.Bucket(request.NamespaceName, request.BucketName), this.Region)}/l");

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                OpcClientRequestId = request.OpcClientRequestId
            };
            using (var webResponse = this.RestClient.Get(uri, httpRequestHeaderParam))
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
        public GetPreauthenticatedRequestResponse GetPreauthenticatedRequest(GetPreauthenticatedRequestRequest request)
        {
            var uri = new Uri($"{GetEndPointNoneVersion(ObjectStorageServices.Bucket(request.NamespaceName, request.BucketName), this.Region)}/p/{request.ParId}");

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                OpcClientRequestId = request.OpcClientRequestId
            };
            using (var webResponse = this.RestClient.Get(uri, httpRequestHeaderParam))
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
        public bool? DownloadObject(GetObjectRequest request, string savePath)
        {
            savePath = ObjectStorageHelper.EncodeKey(savePath);

            var dirs = savePath.Split('/');

            string fileName = dirs[dirs.Length - 1];
            string newPath = "";
            for (var i = 0; i < dirs.Length - 1; i++)
            {
                newPath = $"{newPath}{dirs[i]}/";
            }

            return DownloadObject(request, newPath, fileName);
        }

        /// <summary>
        /// Download Object
        /// </summary>
        /// <param name="request"></param>
        /// <param name="savePath"></param>
        /// <param name="filename"></param>
        public bool? DownloadObject(GetObjectRequest request, string savePath, string filename)
        {
            savePath = ObjectStorageHelper.EncodeKey(savePath);

            Uri uri = new Uri($"{GetEndPointNoneVersion(ObjectStorageServices.Object(request.NamespaceName, request.BucketName), this.Region)}/{request.ObjectName}");

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                IfMatch = request.IfMatch,
                IfNoneMatch = request.IfNoneMatch,
                OpcClientRequestId = request.OpcClientRequestId,
                Range = request.Range
            };

            if (!Directory.Exists(savePath))
            {
                Directory.CreateDirectory(savePath);
            }

            string path = savePath;
            if (path[path.Length - 1] != '/')
            {
                path = $"{path}/";
            }

            if (!string.IsNullOrEmpty(filename))
            {
                path = $"{path}{filename}";
            }
            else
            {
                if (request.ObjectName.IndexOf('/') != -1)
                {
                    var strs = request.ObjectName.Split('/');
                    path = $"{path}{strs[strs.Length - 1]}";
                }
                else
                {
                    path = $"{path}{request.ObjectName}";
                }
            }

            try
            {
                using (var webResponse = this.RestClient.Get(uri, httpRequestHeaderParam))
                using (var stream = webResponse.GetResponseStream())
                using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
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
            catch (WebException we)
            {
                if (we.Status.Equals(WebExceptionStatus.ProtocolError) && ((HttpWebResponse)we.Response).StatusCode == HttpStatusCode.NotFound)
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }

            return true;
        }

        /// <summary>
        /// Get the replication policy.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public GetReplicationPolicyResponse GetReplicationPolicy(GetReplicationPolicyRequest request)
        {
            var uri = new Uri($"{GetEndPointNoneVersion(ObjectStorageServices.Bucket(request.NamespaceName, request.BucketName), this.Region)}/replicationPolicies/{request.ReplicationId}");

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                OpcClientRequestId = request.OpcClientRequestId
            };
            using (var webResponse = this.RestClient.Get(uri, httpRequestHeaderParam))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new GetReplicationPolicyResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcClientRequestId = webResponse.Headers.Get("opc-client-request-id"),
                    ReplicationPolicy = JsonSerializer.Deserialize<ReplicationPolicy>(response)
                };
            }
        }

        /// <summary>
        /// Get the specified retention rule.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public GetRetentionRuleResponse GetRetentionRule(GetRetentionRuleRequest request)
        {
            var uri = new Uri($"{GetEndPointNoneVersion(ObjectStorageServices.Bucket(request.NamespaceName, request.BucketName), this.Region)}/retentionRules/{request.RetentionRuleId}");

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                OpcClientRequestId = request.OpcClientRequestId
            };
            using (var webResponse = this.RestClient.Get(uri, httpRequestHeaderParam))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new GetRetentionRuleResponse()
                {
                    Etag = webResponse.Headers.Get("etag"),
                    LastModified = webResponse.Headers.Get("last-modified"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcClientRequestId = webResponse.Headers.Get("opc-client-request-id"),
                    RetentionRule = JsonSerializer.Deserialize<RetentionRule>(response)
                };
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

            using (var webResponse = this.RestClient.Get(uri, new HttpRequestHeaderParam { OpcClientRequestId = request.OpcClientRequestId }))
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

            using (var webResponse = this.RestClient.Get(uri, new HttpRequestHeaderParam { OpcClientRequestId = request.OpcClientRequestId }))
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
        public ListMultipartUploadPartsResponse ListMultipartUploadParts(ListMultipartUploadPartsRequest request)
        {
            var uri = new Uri($"{GetEndPointNoneVersion(ObjectStorageServices.Object(request.NamespaceName, request.BucketName), this.Region)}/u/{request.ObjectName}?{request.GetOptionQuery()}");

            using (var webResponse = this.RestClient.Get(uri, new HttpRequestHeaderParam { OpcClientRequestId = request.OpcClientRequestId }))
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
        public ListMultipartUploadsResponse ListMultipartUploads(ListMultipartUploadsRequest request)
        {
            var uriStr = $"{GetEndPointNoneVersion(ObjectStorageServices.Object(request.NamespaceName, request.BucketName), this.Region)}/u";
            var optional = request.GetOptionQuery();
            if(!string.IsNullOrEmpty(optional))
            {
                uriStr = $"{uriStr}?{optional}";
            }

            var uri = new Uri(uriStr);

            using (var webResponse = this.RestClient.Get(uri, new HttpRequestHeaderParam { OpcClientRequestId = request.OpcClientRequestId }))
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
        public ListPreauthenticatedRequestsResponse ListPreauthenticatedRequests(ListPreauthenticatedRequestsRequest request)
        {
            var uriStr = $"{GetEndPointNoneVersion(ObjectStorageServices.Object(request.NamespaceName, request.BucketName), this.Region)}/p";
            var optional = request.GetOptionQuery();
            if (!string.IsNullOrEmpty(optional))
            {
                uriStr = $"{uriStr}?{optional}";
            }

            var uri = new Uri(uriStr);

            using (var webResponse = this.RestClient.Get(uri, new HttpRequestHeaderParam { OpcClientRequestId = request.OpcClientRequestId }))
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
        /// List the replication policies associated with a bucket.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ListReplicationPoliciesResponse ListReplicationPolicies(ListReplicationPoliciesRequest request)
        {
            var uriStr = $"{GetEndPointNoneVersion(ObjectStorageServices.Object(request.NamespaceName, request.BucketName), this.Region)}/replicationPolicies";
            var optional = request.GetOptionQuery();
            if (!string.IsNullOrEmpty(optional))
            {
                uriStr = $"{uriStr}?{optional}";
            }

            var uri = new Uri(uriStr);

            using (var webResponse = this.RestClient.Get(uri, new HttpRequestHeaderParam { OpcClientRequestId = request.OpcClientRequestId }))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListReplicationPoliciesResponse()
                {
                    Items = JsonSerializer.Deserialize<List<ReplicationPolicySummary>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcClientRequestId = webResponse.Headers.Get("opc-client-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
        }

        /// <summary>
        /// The summary of a retention rule.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ListRetentionRulesResponse ListRetentionRules(ListRetentionRulesRequest request)
        {
            var uriStr = $"{GetEndPointNoneVersion(ObjectStorageServices.Object(request.NamespaceName, request.BucketName), this.Region)}/retentionRules";
            if (!string.IsNullOrEmpty(request.Page))
            {
                uriStr = $"{uriStr}?page={request.Page}";
            }

            var uri = new Uri(uriStr);

            using (var webResponse = this.RestClient.Get(uri))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListRetentionRulesResponse()
                {
                    RetentionRuleCollection = JsonSerializer.Deserialize<RetentionRuleCollection>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcClientRequestId = webResponse.Headers.Get("opc-client-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
        }

        /// <summary>
        /// List the replication sources of a destination bucket.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ListReplicationSourcesResponse ListReplicationSources(ListReplicationSourcesRequest request)
        {
            var uriStr = $"{GetEndPointNoneVersion(ObjectStorageServices.Object(request.NamespaceName, request.BucketName), this.Region)}/replicationSources";
            var optional = request.GetOptionQuery();
            if (!string.IsNullOrEmpty(optional))
            {
                uriStr = $"{uriStr}?{optional}";
            }

            var uri = new Uri(uriStr);

            using (var webResponse = this.RestClient.Get(uri, new HttpRequestHeaderParam { OpcClientRequestId = request.OpcClientRequestId }))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListReplicationSourcesResponse()
                {
                    Items = JsonSerializer.Deserialize<List<ReplicationSource>>(response),
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
        public CreateBucketResponse CreateBucket(CreateBucketRequest request)
        {
            var uri = new Uri(GetEndPointNoneVersion(ObjectStorageServices.Bucket(request.NamespaceName), this.Region));

            using (var webResponse = this.RestClient.Post(uri, request.CreateBucketDetails, new HttpRequestHeaderParam() { OpcClientRequestId = request.OpcClientRequestId }))
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
        /// Stops replication to the destination bucket and removes the replication policy. When the replication policy was created, this destination bucket became read-only except for 
        /// new and changed objects replicated automatically from the source bucket. MakeBucketWritable removes the replication policy. This bucket is no longer the target for replication 
        /// and is now writable, allowing users to make changes to bucket contents.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public MakeBucketWritableResponse MakeBucketWritable(MakeBucketWritableRequest request)
        {
            var uri = new Uri($"{GetEndPointNoneVersion(ObjectStorageServices.Bucket(request.NamespaceName), this.Region)}/actions/makeBucketWritable");

            using (var webResponse = this.RestClient.Post(uri, new HttpRequestHeaderParam() { OpcClientRequestId = request.OpcClientRequestId }))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new MakeBucketWritableResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcClientRequestId = webResponse.Headers.Get("opc-client-request-id")
                };
            }
        }

        /// <summary>
        /// Rename an object in the given Object Storage namespace.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public RenameObjectResponse RenameObject(RenameObjectRequest request)
        {
            var uri = new Uri($"{GetEndPointNoneVersion(ObjectStorageServices.Bucket(request.NamespaceName, request.BucketName), this.Region)}/actions/renameObject");

            using (var webResponse = this.RestClient.Post(uri, request.RenameObjectDetails, new HttpRequestHeaderParam() { OpcClientRequestId = request.OpcClientRequestId }))
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
        public RestoreObjectsResponse RestoreObjects(RestoreObjectsRequest request)
        {
            var uri = new Uri($"{GetEndPointNoneVersion(ObjectStorageServices.Bucket(request.NamespaceName, request.BucketName), this.Region)}/actions/restoreObjects");

            using (var webResponse = this.RestClient.Post(uri, request.RestoreObjectsDetails, new HttpRequestHeaderParam() { OpcClientRequestId = request.OpcClientRequestId }))
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
        public UpdateNamespaceMetadataResponse UpdateNamespaceMetadata(UpdateNamespaceMetadataRequest request)
        {
            var uri = new Uri($"{GetEndPointNoneVersion(ObjectStorageServices.Namespace, this.Region)}/{request.NamespaceName}");

            using (var webResponse = this.RestClient.Post(uri, request.UpdateNamespaceMetadataDetails, new HttpRequestHeaderParam() { OpcClientRequestId = request.OpcClientRequestId }))
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
        public UpdateBucketResponse UpdateBucket(UpdateBucketRequest request)
        {
            var uri = new Uri(GetEndPointNoneVersion(ObjectStorageServices.Bucket(request.NamespaceName, request.BucketName), this.Region));

            HttpRequestHeaderParam HttpRequestHeaderParam = new HttpRequestHeaderParam() {
                IfMatch = request.IfMatch,
                OpcClientRequestId = request.OpcClientRequestId
            };
            using (var webResponse = this.RestClient.Post(uri, request.UpdateBucketDetails, HttpRequestHeaderParam))
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
        public PutObjectResponse PutObject(PutObjectRequest request)
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
            using (var webResponse = this.RestClient.Put(uri, request.UploadPartBody, HttpRequestHeaderParam, false))
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
        public UploadPartResponse UploadPart(UploadPartRequest request)
        {
            var uri = new Uri(
                $"{GetEndPointNoneVersion(ObjectStorageServices.Bucket(request.NamespaceName, request.BucketName), this.Region)}/u/{request.ObjectName}?" +
                $"uploadId={request.UploadId}&uploadPartNum={request.UploadPartNum}");

            HttpRequestHeaderParam HttpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                IfMatch = request.IfMatch,
                IfNoneMatch = request.IfNoneMatch,
                Expect = request.Expect,
                ContentLength = request.ContentLength,
                ContentMD5 = request.ContentMD5,
                OpcClientRequestId = request.OpcClientRequestId
            };
            using (var webResponse = this.RestClient.Put(uri, request.UploadPartBody, HttpRequestHeaderParam))
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
        /// Updates the specified retention rule. Rule changes take effect typically within 30 seconds.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public UpdateRetentionRuleResponse UpdateRetentionRule(UpdateRetentionRuleRequest request)
        {
            var uri = new Uri(
                $"{GetEndPointNoneVersion(ObjectStorageServices.Bucket(request.NamespaceName, request.BucketName), this.Region)}/retentionRules/{request.RetentionRuleId}");

            HttpRequestHeaderParam HttpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                IfMatch = request.IfMatch,
                OpcClientRequestId = request.OpcClientRequestId
            };
            using (var webResponse = this.RestClient.Put(uri, request.UpdateRetentionRuleDetails, HttpRequestHeaderParam))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new UpdateRetentionRuleResponse()
                {
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcClientRequestId = webResponse.Headers.Get("opc-client-request-id")
                };
            }
        }

        /// <summary>
        /// Creates or replaces the object lifecycle policy for the bucket.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public PutObjectLifecyclePolicyResponse PutObjectLifecyclePolicy(PutObjectLifecyclePolicyRequest request)
        {
            var uri = new Uri(
                $"{GetEndPointNoneVersion(ObjectStorageServices.Bucket(request.NamespaceName, request.BucketName), this.Region)}/l");

            HttpRequestHeaderParam HttpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                IfMatch = request.IfMatch,
                IfNoneMatch = request.IfNoneMatch,
                OpcClientRequestId = request.OpcClientRequestId
            };
            using (var webResponse = this.RestClient.Put(uri, request.PutObjectLifecyclePolicyDetails, HttpRequestHeaderParam))
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
        public ReencryptBucketResponse ReencryptBucket(ReencryptBucketRequest request)
        {
            var uri = new Uri($"{GetEndPointNoneVersion(ObjectStorageServices.Bucket(request.NamespaceName, request.BucketName), this.Region)}/actions/reencrypt");

            HttpRequestHeaderParam HttpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                OpcClientRequestId = request.OpcClientRequestId
            };
            using (var webResponse = this.RestClient.Post(uri, null, HttpRequestHeaderParam))
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
        public CreateMultipartUploadResponse CreateMultipartUpload(CreateMultipartUploadRequest request)
        {
            var uri = new Uri($"{GetEndPointNoneVersion(ObjectStorageServices.Bucket(request.NamespaceName, request.BucketName), this.Region)}/u");

            HttpRequestHeaderParam HttpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                IfMatch = request.IfMatch,
                IfNoneMatch = request.IfNoneMatch,
                OpcClientRequestId = request.OpcClientRequestId
            };
            using (var webResponse = this.RestClient.Post(uri, request.CreateMultipartUploadDetails, HttpRequestHeaderParam))
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
        public CommitMultipartUploadResponse CommitMultipartUpload(CommitMultipartUploadRequest request)
        {
            var uri = new Uri($"{GetEndPointNoneVersion(ObjectStorageServices.Bucket(request.NamespaceName, request.BucketName), this.Region)}/u/{request.ObjectName}?uploadId={request.UploadId}");

            HttpRequestHeaderParam HttpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                IfMatch = request.IfMatch,
                IfNoneMatch = request.IfNoneMatch,
                OpcClientRequestId = request.OpcClientRequestId
            };
            using (var webResponse = this.RestClient.Post(uri, request.CommitMultipartUploadDetails, HttpRequestHeaderParam))
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
        public CreatePreauthenticatedRequestResponse CreatePreauthenticatedRequest(CreatePreauthenticatedRequestRequest request)
        {
            var uri = new Uri($"{GetEndPointNoneVersion(ObjectStorageServices.Bucket(request.NamespaceName, request.BucketName), this.Region)}/p");

            HttpRequestHeaderParam HttpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                OpcClientRequestId = request.OpcClientRequestId
            };
            using (var webResponse = this.RestClient.Post(uri, request.CreatePreauthenticatedRequestDetails, HttpRequestHeaderParam))
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
        /// Creates a replication policy for the specified bucket.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public CreateReplicationPolicyResponse CreateReplicationPolicy(CreateReplicationPolicyRequest request)
        {
            var uri = new Uri($"{GetEndPointNoneVersion(ObjectStorageServices.Bucket(request.NamespaceName, request.BucketName), this.Region)}/replicationPolicies");

            HttpRequestHeaderParam HttpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                OpcClientRequestId = request.OpcClientRequestId
            };
            using (var webResponse = this.RestClient.Post(uri, request.CreateReplicationPolicyDetails, HttpRequestHeaderParam))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new CreateReplicationPolicyResponse()
                {
                    ReplicationPolicy = JsonSerializer.Deserialize<ReplicationPolicy>(response),
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
        public DeleteBucketResponse DeleteBucket(DeleteBucketRequest request)
        {
            var uri = new Uri(GetEndPointNoneVersion(ObjectStorageServices.Bucket(request.NamespaceName, request.BucketName), this.Region));

            using (var webResponse = this.RestClient.Delete(uri, new HttpRequestHeaderParam() { IfMatch = request.IfMatch }))
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
        public DeleteObjectResponse DeleteObject(DeleteObjectRequest request)
        {
            var uri = new Uri($"{GetEndPointNoneVersion(ObjectStorageServices.Object(request.NamespaceName, request.BucketName), this.Region)}/{request.ObjectName}");

            var headers = new HttpRequestHeaderParam() {
                IfMatch = request.IfMatch ,
                OpcClientRequestId = request.OpcClientRequestId
            };

            using (var webResponse = this.RestClient.Delete(uri, headers))
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
        /// Deletes an objects.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public DeleteObjectsResponse DeleteObjects(DeleteObjectsRequest request)
        {
            string uriStr = $"{GetEndPointNoneVersion(ObjectStorageServices.Object(request.NamespaceName, request.BucketName), this.Region)}/";

            var headers = new HttpRequestHeaderParam()
            {
                OpcClientRequestId = request.OpcClientRequestId
            };

            bool quiet = false;
            if (request.Quiet.HasValue && request.Quiet.Value)
            {
                quiet = true;
            }

            return ExecuteDeleteObjects(uriStr, headers, quiet, request.Objects);
        }

        /// <summary>
        /// execute delete objects.
        /// </summary>
        /// <param name="uriStr"></param>
        /// <param name="headers"></param>
        /// <param name="quiet"></param>
        /// <param name="objects"></param>
        /// <returns></returns>
        private DeleteObjectsResponse ExecuteDeleteObjects(string uriStr, HttpRequestHeaderParam headers, bool quiet, List<TargetDelete> objects)
        {
            DeleteObjectsResponse deleteObjectsResponse = new DeleteObjectsResponse
            {
                DeletedObjects = new List<DeletedObject>()
            };

            foreach (var obj in objects)
            {
                var uri = new Uri($"{uriStr}{obj.ObjectName}");

                if (!string.IsNullOrEmpty(obj.IfMatch))
                {
                    headers.IfMatch = obj.IfMatch;
                }

                try
                {
                    using (var webResponse = this.RestClient.Delete(uri, headers))
                    using (var stream = webResponse.GetResponseStream())
                    using (var reader = new StreamReader(stream))
                    {
                        var response = reader.ReadToEnd();

                        if (!quiet)
                        {
                            DeletedObject deletedObject = new DeletedObject
                            {
                                Name = obj.ObjectName,
                                Message = "",
                                Code = (int)webResponse.StatusCode,
                                OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                                OpcClientRequestId = webResponse.Headers.Get("opc-client-request-id"),
                                LastModified = webResponse.Headers.Get("last-modified")
                            };
                            deleteObjectsResponse.DeletedObjects.Add(deletedObject);
                        }
                    }
                }
                catch (WebException we)
                {
                    if (we.Status.Equals(WebExceptionStatus.ProtocolError))
                    {
                        DeletedObject deletedObject = new DeletedObject
                        {
                            Name = obj.ObjectName,
                            Message = we.Message,
                            Code = (int)((HttpWebResponse)we.Response).StatusCode
                        };
                        deleteObjectsResponse.DeletedObjects.Add(deletedObject);
                    }
                    else
                    {
                        throw we;
                    }
                }
            }

            return deleteObjectsResponse;
        }

        /// <summary>
        /// Deletes the object lifecycle policy for the bucket.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public DeleteObjectLifecyclePolicyResponse DeleteObjectLifecyclePolicy(DeleteObjectLifecyclePolicyRequest request)
        {
            var uri = new Uri($"{GetEndPointNoneVersion(ObjectStorageServices.Bucket(request.NamespaceName, request.BucketName), this.Region)}/l");

            var headers = new HttpRequestHeaderParam() {
                IfMatch = request.IfMatch,
                OpcClientRequestId = request.OpcClientRequestId
            };

            using (var webResponse = this.RestClient.Delete(uri, headers))
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
        public DeletePreauthenticatedRequestResponse DeletePreauthenticatedRequest(DeletePreauthenticatedRequestRequest request)
        {
            var uri = new Uri($"{GetEndPointNoneVersion(ObjectStorageServices.Bucket(request.NamespaceName, request.BucketName), this.Region)}/p{request.ParId}");

            var headers = new HttpRequestHeaderParam()
            {
                OpcClientRequestId = request.OpcClientRequestId
            };

            using (var webResponse = this.RestClient.Delete(uri, headers))
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
        /// Deletes the replication policy associated with the source bucket.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public DeleteReplicationPolicyResponse DeleteReplicationPolicy(DeleteReplicationPolicyRequest request)
        {
            var uri = new Uri($"{GetEndPointNoneVersion(ObjectStorageServices.Bucket(request.NamespaceName, request.BucketName), this.Region)}/replicationPolicies/{request.ReplicationId}");

            var headers = new HttpRequestHeaderParam()
            {
                OpcClientRequestId = request.OpcClientRequestId
            };

            using (var webResponse = this.RestClient.Delete(uri, headers))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new DeleteReplicationPolicyResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcClientRequestId = webResponse.Headers.Get("opc-client-request-id")
                };
            }
        }

        /// <summary>
        /// Deletes the specified rule. The deletion takes effect typically within 30 seconds.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public DeleteRetentionRuleResponse DeleteRetentionRule(DeleteRetentionRuleRequest request)
        {
            var uri = new Uri($"{GetEndPointNoneVersion(ObjectStorageServices.Bucket(request.NamespaceName, request.BucketName), this.Region)}/retentionRules/{request.RetentionRuleId}");

            var headers = new HttpRequestHeaderParam()
            {
                OpcClientRequestId = request.OpcClientRequestId,
                IfMatch = request.IfMatch
            };

            using (var webResponse = this.RestClient.Delete(uri, headers))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new DeleteRetentionRuleResponse()
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
        public AbortMultipartUploadResponse AbortMultipartUpload(AbortMultipartUploadRequest request)
        {
            var uri = new Uri($"{GetEndPointNoneVersion(ObjectStorageServices.Bucket(request.NamespaceName, request.BucketName), this.Region)}/u/{request.ObjectName}?uploadId={request.UploadId}");

            using (var webResponse = this.RestClient.Delete(uri, new HttpRequestHeaderParam() { OpcClientRequestId = request.OpcClientRequestId }))
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

        /// <summary>
        /// Gets the status of the work request for the given ID.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public GetWorkRequestResponse GetWorkRequest(GetWorkRequestRequest request)
        {
            var uri = new Uri($"{GetEndPointNoneVersion("workRequests", this.Region)}/{request.WorkRequestId}");

            using (var webResponse = this.RestClient.Get(uri, new HttpRequestHeaderParam { OpcClientRequestId = request.OpcClientRequestId }))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new GetWorkRequestResponse()
                {
                    WorkRequest = JsonSerializer.Deserialize<WorkRequestDetails>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcClientRequestId = webResponse.Headers.Get("opc-client-request-id"),
                    RetryAfter = webResponse.Headers.Get("retry-after")
                };
            }
        }

        /// <summary>
        /// Lists the work requests in a compartment.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ListWorkRequestsResponse ListWorkRequests(ListWorkRequestsRequest request)
        {
            var uriStr = $"{GetEndPointNoneVersion("workRequests", this.Region)}?{request.GetOptionQuery()}";

            var uri = new Uri(uriStr);

            using (var webResponse = this.RestClient.Get(uri, new HttpRequestHeaderParam { OpcClientRequestId = request.OpcClientRequestId }))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListWorkRequestsResponse()
                {
                    Items = JsonSerializer.Deserialize<List<WorkRequestSummary>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcClientRequestId = webResponse.Headers.Get("opc-client-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
        }

        /// <summary>
        /// Cancels a work request.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public CancelWorkRequestResponse CancelWorkRequest(CancelWorkRequestRequest request)
        {
            var uri = new Uri($"{GetEndPointNoneVersion("workRequests", this.Region)}/{request.WorkRequestId}");

            using (var webResponse = this.RestClient.Delete(uri, new HttpRequestHeaderParam() { OpcClientRequestId = request.OpcClientRequestId }))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new CancelWorkRequestResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcClientRequestId = webResponse.Headers.Get("opc-client-request-id")
                };
            }
        }

        /// <summary>
        /// Lists the errors of the work request with the given ID.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ListWorkRequestErrorsResponse ListWorkRequestErrors(ListWorkRequestErrorsRequest request)
        {
            var uriStr = $"{GetEndPointNoneVersion("workRequests", this.Region)}/{request.WorkRequestId}/errors";
            var optional = request.GetOptionQuery();
            if (!string.IsNullOrEmpty(optional))
            {
                uriStr = $"{uriStr}?{optional}";
            }

            var uri = new Uri(uriStr);

            using (var webResponse = this.RestClient.Get(uri, new HttpRequestHeaderParam { OpcClientRequestId = request.OpcClientRequestId }))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListWorkRequestErrorsResponse()
                {
                    Items = JsonSerializer.Deserialize<List<WorkRequestError>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcClientRequestId = webResponse.Headers.Get("opc-client-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
        }

        /// <summary>
        /// Lists the logs of the work request with the given ID.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ListWorkRequestLogsResponse ListWorkRequestLogs(ListWorkRequestLogsRequest request)
        {
            var uriStr = $"{GetEndPointNoneVersion("workRequests", this.Region)}/{request.WorkRequestId}/logs";
            var optional = request.GetOptionQuery();
            if (!string.IsNullOrEmpty(optional))
            {
                uriStr = $"{uriStr}?{optional}";
            }

            var uri = new Uri(uriStr);

            using (var webResponse = this.RestClient.Get(uri, new HttpRequestHeaderParam { OpcClientRequestId = request.OpcClientRequestId }))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListWorkRequestLogsResponse()
                {
                    Items = JsonSerializer.Deserialize<List<WorkRequestLogEntry>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcClientRequestId = webResponse.Headers.Get("opc-client-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
        }
    }
}

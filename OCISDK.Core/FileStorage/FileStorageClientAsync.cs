using System;
using System.Collections.Generic;
using System.Text;
using OCISDK.Core.Common;
using OCISDK.Core.FileStorage.Request;
using OCISDK.Core.FileStorage.Response;
using System.Threading.Tasks;
using System.IO;
using OCISDK.Core.FileStorage.Model;

namespace OCISDK.Core.FileStorage
{
    /// <summary>
    /// FileStorageClient
    /// </summary>
    public class FileStorageClientAsync : ServiceClient, IFileStorageClientAsync
    {
        private readonly string FileStorageServiceName = "filestorage";

        /// <summary>
        /// Constructer
        /// </summary>
        public FileStorageClientAsync(ClientConfig config) : base(config)
        {
            ServiceName = FileStorageServiceName;
        }

        /// <summary>
        /// Constructer
        /// </summary>
        public FileStorageClientAsync(ClientConfig config, OciSigner ociSigner) : base(config, ociSigner)
        {
            ServiceName = FileStorageServiceName;
        }

        /// <summary>
        /// Constructer
        /// </summary>
        public FileStorageClientAsync(ClientConfigStream config) : base(config)
        {
            ServiceName = FileStorageServiceName;
        }

        /// <summary>
        /// Constructer
        /// </summary>
        public FileStorageClientAsync(ClientConfigStream config, OciSigner ociSigner) : base(config, ociSigner)
        {
            ServiceName = FileStorageServiceName;
        }
        
        /// <summary>
        /// Moves a file system and its associated snapshots into a different compartment within the same tenancy. 
        /// For information about moving resources between compartments, see Moving Resources to a Different Compartment
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ChangeFileSystemCompartmentResponse> ChangeFileSystemCompartment(ChangeFileSystemCompartmentRequest request)
        {
            var uri = new Uri($"{GetEndPoint(FileStorageServices.FileSystems, this.Region)}/{request.FileSystemId}/actions/changeCompartment");

            var headers = new HttpRequestHeaderParam
            {
                IfMatch = request.FileSystemId,
                OpcRequestId = request.OpcRequestId
            };
            var webResponse = await this.RestClientAsync.Post(uri, request.ChangeFileSystemCompartmentDetails, headers);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ChangeFileSystemCompartmentResponse()
                {
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Creates a new file system in the specified compartment and availability domain. Instances can mount file 
        /// systems in another availability domain, but doing so might increase latency when compared to mounting 
        /// instances in the same availability domain.
        /// 
        /// After you create a file system, you can associate it with a mount target. Instances can then mount the file 
        /// system by connecting to the mount target's IP address. You can associate a file system with more than one 
        /// mount target at a time.
        /// 
        /// For information about access control and compartments, see Overview of the IAM Service.
        /// 
        /// For information about availability domains, see Regions and Availability Domains. To get a list of availability 
        /// domains, use the ListAvailabilityDomains operation in the Identity and Access Management Service API.
        /// 
        /// All Oracle Cloud Infrastructure resources, including file systems, get an Oracle-assigned, unique ID called an 
        /// Oracle Cloud Identifier (OCID). When you create a resource, you can find its OCID in the response. You can 
        /// also retrieve a resource's OCID by using a List API operation on that resource type or by viewing the resource 
        /// in the Console.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CreateFileSystemResponse> CreateFileSystem(CreateFileSystemRequest request)
        {
            var uri = new Uri($"{GetEndPoint(FileStorageServices.FileSystems, this.Region)}");

            var headers = new HttpRequestHeaderParam()
            {
                OpcRetryToken = request.OpcRetryToken,
                OpcRequestId = request.OpcRequestId
            };
            var webResponse = await this.RestClientAsync.Post(uri, request.CreateFileSystemDetails, headers);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new CreateFileSystemResponse()
                {
                    FileSystem = this.JsonSerializer.Deserialize<FileSystem>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    ETag = webResponse.Headers.Get("ETag")
                };
            }
        }

        /// <summary>
        /// Updates the specified file system's information. You can use this operation to rename a file system.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<UpdateFileSystemResponse> UpdateFileSystem(UpdateFileSystemRequest request)
        {
            var uri = new Uri($"{GetEndPoint(FileStorageServices.FileSystems, this.Region)}");

            var headers = new HttpRequestHeaderParam()
            {
                IfMatch = request.IfMatch,
                OpcRequestId = request.OpcRequestId
            };
            var webResponse = await this.RestClientAsync.Put(uri, request.UpdateFileSystemDetails, headers);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new UpdateFileSystemResponse()
                {
                    FileSystem = this.JsonSerializer.Deserialize<FileSystem>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    ETag = webResponse.Headers.Get("ETag")
                };
            }
        }

        /// <summary>
        /// Gets the specified file system's information.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<GetFileSystemResponse> GetFileSystem(GetFileSystemRequest request)
        {
            var uri = new Uri($"{GetEndPoint(FileStorageServices.FileSystems, this.Region)}/{request.FileSystemId}");

            var headers = new HttpRequestHeaderParam()
            {
                OpcRequestId = request.OpcRequestId
            };
            var webResponse = await this.RestClientAsync.Get(uri, headers);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new GetFileSystemResponse()
                {
                    FileSystem = this.JsonSerializer.Deserialize<FileSystem>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    ETag = webResponse.Headers.Get("ETag")
                };
            }
        }

        /// <summary>
        /// Lists the file system resources in the specified compartment.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ListFileSystemsResponse> ListFileSystems(ListFileSystemsRequest request)
        {
            var uri = new Uri(GetEndPoint(FileStorageServices.FileSystems, this.Region));

            var headers = new HttpRequestHeaderParam()
            {
                OpcRequestId = request.OpcRequestId
            };
            var webResponse = await this.RestClientAsync.Get(uri, headers);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListFileSystemsResponse()
                {
                    Items = this.JsonSerializer.Deserialize<List<FileSystemSummary>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
        }

        /// <summary>
        /// Deletes the specified file system. Before you delete the file system, verify that no remaining export resources 
        /// still reference it. Deleting a file system also deletes all of its snapshots.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<DeleteFileSystemResponse> DeleteFileSystem(DeleteFileSystemRequest request)
        {
            var uriStr = $"{GetEndPoint(FileStorageServices.FileSystems, this.Region)}/{request.FileSystemId}";

            var uri = new Uri(uriStr);

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                IfMatch = request.IfMatch,
                OpcRequestId = request.OpcRequestId
            };
            var webResponse = await this.RestClientAsync.Delete(uri, httpRequestHeaderParam);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new DeleteFileSystemResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }
    }
}

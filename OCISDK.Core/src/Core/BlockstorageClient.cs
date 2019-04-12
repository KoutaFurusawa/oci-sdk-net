/// <summary>
/// Blockstorage Service Client
/// 
/// author: koutaro furusawa
/// </summary>


using OCISDK.Core.src.Common;
using OCISDK.Core.src.Core.Model.Blockstorage;
using OCISDK.Core.src.Core.Request.Blockstorage;
using OCISDK.Core.src.Core.Response.Blockstorage;
using System;
using System.Collections.Generic;
using System.IO;

namespace OCISDK.Core.src.Core
{
    public class BlockstorageClient : ServiceClient, IBlockstorageClient
    {
        private string _region;
        public string Region
        {
            get { return _region; }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _region = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }
        
        private RestClient RestClient { get; set; }

        /// <summary>
        /// Constructer
        /// </summary>
        public BlockstorageClient(ClientConfig config) : base(config)
        {
            ServiceName = "core";

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
        }

        public BlockstorageClient(ClientConfig config, RestClient restClient) : base(config)
        {
            ServiceName = "core";

            Config = config;

            RestClient = restClient;
        }

        /// <summary>
        /// Lists the boot volumes in the specified compartment and availability domain.
        /// </summary>
        /// <param name="listRequest"></param>
        /// <returns></returns>
        public ListBootVolumesResponse ListBootVolumes(ListBootVolumesRequest listRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.BootVolume, this.Region)}?{listRequest.GetOptionQuery()}");
            
            var webResponse = this.RestClient.Get(uri);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListBootVolumesResponse()
                {
                    Items = JsonSerializer.Deserialize<List<BootVolume>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
        }

        /// <summary>
        /// Creates a new boot volume in the specified compartment from an existing boot volume or a 
        /// boot volume backup. For general information about boot volumes, see Boot Volumes. You may 
        /// optionally specify a display name for the volume, which is simply a friendly name or description. 
        /// It does not have to be unique, and you can change it. Avoid entering confidential information.
        /// </summary>
        /// <param name="createRequest"></param>
        /// <returns></returns>
        public CreateBootVolumeResponse CreateBootVolume(CreateBootVolumeRequest createRequest)
        {
            var uri = new Uri(GetEndPoint(CoreServices.BootVolume, this.Region));
            
            var webResponse = this.RestClient.Post(uri, createRequest.CreateBootVolumeDetails, createRequest.OpcRetryToken);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new CreateBootVolumeResponse()
                {
                    BootVolume = JsonSerializer.Deserialize<BootVolume>(response),
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Updates the specified boot volume's display name, defined tags, and free-form tags.
        /// </summary>
        /// <param name="updateRequest"></param>
        /// <returns></returns>
        public UpdateBootVolumeResponse UpdateBootVolume(UpdateBootVolumeRequest updateRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.BootVolume, this.Region)}/{updateRequest.BootVolumeId}");
            
            var webResponse = this.RestClient.Put(uri, updateRequest.UpdateBootVolumeDetails, updateRequest.IfMatch);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new UpdateBootVolumeResponse()
                {
                    BootVolume = JsonSerializer.Deserialize<BootVolume>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    ETag = webResponse.Headers.Get("etag")
                };
            }
        }

        /// <summary>
        /// Gets information for the specified boot volume.
        /// </summary>
        /// <param name="getRequest"></param>
        /// <returns></returns>
        public GetBootVolumeResponse GetBootVolume(GetBootVolumeRequest getRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.BootVolume, this.Region)}/{getRequest.BootVolumeId}");
            
            var webResponse = this.RestClient.Get(uri);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new GetBootVolumeResponse()
                {
                    BootVolume = JsonSerializer.Deserialize<BootVolume>(response),
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Deletes the specified boot volume. The volume cannot have an active connection to an instance. 
        /// To disconnect the boot volume from a connected instance, see Disconnecting From a Boot Volume. 
        /// Warning: All data on the boot volume will be permanently lost when the boot volume is deleted.
        /// </summary>
        /// <param name="deleteRequest"></param>
        /// <returns></returns>
        public DeleteBootVolumeResponse DeleteBootVolume(DeleteBootVolumeRequest deleteRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.BootVolume, this.Region)}/{deleteRequest.BootVolumeId}");
            
            var webResponse = this.RestClient.Delete(uri, deleteRequest.IfMatch);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new DeleteBootVolumeResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }
    }
}

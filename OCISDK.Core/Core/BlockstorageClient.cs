using OCISDK.Core.Common;
using OCISDK.Core.Core.Model.Blockstorage;
using OCISDK.Core.Core.Request.Blockstorage;
using OCISDK.Core.Core.Response.Blockstorage;
using System;
using System.Collections.Generic;
using System.IO;

namespace OCISDK.Core.Core
{
    /// <summary>
    /// Blockstorage Service Client
    /// </summary>

    public class BlockstorageClient : ServiceClient, IBlockstorageClient
    {
        /// <summary>
        /// Constructer
        /// </summary>
        public BlockstorageClient(ClientConfig config) : base(config)
        {
            ServiceName = "core";
        }

        /// <summary>
        /// Constructer
        /// </summary>
        public BlockstorageClient(ClientConfig config, OciSigner ociSigner) : base(config, ociSigner)
        {
            ServiceName = "core";
        }

        /// <summary>
        /// Constructer
        /// </summary>
        public BlockstorageClient(ClientConfigStream config) : base(config)
        {
            ServiceName = "core";
        }

        /// <summary>
        /// Constructer
        /// </summary>
        public BlockstorageClient(ClientConfigStream config, OciSigner ociSigner) : base(config, ociSigner)
        {
            ServiceName = "core";
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
        /// Lists the boot volume backups in the specified compartment. You can filter the results by boot volume.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public ListBootVolumeBackupsResponse ListBootVolumeBackups(ListBootVolumeBackupsRequest param)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.BootVolumeBackup, this.Region)}?{param.GetOptionQuery()}");

            var webResponse = this.RestClient.Get(uri);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListBootVolumeBackupsResponse()
                {
                    Items = JsonSerializer.Deserialize<List<BootVolumeBackup>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
        }

        /// <summary>
        /// Lists the volume backups in the specified compartment. You can filter the results by volume.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public ListVolumeBackupsResponse ListVolumeBackups(ListVolumeBackupsRequest param)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.VolumeBackup, this.Region)}?{param.GetOptionQuery()}");

            var webResponse = this.RestClient.Get(uri);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListVolumeBackupsResponse()
                {
                    Items = JsonSerializer.Deserialize<List<VolumeBackup>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
        }

        /// <summary>
        /// Lists the volumes in the specified compartment and availability domain.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public ListVolumesResponse ListVolumes(ListVolumesRequest param)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.Volume, this.Region)}?{param.GetOptionQuery()}");

            var webResponse = this.RestClient.Get(uri);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListVolumesResponse()
                {
                    Items = JsonSerializer.Deserialize<List<VolumeDetails>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
        }

        /// <summary>
        /// Lists all volume backup policies available to the caller.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public ListVolumeBackupPoliciesResponse ListVolumeBackupPolicies(ListVolumeBackupPoliciesRequest param)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.VolumeBackupPolicy, this.Region)}?{param.GetOptionQuery()}");

            var webResponse = this.RestClient.Get(uri);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListVolumeBackupPoliciesResponse()
                {
                    Items = JsonSerializer.Deserialize<List<VolumeBackupPolicy>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
        }

        /// <summary>
        /// Lists the volume groups in the specified compartment and availability domain. For more information, see Volume Groups.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public ListVolumeGroupsResponse ListVolumeGroups(ListVolumeGroupsRequest param)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.VolumeGroup, this.Region)}?{param.GetOptionQuery()}");

            var webResponse = this.RestClient.Get(uri);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListVolumeGroupsResponse()
                {
                    Items = JsonSerializer.Deserialize<List<VolumeGroup>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
        }

        /// <summary>
        /// Lists the volume group backups in the specified compartment. You can filter the results by volume group. For more information, see Volume Groups.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public ListVolumeGroupBackupsResponse ListVolumeGroupBackups(ListVolumeGroupBackupsRequest param)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.VolumeGroupBackup, this.Region)}?{param.GetOptionQuery()}");

            var webResponse = this.RestClient.Get(uri);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListVolumeGroupBackupsResponse()
                {
                    Items = JsonSerializer.Deserialize<List<VolumeGroupBackup>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
        }

        /// <summary>
        /// Gets the volume backup policy assignment for the specified asset.
        /// Note that the assetId query parameter is required, and that the returned list will contain at most one item 
        /// (since any given asset can only have one policy assigned to it).
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public GetVolumeBackupPolicyAssetAssignmentResponse GetVolumeBackupPolicyAssetAssignment(GetVolumeBackupPolicyAssetAssignmentRequest param)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.VolumeBackupPolicyAssignment, this.Region)}?{param.GetOptionQuery()}");

            var webResponse = this.RestClient.Get(uri);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new GetVolumeBackupPolicyAssetAssignmentResponse()
                {
                    Items = JsonSerializer.Deserialize<List<VolumeBackupPolicyAssignment>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
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
        /// Gets information for the specified boot volume backup.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public GetBootVolumeBackupResponse GetBootVolumeBackup(GetBootVolumeBackupRequest param)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.BootVolumeBackup, this.Region)}/{param.BootVolumeBackupId}");

            var webResponse = this.RestClient.Get(uri);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new GetBootVolumeBackupResponse()
                {
                    BootVolumeBackup = JsonSerializer.Deserialize<BootVolumeBackup>(response),
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Gets the KMS key ID for the specified boot volume.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public GetBootVolumeKmsKeyResponse GetBootVolumeKmsKey(GetBootVolumeKmsKeyRequest param)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.BootVolume, this.Region)}/{param.BootVolumeId}/kmsKey");

            var webResponse = this.RestClient.Get(uri);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new GetBootVolumeKmsKeyResponse()
                {
                    BootVolumeKmsKey = JsonSerializer.Deserialize<BootVolumeKmsKey>(response),
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Gets information for the specified volume.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public GetVolumeResponse GetVolume(GetVolumeRequest param)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.Volume, this.Region)}/{param.VolumeId}");

            var webResponse = this.RestClient.Get(uri);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new GetVolumeResponse()
                {
                    Volume = JsonSerializer.Deserialize<VolumeDetails>(response),
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Gets information for the specified volume backup.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public GetVolumeBackupResponse GetVolumeBackup(GetVolumeBackupRequest param)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.VolumeBackup, this.Region)}/{param.VolumeBackupId}");

            var webResponse = this.RestClient.Get(uri);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new GetVolumeBackupResponse()
                {
                    VolumeBackup = JsonSerializer.Deserialize<VolumeBackup>(response),
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Gets information for the specified volume backup policy.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public GetVolumeBackupPolicyResponse GetVolumeBackupPolicy(GetVolumeBackupPolicyRequest param)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.VolumeBackupPolicy, this.Region)}/{param.PolicyId}");

            var webResponse = this.RestClient.Get(uri);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new GetVolumeBackupPolicyResponse()
                {
                    VolumeBackupPolicy = JsonSerializer.Deserialize<VolumeBackupPolicy>(response),
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Gets information for the specified volume backup policy assignment.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public GetVolumeBackupPolicyAssignmentResponse GetVolumeBackupPolicyAssignment(GetVolumeBackupPolicyAssignmentRequest param)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.VolumeBackupPolicyAssignment, this.Region)}/{param.PolicyAssignmentId}");

            var webResponse = this.RestClient.Get(uri);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new GetVolumeBackupPolicyAssignmentResponse()
                {
                    VolumeBackupPolicyAssignment = JsonSerializer.Deserialize<VolumeBackupPolicyAssignment>(response),
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Gets information for the specified volume group. For more information, see Volume Groups.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public GetVolumeGroupResponse GetVolumeGroup(GetVolumeGroupRequest param)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.VolumeGroup, this.Region)}/{param.VolumeGroupId}");

            var webResponse = this.RestClient.Get(uri);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new GetVolumeGroupResponse()
                {
                    VolumeGroup = JsonSerializer.Deserialize<VolumeGroup>(response),
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Gets information for the specified volume group backup. For more information, see Volume Groups.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public GetVolumeGroupBackupResponse GetVolumeGroupBackup(GetVolumeGroupBackupRequest param)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.VolumeGroupBackup, this.Region)}/{param.VolumeGroupBackupId}");

            var webResponse = this.RestClient.Get(uri);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new GetVolumeGroupBackupResponse()
                {
                    VolumeGroupBackup = JsonSerializer.Deserialize<VolumeGroupBackup>(response),
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Gets the KMS key ID for the specified volume.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public GetVolumeKmsKeyResponse GetVolumeKmsKey(GetVolumeKmsKeyRequest param)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.Volume, this.Region)}/{param.VolumeId}/kmsKey");

            var webResponse = this.RestClient.Get(uri, new HttpRequestHeaderParam { IfMatch = param.IfMatch });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new GetVolumeKmsKeyResponse()
                {
                    VolumeKmsKey = JsonSerializer.Deserialize<VolumeKmsKey>(response),
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Moves a boot volume into a different compartment within the same tenancy. 
        /// For information about moving resources between compartments, see Moving Resources to a Different Compartment.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public ChangeBootVolumeCompartmentResponse ChangeBootVolumeCompartment(ChangeBootVolumeCompartmentRequest param)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.BootVolume, this.Region)}/{param.BootVolumeId}/actions/changeCompartment");

            var webResponse = this.RestClient.Post(uri, param.ChangeBootVolumeCompartmentDetails, new HttpRequestHeaderParam { OpcRequestId = param.OpcRequestId });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ChangeBootVolumeCompartmentResponse()
                {
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Moves a volume into a different compartment within the same tenancy. 
        /// \For information about moving resources between compartments, see Moving Resources to a Different Compartment.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public ChangeVolumeCompartmentResponse ChangeVolumeCompartment(ChangeVolumeCompartmentRequest param)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.Volume, this.Region)}/{param.VolumeId}/actions/changeCompartment");

            var webResponse = this.RestClient.Post(uri, param.ChangeVolumeCompartmentDetails, new HttpRequestHeaderParam { OpcRequestId = param.OpcRequestId });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ChangeVolumeCompartmentResponse()
                {
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Moves a volume backup into a different compartment within the same tenancy.
        /// For information about moving resources between compartments, see Moving Resources to a Different Compartment.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public ChangeVolumeBackupCompartmentResponse ChangeVolumeBackupCompartment(ChangeVolumeBackupCompartmentRequest param)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.VolumeBackup, this.Region)}/{param.VolumeBackupId}/actions/changeCompartment");

            var webResponse = this.RestClient.Post(uri, param.ChangeVolumeBackupCompartmentDetails, new HttpRequestHeaderParam { OpcRequestId = param.OpcRequestId });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ChangeVolumeBackupCompartmentResponse()
                {
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Moves a volume group into a different compartment within the same tenancy. 
        /// For information about moving resources between compartments, see Moving Resources to a Different Compartment.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public ChangeVolumeGroupCompartmentResponse ChangeVolumeGroupCompartment(ChangeVolumeGroupCompartmentRequest param)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.VolumeGroup, this.Region)}/{param.VolumeGroupId}/actions/changeCompartment");

            var webResponse = this.RestClient.Post(uri, param.ChangeVolumeGroupCompartmentDetails, new HttpRequestHeaderParam { OpcRequestId = param.OpcRequestId });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ChangeVolumeGroupCompartmentResponse()
                {
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Moves a volume group backup into a different compartment within the same tenancy. 
        /// For information about moving resources between compartments, see Moving Resources to a Different Compartment.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public ChangeVolumeGroupBackupCompartmentResponse ChangeVolumeGroupBackupCompartment(ChangeVolumeGroupBackupCompartmentRequest param)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.VolumeGroupBackup, this.Region)}/{param.VolumeGroupBackupId}/actions/changeCompartment");

            var webResponse = this.RestClient.Post(uri, param.ChangeVolumeGroupBackupCompartmentDetails, new HttpRequestHeaderParam { OpcRequestId = param.OpcRequestId });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ChangeVolumeGroupBackupCompartmentResponse()
                {
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Moves a boot volume backup into a different compartment within the same tenancy. 
        /// For information about moving resources between compartments, see Moving Resources to a Different Compartment.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public ChangeBootVolumeBackupCompartmentResponse ChangeBootVolumeBackupCompartment(ChangeBootVolumeBackupCompartmentRequest param)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.BootVolumeBackup, this.Region)}/{param.BootVolumeBackupId}/actions/changeCompartment");

            var webResponse = this.RestClient.Post(uri, param.ChangeBootVolumeBackupCompartmentDetails, new HttpRequestHeaderParam { OpcRequestId = param.OpcRequestId });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ChangeBootVolumeBackupCompartmentResponse()
                {
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
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

            var webResponse = this.RestClient.Post(uri, createRequest.CreateBootVolumeDetails, new HttpRequestHeaderParam { OpcRetryToken = createRequest.OpcRetryToken });

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
        /// Creates a new boot volume backup of the specified boot volume. 
        /// For general information about boot volume backups, see Overview of Boot Volume Backups
        /// 
        /// When the request is received, the backup object is in a REQUEST_RECEIVED state. 
        /// When the data is imaged, it goes into a CREATING state. After the backup is fully uploaded to the cloud, it goes into an AVAILABLE state.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public CreateBootVolumeBackupResponse CreateBootVolumeBackup(CreateBootVolumeBackupRequest param)
        {
            var uri = new Uri(GetEndPoint(CoreServices.BootVolumeBackup, this.Region));

            var webResponse = this.RestClient.Post(uri, param.CreateBootVolumeBackupDetails, new HttpRequestHeaderParam { OpcRetryToken = param.OpcRetryToken });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new CreateBootVolumeBackupResponse()
                {
                    BootVolumeBackup = JsonSerializer.Deserialize<BootVolumeBackup>(response),
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Creates a new volume in the specified compartment. Volumes can be created in sizes ranging from 50 GB 
        /// (51200 MB) to 32 TB (33554432 MB), in 1 GB (1024 MB) increments. By default, volumes are 1 TB (1048576 MB). 
        /// For general information about block volumes, see Overview of Block Volume Service.
        /// 
        /// A volume and instance can be in separate compartments but must be in the same availability domain. 
        /// For information about access control and compartments, see Overview of the IAM Service. 
        /// For information about availability domains, see Regions and Availability Domains. 
        /// To get a list of availability domains, use the ListAvailabilityDomains operation in the Identity and Access Management Service API.
        /// 
        /// You may optionally specify a display name for the volume, which is simply a friendly name or description. 
        /// It does not have to be unique, and you can change it. Avoid entering confidential information.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public CreateVolumeResponse CreateVolume(CreateVolumeRequest param)
        {
            var uri = new Uri(GetEndPoint(CoreServices.Volume, this.Region));

            var webResponse = this.RestClient.Post(uri, param.CreateVolumeDetails, new HttpRequestHeaderParam { OpcRetryToken = param.OpcRetryToken });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new CreateVolumeResponse()
                {
                    Volume = JsonSerializer.Deserialize<VolumeDetails>(response),
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Creates a new backup of the specified volume. For general information about volume backups, see Overview of Block Volume Service Backups
        /// 
        /// When the request is received, the backup object is in a REQUEST_RECEIVED state. 
        /// When the data is imaged, it goes into a CREATING state. After the backup is fully uploaded to the cloud, it goes into an AVAILABLE state.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public CreateVolumeBackupResponse CreateVolumeBackup(CreateVolumeBackupRequest param)
        {
            var uri = new Uri(GetEndPoint(CoreServices.VolumeBackup, this.Region));

            var webResponse = this.RestClient.Post(uri, param.CreateVolumeBackupDetails, new HttpRequestHeaderParam { OpcRetryToken = param.OpcRetryToken });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new CreateVolumeBackupResponse()
                {
                    VolumeBackup = JsonSerializer.Deserialize<VolumeBackup>(response),
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Assigns a policy to the specified asset, such as a volume. 
        /// Note that a given asset can only have one policy assigned to it; if this method is called for an asset that previously has a different policy assigned, 
        /// the prior assignment will be silently deleted.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public CreateVolumeBackupPolicyAssignmentResponse CreateVolumeBackupPolicyAssignment(CreateVolumeBackupPolicyAssignmentRequest param)
        {
            var uri = new Uri(GetEndPoint(CoreServices.VolumeBackupPolicyAssignment, this.Region));

            var webResponse = this.RestClient.Post(uri, param.CreateVolumeBackupPolicyAssignmentDetails);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new CreateVolumeBackupPolicyAssignmentResponse()
                {
                    VolumeBackupPolicyAssignment = JsonSerializer.Deserialize<VolumeBackupPolicyAssignment>(response),
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Creates a new volume group in the specified compartment. 
        /// A volume group is a collection of volumes and may be created from a list of volumes, cloning an existing volume group, or by restoring a volume group backup. 
        /// A volume group can contain up to 64 volumes. You may optionally specify a display name for the volume group, which is simply a friendly name or description. 
        /// It does not have to be unique, and you can change it. Avoid entering confidential information.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public CreateVolumeGroupResponse CreateVolumeGroup(CreateVolumeGroupRequest param)
        {
            var uri = new Uri(GetEndPoint(CoreServices.VolumeGroup, this.Region));

            var webResponse = this.RestClient.Post(uri, param.CreateVolumeGroupDetails, new HttpRequestHeaderParam { OpcRetryToken = param.OpcRetryToken });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new CreateVolumeGroupResponse()
                {
                    VolumeGroup = JsonSerializer.Deserialize<VolumeGroup>(response),
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Creates a new backup volume group of the specified volume group. For more information, see Volume Groups.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public CreateVolumeGroupBackupResponse CreateVolumeGroupBackup(CreateVolumeGroupBackupRequest param)
        {
            var uri = new Uri(GetEndPoint(CoreServices.VolumeGroupBackup, this.Region));

            var webResponse = this.RestClient.Post(uri, param.CreateVolumeGroupBackupDetails, new HttpRequestHeaderParam { OpcRetryToken = param.OpcRetryToken });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new CreateVolumeGroupBackupResponse()
                {
                    VolumeGroupBackup = JsonSerializer.Deserialize<VolumeGroupBackup>(response),
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

            var webResponse = this.RestClient.Put(uri, updateRequest.UpdateBootVolumeDetails, new HttpRequestHeaderParam(){ IfMatch = updateRequest.IfMatch });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new UpdateBootVolumeResponse()
                {
                    BootVolume = JsonSerializer.Deserialize<BootVolume>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    ETag = webResponse.Headers.Get("ETag")
                };
            }
        }

        /// <summary>
        /// Updates the display name for the specified boot volume backup. Avoid entering confidential information.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public UpdateBootVolumeBackupResponse UpdateBootVolumeBackup(UpdateBootVolumeBackupRequest param)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.BootVolumeBackup, this.Region)}/{param.BootVolumeBackupId}");

            var webResponse = this.RestClient.Put(uri, param.UpdateBootVolumeBackupDetails, new HttpRequestHeaderParam() { IfMatch = param.IfMatch });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new UpdateBootVolumeBackupResponse()
                {
                    BootVolumeBackup = JsonSerializer.Deserialize<BootVolumeBackup>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    ETag = webResponse.Headers.Get("ETag")
                };
            }
        }

        /// <summary>
        /// Updates the KMS key ID for the specified volume.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public UpdateBootVolumeKmsKeyResponse UpdateBootVolumeKmsKey(UpdateBootVolumeKmsKeyRequest param)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.BootVolume, this.Region)}/{param.BootVolumeId}/kmsKey");

            var webResponse = this.RestClient.Put(uri, param.UpdateBootVolumeKmsKeyDetails, new HttpRequestHeaderParam() { IfMatch = param.IfMatch });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new UpdateBootVolumeKmsKeyResponse()
                {
                    BootVolumeKmsKey = JsonSerializer.Deserialize<BootVolumeKmsKey>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    ETag = webResponse.Headers.Get("ETag")
                };
            }
        }

        /// <summary>
        /// Updates the specified volume's display name. Avoid entering confidential information.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public UpdateVolumeResponse UpdateVolume(UpdateVolumeRequest param)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.Volume, this.Region)}/{param.VolumeId}");

            var webResponse = this.RestClient.Put(uri, param.UpdateVolumeDetails, new HttpRequestHeaderParam() { IfMatch = param.IfMatch });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new UpdateVolumeResponse()
                {
                    Volume = JsonSerializer.Deserialize<VolumeDetails>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    ETag = webResponse.Headers.Get("ETag")
                };
            }
        }

        /// <summary>
        /// Updates the display name for the specified volume backup. Avoid entering confidential information.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public UpdateVolumeBackupResponse UpdateVolumeBackup(UpdateVolumeBackupRequest param)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.VolumeBackup, this.Region)}/{param.VolumeBackupId}");

            var webResponse = this.RestClient.Put(uri, param.UpdateVolumeBackupDetails, new HttpRequestHeaderParam() { IfMatch = param.IfMatch });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new UpdateVolumeBackupResponse()
                {
                    VolumeBackup = JsonSerializer.Deserialize<VolumeBackup>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    ETag = webResponse.Headers.Get("ETag")
                };
            }
        }

        /// <summary>
        /// Updates the set of volumes in a volume group along with the display name. 
        /// Use this operation to add or remove volumes in a volume group. Specify the full list of volume IDs to include in the volume group. 
        /// If the volume ID is not specified in the call, it will be removed from the volume group. Avoid entering confidential information.
        /// 
        /// For more information, see Volume Groups.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public UpdateVolumeGroupResponse UpdateVolumeGroup(UpdateVolumeGroupRequest param)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.VolumeGroup, this.Region)}/{param.VolumeGroupId}");

            var webResponse = this.RestClient.Put(uri, param.UpdateVolumeGroupDetails, new HttpRequestHeaderParam() { IfMatch = param.IfMatch });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new UpdateVolumeGroupResponse()
                {
                    VolumeGroup = JsonSerializer.Deserialize<VolumeGroup>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    ETag = webResponse.Headers.Get("ETag")
                };
            }
        }

        /// <summary>
        /// Updates the display name for the specified volume group backup. For more information, see Volume Groups.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public UpdateVolumeGroupBackupResponse UpdateVolumeGroupBackup(UpdateVolumeGroupBackupRequest param)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.VolumeGroupBackup, this.Region)}/{param.VolumeGroupBackupId}");

            var webResponse = this.RestClient.Put(uri, param.UpdateVolumeGroupBackupDetails, new HttpRequestHeaderParam() { IfMatch = param.IfMatch });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new UpdateVolumeGroupBackupResponse()
                {
                    VolumeGroupBackup = JsonSerializer.Deserialize<VolumeGroupBackup>(response),
                    ETag = webResponse.Headers.Get("ETag")
                };
            }
        }
        
        /// <summary>
        /// Updates the KMS key ID for the specified volume.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public UpdateVolumeKmsKeyResponse UpdateVolumeKmsKey(UpdateVolumeKmsKeyRequest param)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.Volume, this.Region)}/{param.VolumeId}/kmsKey");

            var webResponse = this.RestClient.Put(uri, param.UpdateVolumeKmsKeyDetails, new HttpRequestHeaderParam() { IfMatch = param.IfMatch });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new UpdateVolumeKmsKeyResponse()
                {
                    VolumeKmsKey = JsonSerializer.Deserialize<VolumeKmsKey>(response),
                    ETag = webResponse.Headers.Get("ETag")
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
            
            var webResponse = this.RestClient.Delete(uri, new HttpRequestHeaderParam() { IfMatch = deleteRequest.IfMatch });

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

        /// <summary>
        /// /Deletes a boot volume backup.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public DeleteBootVolumeBackupResponse DeleteBootVolumeBackup(DeleteBootVolumeBackupRequest param)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.BootVolumeBackup, this.Region)}/{param.BootVolumeBackupId}");

            var webResponse = this.RestClient.Delete(uri, new HttpRequestHeaderParam() { IfMatch = param.IfMatch });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new DeleteBootVolumeBackupResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Removes the KMS key for the specified boot volume.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public DeleteBootVolumeKmsKeyResponse DeleteBootVolumeKmsKey(DeleteBootVolumeKmsKeyRequest param)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.BootVolume, this.Region)}/{param.BootVolumeId}/kmsKey");

            var webResponse = this.RestClient.Delete(uri, new HttpRequestHeaderParam() { IfMatch = param.IfMatch });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new DeleteBootVolumeKmsKeyResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Deletes the specified volume. The volume cannot have an active connection to an instance. 
        /// To disconnect the volume from a connected instance, see Disconnecting From a Volume. 
        /// Warning: All data on the volume will be permanently lost when the volume is deleted.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public DeleteVolumeResponse DeleteVolume(DeleteVolumeRequest param)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.VolumeBackup, this.Region)}/{param.VolumeId}");

            var webResponse = this.RestClient.Delete(uri, new HttpRequestHeaderParam() { IfMatch = param.IfMatch });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new DeleteVolumeResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Deletes a volume backup.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public DeleteVolumeBackupResponse DeleteVolumeBackup(DeleteVolumeBackupRequest param)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.VolumeBackup, this.Region)}/{param.VolumeBackupId}");

            var webResponse = this.RestClient.Delete(uri, new HttpRequestHeaderParam() { IfMatch = param.IfMatch });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new DeleteVolumeBackupResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Deletes a volume backup policy assignment (i.e. unassigns the policy from an asset).
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public DeleteVolumeBackupPolicyAssignmentResponse DeleteVolumeBackupPolicyAssignment(DeleteVolumeBackupPolicyAssignmentRequest param)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.VolumeBackupPolicyAssignment, this.Region)}/{param.PolicyAssignmentId}");

            var webResponse = this.RestClient.Delete(uri, new HttpRequestHeaderParam() { IfMatch = param.IfMatch });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new DeleteVolumeBackupPolicyAssignmentResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Deletes a volume group backup. This operation deletes all the backups in the volume group. For more information, see Volume Groups.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public DeleteVolumeGroupBackupResponse DeleteVolumeGroupBackup(DeleteVolumeGroupBackupRequest param)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.VolumeGroupBackup, this.Region)}/{param.VolumeGroupBackupId}");

            var webResponse = this.RestClient.Delete(uri, new HttpRequestHeaderParam() { IfMatch = param.IfMatch });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new DeleteVolumeGroupBackupResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Removes the KMS key for the specified volume.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public DeleteVolumeKmsKeyResponse DeleteVolumeKmsKey(DeleteVolumeKmsKeyRequest param)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.Volume, this.Region)}/{param.VolumeId}/kmsKey");

            var webResponse = this.RestClient.Delete(uri, new HttpRequestHeaderParam() { IfMatch = param.IfMatch });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new DeleteVolumeKmsKeyResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Creates a volume backup copy in specified region. For general information about volume backups, see Overview of Block Volume Service Backups
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public CopyVolumeBackupResponse CopyVolumeBackup(CopyVolumeBackupRequest param)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.VolumeBackup, this.Region)}/{param.VolumeBackupId}/actions/copy");

            var webResponse = this.RestClient.Post(uri, param.CopyVolumeBackupDetails, new HttpRequestHeaderParam { OpcRetryToken = param.OpcRetryToken });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new CopyVolumeBackupResponse()
                {
                    VolumeBackup = JsonSerializer.Deserialize<VolumeBackup>(response),
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }
    }
}

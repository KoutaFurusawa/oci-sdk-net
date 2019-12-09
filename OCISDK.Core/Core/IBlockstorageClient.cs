using OCISDK.Core.Core.Request.Blockstorage;
using OCISDK.Core.Core.Response.Blockstorage;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core
{
    /// <summary>
    /// BlockstorageClient interface
    /// </summary>
    public interface IBlockstorageClient : IClientSetting
    {
        /// <summary>
        /// Lists the boot volumes in the specified compartment and availability domain.
        /// </summary>
        /// <param name="listRequest"></param>
        /// <returns></returns>
        ListBootVolumesResponse ListBootVolumes(ListBootVolumesRequest listRequest);

        /// <summary>
        /// Lists the boot volume backups in the specified compartment. You can filter the results by boot volume.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        ListBootVolumeBackupsResponse ListBootVolumeBackups(ListBootVolumeBackupsRequest param);

        /// <summary>
        /// Lists the volumes in the specified compartment and availability domain.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        ListVolumesResponse ListVolumes(ListVolumesRequest param);

        /// <summary>
        /// Lists the volume backups in the specified compartment. You can filter the results by volume.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        ListVolumeBackupsResponse ListVolumeBackups(ListVolumeBackupsRequest param);

        /// <summary>
        /// Lists all volume backup policies available to the caller.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        ListVolumeBackupPoliciesResponse ListVolumeBackupPolicies(ListVolumeBackupPoliciesRequest param);

        /// <summary>
        /// Lists the volume groups in the specified compartment and availability domain. For more information, see Volume Groups.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        ListVolumeGroupsResponse ListVolumeGroups(ListVolumeGroupsRequest param);

        /// <summary>
        /// Lists the volume group backups in the specified compartment. You can filter the results by volume group. For more information, see Volume Groups.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        ListVolumeGroupBackupsResponse ListVolumeGroupBackups(ListVolumeGroupBackupsRequest param);

        /// <summary>
        /// Gets the volume backup policy assignment for the specified asset.
        /// Note that the assetId query parameter is required, and that the returned list will contain at most one item 
        /// (since any given asset can only have one policy assigned to it).
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        GetVolumeBackupPolicyAssetAssignmentResponse GetVolumeBackupPolicyAssetAssignment(GetVolumeBackupPolicyAssetAssignmentRequest param);

        /// <summary>
        /// Gets information for the specified boot volume.
        /// </summary>
        /// <param name="getRequest"></param>
        /// <returns></returns>
        GetBootVolumeResponse GetBootVolume(GetBootVolumeRequest getRequest);

        /// <summary>
        /// Gets information for the specified boot volume backup.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        GetBootVolumeBackupResponse GetBootVolumeBackup(GetBootVolumeBackupRequest param);

        /// <summary>
        /// Gets the KMS key ID for the specified boot volume.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        GetBootVolumeKmsKeyResponse GetBootVolumeKmsKey(GetBootVolumeKmsKeyRequest param);

        /// <summary>
        /// Gets information for the specified volume.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        GetVolumeResponse GetVolume(GetVolumeRequest param);

        /// <summary>
        /// Gets information for the specified volume backup.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        GetVolumeBackupResponse GetVolumeBackup(GetVolumeBackupRequest param);

        /// <summary>
        /// Gets information for the specified volume backup policy.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        GetVolumeBackupPolicyResponse GetVolumeBackupPolicy(GetVolumeBackupPolicyRequest param);

        /// <summary>
        /// Gets information for the specified volume backup policy assignment.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        GetVolumeBackupPolicyAssignmentResponse GetVolumeBackupPolicyAssignment(GetVolumeBackupPolicyAssignmentRequest param);

        /// <summary>
        /// Gets information for the specified volume group. For more information, see Volume Groups.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        GetVolumeGroupResponse GetVolumeGroup(GetVolumeGroupRequest param);

        /// <summary>
        /// Gets information for the specified volume group backup. For more information, see Volume Groups.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        GetVolumeGroupBackupResponse GetVolumeGroupBackup(GetVolumeGroupBackupRequest param);

        /// <summary>
        /// Gets the KMS key ID for the specified volume.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        GetVolumeKmsKeyResponse GetVolumeKmsKey(GetVolumeKmsKeyRequest param);

        /// <summary>
        /// Moves a boot volume into a different compartment within the same tenancy. 
        /// For information about moving resources between compartments, see Moving Resources to a Different Compartment.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        ChangeBootVolumeCompartmentResponse ChangeBootVolumeCompartment(ChangeBootVolumeCompartmentRequest param);

        /// <summary>
        /// Moves a volume into a different compartment within the same tenancy. 
        /// \For information about moving resources between compartments, see Moving Resources to a Different Compartment.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        ChangeVolumeCompartmentResponse ChangeVolumeCompartment(ChangeVolumeCompartmentRequest param);

        /// <summary>
        /// Moves a volume backup into a different compartment within the same tenancy.
        /// For information about moving resources between compartments, see Moving Resources to a Different Compartment.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        ChangeVolumeBackupCompartmentResponse ChangeVolumeBackupCompartment(ChangeVolumeBackupCompartmentRequest param);

        /// <summary>
        /// Moves a volume group into a different compartment within the same tenancy. 
        /// For information about moving resources between compartments, see Moving Resources to a Different Compartment.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        ChangeVolumeGroupCompartmentResponse ChangeVolumeGroupCompartment(ChangeVolumeGroupCompartmentRequest param);

        /// <summary>
        /// Moves a volume group backup into a different compartment within the same tenancy. 
        /// For information about moving resources between compartments, see Moving Resources to a Different Compartment.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        ChangeVolumeGroupBackupCompartmentResponse ChangeVolumeGroupBackupCompartment(ChangeVolumeGroupBackupCompartmentRequest param);

        /// <summary>
        /// Moves a boot volume backup into a different compartment within the same tenancy. 
        /// For information about moving resources between compartments, see Moving Resources to a Different Compartment.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        ChangeBootVolumeBackupCompartmentResponse ChangeBootVolumeBackupCompartment(ChangeBootVolumeBackupCompartmentRequest param);

        /// <summary>
        /// Creates a new boot volume in the specified compartment from an existing boot volume or a 
        /// boot volume backup. For general information about boot volumes, see Boot Volumes. You may 
        /// optionally specify a display name for the volume, which is simply a friendly name or description. 
        /// It does not have to be unique, and you can change it. Avoid entering confidential information.
        /// </summary>
        /// <param name="createRequest"></param>
        /// <returns></returns>
        CreateBootVolumeResponse CreateBootVolume(CreateBootVolumeRequest createRequest);

        /// <summary>
        /// Creates a new boot volume backup of the specified boot volume. 
        /// For general information about boot volume backups, see Overview of Boot Volume Backups
        /// 
        /// When the request is received, the backup object is in a REQUEST_RECEIVED state. 
        /// When the data is imaged, it goes into a CREATING state. After the backup is fully uploaded to the cloud, it goes into an AVAILABLE state.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        CreateBootVolumeBackupResponse CreateBootVolumeBackup(CreateBootVolumeBackupRequest param);

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
        CreateVolumeResponse CreateVolume(CreateVolumeRequest param);

        /// <summary>
        /// Creates a new backup of the specified volume. For general information about volume backups, see Overview of Block Volume Service Backups
        /// 
        /// When the request is received, the backup object is in a REQUEST_RECEIVED state. 
        /// When the data is imaged, it goes into a CREATING state. After the backup is fully uploaded to the cloud, it goes into an AVAILABLE state.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        CreateVolumeBackupResponse CreateVolumeBackup(CreateVolumeBackupRequest param);

        /// <summary>
        /// Assigns a policy to the specified asset, such as a volume. 
        /// Note that a given asset can only have one policy assigned to it; if this method is called for an asset that previously has a different policy assigned, 
        /// the prior assignment will be silently deleted.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        CreateVolumeBackupPolicyAssignmentResponse CreateVolumeBackupPolicyAssignment(CreateVolumeBackupPolicyAssignmentRequest param);

        /// <summary>
        /// Creates a new volume group in the specified compartment. 
        /// A volume group is a collection of volumes and may be created from a list of volumes, cloning an existing volume group, or by restoring a volume group backup. 
        /// A volume group can contain up to 64 volumes. You may optionally specify a display name for the volume group, which is simply a friendly name or description. 
        /// It does not have to be unique, and you can change it. Avoid entering confidential information.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        CreateVolumeGroupResponse CreateVolumeGroup(CreateVolumeGroupRequest param);

        /// <summary>
        /// Creates a new backup volume group of the specified volume group. For more information, see Volume Groups.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        CreateVolumeGroupBackupResponse CreateVolumeGroupBackup(CreateVolumeGroupBackupRequest param);

        /// <summary>
        /// Updates the specified boot volume's display name, defined tags, and free-form tags.
        /// </summary>
        /// <param name="updateRequest"></param>
        /// <returns></returns>
        UpdateBootVolumeResponse UpdateBootVolume(UpdateBootVolumeRequest updateRequest);

        /// <summary>
        /// Updates the display name for the specified boot volume backup. Avoid entering confidential information.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        UpdateBootVolumeBackupResponse UpdateBootVolumeBackup(UpdateBootVolumeBackupRequest param);

        /// <summary>
        /// Updates the KMS key ID for the specified volume.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        UpdateBootVolumeKmsKeyResponse UpdateBootVolumeKmsKey(UpdateBootVolumeKmsKeyRequest param);

        /// <summary>
        /// Updates the specified volume's display name. Avoid entering confidential information.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        UpdateVolumeResponse UpdateVolume(UpdateVolumeRequest param);

        /// <summary>
        /// Updates the display name for the specified volume backup. Avoid entering confidential information.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        UpdateVolumeBackupResponse UpdateVolumeBackup(UpdateVolumeBackupRequest param);

        /// <summary>
        /// Updates the set of volumes in a volume group along with the display name. 
        /// Use this operation to add or remove volumes in a volume group. Specify the full list of volume IDs to include in the volume group. 
        /// If the volume ID is not specified in the call, it will be removed from the volume group. Avoid entering confidential information.
        /// 
        /// For more information, see Volume Groups.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        UpdateVolumeGroupResponse UpdateVolumeGroup(UpdateVolumeGroupRequest param);

        /// <summary>
        /// Updates the display name for the specified volume group backup. For more information, see Volume Groups.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        UpdateVolumeGroupBackupResponse UpdateVolumeGroupBackup(UpdateVolumeGroupBackupRequest param);

        /// <summary>
        /// Updates the KMS key ID for the specified volume.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        UpdateVolumeKmsKeyResponse UpdateVolumeKmsKey(UpdateVolumeKmsKeyRequest param);

        /// <summary>
        /// Deletes the specified boot volume. The volume cannot have an active connection to an instance. 
        /// To disconnect the boot volume from a connected instance, see Disconnecting From a Boot Volume. 
        /// Warning: All data on the boot volume will be permanently lost when the boot volume is deleted.
        /// </summary>
        /// <param name="deleteRequest"></param>
        /// <returns></returns>
        DeleteBootVolumeResponse DeleteBootVolume(DeleteBootVolumeRequest deleteRequest);

        /// <summary>
        /// /Deletes a boot volume backup.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        DeleteBootVolumeBackupResponse DeleteBootVolumeBackup(DeleteBootVolumeBackupRequest param);

        /// <summary>
        /// Removes the KMS key for the specified boot volume.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        DeleteBootVolumeKmsKeyResponse DeleteBootVolumeKmsKey(DeleteBootVolumeKmsKeyRequest param);

        /// <summary>
        /// Deletes the specified volume. The volume cannot have an active connection to an instance. 
        /// To disconnect the volume from a connected instance, see Disconnecting From a Volume. 
        /// Warning: All data on the volume will be permanently lost when the volume is deleted.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        DeleteVolumeResponse DeleteVolume(DeleteVolumeRequest param);

        /// <summary>
        /// Deletes a volume backup.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        DeleteVolumeBackupResponse DeleteVolumeBackup(DeleteVolumeBackupRequest param);

        /// <summary>
        /// Deletes a volume backup policy assignment (i.e. unassigns the policy from an asset).
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        DeleteVolumeBackupPolicyAssignmentResponse DeleteVolumeBackupPolicyAssignment(DeleteVolumeBackupPolicyAssignmentRequest param);

        /// <summary>
        /// Deletes a volume group backup. This operation deletes all the backups in the volume group. For more information, see Volume Groups.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        DeleteVolumeGroupBackupResponse DeleteVolumeGroupBackup(DeleteVolumeGroupBackupRequest param);

        /// <summary>
        /// Removes the KMS key for the specified volume.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        DeleteVolumeKmsKeyResponse DeleteVolumeKmsKey(DeleteVolumeKmsKeyRequest param);

        /// <summary>
        /// Creates a volume backup copy in specified region. For general information about volume backups, see Overview of Block Volume Service Backups
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        CopyVolumeBackupResponse CopyVolumeBackup(CopyVolumeBackupRequest param);

    }
}

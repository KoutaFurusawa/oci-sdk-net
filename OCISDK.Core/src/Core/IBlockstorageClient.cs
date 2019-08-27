using OCISDK.Core.src.Core.Request.Blockstorage;
using OCISDK.Core.src.Core.Response.Blockstorage;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.src.Core
{
    public interface IBlockstorageClient
    {
        /// <summary>
        /// setter region
        /// </summary>
        /// <param name="region"></param>
        void SetRegion(string region);

        /// <summary>
        /// getter region
        /// </summary>
        /// <returns></returns>
        string GetRegion();

        /// <summary>
        /// Lists the boot volumes in the specified compartment and availability domain.
        /// </summary>
        /// <param name="listRequest"></param>
        /// <returns></returns>
        ListBootVolumesResponse ListBootVolumes(ListBootVolumesRequest listRequest);

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
        /// Gets information for the specified boot volume.
        /// </summary>
        /// <param name="getRequest"></param>
        /// <returns></returns>
        GetBootVolumeResponse GetBootVolume(GetBootVolumeRequest getRequest);

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
        /// Creates a new boot volume in the specified compartment from an existing boot volume or a 
        /// boot volume backup. For general information about boot volumes, see Boot Volumes. You may 
        /// optionally specify a display name for the volume, which is simply a friendly name or description. 
        /// It does not have to be unique, and you can change it. Avoid entering confidential information.
        /// </summary>
        /// <param name="createRequest"></param>
        /// <returns></returns>
        CreateBootVolumeResponse CreateBootVolume(CreateBootVolumeRequest createRequest);

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
        /// Updates the specified boot volume's display name, defined tags, and free-form tags.
        /// </summary>
        /// <param name="updateRequest"></param>
        /// <returns></returns>
        UpdateBootVolumeResponse UpdateBootVolume(UpdateBootVolumeRequest updateRequest);

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
        /// Deletes the specified boot volume. The volume cannot have an active connection to an instance. 
        /// To disconnect the boot volume from a connected instance, see Disconnecting From a Boot Volume. 
        /// Warning: All data on the boot volume will be permanently lost when the boot volume is deleted.
        /// </summary>
        /// <param name="deleteRequest"></param>
        /// <returns></returns>
        DeleteBootVolumeResponse DeleteBootVolume(DeleteBootVolumeRequest deleteRequest);

        /// <summary>
        /// Deletes a volume backup.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        DeleteVolumeBackupResponse DeleteVolumeBackup(DeleteVolumeBackupRequest param);

        /// <summary>
        /// Creates a volume backup copy in specified region. For general information about volume backups, see Overview of Block Volume Service Backups
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        CopyVolumeBackupResponse CopyVolumeBackup(CopyVolumeBackupRequest param);

    }
}

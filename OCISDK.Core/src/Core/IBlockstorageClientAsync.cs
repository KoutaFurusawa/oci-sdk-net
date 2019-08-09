using OCISDK.Core.src.Core.Request.Blockstorage;
using OCISDK.Core.src.Core.Response.Blockstorage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OCISDK.Core.src.Core
{
    public interface IBlockstorageClientAsync
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
        Task<ListBootVolumesResponse> ListBootVolumes(ListBootVolumesRequest listRequest);

        /// <summary>
        /// Moves a boot volume into a different compartment within the same tenancy. 
        /// For information about moving resources between compartments, see Moving Resources to a Different Compartment.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        Task<ChangeBootVolumeCompartmentResponse> ChangeBootVolumeCompartment(ChangeBootVolumeCompartmentRequest param);

        /// <summary>
        /// Creates a new boot volume in the specified compartment from an existing boot volume or a 
        /// boot volume backup. For general information about boot volumes, see Boot Volumes. You may 
        /// optionally specify a display name for the volume, which is simply a friendly name or description. 
        /// It does not have to be unique, and you can change it. Avoid entering confidential information.
        /// </summary>
        /// <param name="createRequest"></param>
        /// <returns></returns>
        Task<CreateBootVolumeResponse> CreateBootVolume(CreateBootVolumeRequest createRequest);

        /// <summary>
        /// Updates the specified boot volume's display name, defined tags, and free-form tags.
        /// </summary>
        /// <param name="updateRequest"></param>
        /// <returns></returns>
        Task<UpdateBootVolumeResponse> UpdateBootVolume(UpdateBootVolumeRequest updateRequest);

        /// <summary>
        /// Gets information for the specified boot volume.
        /// </summary>
        /// <param name="getRequest"></param>
        /// <returns></returns>
        Task<GetBootVolumeResponse> GetBootVolume(GetBootVolumeRequest getRequest);

        /// <summary>
        /// Deletes the specified boot volume. The volume cannot have an active connection to an instance. 
        /// To disconnect the boot volume from a connected instance, see Disconnecting From a Boot Volume. 
        /// Warning: All data on the boot volume will be permanently lost when the boot volume is deleted.
        /// </summary>
        /// <param name="deleteRequest"></param>
        /// <returns></returns>
        Task<DeleteBootVolumeResponse> DeleteBootVolume(DeleteBootVolumeRequest deleteRequest);
        
    }
}

using OCISDK.Core.Core.Model.Blockstorage;

namespace OCISDK.Core.Core.Request.Blockstorage
{
    /// <summary>
    /// ChangeVolumeBackupCompartment Request
    /// </summary>
    public class ChangeVolumeBackupCompartmentRequest
    {
        /// <summary>
        /// The OCID of the volume backup.
        /// <para>Required: yes</para>
        /// </summary>
        public string VolumeBackupId { get; set; }

        /// <summary>
        /// Unique identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.
        /// <para>Required: no</para>
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// The request body must contain a single ChangeVolumeBackupCompartmentDetails resource.
        /// </summary>
        public ChangeVolumeBackupCompartmentDetails ChangeVolumeBackupCompartmentDetails { get; set; }
    }
}

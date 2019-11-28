using OCISDK.Core.Core.Model.Blockstorage;

namespace OCISDK.Core.Core.Request.Blockstorage
{
    /// <summary>
    /// UpdateBootVolume Request
    /// </summary>
    public class UpdateBootVolumeRequest
    {
        /// <summary>
        /// The OCID of the boot volume.
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string BootVolumeId { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// <para>if-match header parameter</para>
        /// </summary>
        public string IfMatch { get; set; }

        /// <summary>
        /// The request body must contain a single UpdateBootVolumeDetails resource.
        /// </summary>
        public UpdateBootVolumeDetails UpdateBootVolumeDetails { get; set; }
    }
}

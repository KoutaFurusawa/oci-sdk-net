/// <summary>
/// GetBootVolumeRequest class
/// 
/// author: koutaro furusawa
/// </summary>

namespace OCISDK.Core.src.Core.Request.Blockstorage
{
    public class GetBootVolumeRequest
    {
        /// <summary>
        /// The OCID of the boot volume.
        /// <para>Required: yes</para>
        /// </summary>
        public string BootVolumeId { get; set; }
    }
}

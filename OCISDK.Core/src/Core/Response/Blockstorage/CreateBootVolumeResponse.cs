/// <summary>
/// CreateBootVolumeResponse class
/// 
/// author: koutaro furusawa
/// </summary>

using OCISDK.Core.src.Core.Model.Blockstorage;

namespace OCISDK.Core.src.Core.Response.Blockstorage
{
    public class CreateBootVolumeResponse
    {
        /// <summary>
        /// response header parameter ETag
        /// </summary>
        public string ETag { get; set; }

        /// <summary>
        /// response header parameter opcRequestId
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// The response body will contain a single BootVolume resource.
        /// </summary>
        public BootVolume BootVolume { get; set; }
    }
}

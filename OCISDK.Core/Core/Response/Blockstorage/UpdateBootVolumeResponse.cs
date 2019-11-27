using OCISDK.Core.Core.Model.Blockstorage;

namespace OCISDK.Core.Core.Response.Blockstorage
{
    /// <summary>
    /// UpdateBootVolume Response
    /// </summary>
    public class UpdateBootVolumeResponse
    {
        /// <summary>
        /// For optimistic concurrency control. See if-match.
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

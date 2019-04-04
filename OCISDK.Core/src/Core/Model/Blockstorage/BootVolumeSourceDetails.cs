/// <summary>
/// BootVolumeSourceDetails Reference
/// 
/// author: koutaro furusawa
/// </summary>
namespace OCISDK.Core.src.Core.Model.Blockstorage
{
    public class BootVolumeSourceDetails
    {
        /// <summary>
        /// <para>Required: yes</para>
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string Id { get; set; }
    }
}

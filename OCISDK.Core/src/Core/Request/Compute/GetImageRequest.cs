/// <summary>
/// GetImageRequest class
/// 
/// author: koutaro furusawa
/// </summary>
namespace OCISDK.Core.src.Core.Request.Compute
{
    public class GetImageRequest
    {
        /// <summary>
        /// The OCID of the image.
        /// <para>Required: yes</para>
        /// </summary>
        public string ImageId { get; set; }
    }
}

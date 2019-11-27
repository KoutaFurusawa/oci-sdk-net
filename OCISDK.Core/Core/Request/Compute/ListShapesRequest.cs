using System;
using System.Text;

namespace OCISDK.Core.Core.Request.Compute
{
    /// <summary>
    /// ListShapes Request
    /// </summary>
    public class ListShapesRequest
    {
        /// <summary>
        /// The name of the availability domain.
        /// Example: Uocm:PHX-AD-1
        /// <para>Required: no</para>
        /// </summary>
        public string AvailabilityDomain { get; set; }

        /// <summary>
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// The OCID of an image.
        /// </summary>
        public string ImageId { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public int? Limit { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 512</para>
        /// </summary>
        public string Page { get; set; }

        /// <summary>
        /// option query
        /// </summary>
        /// <returns></returns>
        public string GetOptionQuery()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"compartmentId={this.CompartmentId}");

            if (!String.IsNullOrEmpty(this.AvailabilityDomain))
            {
                sb.Append($"&availabilityDomain={this.AvailabilityDomain}");
            }
            if (!String.IsNullOrEmpty(this.ImageId))
            {
                sb.Append($"&imageId={this.ImageId}");
            }
            if (this.Limit.HasValue)
            {
                sb.Append($"&limit={this.Limit.Value}");
            }
            if (!String.IsNullOrEmpty(this.Page))
            {
                sb.Append($"&page={this.Page}");
            }

            return sb.ToString();
        }
    }
}

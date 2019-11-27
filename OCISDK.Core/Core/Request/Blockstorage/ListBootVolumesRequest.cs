using System;
using System.Text;

namespace OCISDK.Core.Core.Request.Blockstorage
{
    /// <summary>
    /// ListBootVolumes Request
    /// </summary>
    public class ListBootVolumesRequest
    {
        /// <summary>
        /// The name of the availability domain.
        /// <para>Required: yes</para>
        /// </summary>
        public string AvailabilityDomain { get; set; }

        /// <summary>
        /// The OCID of the compartment.
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string CompartmentId { get; set; }

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
        /// The OCID of the volume group.
        /// <para>Required: no</para>
        /// </summary>
        public string VolumeGroupId { get; set; }

        /// <summary>
        /// optional query
        /// </summary>
        /// <returns></returns>
        public string GetOptionQuery()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"availabilityDomain={this.AvailabilityDomain}");

            sb.Append($"&compartmentId={this.CompartmentId}");

            if (!String.IsNullOrEmpty(this.VolumeGroupId))
            {
                sb.Append($"&volumeGroupId={this.VolumeGroupId}");
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

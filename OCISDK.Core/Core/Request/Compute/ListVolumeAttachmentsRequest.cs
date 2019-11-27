using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Request.Compute
{
    /// <summary>
    /// ListVolumeAttachments Request
    /// </summary>
    public class ListVolumeAttachmentsRequest
    {
        /// <summary>
        /// The OCID of the compartment.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// The name of the availability domain.
        /// <para>Required: no</para>
        /// </summary>
        public string AvailabilityDomain { get; set; }

        /// <summary>
        /// For list pagination. The maximum number of results per page, or items to return in a paginated "List" call. 
        /// For important details about how pagination works, see List Pagination.
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 1000</para>
        /// </summary>
        public int? Limit { get; set; }

        /// <summary>
        /// For list pagination. The value of the opc-next-page response header from the previous "List" call. 
        /// For important details about how pagination works, see List Pagination.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 512</para>
        /// </summary>
        public string Page { get; set; }

        /// <summary>
        /// The OCID of the instance.
        /// <para>Required: no</para>
        /// </summary>
        public string InstanceId { get; set; }

        /// <summary>
        /// The OCID of the volume.
        /// <para>Required: no</para>
        /// </summary>
        public string VolumeId { get; set; }

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

            if (!String.IsNullOrEmpty(this.InstanceId))
            {
                sb.Append($"&instanceId={this.InstanceId}");
            }
            if (!String.IsNullOrEmpty(this.VolumeId))
            {
                sb.Append($"&volumeId={this.VolumeId}");
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

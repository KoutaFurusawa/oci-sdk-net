using System;
using System.Text;

namespace OCISDK.Core.Core.Request.Compute
{
    /// <summary>
    /// ListVnicAttachments Request
    /// </summary>
    public class ListVnicAttachmentsRequest
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
        /// The OCID of the instance.
        /// <para>Required: no</para>
        /// </summary>
        public string InstanceId { get; set; }

        /// <summary>
        /// The OCID of the VNIC.
        /// <para>Required: no</para>
        /// </summary>
        public string VnicId { get; set; }

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

            if (!String.IsNullOrEmpty(this.InstanceId))
            {
                sb.Append($"&instanceId={this.InstanceId}");
            }
            if (!String.IsNullOrEmpty(this.VnicId))
            {
                sb.Append($"&vnicId={this.VnicId}");
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

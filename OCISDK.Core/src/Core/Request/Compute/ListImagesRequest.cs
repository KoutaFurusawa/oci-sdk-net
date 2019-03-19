/// <summary>
/// ListImagesRequest class
/// 
/// author: koutaro furusawa
/// </summary>

using OCISDK.Core.src.Common;
using System;
using System.ComponentModel;
using System.Text;

namespace OCISDK.Core.src.Core.Request.Compute
{
    public class ListImagesRequest
    {
        /// <summary>
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The image's operating system. 
        /// Example: Oracle Linux
        /// <para>Required: no</para>
        /// </summary>
        public string OperatingSystem { get; set; }

        /// <summary>
        /// The image's operating system version.
        /// Example: 7.2
        /// <para>Required: no</para>
        /// </summary>
        public string OperatingSystemVersion { get; set; }

        /// <summary>
        /// Shape name.
        /// <para>Required: no</para>
        /// </summary>
        public string Shape { get; set; }

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
        /// <para>Required: no</para>
        /// <para>Allowed values are:
        /// TIMECREATED
        /// , DISPLAYNAME</para>
        /// </summary>
        public SortBy? SortBy { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// <para>Allowed values are:
        /// ASC
        /// , DESC</para>
        /// </summary>
        public SortOrder? SortOrder { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public LifecycleStates? LifecycleState { get; set; }

        public enum LifecycleStates
        {
            [DisplayName("PROVISIONING")]
            PROVISIONING,
            [DisplayName("IMPORTING")]
            IMPORTING,
            [DisplayName("AVAILABLE")]
            AVAILABLE,
            [DisplayName("EXPORTING")]
            EXPORTING,
            [DisplayName("DISABLED")]
            DISABLED,
            [DisplayName("DELETED")]
            DELETED
        }

        public string GetOptionQuery()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"compartmentId={this.CompartmentId}");

            if (!String.IsNullOrEmpty(this.OperatingSystem))
            {
                sb.Append($"&operatingSystem={this.OperatingSystem}");
            }
            if (!String.IsNullOrEmpty(this.OperatingSystemVersion))
            {
                sb.Append($"&operatingSystemVersion={this.OperatingSystemVersion}");
            }
            if (!String.IsNullOrEmpty(this.Shape))
            {
                sb.Append($"&shape={this.Shape}");
            }
            if (!String.IsNullOrEmpty(this.DisplayName))
            {
                sb.Append($"&displayName={this.DisplayName}");
            }
            if (this.LifecycleState.HasValue)
            {
                sb.Append($"&lifecycleState={EnumAttribute.GetDisplayName(this.LifecycleState.Value)}");
            }
            if (this.Limit.HasValue)
            {
                sb.Append($"&limit={this.Limit.Value}");
            }
            if (!String.IsNullOrEmpty(this.Page))
            {
                sb.Append($"&page={this.Page}");
            }
            if (this.SortBy.HasValue)
            {
                sb.Append($"&sortBy={EnumAttribute.GetDisplayName(this.SortBy.Value)}");
            }
            if (this.SortOrder.HasValue)
            {
                sb.Append($"&sortOrder={EnumAttribute.GetDisplayName(this.SortOrder.Value)}");
            }

            return sb.ToString();
        }
    }
}

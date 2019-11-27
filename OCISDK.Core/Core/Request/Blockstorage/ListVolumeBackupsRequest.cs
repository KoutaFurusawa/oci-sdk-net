﻿using OCISDK.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace OCISDK.Core.Core.Request.Blockstorage
{
    /// <summary>
    /// ListVolumeBackups Request
    /// </summary>
    public class ListVolumeBackupsRequest
    {
        /// <summary>
        /// The OCID of the compartment.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// The OCID of the volume.
        /// <para>Required: no</para>
        /// </summary>
        public string VolumeId { get; set; }

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
        /// A filter to return only resources that match the given display name exactly.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// A filter to return only resources that originated from the given source volume backup.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string SourceVolumeBackupId { get; set; }

        /// <summary>
        /// The field to sort by. You can provide one sort order (sortOrder). 
        /// Default order for TIMECREATED is descending. Default order for DISPLAYNAME is ascending. 
        /// The DISPLAYNAME sort order is case sensitive.
        /// <para>Required: no</para>
        /// </summary>
        public SortByParam SortBy { get; set; }
        
        /// <summary>
        /// SortBy ExpandableEnum
        /// </summary>
        public class SortByParam : ExpandableEnum<SortByParam>
        {
            /// <summary>
            /// SortBy ExpandableEnum
            /// </summary>
            /// <param name="value"></param>
            public SortByParam(string value) : base(value) { }

            /// <summary>
            /// parse
            /// </summary>
            /// <param name="value"></param>
            public static implicit operator SortByParam(string value)
            {
                return Parse(value);
            }

            /// <summary>
            /// TIMECREATED
            /// </summary>
            public static readonly SortByParam TIMECREATED = new SortByParam("TIMECREATED");

            /// <summary>
            /// DISPLAYNAME
            /// </summary>
            public static readonly SortByParam DISPLAYNAME = new SortByParam("DISPLAYNAME");
        }


        /// <summary>
        /// The sort order to use, either ascending (ASC) or descending (DESC). 
        /// The DISPLAYNAME sort order is case sensitive.
        /// <para>Required: no</para>
        /// </summary>
        public SortOrder SortOrder { get; set; }

        /// <summary>
        /// A filter to only return resources that match the given lifecycle state. 
        /// The state value is case-insensitive.
        /// </summary>
        public string LifecycleState { get; set; }

        /// <summary>
        /// option query
        /// </summary>
        /// <returns></returns>
        public string GetOptionQuery()
        {
            StringBuilder sb = new StringBuilder();
            
            sb.Append($"compartmentId={this.CompartmentId}");

            if (!String.IsNullOrEmpty(this.VolumeId))
            {
                sb.Append($"&volumeId={this.VolumeId}");
            }
            if (!String.IsNullOrEmpty(this.DisplayName))
            {
                sb.Append($"&displayName={this.DisplayName}");
            }
            if (!String.IsNullOrEmpty(this.SourceVolumeBackupId))
            {
                sb.Append($"&sourceVolumeBackupId={this.SourceVolumeBackupId}");
            }
            if (!(SortBy is null))
            {
                sb.Append($"&sortBy={SortBy.Value}");
            }

            if (!(SortOrder is null))
            {
                sb.Append($"&sortOrder={this.SortOrder.Value}");
            }

            if (this.Limit.HasValue)
            {
                sb.Append($"&limit={this.Limit.Value}");
            }
            if (!String.IsNullOrEmpty(this.Page))
            {
                sb.Append($"&page={this.Page}");
            }
            if (!String.IsNullOrEmpty(this.LifecycleState))
            {
                sb.Append($"&lifecycleState={this.LifecycleState}");
            }

            return sb.ToString();
        }
    }
}

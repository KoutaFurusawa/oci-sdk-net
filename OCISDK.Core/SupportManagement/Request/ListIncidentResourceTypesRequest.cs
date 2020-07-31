﻿using OCISDK.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.SupportManagement.Request
{
    /// <summary>
    /// ListIncidentResourceTypes request
    /// </summary>
    public class ListIncidentResourceTypesRequest
    {
        /// <summary>
        /// Unique Oracle-assigned identifier for the request. If you need to contact Oracle about 
        /// a particular request, please provide the request ID.
        /// <para>Required: no</para>
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// The kind of support request.
        /// <para>Required: yes</para>
        /// </summary>
        public string ProblemType { get; set; }

        /// <summary>
        /// The maximum number of returned results in a call.
        /// <para>Required: no</para>
        /// <para>Default: 50</para>
        /// </summary>
        public int? Limit { get; set; }

        /// <summary>
        /// The pagination token to continue listing from.
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 512</para>
        /// </summary>
        public string Page { get; set; }

        /// <summary>
        /// The field by which to sort steering policies. If unspecified, defaults to timeCreated.
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
            /// displayName
            /// </summary>
            public static readonly SortByParam DateUpdated = new SortByParam("dateUpdated");

            /// <summary>
            /// severity
            /// </summary>
            public static readonly SortByParam Severity = new SortByParam("severity");
        }

        /// <summary>
        /// The sort order to use, either ascending (ASC) or descending (DESC).
        /// <para>Required: no</para>
        /// <para>Allowed values are: ASC, DESC</para>
        /// </summary>
        public SortOrder SortOrder { get; set; }

        /// <summary>
        /// The OCID of the tenancy.
        /// <para>Required: yes</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// The user-friendly name of the incident type.
        /// <para>Required: no</para>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The Customer Support Identifier associated with the support account.
        /// <para>Required: yes</para>
        /// </summary>
        public string Csi { get; set; }

        /// <summary>
        /// User OCID for Oracle Identity Cloud Service (IDCS) users who also have a federated Oracle Cloud Infrastructure account.
        /// <para>Required: yes</para>
        /// </summary>
        public string Ocid { get; set; }

        /// <summary>
        /// The region of the tenancy.
        /// <para>Required: no</para>
        /// </summary>
        public string Homeregion { get; set; }

        /// <summary>
        /// option query
        /// </summary>
        /// <returns></returns>
        public string GetOptionQuery()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"compartmentId={this.CompartmentId}");

            sb.Append($"&problemType={this.ProblemType}");

            if (!string.IsNullOrEmpty(this.Name))
            {
                sb.Append($"&name={this.Name}");
            }

            if (this.Limit.HasValue)
            {
                sb.Append($"&limit={this.Limit.Value}");
            }

            if (!string.IsNullOrEmpty(this.Page))
            {
                sb.Append($"&page={this.Page}");
            }

            if (!(SortBy is null))
            {
                sb.Append($"&sortBy={SortBy.Value}");
            }

            if (!(SortOrder is null))
            {
                sb.Append($"&sortOrder={SortOrder.Value}");
            }

            return sb.ToString();
        }
    }
}

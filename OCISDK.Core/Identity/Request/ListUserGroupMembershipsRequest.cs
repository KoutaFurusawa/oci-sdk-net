using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Identity.Request
{
    /// <summary>
    /// ListUserGroupMemberships Request
    /// </summary>
    public class ListUserGroupMembershipsRequest
    {
        /// <summary>
        /// The OCID of the compartment (remember that the tenancy is simply the root compartment).
        /// <para>Required: yes</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// The OCID of the user.
        /// <para>Required: no</para>
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// The OCID of the group.
        /// <para>Required: no</para>
        /// </summary>
        public string GroupId { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 512</para>
        /// </summary>
        public string Page { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 1000</para>
        /// </summary>
        public int? Limit { get; set; }

        /// <summary>
        /// option query
        /// </summary>
        /// <returns></returns>
        public string GetOptionQuery()
        {
            var options = $"compartmentId={this.CompartmentId}";

            if (!string.IsNullOrEmpty(this.UserId))
            {
                options += $"&userId={this.UserId}";
            }

            if (!string.IsNullOrEmpty(this.GroupId))
            {
                options += $"&groupId={this.GroupId}";
            }

            if (!string.IsNullOrEmpty(this.Page))
            {
                options += $"&page={this.Page}";
            }

            if (this.Limit.HasValue)
            {
                options += $"&limit={this.Limit.Value}";
            }

            return options;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Identity.Request
{
    /// <summary>
    /// GetUserGroupMembership Request
    /// </summary>
    public class GetUserGroupMembershipRequest
    {
        /// <summary>
        /// The OCID of the userGroupMembership.
        /// <para>Required: yes</para>
        /// </summary>
        public string UserGroupMembershipId { get; set; }
    }
}

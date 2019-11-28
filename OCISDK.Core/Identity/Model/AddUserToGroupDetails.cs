using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Identity.Model
{
    /// <summary>
    /// AddUserToGroupDetails Reference
    /// </summary>
    public class AddUserToGroupDetails
    {
        /// <summary>
        /// The OCID of the user.
        /// <para>Required: yes</para>
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// The OCID of the group.
        /// <para>Required: yes</para>
        /// </summary>
        public string GroupId { get; set; }
    }
}

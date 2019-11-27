using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Identity.Model
{
    /// <summary>
    /// An object that represents the membership of a user in a group. 
    /// When you add a user to a group, the result is a UserGroupMembership with its own OCID. 
    /// To remove a user from a group, you delete the UserGroupMembership object.
    /// </summary>
    public class UserGroupMembership
    {
        /// <summary>
        /// The OCID of the membership.
        /// <para>Required: yes</para>
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The OCID of the tenancy containing the user, group, and membership object.
        /// <para>Required: yes</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// The OCID of the group.
        /// <para>Required: yes</para>
        /// </summary>
        public string GroupId { get; set; }

        /// <summary>
        /// The OCID of the user.
        /// <para>Required: yes</para>
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Date and time the membership was created, in the format defined by RFC3339.
        /// <para>Required: yes</para>
        /// </summary>
        public string TimeCreated { get; set; }

        /// <summary>
        /// The membership's current state. 
        /// After creating a membership object, make sure its lifecycleState changes from CREATING to ACTIVE before using it.
        /// <para>Required: yes</para>
        /// </summary>
        public string LifecycleState { get; set; }

        /// <summary>
        /// The detailed status of INACTIVE lifecycleState.
        /// <para>Required: no</para>
        /// </summary>
        public int? InactiveStatus { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Identity.Model
{
    /// <summary>
    /// A text password that enables a user to sign in to the Console, the user interface for interacting with Oracle Cloud Infrastructure.
    /// 
    /// For more information about user credentials, see User Credentials.
    /// </summary>
    public class UIPasswordDetails
    {
        /// <summary>
        /// The user's password for the Console.
        /// <para>Required: no</para>
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// The OCID of the user.
        /// <para>Required: no</para>
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Date and time the password was created, in the format defined by RFC3339.
        /// <para>Required: no</para>
        /// </summary>
        public string TimeCreated { get; set; }

        /// <summary>
        /// The password's current state. 
        /// After creating a password, make sure its lifecycleState changes from CREATING to ACTIVE before using it.
        /// <para>Required: no</para>
        /// </summary>
        public string LifecycleState { get; set; }

        /// <summary>
        /// The detailed status of INACTIVE lifecycleState.
        /// <para>Required: no</para>
        /// </summary>
        public int? InactiveStatus { get; set; }
    }
}

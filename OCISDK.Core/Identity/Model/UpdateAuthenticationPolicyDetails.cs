using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Identity.Model
{
    /// <summary>
    /// Update request for authentication policy, describes set of validation rules and their parameters to be updated.
    /// </summary>
    public class UpdateAuthenticationPolicyDetails
    {
        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public NetworkPolicy NetworkPolicy { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public PasswordPolicy PasswordPolicy { get; set; }
    }
}

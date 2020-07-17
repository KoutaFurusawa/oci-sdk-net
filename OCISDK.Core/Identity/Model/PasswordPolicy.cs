using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Identity.Model
{
    /// <summary>
    /// Password policy, currently set for the given compartment.
    /// </summary>
    public class PasswordPolicy
    {
        /// <summary>
        /// At least one lower case character required.
        /// <para>Required: no</para>
        /// <para>Default: true</para>
        /// </summary>
        public bool? IsLowercaseCharactersRequired { get; set; }

        /// <summary>
        /// At least one numeric character required.
        /// <para>Required: no</para>
        /// <para>Default: true</para>
        /// </summary>
        public bool? IsNumericCharactersRequired { get; set; }

        /// <summary>
        /// At least one special character required.
        /// <para>Required: no</para>
        /// <para>Default: true</para>
        /// </summary>
        public bool? IsSpecialCharactersRequired { get; set; }

        /// <summary>
        /// At least one uppercase character required.
        /// <para>Required: no</para>
        /// <para>Default: true</para>
        /// </summary>
        public bool? IsUppercaseCharactersRequired { get; set; }

        /// <summary>
        /// User name is allowed to be part of the password.
        /// <para>Required: no</para>
        /// <para>Default: false</para>
        /// </summary>
        public bool? IsUsernameContainmentAllowed { get; set; }

        /// <summary>
        /// Minimum password length required.
        /// <para>Required: no</para>
        /// <para>Default: 12</para>
        /// </summary>
        public int? MinimumPasswordLength { get; set; }
    }
}

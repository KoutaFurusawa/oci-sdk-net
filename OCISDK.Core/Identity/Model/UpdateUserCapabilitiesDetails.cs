using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Identity.Model
{
    /// <summary>
    /// UpdateUserCapabilitiesDetails Reference
    /// </summary>
    public class UpdateUserCapabilitiesDetails
    {
        /// <summary>
        /// Indicates if the user can log in to the console.
        /// <para>Required: no</para>
        /// </summary>
        public bool? CanUseConsolePassword { get; set; }

        /// <summary>
        /// Indicates if the user can use API keys.
        /// <para>Required: no</para>
        /// </summary>
        public bool? CanUseApiKeys { get; set; }

        /// <summary>
        /// Indicates if the user can use SWIFT passwords / auth tokens.
        /// <para>Required: no</para>
        /// </summary>
        public bool? CanUseAuthTokens { get; set; }

        /// <summary>
        /// Indicates if the user can use SMTP passwords.
        /// <para>Required: no</para>
        /// </summary>
        public bool? CanUseSmtpCredentials { get; set; }

        /// <summary>
        /// Indicates if the user can use SigV4 symmetric keys.
        /// <para>Required: no</para>
        /// </summary>
        public bool? CanUseCustomerSecretKeys { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Identity.Model
{
    /// <summary>
    /// Authentication policy, currently set for the given compartment
    /// </summary>
    public class AuthenticationPolicy
    {
        /// <summary>
        /// Compartment OCID.
        /// <para>Required: no</para>
        /// </summary>
        public string CompartmentId { get; set; }

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

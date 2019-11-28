using OCISDK.Core.DNS.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.DNS.Request
{
    /// <summary>
    /// CreateSteeringPolicy Request
    /// </summary>
    public class CreateSteeringPolicyRequest
    {
        /// <summary>
        /// A token that uniquely identifies a request so it can be retried in case of a timeout or server error without risk of executing that same action again.
        /// Retry tokens expire after 24 hours, but can be invalidated before then due to conflicting operations (for example, if a resource has been deleted and 
        /// purged from the system, then a retry of the original creation request may be rejected).
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 64</para>
        /// </summary>
        public string OpcRetryToken { get; set; }

        /// <summary>
        /// The request body must contain a single CreateSteeringPolicyDetails resource.
        /// </summary>
        public CreateSteeringPolicyDetails CreateSteeringPolicyDetails { get; set; }
    }
}

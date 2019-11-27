using OCISDK.Core.DNS.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.DNS.Request
{
    /// <summary>
    /// ChangeSteeringPolicyCompartment Request Reference
    /// </summary>
    public class ChangeSteeringPolicyCompartmentRequest
    {
        /// <summary>
        /// The If-Match header field makes the request method conditional on the existence of at least one current representation of the target resource, 
        /// when the field-value is *, or having a current representation of the target resource that has an entity-tag matching a member of the list of 
        /// entity-tags provided in the field-value.
        /// <para>Required: no</para>
        /// </summary>
        public string IfMatch { get; set; }

        /// <summary>
        /// A token that uniquely identifies a request so it can be retried in case of a timeout or server error without risk of executing that same action again.
        /// Retry tokens expire after 24 hours, but can be invalidated before then due to conflicting operations (for example, if a resource has been deleted and 
        /// purged from the system, then a retry of the original creation request may be rejected).
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 64</para>
        /// </summary>
        public string OpcRetryToken { get; set; }

        /// <summary>
        /// The OCID of the target steering policy.
        /// <para>Required: yes</para>
        /// </summary>
        public string SteeringPolicyId { get; set; }

        /// <summary>
        /// The request body must contain a single ChangeSteeringPolicyCompartmentDetails resource.
        /// </summary>
        public ChangeSteeringPolicyCompartmentDetails ChangeSteeringPolicyCompartmentDetails { get; set; }
    }
}

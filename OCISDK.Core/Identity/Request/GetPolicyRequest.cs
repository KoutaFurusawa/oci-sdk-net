using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Identity.Request
{
    /// <summary>
    /// GetPolicy Request
    /// </summary>
    public class GetPolicyRequest
    {
        /// <summary>
        /// The OCID of the policy.
        /// <para>Required: yes</para>
        /// </summary>
        public string PolicyId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Identity.Model
{
    /// <summary>
    /// A document that specifies the type of access a group has to the resources in a compartment. 
    /// For information about policies and other IAM Service components, see Overview of the IAM Service. 
    /// If you're new to policies, see Getting Started with Policies.
    /// </summary>
    public class Policy
    {
        /// <summary>
        /// The OCID of the policy.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The OCID of the compartment containing the policy (either the tenancy or another compartment).
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// The name you assign to the policy during creation. The name must be unique across all policies in the tenancy and cannot be changed.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// An array of one or more policy statements written in the policy language.
        /// </summary>
        public List<string> Statements { get; set; }

        /// <summary>
        /// The description you assign to the policy. Does not have to be unique, and it's changeable.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Date and time the policy was created, in the format defined by RFC3339.
        /// </summary>
        public string TimeCreated { get; set; }

        /// <summary>
        /// The policy's current state. After creating a policy, make sure its lifecycleState changes from CREATING to ACTIVE before using it.
        /// </summary>
        public string LifecycleState { get; set; }

        /// <summary>
        /// The detailed status of INACTIVE lifecycleState.
        /// </summary>
        public int? InactiveStatus { get; set; }

        /// <summary>
        /// The version of the policy. 
        /// If null or set to an empty string, when a request comes in for authorization, the policy will be evaluated according to the current behavior of 
        /// the services at that moment. If set to a particular date (YYYY-MM-DD), the policy will be evaluated according to the behavior of the services on that date.
        /// </summary>
        public string VersionDate { get; set; }

        /// <summary>
        /// Free-form tags for this resource. Each tag is a simple key-value pair with no predefined name, type, or namespace. 
        /// For more information, see Resource Tags.
        /// </summary>
        public IDictionary<string, string> FreeformTags { get; set; }

        /// <summary>
        /// Defined tags for this resource. Each key is predefined and scoped to a namespace. 
        /// For more information, see Resource Tags.
        /// </summary>
        public IDictionary<string, IDictionary<string, string>> DefinedTags { get; set; }
    }
}

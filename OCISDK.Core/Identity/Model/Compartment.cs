
using System.Collections.Generic;

namespace OCISDK.Core.Identity.Model
{
    /// <summary>
    /// Compartment Reference
    /// A collection of related resources. Compartments are a fundamental component of 
    /// Oracle Cloud Infrastructure for organizing and isolating your cloud resources. 
    /// You use them to clearly separate resources for the purposes of measuring usage 
    /// and billing, access (through the use of IAM Service policies), and isolation 
    /// (separating the resources for one project or business unit from another). A common 
    /// approach is to create a compartment for each major part of your organization. 
    /// For more information, see Overview of the IAM Service and also Setting Up Your 
    /// Tenancy.
    /// 
    /// author: koutaro furusawa
    /// </summary>
    public class Compartment
    {
        /// <summary>
        /// The OCID of the compartment.
        /// <para>Required: yes</para>
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The OCID of the parent compartment containing the compartment.
        /// <para>Required: yes</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// The name you assign to the compartment during creation. The name must be unique across all compartments in the parent. 
        /// Avoid entering confidential information.
        /// <para>Required: yes</para>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description you assign to the compartment. Does not have to be unique, and it's changeable.
        /// <para>Required: yes</para>
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Date and time the compartment was created, in the format defined by RFC3339.
        /// <para>Required: yes</para>
        /// </summary>
        public string TimeCreated { get; set; }

        /// <summary>
        /// The compartment's current state. After creating a compartment, make sure its lifecycleState changes from CREATING to ACTIVE before using it.
        /// <para>Required: yes</para>
        /// </summary>
        public string LifecycleState { get; set; }

        /// <summary>
        /// The detailed status of INACTIVE lifecycleState.
        /// <para>Required: no</para>
        /// </summary>
        public int? InactiveStatus { get; set; }

        /// <summary>
        /// Indicates whether or not the compartment is accessible for the user making the request. 
        /// Returns true when the user has INSPECT permissions directly on a resource in the compartment or indirectly 
        /// (permissions can be on a resource in a subcompartment).
        /// <para>Required: no</para>
        /// </summary>
        public bool? IsAccessible { get; set; }

        /// <summary>
        /// Free-form tags for this resource. Each tag is a simple key-value pair with no predefined name, type, or namespace.
        /// <para>Required: no</para>
        /// </summary>
        public IDictionary<string, string> FreeformTags { get; set; }

        /// <summary>
        /// Defined tags for this resource. Each key is predefined and scoped to a namespace. 
        /// <para>Required: no</para>
        /// </summary>
        public IDictionary<string, IDictionary<string, string>> DefinedTags { get; set; }
    }
}

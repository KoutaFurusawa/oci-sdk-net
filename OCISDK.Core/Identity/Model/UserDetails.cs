using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Identity.Model
{
    /// <summary>
    /// An individual employee or system that needs to manage or use your company's Oracle Cloud Infrastructure resources. 
    /// Users might need to launch instances, manage remote disks, work with your cloud network, etc. 
    /// Users have one or more IAM Service credentials (ApiKey, UIPassword, SwiftPassword and AuthToken). 
    /// For more information, see User Credentials). End users of your application are not typically IAM Service users. 
    /// For conceptual information about users and other IAM Service components, see Overview of the IAM Service.
    /// 
    /// These users are created directly within the Oracle Cloud Infrastructure system, via the IAM service. 
    /// They are different from federated users, who authenticate themselves to the Oracle Cloud Infrastructure Console via an identity provider. 
    /// For more information, see Identity Providers and Federation.
    /// 
    /// To use any of the API operations, you must be authorized in an IAM policy. 
    /// If you're not authorized, talk to an administrator. If you're an administrator who needs to write policies to give users access, see Getting Started with Policies.
    /// 
    /// Warning: Oracle recommends that you avoid using any confidential information when you supply string values using the API.
    /// </summary>
    public class UserDetails
    {
        /// <summary>
        /// The OCID of the user.
        /// <para>Required: yes</para>
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The OCID of the tenancy containing the user.
        /// <para>Required: yes</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// The name you assign to the user during creation. 
        /// This is the user's login for the Console. 
        /// The name must be unique across all users in the tenancy and cannot be changed.
        /// <para>Required: yes</para>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description you assign to the user. Does not have to be unique, and it's changeable.
        /// <para>Required: yes</para>
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The email address you assign to the user. The email address must be unique across all users in the tenancy.
        /// <para>Required: no</para>
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The OCID of the IdentityProvider this user belongs to.
        /// <para>Required: no</para>
        /// </summary>
        public string IdentityProviderId { get; set; }

        /// <summary>
        /// Identifier of the user in the identity provider
        /// <para>Required: no</para>
        /// </summary>
        public string ExternalIdentifier { get; set; }

        /// <summary>
        /// Date and time the user was created, in the format defined by RFC3339.
        /// <para>Required: yes</para>
        /// </summary>
        public string TimeCreated { get; set; }

        /// <summary>
        /// The user's current state. After creating a user, make sure its lifecycleState changes from CREATING to ACTIVE before using it.
        /// <para>Required: yes</para>
        /// </summary>
        public string LifecycleState { get; set; }

        /// <summary>
        /// Returned only if the user's lifecycleState is INACTIVE.
        /// <para>Required: no</para>
        /// </summary>
        public int? InactiveStatus { get; set; }

        /// <summary>
        /// Properties indicating how the user is allowed to authenticate.
        /// <para>Required: no</para>
        /// </summary>
        public UserCapabilities Capabilities { get; set; }

        /// <summary>
        /// Flag indicates if MFA has been activated for the user.
        /// <para>Required: yes</para>
        /// </summary>
        public bool IsMfaActivated { get; set; }

        /// <summary>
        /// Free-form tags for this resource. Each tag is a simple key-value pair with no predefined name, type, or namespace. 
        /// For more information, see Resource Tags.
        /// <para>Required: no</para>
        /// </summary>
        public IDictionary<string, string> FreeformTags { get; set; }

        /// <summary>
        /// Defined tags for this resource. Each key is predefined and scoped to a namespace. 
        /// For more information, see Resource Tags.
        /// <para>Required: no</para>
        /// </summary>
        public IDictionary<string, IDictionary<string, string>> DefinedTags { get; set; }
    }
}

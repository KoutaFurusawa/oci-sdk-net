using System.Collections.Generic;


namespace OCISDK.Core.Core.Model.VirtualNetwork
{
    /// <summary>
    /// A dynamic routing gateway (DRG), which is a virtual router that provides a path for private network traffic between your VCN and your existing network. 
    /// You use it with other Networking Service components to create an IPSec VPN or a connection that uses Oracle Cloud Infrastructure FastConnect. 
    /// For more information, see Overview of the Networking Service.
    /// 
    /// To use any of the API operations, you must be authorized in an IAM policy. 
    /// If you're not authorized, talk to an administrator. 
    /// If you're an administrator who needs to write policies to give users access, see Getting Started with Policies.
    /// 
    /// Warning: Oracle recommends that you avoid using any confidential information when you supply string values using the API.
    /// </summary>
    public class DrgDetails
    {
        /// <summary>
        /// The OCID of the compartment containing the DRG.
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// A user-friendly name. Does not have to be unique, and it's changeable.
        /// Avoid entering confidential information.
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The DRG's Oracle ID (OCID).
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The DRG's current state.
        /// <para>Required: yes</para>
        /// </summary>
        public string LifecycleState { get; set; }

        /// <summary>
        /// The date and time the DRG was created, in the format defined by RFC3339.
        /// <para>Required: no</para>
        /// </summary>
        public string TimeCreated { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public IDictionary<string, string> FreeformTags { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public IDictionary<string, IDictionary<string, string>> DefinedTags { get; set; }
    }
}

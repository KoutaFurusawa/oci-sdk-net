using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Model.VirtualNetwork
{
    /// <summary>
    /// An object you create when setting up an IPSec VPN between your on-premises network and VCN. The Cpe 
    /// is a virtual representation of your customer-premises equipment, which is the actual router on-premises 
    /// at your site at your end of the IPSec VPN connection. For more information, see Overview of the Networking 
    /// Service.
    /// 
    /// To use any of the API operations, you must be authorized in an IAM policy. If you're not authorized, talk to 
    /// an administrator. If you're an administrator who needs to write policies to give users access, see Getting 
    /// Started with Policies.
    /// 
    /// Warning: Oracle recommends that you avoid using any confidential information when you supply string values 
    /// using the API.
    /// </summary>
    public class CpeDetails
    {
        /// <summary>
        /// The OCID of the compartment containing the CPE.
        /// <para>Required: yes</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// A user-friendly name. Does not have to be unique, and it's changeable. Avoid entering confidential information.
        /// <para>Required: no</para>
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The CPE's Oracle ID (OCID).
        /// <para>Required: yes</para>
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The public IP address of the on-premises router.
        /// <para>Required: yes</para>
        /// </summary>
        public string IpAddress { get; set; }

        /// <summary>
        /// The date and time the CPE was created, in the format defined by RFC3339.
        /// <para>Required: no</para>
        /// </summary>
        public string TimeCreated { get; set; }
    }
}

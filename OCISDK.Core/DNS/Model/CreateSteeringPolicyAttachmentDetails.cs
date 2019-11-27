using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.DNS.Model
{
    /// <summary>
    /// The body for defining an attachment between a steering policy and a domain.
    /// 
    /// Warning: Oracle recommends that you avoid using any confidential information when you supply string values using the API.
    /// </summary>
    public class CreateSteeringPolicyAttachmentDetails
    {
        /// <summary>
        /// The OCID of the attached steering policy.
        /// <para>Required: tes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string SteeringPolicyId { get; set; }

        /// <summary>
        /// The OCID of the attached zone.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string ZoneId { get; set; }

        /// <summary>
        /// The attached domain within the attached zone.
        /// <para>Required: yes</para>
        /// </summary>
        public string DomainName { get; set; }

        /// <summary>
        /// A user-friendly name for the steering policy attachment.
        /// Does not have to be unique and can be changed. Avoid entering confidential information.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string DisplayName { get; set; }
    }
}

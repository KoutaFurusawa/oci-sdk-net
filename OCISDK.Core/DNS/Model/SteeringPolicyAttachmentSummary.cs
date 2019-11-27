using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.DNS.Model
{
    /// <summary>
    /// An attachment between a steering policy and a domain.
    /// </summary>
    public class SteeringPolicyAttachmentSummary
    {
        /// <summary>
        /// The OCID of the attached steering policy.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string SteeringPolicyId { get; set; }

        /// <summary>
        /// The OCID of the attached zone.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string ZoneId { get; set; }

        /// <summary>
        /// The attached domain within the attached zone.
        /// <para>Required: no</para>
        /// </summary>
        public string DomainName { get; set; }

        /// <summary>
        /// A user-friendly name for the steering policy attachment.
        /// Does not have to be unique and can be changed. Avoid entering confidential information.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The record types covered by the attachment at the domain.
        /// The set of record types is determined by aggregating the record types from the answers defined in the steering policy.
        /// <para>Required: no</para>
        /// </summary>
        public List<string> Rtypes { get; set; }

        /// <summary>
        /// The OCID of the compartment containing the steering policy attachment.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// The canonical absolute URL of the resource.
        /// <para>Required: no</para>
        /// </summary>
        public string Self { get; set; }

        /// <summary>
        /// The OCID of the resource.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The date and time the resource was created, expressed in RFC 3339 timestamp format.
        /// <para>Required: no</para>
        /// </summary>
        public string TimeCreated { get; set; }

        /// <summary>
        /// The current state of the resource.
        /// <para>Required: no</para>
        /// </summary>
        public string LifecycleState { get; set; }
    }
}

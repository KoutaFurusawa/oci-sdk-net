using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.DNS.Model
{
    /// <summary>
    /// A DNS steering policy.
    /// 
    /// Warning: Oracle recommends that you avoid using any confidential information when you supply string values using the API.
    /// </summary>
    public class SteeringPolicySummary
    {
        /// <summary>
        /// The OCID of the compartment containing the steering policy.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// A user-friendly name for the steering policy. Does not have to be unique and can be changed. Avoid entering confidential information.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The Time To Live (TTL) for responses from the steering policy, in seconds. If not specified during creation, a value of 30 seconds will be used.
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 604800</para>
        /// </summary>
        public int? Ttl { get; set; }

        /// <summary>
        /// The OCID of the health check monitor providing health data about the answers of the steering policy.
        /// A steering policy answer with rdata matching a monitored endpoint will use the health data of that endpoint.
        /// A steering policy answer with rdata not matching any monitored endpoint will be assumed healthy.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string HealthCheckMonitorId { get; set; }

        /// <summary>
        /// A set of predefined rules based on the desired purpose of the steering policy.
        /// Each template utilizes Traffic Management's rules in a different order to produce the desired results when answering DNS queries.
        /// <para>Required: no</para>
        /// </summary>
        public string Template { get; set; }

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

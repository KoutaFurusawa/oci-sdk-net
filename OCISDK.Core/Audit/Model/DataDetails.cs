using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace OCISDK.Core.Audit.Model
{
    /// <summary>
    /// The payload of the event. Information within data comes from the resource emitting the event.
    /// </summary>
    public class DataDetails
    {
        /// <summary>
        /// This value links multiple audit events that are part of the same API operation. 
        /// For example, a long running API operations that emit an event at the start and the end of an operation would use the same value in this field for both events.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string EventGroupingId { get; set; }

        /// <summary>
        /// Name of the API operation that generated this event.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string EventName { get; set; }

        /// <summary>
        /// The OCID of the compartment of the resource emitting the event.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// The name of the compartment. This value is the friendly name associated with compartmentId.
        /// This value can change, but the service logs the value that appeared at the time of the audit event.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 100</para>
        /// </summary>
        public string CompartmentName { get; set; }

        /// <summary>
        /// The name of the resource emitting the event.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string ResourceName { get; set; }

        /// <summary>
        /// An OCID or some other ID for the resource emitting the event.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string ResourceId { get; set; }

        /// <summary>
        /// The availability domain where the resource resides.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string AvailabilityDomain { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public IdentityDetails Identity { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public RequestDetails Request { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public ResponseDetails Response { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public StateChangeDetails StateChange { get; set; }

        /// <summary>
        /// A container object for attribues unique to the resource emitting the event.
        /// <para>Required: no</para>
        /// </summary>
        public object AdditionalDetails { get; set; }

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
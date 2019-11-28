using System;

namespace OCISDK.Core.Audit.Model
{
    /// <summary>
    /// All the attributes of an audit event. 
    /// For more information, see Viewing Audit Log Events.
    /// </summary>
    public class AuditEvent
    {
        /// <summary>
        /// The type of event that happened.
        /// 
        /// The service that produces the event can also add, remove, or change the meaning of a field. 
        /// A service implementing these type changes would publish a new version of an eventType and revise the eventTypeVersion field.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 1024</para>
        /// </summary>
        public string EventType { get; set; }

        /// <summary>
        /// The version of the CloudEvents specification. 
        /// The structure of the envelope follows the CloudEvents industry standard format hosted by the Cloud Native Computing Foundation ( CNCF).
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string CloudEventsVersion { get; set; }

        /// <summary>
        /// The version of the event type. This version applies to the payload of the event, not the envelope. 
        /// Use cloudEventsVersion to determine the version of the envelope.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string EventTypeVersion { get; set; }

        /// <summary>
        /// The source of the event.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 1024</para>
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// The GUID of the event.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string EventId { get; set; }

        /// <summary>
        /// The time the event occurred, expressed in RFC 3339 timestamp format.
        /// <para>Required: yes</para>
        /// </summary>
        public string EventTime { get; set; }

        /// <summary>
        /// The content type of the data contained in data.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// <para>Required: yes</para>
        /// </summary>
        public DataDetails Data { get; set; }
    }
}

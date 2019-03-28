/// <summary>
/// AuditEvent
/// 
/// author: koutaro furusawa
/// </summary>
using Newtonsoft.Json;
using System;

namespace OCISDK.Core.src.Audit.Model
{
    /// <summary>
    /// All the attributes of an audit event. 
    /// For more information, see Viewing Audit Log Events.
    /// </summary>
    public class AuditEvent
    {
        /// <summary>
        /// The OCID of the tenant.
        /// </summary>
        [JsonProperty("tenantId")]
        public string TenantId { get; set; }

        /// <summary>
        /// The OCID of the compartment.
        /// </summary>
        [JsonProperty("compartmentId")]
        public string CompartmentId { get; set; }

        /// <summary>
        /// The name of the compartment. This value is the friendly name associated with compartmentId. 
        /// This value can change, but the service logs the value that appeared at the time of the audit event.
        /// </summary>
        [JsonProperty("compartmentName")]
        public string CompartmentName { get; set; }

        /// <summary>
        /// The GUID of the event.
        /// Example: examplea9-f488-4842-96cb-a10f2893b369
        /// </summary>
        [JsonProperty("eventId")]
        public string EventId { get; set; }

        /// <summary>
        /// The name of the event.
        /// </summary>
        [JsonProperty("eventName")]
        public string EventName { get; set; }

        /// <summary>
        /// The source of the event.
        /// </summary>
        [JsonProperty("eventSource")]
        public string EventSource { get; set; }

        /// <summary>
        /// The type of event.
        /// </summary>
        [JsonProperty("eventType")]
        public string EventType { get; set; }

        /// <summary>
        /// The time the event occurred, expressed in RFC 3339 timestamp format.
        /// </summary>
        [JsonProperty("eventTime")]
        public string EventTime { get; set; }

        /// <summary>
        /// The OCID of the user whose action triggered the event.
        /// </summary>
        [JsonProperty("principalId")]
        public string PrincipalId { get; set; }

        /// <summary>
        /// The credential ID of the user. This value is extracted from the HTTP 'Authorization' request header. 
        /// It consists of the tenantId, userId, and user fingerprint, all delimited by a slash (/).
        /// </summary>
        [JsonProperty("credentialId")]
        public string CredentialId { get; set; }

        /// <summary>
        /// The HTTP method of the request.
        /// </summary>
        [JsonProperty("requestAction")]
        public string RequestAction { get; set; }

        /// <summary>
        /// The opc-request-id of the request.
        /// </summary>
        [JsonProperty("requestId")]
        public string RequestId { get; set; }

        /// <summary>
        /// The user agent of the client that made the request.
        /// </summary>
        [JsonProperty("requestAgent")]
        public string RequestAgent { get; set; }

        /// <summary>
        /// The HTTP header fields and values in the request.
        /// </summary>
        [JsonProperty("requestHeaders")]
        public Object RequestHeaders { get; set; }

        /// <summary>
        /// The IP address of the source of the request.
        /// </summary>
        [JsonProperty("requestOrigin")]
        public string RequestOrigin { get; set; }

        /// <summary>
        /// The query parameter fields and values for the request.
        /// </summary>
        [JsonProperty("requestParameters")]
        public Object RequestParameters { get; set; }

        /// <summary>
        /// The resource targeted by the request.
        /// </summary>
        [JsonProperty("requestResource")]
        public string RequestResource { get; set; }

        /// <summary>
        /// The headers of the response.
        /// </summary>
        [JsonProperty("responseHeaders")]
        public Object ResponseHeaders { get; set; }

        /// <summary>
        /// The status code of the response.
        /// </summary>
        [JsonProperty("responseStatus")]
        public string ResponseStatus { get; set; }

        /// <summary>
        /// The time of the response to the audited request, expressed in RFC 3339 timestamp format.
        /// </summary>
        [JsonProperty("responseTime")]
        public string ResponseTime { get; set; }

        /// <summary>
        /// Metadata of interest from the response payload. For example, the OCID of a resource (id) and 
        /// the name of the resource (resourceName). Some API operations can generate an audit event, 
        /// but don't involve a resource, so then responsePayload is empty.
        /// </summary>
        [JsonProperty("responsePayload")]
        public Object ResponsePayload { get; set; }

        /// <summary>
        /// The name of the user or service. This value is the friendly name associated with principalId.
        /// </summary>
        [JsonProperty("userName")]
        public string UserName { get; set; }
    }
}

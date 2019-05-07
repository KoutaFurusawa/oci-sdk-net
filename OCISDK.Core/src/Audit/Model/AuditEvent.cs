/// <summary>
/// AuditEvent
/// 
/// author: koutaro furusawa
/// </summary>

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
        public string TenantId { get; set; }

        /// <summary>
        /// The OCID of the compartment.
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// The name of the compartment. This value is the friendly name associated with compartmentId. 
        /// This value can change, but the service logs the value that appeared at the time of the audit event.
        /// </summary>
        public string CompartmentName { get; set; }

        /// <summary>
        /// The GUID of the event.
        /// Example: examplea9-f488-4842-96cb-a10f2893b369
        /// </summary>
        public string EventId { get; set; }

        /// <summary>
        /// The name of the event.
        /// </summary>
        public string EventName { get; set; }

        /// <summary>
        /// The source of the event.
        /// </summary>
        public string EventSource { get; set; }

        /// <summary>
        /// The type of event.
        /// </summary>
        public string EventType { get; set; }

        /// <summary>
        /// The time the event occurred, expressed in RFC 3339 timestamp format.
        /// </summary>
        public string EventTime { get; set; }

        /// <summary>
        /// The OCID of the user whose action triggered the event.
        /// </summary>
        public string PrincipalId { get; set; }

        /// <summary>
        /// The credential ID of the user. This value is extracted from the HTTP 'Authorization' request header. 
        /// It consists of the tenantId, userId, and user fingerprint, all delimited by a slash (/).
        /// </summary>
        public string CredentialId { get; set; }

        /// <summary>
        /// The HTTP method of the request.
        /// </summary>
        public string RequestAction { get; set; }

        /// <summary>
        /// The opc-request-id of the request.
        /// </summary>
        public string RequestId { get; set; }

        /// <summary>
        /// The user agent of the client that made the request.
        /// </summary>
        public string RequestAgent { get; set; }

        /// <summary>
        /// The HTTP header fields and values in the request.
        /// </summary>
        public object RequestHeaders { get; set; }

        /// <summary>
        /// The IP address of the source of the request.
        /// </summary>
        public string RequestOrigin { get; set; }

        /// <summary>
        /// The query parameter fields and values for the request.
        /// </summary>
        public object RequestParameters { get; set; }

        /// <summary>
        /// The resource targeted by the request.
        /// </summary>
        public string RequestResource { get; set; }

        /// <summary>
        /// The headers of the response.
        /// </summary>
        public object ResponseHeaders { get; set; }

        /// <summary>
        /// The status code of the response.
        /// </summary>
        public string ResponseStatus { get; set; }

        /// <summary>
        /// The time of the response to the audited request, expressed in RFC 3339 timestamp format.
        /// </summary>
        public string ResponseTime { get; set; }

        /// <summary>
        /// Metadata of interest from the response payload. For example, the OCID of a resource (id) and 
        /// the name of the resource (resourceName). Some API operations can generate an audit event, 
        /// but don't involve a resource, so then responsePayload is empty.
        /// </summary>
        public Object ResponsePayload { get; set; }

        /// <summary>
        /// The name of the user or service. This value is the friendly name associated with principalId.
        /// </summary>
        public string UserName { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace OCISDK.Core.Audit.Model
{
    /// <summary>
    /// A container object for identity attributes.
    /// </summary>
    public class IdentityDetails
    {
        /// <summary>
        /// The name of the user or service. This value is the friendly name associated with principalId.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 100</para>
        /// </summary>
        public string PrincipalName { get; set; }

        /// <summary>
        /// The OCID of the principal.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string PrincipalId { get; set; }

        /// <summary>
        /// The type of authentication used.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string AuthType { get; set; }

        /// <summary>
        /// The name of the user or service. This value is the friendly name associated with callerId.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 100</para>
        /// </summary>
        public string CallerName { get; set; }

        /// <summary>
        /// The OCID of the caller. The caller that made a request on behalf of the prinicpal.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string CallerId { get; set; }

        /// <summary>
        /// The OCID of the tenant.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string TenantId { get; set; }

        /// <summary>
        /// The IP address of the source of the request.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string IpAddress { get; set; }

        /// <summary>
        /// The credential ID of the user. This value is extracted from the HTTP 'Authorization' request header.
        /// It consists of the tenantId, userId, and user fingerprint, all delimited by a slash (/).
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string Credentials { get; set; }

        /// <summary>
        /// The user agent of the client that made the request.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 1024</para>
        /// </summary>
        public string UserAgent { get; set; }

        /// <summary>
        /// This value identifies any Console session associated with this request.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string ConsoleSessionId { get; set; }
    }
}
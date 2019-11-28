using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace OCISDK.Core.Audit.Model
{
    /// <summary>
    /// A container object for response attributes.
    /// </summary>
    public class ResponseDetails
    {
        /// <summary>
        /// The status code of the response.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// The time of the response to the audited request, expressed in RFC 3339 timestamp format.
        /// <para>Required: no</para>
        /// </summary>
        public string ResponseTime { get; set; }

        /// <summary>
        /// The headers of the response.
        /// <para>Required: no</para>
        /// </summary>
        public object Headers { get; set; }

        /// <summary>
        /// This value is included for backward compatibility with the Audit version 1 schema, where it contained metadata of interest from the response payload.
        /// <para>Required: no</para>
        /// </summary>
        public object Payload { get; set; }

        /// <summary>
        /// A friendly description of what happened during the operation. Use this for troubleshooting.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 1024</para>
        /// </summary>
        public string Message { get; set; }
    }
}
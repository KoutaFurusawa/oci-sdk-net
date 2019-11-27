using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace OCISDK.Core.Audit.Model
{
    /// <summary>
    /// A container object for request attributes.
    /// </summary>
    public class RequestDetails
    {
        /// <summary>
        /// The opc-request-id of the request.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The full path of the API request.
        /// <para>Required: no</para>
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// The HTTP method of the request.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        /// The parameters supplied by the caller during this operation.
        /// <para>Required: no</para>
        /// </summary>
        public object Parameters { get; set; }

        /// <summary>
        /// The HTTP header fields and values in the request.
        /// <para>Required: no</para>
        /// </summary>
        public object Headers { get; set; }
    }
}
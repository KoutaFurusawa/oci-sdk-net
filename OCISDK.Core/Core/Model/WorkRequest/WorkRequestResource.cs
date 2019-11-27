using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Model.WorkRequest
{
    /// <summary>
    /// WorkRequestResource
    /// </summary>
    public class WorkRequestResource
    {
        /// <summary>
        /// The way in which this resource was affected by the operation that spawned the work request.
        /// <para>Required: yes</para>
        /// </summary>
        public string ActionType { get; set; }

        /// <summary>
        /// The resource type the work request affects.
        /// <para>Required: yes</para>
        /// </summary>
        public string EntityType { get; set; }

        /// <summary>
        /// An OCID or other unique identifier for the resource.
        /// <para>Required: yes</para>
        /// </summary>
        public string Identifier { get; set; }

        /// <summary>
        /// The URI path that you can use for a GET request to access the resource metadata.
        /// <para>Required: no</para>
        /// </summary>
        public string EntityUri { get; set; }
    }
}

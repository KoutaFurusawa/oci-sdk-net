using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.ObjectStorage.Model
{
    /// <summary>
    /// WorkRequestResource Reference
    /// </summary>
    public class WorkRequestResource
    {
        /// <summary>
        /// The status of the work request.
        /// <para>Required: no</para>
        /// </summary>
        public string ActionType { get; set; }

        /// <summary>
        /// The resource type the work request affects.
        /// <para>Required: no</para>
        /// </summary>
        public string EntityType { get; set; }

        /// <summary>
        /// The resource type identifier.
        /// <para>Required: no</para>
        /// </summary>
        public string Identifier { get; set; }

        /// <summary>
        /// The URI path that you can use for a GET request to access the resource metadata.
        /// <para>Required: no</para>
        /// </summary>
        public string EntityUri { get; set; }

        /// <summary>
        /// The metadata of the resource.
        /// <para>Required: no</para>
        /// </summary>
        public object Metadata { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Database.Request
{
    /// <summary>
    /// TerminateDbSystem Request
    /// </summary>
    public class TerminateDbSystemRequest
    {
        /// <summary>
        /// The DB system OCID.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string DbSystemId { get; set; }

        /// <summary>
        /// For optimistic concurrency control. In the PUT or DELETE call for a resource, 
        /// set the if-match parameter to the value of the etag from a previous GET or POST 
        /// response for that resource. The resource will be updated or deleted only if the 
        /// etag you provide matches the resource's current etag value.
        /// <para>Required: no</para>
        /// <para>if-match header parameter</para>
        /// </summary>
        public string IfMatch { get; set; }
    }
}

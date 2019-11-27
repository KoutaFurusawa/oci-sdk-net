using OCISDK.Core.Database.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Database.Request
{
    /// <summary>
    /// ChangeDbSystemCompartment Request
    /// </summary>
    public class ChangeDbSystemCompartmentRequest
    {
        /// <summary>
        /// The DB system OCID.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string DbSystemId { get; set; }

        /// <summary>
        /// A token that uniquely identifies a request so it can be retried in case of a 
        /// timeout or server error without risk of executing that same action again. 
        /// Retry tokens expire after 24 hours, but can be invalidated before then due to 
        /// conflicting operations (for example, if a resource has been deleted and purged 
        /// from the system, then a retry of the original creation request may be rejected).
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 64</para>
        /// </summary>
        public string OpcRetryToken { get; set; }

        /// <summary>
        /// Unique identifier for the request.
        /// <para>Required: no</para>
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// For optimistic concurrency control. In the PUT or DELETE call for a resource, 
        /// set the if-match parameter to the value of the etag from a previous GET or POST 
        /// response for that resource. The resource will be updated or deleted only if the 
        /// etag you provide matches the resource's current etag value.
        /// <para>Required: no</para>
        /// <para>if-match header parameter</para>
        /// </summary>
        public string IfMatch { get; set; }

        /// <summary>
        /// The request body must contain a single ChangeCompartmentDetails resource.
        /// </summary>
        public ChangeCompartmentDetails ChangeCompartmentDetails { get; set; }
    }
}

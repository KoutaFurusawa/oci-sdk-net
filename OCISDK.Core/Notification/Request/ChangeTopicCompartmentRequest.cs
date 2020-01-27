using OCISDK.Core.Notification.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Notification.Request
{
    /// <summary>
    /// ChangeTopicCompartment request
    /// </summary>
    public class ChangeTopicCompartmentRequest
    {
        /// <summary>
        /// The OCID of the topic to move.
        /// <para>Required: yes</para>
        /// </summary>
        public string TopicId { get; set; }

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
        /// For optimistic concurrency control. 
        /// In the PUT or DELETE call for a resource, set the if-match parameter to the value of the etag from a previous GET or POST response for that resource. 
        /// The resource will be updated or deleted only if the etag you provide matches the resource's current etag value.
        /// <para>Required: no</para>
        /// </summary>
        public string IfMatch { get; set; }

        /// <summary>
        /// Customer part of the request identifier token. If you need to contact Oracle about a particular request, please provide the complete request ID.
        /// <para>Required: no</para>
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// The request body must contain a single ChangeCompartmentDetails resource.
        /// </summary>
        public ChangeCompartmentDetails ChangeCompartmentDetails { get; set; }
    }
}

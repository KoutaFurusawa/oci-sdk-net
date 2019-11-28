using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.DNS.Request
{
    /// <summary>
    /// DeleteSteeringPolicy Request
    /// </summary>
    public class DeleteSteeringPolicyRequest
    {
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
        /// The If-Unmodified-Since header field makes the request method conditional on 
        /// the selected representation's last modification date being earlier than or 
        /// equal to the date provided in the field-value. This field accomplishes 
        /// the same purpose as If-Match for cases where the user agent does not have an 
        /// entity-tag for the representation.
        /// <para>Required: no</para>
        /// <para>if-unmodified-since header parameter</para>
        /// </summary>
        public string IfUnmodifiedSince { get; set; }

        /// <summary>
        /// The OCID of the target steering policy.
        /// <para>Required: yes</para>
        /// </summary>
        public string SteeringPolicyId { get; set; }
    }
}

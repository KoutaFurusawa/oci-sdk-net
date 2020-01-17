﻿using OCISDK.Core.Notification.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Notification.Request
{
    /// <summary>
    /// UpdateTopic request
    /// </summary>
    public class UpdateTopicRequest
    {
        /// <summary>
        /// The OCID of the topic to update.
        /// <para>Required: yes</para>
        /// </summary>
        public string TopicId { get; set; }

        /// <summary>
        /// Customer part of the request identifier token. 
        /// If you need to contact Oracle about a particular request, please provide the complete request ID.
        /// <para>Required: no</para>
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// Used for optimistic concurrency control. In the PUT or DELETE call for a resource, set the if-match parameter to 
        /// the value of the etag from a previous GET or POST response for that resource. The resource will be updated or 
        /// deleted only if the etag you provide matches the resource's current etag value.
        /// <para>Required: no</para>
        /// </summary>
        public string IfMatch { get; set; }

        /// <summary>
        /// The request body must contain a single TopicAttributesDetails resource.
        /// </summary>
        public TopicAttributesDetails TopicAttributesDetails { get; set; }
    }
}

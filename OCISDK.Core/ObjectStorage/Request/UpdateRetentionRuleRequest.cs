using System;
using System.Collections.Generic;
using System.Text;
using OCISDK.Core.ObjectStorage.Model;

namespace OCISDK.Core.ObjectStorage.Request
{
    /// <summary>
    /// UpdateRetentionRule request
    /// </summary>
    public class UpdateRetentionRuleRequest
    {
        /// <summary>
        /// The Object Storage namespace used for the request.
        /// <para>Required: yes</para>
        /// </summary>
        public string NamespaceName { get; set; }

        /// <summary>
        /// The name of the bucket. Avoid entering confidential information.
        /// <para>Required: yes</para>
        /// </summary>
        public string BucketName { get; set; }

        /// <summary>
        /// The ID of the retention rule.
        /// <para>Required: yes</para>
        /// </summary>
        public string RetentionRuleId { get; set; }

        /// <summary>
        /// The entity tag (ETag) to match. For creating and committing a multipart upload to an object, this is the entity tag of the target object. 
        /// For uploading a part, this is the entity tag of the target part.
        /// </summary>
        public string IfMatch { get; set; }

        /// <summary>
        /// The client request ID for tracing.
        /// <para>Required: no</para>
        /// </summary>
        public string OpcClientRequestId { get; set; }

        /// <summary>
        /// The request body must contain a single UpdateRetentionRuleDetails resource.
        /// </summary>
        public UpdateRetentionRuleDetails UpdateRetentionRuleDetails { get; set; }
    }
}

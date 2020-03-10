using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.ObjectStorage.Model
{
    /// <summary>
    /// Pre-authenticated requests provide a way to let users access a bucket or an object without having their own credentials. 
    /// When you create a pre-authenticated request, a unique URL is generated. Users in your organization, partners, or third 
    /// parties can use this URL to access the targets identified in the pre-authenticated request. See Using Pre-Authenticated Requests.
    /// 
    /// To use any of the API operations, you must be authorized in an IAM policy. If you are not authorized, talk to an administrator. 
    /// If you are an administrator who needs to write policies to give users access, see Getting Started with Policies.
    /// </summary>
    public class PreauthenticatedRequestDetails
    {
        /// <summary>
        /// The unique identifier to use when directly addressing the pre-authenticated request.
        /// <para>Required: yes</para>
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The user-provided name of the pre-authenticated request.
        /// <para>Required: yes</para>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The URI to embed in the URL when using the pre-authenticated request.
        /// <para>Required: yes</para>
        /// </summary>
        public string AccessUri { get; set; }

        /// <summary>
        /// The name of the object that is being granted access to by the pre-authenticated request. Avoid entering confidential information. 
        /// The object name can be null and if so, the pre-authenticated request grants access to the entire bucket.
        /// <para>Required: no</para>
        /// </summary>
        public string ObjectName { get; set; }

        /// <summary>
        /// The operation that can be performed on this resource.
        /// <para>Required: yes</para>
        /// </summary>
        public string AccessType { get; set; }

        /// <summary>
        /// The expiration date for the pre-authenticated request as per RFC 3339. After this date the pre-authenticated request will no longer be valid.
        /// <para>Required: yes</para>
        /// </summary>
        public string TimeExpires { get; set; }

        /// <summary>
        /// The date when the pre-authenticated request was created as per specification RFC 3339.
        /// <para>Required: yes</para>
        /// </summary>
        public string TimeCreated { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.ObjectStorage.Model
{
    /// <summary>
    /// CreatePreauthenticatedRequestDetails Reference
    /// </summary>
    public class CreatePreauthenticatedRequestDetails
    {
        /// <summary>
        /// The user-provided name of the pre-authenticated request.
        /// <para>Required: yes</para>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The name of the object that is being granted access to by the pre-authenticated request. Avoid entering confidential information. 
        /// The object name can be null and if so, the pre-authenticated request grants access to the entire bucket.
        /// <para>Required: no</para>
        /// </summary>
        public string ObjectName { get; set; }

        /// <summary>
        /// The URI to embed in the URL when using the pre-authenticated request.
        /// <para>Required: yes</para>
        /// </summary>
        public string AccessUri { get; set; }

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
    }
}

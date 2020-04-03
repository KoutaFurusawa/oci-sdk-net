using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.ObjectStorage.Model
{
    /// <summary>
    /// Get summary information about pre-authenticated requests.
    /// </summary>
    public class PreauthenticatedRequestSummary
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
        /// The name of object that is being granted access to by the pre-authenticated request. 
        /// This can be null and if it is, the pre-authenticated request grants access to the entire bucket.
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

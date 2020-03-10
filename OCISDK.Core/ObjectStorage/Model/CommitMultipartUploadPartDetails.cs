using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.ObjectStorage.Model
{
    /// <summary>
    /// To use any of the API operations, you must be authorized in an IAM policy. If you are not authorized, talk to an administrator. 
    /// If you are an administrator who needs to write policies to give users access, see Getting Started with Policies.
    /// </summary>
    public class CommitMultipartUploadPartDetails
    {
        /// <summary>
        /// The part number for this part.
        /// <para>Required: yes</para>
        /// </summary>
        public long PartNum { get; set; }

        /// <summary>
        /// The entity tag (ETag) returned when this part was uploaded.
        /// <para>Required: yes</para>
        /// </summary>
        public string Etag { get; set; }
    }
}

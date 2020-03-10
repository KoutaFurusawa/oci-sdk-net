using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.ObjectStorage.Model
{
    /// <summary>
    /// Gets summary information about multipart uploads.
    /// 
    /// To use any of the API operations, you must be authorized in an IAM policy. If you are not authorized, talk to an administrator. 
    /// If you are an administrator who needs to write policies to give users access, see Getting Started with Policies.
    /// </summary>
    public class MultipartUploadPartSummary
    {
        /// <summary>
        /// The current entity tag (ETag) for the part.
        /// <para>Required: yes</para>
        /// </summary>
        public string Etag { get; set; }

        /// <summary>
        /// The MD5 hash of the bytes of the part.
        /// <para>Required: yes</para>
        /// </summary>
        public string Md5 { get; set; }

        /// <summary>
        /// The size of the part in bytes.
        /// <para>Required: yes</para>
        /// </summary>
        public long Size { get; set; }

        /// <summary>
        /// The part number for this part.
        /// <para>Required: yes</para>
        /// </summary>
        public long PartNumber { get; set; }
    }
}

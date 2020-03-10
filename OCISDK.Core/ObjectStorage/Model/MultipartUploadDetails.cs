using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.ObjectStorage.Model
{
    /// <summary>
    /// Multipart uploads provide efficient and resilient uploads, especially for large objects. Multipart uploads 
    /// also accommodate objects that are too large for a single upload operation. With multipart uploads, individual 
    /// parts of an object can be uploaded in parallel to reduce the amount of time you spend uploading. Multipart uploads 
    /// can also minimize the impact of network failures by letting you retry a failed part upload instead of requiring you to 
    /// retry an entire object upload. See Using Multipart Uploads.
    /// 
    /// To use any of the API operations, you must be authorized in an IAM policy. If you are not authorized, talk to an administrator. 
    /// If you are an administrator who needs to write policies to give users access, see Getting Started with Policies.
    /// </summary>
    public class MultipartUploadDetails
    {
        /// <summary>
        /// The Object Storage namespace in which the in-progress multipart upload is stored.
        /// <paraa>Required: yes</paraa>
        /// </summary>
        public string Namespace { get; set; }

        /// <summary>
        /// The bucket in which the in-progress multipart upload is stored.
        /// <paraa>Required: yes</paraa>
        /// </summary>
        public string Bucket { get; set; }

        /// <summary>
        /// The object name of the in-progress multipart upload.
        /// <paraa>Required: yes</paraa>
        /// </summary>
        public string Object { get; set; }

        /// <summary>
        /// The unique identifier for the in-progress multipart upload.
        /// <paraa>Required: yes</paraa>
        /// </summary>
        public string UploadId { get; set; }

        /// <summary>
        /// The date and time the upload was created, as described in RFC 2616.
        /// <paraa>Required: yes</paraa>
        /// </summary>
        public string TimeCreated { get; set; }
    }
}

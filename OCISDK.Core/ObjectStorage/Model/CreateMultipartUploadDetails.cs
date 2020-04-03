using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.ObjectStorage.Model
{
    /// <summary>
    /// To use any of the API operations, you must be authorized in an IAM policy. If you are not authorized, talk to an administrator. If you are an 
    /// administrator who needs to write policies to give users access, see Getting Started with Policies.
    /// </summary>
    public class CreateMultipartUploadDetails
    {
        /// <summary>
        /// The name of the object to which this multi-part upload is targeted. Avoid entering confidential information.
        /// <para>Required: yes</para>
        /// </summary>
        /// <example>test/object1.log</example>
        public string Object { get; set; }

        /// <summary>
        /// The optional Content-Type header that defines the standard MIME type format of the object to upload. Specifying 
        /// values for this header has no effect on Object Storage behavior. Programs that read the object determine what to 
        /// do based on the value provided. For example, you could use this header to identify and perform special operations 
        /// on text only objects.
        /// <para>Required: no</para>
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// The optional Content-Language header that defines the content language of the object to upload. Specifying values for this 
        /// header has no effect on Object Storage behavior. Programs that read the object determine what to do based on the value provided. 
        /// For example, you could use this header to identify and differentiate objects based on a particular language.
        /// <para>Required: no</para>
        /// </summary>
        public string ContentLanguage { get; set; }

        /// <summary>
        /// The optional Content-Encoding header that defines the content encodings that were applied to the object to upload. Specifying values 
        /// for this header has no effect on Object Storage behavior. Programs that read the object determine what to do based on the value provided. 
        /// For example, you could use this header to determine what decoding mechanisms need to be applied to obtain the media-type specified by the 
        /// Content-Type header of the object.
        /// <para>Required: no</para>
        /// </summary>
        public string ContentEncoding { get; set; }

        /// <summary>
        /// The optional Content-Disposition header that defines presentational information for the object to be returned in GetObject and HeadObject 
        /// responses. Specifying values for this header has no effect on Object Storage behavior. Programs that read the object determine what to do 
        /// based on the value provided. For example, you could use this header to let users download objects with custom filenames in a browser.
        /// <para>Required: no</para>
        /// </summary>
        public string ContentDisposition { get; set; }

        /// <summary>
        /// The optional Cache-Control header that defines the caching behavior value to be returned in GetObject and HeadObject responses. Specifying values 
        /// for this header has no effect on Object Storage behavior. Programs that read the object determine what to do based on the value provided. For example, 
        /// you could use this header to identify objects that require caching restrictions.
        /// <para>Required: no</para>
        /// </summary>
        public string CacheControl { get; set; }

        /// <summary>
        /// Arbitrary string keys and values for the user-defined metadata for the object. Keys must be in "opc-meta-*" format. Avoid entering confidential information.
        /// </summary>
        public object Metadata { get; set; }
    }
}

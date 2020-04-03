using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OCISDK.Core.ObjectStorage.Request
{
    /// <summary>
    /// PutObject request
    /// </summary>
    public class PutObjectRequest
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
        /// The name of the object. Avoid entering confidential information.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 1024</para>
        /// </summary>
        public string ObjectName { get; set; }

        /// <summary>
        /// The client request ID for tracing.
        /// <para>Required: no</para>
        /// </summary>
        public string OpcClientRequestId { get; set; }

        /// <summary>
        /// The entity tag (ETag) to match. For creating and committing a multipart upload to an object, this is the 
        /// entity tag of the target object. For uploading a part, this is the entity tag of the target part.
        /// <para>Required: no</para>
        /// </summary>
        public string IfMatch { get; set; }

        /// <summary>
        /// The entity tag (ETag) to avoid matching. The only valid value is '*', which indicates that the request should fail if the 
        /// object already exists. For creating and committing a multipart upload, this is the entity tag of the target object. For 
        /// uploading a part, this is the entity tag of the target part.
        /// <para>Required: no</para>
        /// </summary>
        public string IfNoneMatch { get; set; }

        /// <summary>
        /// 100-continue
        /// <para>Required: no</para>
        /// <para>Default: 100-continue</para>
        /// </summary>
        public string Expect { get; set; }

        /// <summary>
        /// The content length of the body.
        /// <para>Required: yes</para>
        /// </summary>
        public long ContentLength { get; set; }

        /// <summary>
        /// The optional base-64 header that defines the encoded MD5 hash of the body. If the optional Content-MD5 header is present, Object Storage 
        /// performs an integrity check on the body of the HTTP request by computing the MD5 hash for the body and comparing it to the MD5 hash supplied in the 
        /// header. If the two hashes do not match, the object is rejected and an HTTP-400 Unmatched Content MD5 error is returned with the message:
        /// 
        /// "The computed MD5 of the request body (ACTUAL_MD5) does not match the Content-MD5 header (HEADER_MD5)"
        /// <para>Required: no</para>
        /// </summary>
        public string ContentMD5 { get; set; }

        /// <summary>
        /// The optional Content-Type header that defines the standard MIME type format of the object. Content type defaults to 'application/octet-stream' if not 
        /// specified in the PutObject call. Specifying values for this header has no effect on Object Storage behavior. Programs that read the object determine what 
        /// to do based on the value provided. For example, you could use this header to identify and perform special operations on text only objects.
        /// <para>Required: no</para>
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// The optional Content-Language header that defines the content language of the object to upload. Specifying values for this header has no effect on Object Storage 
        /// behavior. Programs that read the object determine what to do based on the value provided. For example, you could use this header to identify and differentiate 
        /// objects based on a particular language.
        /// <para>Required: no</para>
        /// </summary>
        public string ContentLanguage { get; set; }

        /// <summary>
        /// The optional Content-Encoding header that defines the content encodings that were applied to the object to upload. Specifying values for this header has no effect on 
        /// Object Storage behavior. Programs that read the object determine what to do based on the value provided. For example, you could use this header to determine what 
        /// decoding mechanisms need to be applied to obtain the media-type specified by the Content-Type header of the object.
        /// <para>Required: no</para>
        /// </summary>
        public string ContentEncoding { get; set; }

        /// <summary>
        /// The optional Content-Disposition header that defines presentational information for the object to be returned in GetObject and HeadObject responses. Specifying values 
        /// for this header has no effect on Object Storage behavior. Programs that read the object determine what to do based on the value provided. For example, you could use this 
        /// header to let users download objects with custom filenames in a browser.
        /// <para>Required: no</para>
        /// </summary>
        public string ContentDisposition { get; set; }

        /// <summary>
        /// The optional Cache-Control header that defines the caching behavior value to be returned in GetObject and HeadObject responses. Specifying values for this header has 
        /// no effect on Object Storage behavior. Programs that read the object determine what to do based on the value provided. For example, you could use this header to identify
        /// objects that require caching restrictions.
        /// <para>Required: no</para>
        /// </summary>
        public string CacheControl { get; set; }

        /// <summary>
        /// Optional user-defined metadata key and value.
        /// </summary>
        public Dictionary<string, string> OpcMeta;

        /// <summary>
        /// The object to upload to the object store.
        /// <para>Required: yes</para>
        /// </summary>
        public Stream UploadPartBody { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace OCISDK.Core.Common
{
    /// <summary>
    /// HttpRequestHeaderParam
    /// </summary>
    public class HttpRequestHeaderParam
    {
        /// <summary>
        /// IfMatch header
        /// </summary>
        public string IfMatch { get; set; }

        /// <summary>
        /// IfNoneMatch header
        /// </summary>
        public string IfNoneMatch { get; set; }

        /// <summary>
        /// IfModifiedSince header
        /// </summary>
        public string IfModifiedSince { get; set; }

        /// <summary>
        /// IfUnmodifiedSince header
        /// </summary>
        public string IfUnmodifiedSince { get; set; }

        /// <summary>
        /// OpcClientRequestId header
        /// </summary>
        public string OpcClientRequestId { get; set; }

        /// <summary>
        /// OpcRequestId header
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// OpcRetryToken header
        /// </summary>
        public string OpcRetryToken { get; set; }

        /// <summary>
        /// Range headr
        /// </summary>
        public string Range { get; set; }

        /// <summary>
        /// MessageType
        /// </summary>
        public string MessageType { get; set; }

        /// <summary>
        /// Expect
        /// </summary>
        public string Expect { get; set; }

        /// <summary>
        /// Content-Length
        /// </summary>
        public long? ContentLength { get; set; }

        /// <summary>
        /// Content-MD5
        /// </summary>
        public string ContentMD5 { get; set; }

        /// <summary>
        /// Content-Type
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// Content-Language
        /// </summary>
        public string ContentLanguage { get; set; }

        /// <summary>
        /// Content-Encoding
        /// </summary>
        public string ContentEncoding { get; set; }

        /// <summary>
        /// Content-Disposition
        /// </summary>
        public string ContentDisposition { get; set; }

        /// <summary>
        /// Cache-Control
        /// </summary>
        public string CacheControl { get; set; }

        /// <summary>
        /// opc-meta-*
        /// </summary>
        public Dictionary<string, string> OpcMeta { get; set; } = new Dictionary<string, string>();

        /// <summary>
        /// free keyword header
        /// </summary>
        public Dictionary<string, string> FreeHeader { get; set; } = new Dictionary<string, string>();

        /// <summary>
        /// HttpWebRequest setting header
        /// </summary>
        /// <param name="httpWebRequest"></param>
        /// <returns></returns>
        public HttpWebRequest SetHeader(HttpWebRequest httpWebRequest)
        {
            if (!string.IsNullOrEmpty(IfMatch))
            {
                httpWebRequest.Headers["if-match"] = IfMatch;
            }

            if (!string.IsNullOrEmpty(IfNoneMatch))
            {
                httpWebRequest.Headers["if-none-match"] = IfNoneMatch;
            }

            if (!string.IsNullOrEmpty(IfModifiedSince))
            {
                httpWebRequest.Headers["if-modified-since"] = IfModifiedSince;
            }

            if (!string.IsNullOrEmpty(IfUnmodifiedSince))
            {
                httpWebRequest.Headers["if-unmodified-since"] = IfUnmodifiedSince;
            }

            if (!string.IsNullOrEmpty(OpcClientRequestId))
            {
                httpWebRequest.Headers["opc-client-request-id"] = OpcClientRequestId;
            }

            if (!string.IsNullOrEmpty(OpcRequestId))
            {
                httpWebRequest.Headers["opc-request-id"] = OpcRequestId;
            }

            if (!string.IsNullOrEmpty(OpcRetryToken))
            {
                httpWebRequest.Headers["opc-retry-token"] = OpcRetryToken;
            }

            if (!string.IsNullOrEmpty(Range))
            {
                httpWebRequest.Headers["range"] = Range;
            }

            if (!string.IsNullOrEmpty(MessageType))
            {
                httpWebRequest.Headers["messageType"] = MessageType;
            }

            if (!string.IsNullOrEmpty(Expect))
            {
                httpWebRequest.Headers["Expect"] = Expect;
            }

            if (ContentLength.HasValue)
            {
                httpWebRequest.Headers["Content-Length"] = ContentLength.Value.ToString();
            }

            if (!string.IsNullOrEmpty(ContentMD5))
            {
                httpWebRequest.Headers["Content-MD5"] = ContentMD5;
            }

            if (!string.IsNullOrEmpty(ContentType))
            {
                httpWebRequest.Headers["Content-Type"] = ContentType;
            }

            if (!string.IsNullOrEmpty(ContentLanguage))
            {
                httpWebRequest.Headers["Content-Language"] = ContentLanguage;
            }

            if (!string.IsNullOrEmpty(ContentEncoding))
            {
                httpWebRequest.Headers["Content-Encoding"] = ContentEncoding;
            }

            if(!string.IsNullOrEmpty(ContentDisposition))
            {
                httpWebRequest.Headers["Content-Disposition"] = ContentDisposition;
            }

            if(!string.IsNullOrEmpty(CacheControl))
            {
                httpWebRequest.Headers["Cache-Control"] = CacheControl;
            }

            if(OpcMeta.Count > 0)
            {
                foreach (var key in OpcMeta.Keys)
                {
                    httpWebRequest.Headers[$"opc-meta-{key}"] = OpcMeta[key];
                }
            }

            if (FreeHeader.Count > 0)
            {
                foreach (var key in FreeHeader.Keys)
                {
                    httpWebRequest.Headers[key] = FreeHeader[key];
                }
            }

            return httpWebRequest;
        }
    }
}

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

            return httpWebRequest;
        }
    }
}

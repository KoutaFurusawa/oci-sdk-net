using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace OCISDK.Core.src.Common
{
    public class HttpRequestHeaderParam
    {
        public string IfMatch { get; set; }

        public string IfNoneMatch { get; set; }

        public string IfModifiedSince { get; set; }

        public string IfUnmodifiedSince { get; set; }

        public string OpcClientRequestId { get; set; }

        public string OpcRequestId { get; set; }

        public string OpcRetryToken { get; set; }

        public string Range { get; set; }

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

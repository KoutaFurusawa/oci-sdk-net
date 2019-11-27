using OCISDK.Core.Common;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Xunit;

namespace OCISDK.Test.Common
{
    public class HttpRequestHeaderParamTest
    {
        HttpRequestHeaderParam EmptyHttpRequestHeader = new HttpRequestHeaderParam();
        HttpRequestHeaderParam FullHttpRequestHeader = new HttpRequestHeaderParam()
        {
            IfMatch = "testIfMatch",
            IfModifiedSince = "testIfModifiedSince",
            IfNoneMatch = "testIfNoneMatch",
            IfUnmodifiedSince = "testIfUnmodifiedSince",
            OpcClientRequestId = "testOpcClientRequestId",
            OpcRequestId = "testOpcRequestId",
            OpcRetryToken = "testOpcRetryToken",
            Range = "testRange"
        };

        [Fact]
        public void SimpleTest()
        {
            var request = (HttpWebRequest)WebRequest.Create("http://test.com");

            request = FullHttpRequestHeader.SetHeader(request);

            var headers = request.Headers;

            Assert.Equal("testIfMatch", headers["if-match"]);
        }

        [Fact]
        public void EmptyTest()
        {
            var request = (HttpWebRequest)WebRequest.Create("http://test.com");

            request = EmptyHttpRequestHeader.SetHeader(request);
            
            Assert.Empty(request.Headers.Keys);
        }

        [Theory]
        [InlineData("if-match", "testIfMatch")]
        [InlineData("if-modified-since", "testIfModifiedSince")]
        [InlineData("if-none-match", "testIfNoneMatch")]
        [InlineData("if-unmodified-since", "testIfUnmodifiedSince")]
        [InlineData("opc-client-request-id", "testOpcClientRequestId")]
        [InlineData("opc-request-id", "testOpcRequestId")]
        [InlineData("opc-retry-token", "testOpcRetryToken")]
        [InlineData("range", "testRange")]
        public void TheoryFullPatternTest(string key, string value)
        {
            var request = (HttpWebRequest)WebRequest.Create("http://test.com");

            request = FullHttpRequestHeader.SetHeader(request);

            var headers = request.Headers;

            Assert.Equal(value, headers[key]);
        }
    }
}

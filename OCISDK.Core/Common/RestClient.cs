﻿using System;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

using Polly;
using Polly.Wrap;
using System.Net.Http;
using System.Collections.Generic;

namespace OCISDK.Core.Common
{
    /// <summary>
    /// RestClient
    /// </summary>
    public class RestClient : IRestClient
    {
        /// <summary>
        /// signer
        /// </summary>
        public IOciSigner Signer { get; set; }

        /// <summary>
        /// JsonSerializer
        /// </summary>
        public IJsonSerializer JsonSerializer { get; set; }

        /// <summary>
        /// WebRequestPolicy
        /// </summary>
        public IWebRequestPolicy WebRequestPolicy { get; set; }

        /// <summary>
        /// rest option
        /// </summary>
        public RestOption Option { get; set; }

        /// <summary>
        /// request option parameters setting
        /// </summary>
        /// <param name="option"></param>
        public void SetOption(RestOption option)
        {
            Option = option;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public HttpWebResponse Get(HttpWebRequest request)
        {
            var res = WebRequestPolicy.GetPolicies(Option).ExecuteAndCapture(() => (HttpWebResponse)request.GetResponse());

            if (res.Outcome == OutcomeType.Failure && (res.FinalException is WebException))
            {
                throw res.FinalException;
            }

            return res.Result;
        }

        /// <summary>
        /// Request a resource asynchronously.
        /// </summary>
        /// <param name="targetUri"></param>
        /// <returns></returns>
        public HttpWebResponse Get(Uri targetUri)
        {
            return this.Get(targetUri, null);
        }

        /// <summary>
        /// Request a resource asynchronously.
        /// </summary>
        /// <param name="targetUri"></param>
        /// <param name="httpRequestHeaderParam"></param>
        /// <returns></returns>
        public HttpWebResponse Get(Uri targetUri, HttpRequestHeaderParam httpRequestHeaderParam)
        {
            return this.Get(targetUri, httpRequestHeaderParam, null);
        }

        /// <summary>
        /// Request a resource asynchronously.
        /// </summary>
        /// <param name="targetUri"></param>
        /// <param name="httpRequestHeaderParam"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        public HttpWebResponse Get(Uri targetUri, HttpRequestHeaderParam httpRequestHeaderParam, List<string> fields)
        {
            var request = (HttpWebRequest)WebRequest.Create(targetUri);
            request.Method = HttpMethod.Get.Method;
            request.Accept = "application/json";
            request.ReadWriteTimeout = Option.TimeoutSeconds;

            if (httpRequestHeaderParam != null)
            {
                request = httpRequestHeaderParam.SetHeader(request);
            }

            if (fields != null && fields.Count != 0)
            {
                var body = JsonSerializer.Serialize(fields);

                var bytes = Encoding.UTF8.GetBytes(body);

                request.Headers["x-content-sha256"] = Convert.ToBase64String(SHA256.Create().ComputeHash(bytes));
                request.ContentLength = bytes.Length;

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(bytes, 0, bytes.Length);
                }
            }

            if (Signer != null)
            {
                Signer.SignRequest(request);
            }

            var res = WebRequestPolicy.GetPolicies(Option).ExecuteAndCapture(() => (HttpWebResponse)request.GetResponse());

            if (res.Outcome == OutcomeType.Failure && (res.FinalException is WebException))
            {
                throw res.FinalException;
            }

            return res.Result;
        }

        /// <summary>
        /// Request a resource asynchronously.
        /// </summary>
        /// <param name="targetUri"></param>
        /// <returns></returns>
        public HttpWebResponse Post(Uri targetUri)
        {
            return Post(targetUri, null);
        }

        /// <summary>
        /// Request a resource asynchronously.
        /// </summary>
        /// <param name="targetUri"></param>
        /// <param name="requestBody"></param>
        /// <returns></returns>
        public HttpWebResponse Post(Uri targetUri, object requestBody)
        {
            return Post(targetUri, requestBody, null);
        }

        /// <summary>
        /// Post a request object to the endpoint represented by the web target and get the response.
        /// </summary>
        /// <param name="targetUri"></param>
        /// <param name="requestBody"></param>
        /// <param name="httpRequestHeaderParam"></param>
        /// <returns></returns>
        public HttpWebResponse Post(Uri targetUri, object requestBody, HttpRequestHeaderParam httpRequestHeaderParam)
        {
            return Post(targetUri, requestBody, httpRequestHeaderParam, true);
        }

        /// <summary>
        /// Post a request object to the endpoint represented by the web target and get the response.
        /// </summary>
        /// <param name="targetUri"></param>
        /// <param name="requestBody"></param>
        /// <param name="httpRequestHeaderParam"></param>
        /// <param name="bodyJsonSerialize"></param>
        /// <returns></returns>
        public HttpWebResponse Post(Uri targetUri, object requestBody, HttpRequestHeaderParam httpRequestHeaderParam, bool bodyJsonSerialize)
        {
            var request = (HttpWebRequest)WebRequest.Create(targetUri);
            request.Method = HttpMethod.Post.Method;
            request.Accept = "application/json";
            request.ContentType = "application/json";
            request.ReadWriteTimeout = Option.TimeoutSeconds;

            if (httpRequestHeaderParam != null)
            {
                request = httpRequestHeaderParam.SetHeader(request);
            }

            if (requestBody != null)
            {
                request = SetBody(request, requestBody, bodyJsonSerialize);
            }

            if (Signer != null)
            {
                Signer.SignRequest(request);
            }

            var res = WebRequestPolicy.GetPolicies(Option).ExecuteAndCapture(() => (HttpWebResponse)request.GetResponse());

            if (res.Outcome == OutcomeType.Failure && (res.FinalException is WebException))
            {
                throw res.FinalException;
            }

            return res.Result;
        }

        /// <summary>
        /// Request a resource asynchronously.
        /// </summary>
        /// <param name="targetUri"></param>
        /// <returns></returns>
        public HttpWebResponse Put(Uri targetUri)
        {
            return Put(targetUri, null);
        }

        /// <summary>
        /// Request a resource asynchronously.
        /// </summary>
        /// <param name="targetUri"></param>
        /// <param name="requestBody"></param>
        /// <returns></returns>
        public HttpWebResponse Put(Uri targetUri, object requestBody)
        {
            return Put(targetUri, requestBody, null);
        }

        /// <summary>
        /// Request a resource asynchronously.
        /// </summary>
        /// <param name="targetUri"></param>
        /// <param name="requestBody"></param>
        /// <param name="httpRequestHeaderParam"></param>
        /// <returns></returns>
        public HttpWebResponse Put(Uri targetUri, object requestBody, HttpRequestHeaderParam httpRequestHeaderParam)
        {
            return Put(targetUri, requestBody, httpRequestHeaderParam, true);
        }

        /// <summary>
        /// Request a resource asynchronously.
        /// </summary>
        /// <param name="targetUri"></param>
        /// <param name="requestBody"></param>
        /// <param name="httpRequestHeaderParam"></param>
        /// <param name="bodyJsonSerialize"></param>
        /// <returns></returns>
        public HttpWebResponse Put(Uri targetUri, object requestBody, HttpRequestHeaderParam httpRequestHeaderParam, bool bodyJsonSerialize)
        {
            return Put(targetUri, requestBody, httpRequestHeaderParam, bodyJsonSerialize);
        }

        /// <summary>
        /// Put a request object to the endpoint represented by the web target and get the response.
        /// </summary>
        /// <param name="targetUri"></param>
        /// <param name="requestBody"></param>
        /// <param name="httpRequestHeaderParam"></param>
        /// <param name="bodyJsonSerialize"></param>
        /// <param name="sha256"></param>
        /// <returns></returns>
        public HttpWebResponse Put(Uri targetUri, object requestBody, HttpRequestHeaderParam httpRequestHeaderParam, bool bodyJsonSerialize, bool sha256)
        {
            var request = (HttpWebRequest)WebRequest.Create(targetUri);
            request.Method = HttpMethod.Put.Method;
            request.Accept = "application/json";
            request.ContentType = "application/json";
            request.ReadWriteTimeout = Option.TimeoutSeconds;

            if (httpRequestHeaderParam != null)
            {
                request = httpRequestHeaderParam.SetHeader(request);
            }

            if (requestBody != null)
            {
                request = SetBody(request, requestBody, bodyJsonSerialize, sha256);
            }

            if (Signer != null)
            {
                Signer.SignRequest(request);
            }

            var res = WebRequestPolicy.GetPolicies(Option).ExecuteAndCapture(() => (HttpWebResponse)request.GetResponse());

            if (res.Outcome == OutcomeType.Failure && (res.FinalException is WebException))
            {
                throw res.FinalException;
            }

            return res.Result;
        }

        /// <summary>
        /// Request a resource asynchronously.
        /// </summary>
        /// <param name="targetUri"></param>
        /// <returns></returns>
        public HttpWebResponse Patch(Uri targetUri)
        {
            return Patch(targetUri, null);
        }

        /// <summary>
        /// Request a resource asynchronously.
        /// </summary>
        /// <param name="targetUri"></param>
        /// <param name="requestBody"></param>
        /// <returns></returns>
        public HttpWebResponse Patch(Uri targetUri, object requestBody)
        {
            return Patch(targetUri, requestBody, null);
        }

        /// <summary>
        /// Patch
        /// </summary>
        /// <param name="targetUri"></param>
        /// <param name="requestBody"></param>
        /// <param name="httpRequestHeaderParam"></param>
        /// <returns></returns>
        public HttpWebResponse Patch(Uri targetUri, object requestBody, HttpRequestHeaderParam httpRequestHeaderParam)
        {
            return Patch(targetUri, requestBody, httpRequestHeaderParam, true);
        }

        /// <summary>
        /// Patch a request object to the endpoint represented by the web target and get the response.
        /// </summary>
        /// <param name="targetUri"></param>
        /// <param name="requestBody"></param>
        /// <param name="httpRequestHeaderParam"></param>
        /// <param name="bodyJsonSerialize"></param>
        /// <returns></returns>
        public HttpWebResponse Patch(Uri targetUri, object requestBody, HttpRequestHeaderParam httpRequestHeaderParam, bool bodyJsonSerialize)
        {
            var request = (HttpWebRequest)WebRequest.Create(targetUri);
            request.Method = HttpMethod.Patch.Method;
            request.Accept = "application/json";
            request.ContentType = "application/json";
            request.ReadWriteTimeout = Option.TimeoutSeconds;

            if (httpRequestHeaderParam != null)
            {
                request = httpRequestHeaderParam.SetHeader(request);
            }

            if (requestBody != null)
            {
                request = SetBody(request, requestBody, bodyJsonSerialize);
            }

            if (Signer != null)
            {
                Signer.SignRequest(request);
            }

            var res = WebRequestPolicy.GetPolicies(Option).ExecuteAndCapture(() => (HttpWebResponse)request.GetResponse());

            if (res.Outcome == OutcomeType.Failure && (res.FinalException is WebException))
            {
                throw res.FinalException;
            }

            return res.Result;
        }

        /// <summary>
        /// Patch a request object to the endpoint represented by the web target and get the response.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="requestBody"></param>
        /// <param name="bodyJsonSerialize"></param>
        /// <param name="sha256"></param>
        /// <returns></returns>
        private HttpWebRequest SetBody(HttpWebRequest request, object requestBody, bool bodyJsonSerialize, bool sha256 = true)
        {
            string body = "";
            byte[] bytes;
            if (requestBody is Stream)
            {
                bytes = GetByteArrayFromStream(requestBody as Stream);
            }
            else
            {
                if (bodyJsonSerialize)
                {
                    body = JsonSerializer.Serialize(requestBody);
                }
                else
                {
                    body = requestBody as string;
                }

                bytes = Encoding.UTF8.GetBytes(body);
            }

            if (sha256)
            {
                request.Headers["x-content-sha256"] = Convert.ToBase64String(SHA256.Create().ComputeHash(bytes));
            }
            request.ContentLength = bytes.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(bytes, 0, bytes.Length);
            }

            return request;
        }

        private static byte[] GetByteArrayFromStream(Stream sm)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                sm.CopyTo(ms);
                return ms.ToArray();
            }
        }

        private HttpWebRequest SetBody(HttpWebRequest request, Stream streamBody)
        {
            request.ContentLength = streamBody.Length;
            using (Stream requestStream = request.GetRequestStream())
            {
                streamBody.CopyTo(requestStream);
            }

            return request;
        }

        /// <summary>
        /// Request a resource asynchronously.
        /// </summary>
        /// <param name="targetUri"></param>
        /// <returns></returns>
        public HttpWebResponse Delete(Uri targetUri)
        {
            return Delete(targetUri, null);
        }

        /// <summary>
        /// Request a resource asynchronously.
        /// </summary>
        /// <param name="targetUri"></param>
        /// <param name="httpRequestHeaderParam"></param>
        /// <returns></returns>
        public HttpWebResponse Delete(Uri targetUri, HttpRequestHeaderParam httpRequestHeaderParam)
        {
            return Delete(targetUri, httpRequestHeaderParam, null);
        }

        /// <summary>
        /// Execute a delete on a resource and get the response.
        /// </summary>
        /// <param name="targetUri"></param>
        /// <param name="httpRequestHeaderParam"></param>
        /// <param name="requestBody"></param>
        /// <returns></returns>
        public HttpWebResponse Delete(Uri targetUri, HttpRequestHeaderParam httpRequestHeaderParam, object requestBody)
        {
            var request = (HttpWebRequest)WebRequest.Create(targetUri);
            request.Method = HttpMethod.Delete.Method;
            request.ReadWriteTimeout = Option.TimeoutSeconds;

            if (httpRequestHeaderParam != null)
            {
                request = httpRequestHeaderParam.SetHeader(request);
            }

            if (requestBody != null)
            {
                var body = JsonSerializer.Serialize(requestBody);

                var bytes = Encoding.UTF8.GetBytes(body);

                request.Headers["x-content-sha256"] = Convert.ToBase64String(SHA256.Create().ComputeHash(bytes));
                request.ContentLength = bytes.Length;

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(bytes, 0, bytes.Length);
                }
            }

            if (Signer != null)
            {
                Signer.SignRequest(request);
            }

            var res = WebRequestPolicy.GetPolicies(Option).ExecuteAndCapture(() => (HttpWebResponse)request.GetResponse());

            if (res.Outcome == OutcomeType.Failure && (res.FinalException is WebException))
            {
                throw res.FinalException;
            }

            return res.Result;
        }

        /// <summary>
        /// Request a resource asynchronously.
        /// </summary>
        /// <param name="targetUri"></param>
        /// <returns></returns>
        public HttpWebResponse Head(Uri targetUri)
        {
            return Head(targetUri, null);
        }

        /// <summary>
        /// head method
        /// </summary>
        /// <param name="targetUri"></param>
        /// <param name="httpRequestHeaderParam"></param>
        /// <returns></returns>
        public HttpWebResponse Head(Uri targetUri, HttpRequestHeaderParam httpRequestHeaderParam)
        {
            var request = (HttpWebRequest)WebRequest.Create(targetUri);
            request.Method = HttpMethod.Head.Method;
            request.Accept = "application/json";
            request.ReadWriteTimeout = Option.TimeoutSeconds;

            if (httpRequestHeaderParam != null)
            {
                request = httpRequestHeaderParam.SetHeader(request);
            }

            if (Signer != null)
            {
                Signer.SignRequest(request);
            }

            var res = WebRequestPolicy.GetPolicies(Option).ExecuteAndCapture(() => (HttpWebResponse)request.GetResponse());

            if (res.Outcome == OutcomeType.Failure && (res.FinalException is WebException))
            {
                throw res.FinalException;
            }

            return res.Result;
        }
    }

}

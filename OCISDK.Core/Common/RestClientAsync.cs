using System;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

using Polly;    // Microsoft.Extensions.Http.Polly
using Polly.Wrap;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OCISDK.Core.Common
{
    /// <summary>
    /// rest client async
    /// </summary>
    public class RestClientAsync : IRestClientAsync
    {
        /// <summary>
        /// Signer
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
        /// get
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<WebResponse> Get(HttpWebRequest request)
        {
            var res = await WebRequestPolicy.GetPoliciesAsync(Option).ExecuteAndCaptureAsync(() => request.GetResponseAsync());

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
        public async Task<WebResponse> Get(Uri targetUri)
        {
            return await Get(targetUri, null);
        }

        /// <summary>
        /// Request a resource asynchronously.
        /// </summary>
        /// <param name="targetUri"></param>
        /// <param name="httpRequestHeaderParam"></param>
        /// <returns></returns>
        public async Task<WebResponse> Get(Uri targetUri, HttpRequestHeaderParam httpRequestHeaderParam)
        {
            return await Get(targetUri, httpRequestHeaderParam, null);
        }

        /// <summary>
        /// Request a resource asynchronously.
        /// </summary>
        /// <param name="targetUri"></param>
        /// <param name="httpRequestHeaderParam"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        public async Task<WebResponse> Get(Uri targetUri, HttpRequestHeaderParam httpRequestHeaderParam, List<string> fields)
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

            var res = await WebRequestPolicy.GetPoliciesAsync(Option).ExecuteAndCaptureAsync(() => request.GetResponseAsync());

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
        public async Task<WebResponse> Post(Uri targetUri)
        {
            return await Post(targetUri, null);
        }

        /// <summary>
        /// Request a resource asynchronously.
        /// </summary>
        /// <param name="targetUri"></param>
        /// <param name="requestBody"></param>
        /// <returns></returns>
        public async Task<WebResponse> Post(Uri targetUri, object requestBody)
        {
            return await Post(targetUri, requestBody, null);
        }

        /// <summary>
        /// Post a request object to the endpoint represented by the web target and get the response.
        /// </summary>
        /// <param name="targetUri"></param>
        /// <param name="requestBody"></param>
        /// <param name="httpRequestHeaderParam"></param>
        /// <returns></returns>
        public async Task<WebResponse> Post(Uri targetUri, object requestBody, HttpRequestHeaderParam httpRequestHeaderParam)
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

            var res = await WebRequestPolicy.GetPoliciesAsync(Option).ExecuteAndCaptureAsync(() => request.GetResponseAsync());

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
        public async Task<WebResponse> Put(Uri targetUri)
        {
            return await Put(targetUri, null);
        }

        /// <summary>
        /// Request a resource asynchronously.
        /// </summary>
        /// <param name="targetUri"></param>
        /// <param name="requestBody"></param>
        /// <returns></returns>
        public async Task<WebResponse> Put(Uri targetUri, object requestBody)
        {
            return await Put(targetUri, requestBody, null);
        }

        /// <summary>
        /// Put a request object to the endpoint represented by the web target and get the response.
        /// </summary>
        /// <param name="targetUri"></param>
        /// <param name="requestBody"></param>
        /// <param name="httpRequestHeaderParam"></param>
        /// <returns></returns>
        public async Task<WebResponse> Put(Uri targetUri, object requestBody, HttpRequestHeaderParam httpRequestHeaderParam)
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

            var res = await WebRequestPolicy.GetPoliciesAsync(Option).ExecuteAndCaptureAsync(() => request.GetResponseAsync());

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
        public async Task<WebResponse> Patch(Uri targetUri)
        {
            return await Patch(targetUri, null);
        }

        /// <summary>
        /// Request a resource asynchronously.
        /// </summary>
        /// <param name="targetUri"></param>
        /// <param name="requestBody"></param>
        /// <returns></returns>
        public async Task<WebResponse> Patch(Uri targetUri, object requestBody)
        {
            return await Patch(targetUri, requestBody, null);
        }

        /// <summary>
        /// Patch a request object to the endpoint represented by the web target and get the response.
        /// </summary>
        /// <param name="targetUri"></param>
        /// <param name="requestBody"></param>
        /// <param name="httpRequestHeaderParam"></param>
        /// <returns></returns>
        public async Task<WebResponse> Patch(Uri targetUri, object requestBody, HttpRequestHeaderParam httpRequestHeaderParam)
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

            var res = await WebRequestPolicy.GetPoliciesAsync(Option).ExecuteAndCaptureAsync(() => request.GetResponseAsync());

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
        public async Task<WebResponse> Delete(Uri targetUri)
        {
            return await Delete(targetUri, null);
        }

        /// <summary>
        /// Request a resource asynchronously.
        /// </summary>
        /// <param name="targetUri"></param>
        /// <param name="httpRequestHeaderParam"></param>
        /// <returns></returns>
        public async Task<WebResponse> Delete(Uri targetUri, HttpRequestHeaderParam httpRequestHeaderParam)
        {
            return await Delete(targetUri, httpRequestHeaderParam, null);
        }

        /// <summary>
        /// Execute a delete on a resource and get the response.
        /// </summary>
        /// <param name="targetUri"></param>
        /// <param name="httpRequestHeaderParam"></param>
        /// <param name="requestBody"></param>
        /// <returns></returns>
        public async Task<WebResponse> Delete(Uri targetUri, HttpRequestHeaderParam httpRequestHeaderParam, object requestBody)
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

            var res = await WebRequestPolicy.GetPoliciesAsync(Option).ExecuteAndCaptureAsync(() => request.GetResponseAsync());

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
        public async Task<WebResponse> Head(Uri targetUri)
        {
            return await Head(targetUri, null);
        }

        /// <summary>
        /// head method
        /// </summary>
        /// <param name="targetUri"></param>
        /// <param name="httpRequestHeaderParam"></param>
        /// <returns></returns>
        public async Task<WebResponse> Head(Uri targetUri, HttpRequestHeaderParam httpRequestHeaderParam)
        {
            var request = (HttpWebRequest)WebRequest.Create(targetUri);
            request.Method = HttpMethod.Get.Method;
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

            var res = await WebRequestPolicy.GetPoliciesAsync(Option).ExecuteAndCaptureAsync(() => request.GetResponseAsync());

            if (res.Outcome == OutcomeType.Failure && (res.FinalException is WebException))
            {
                throw res.FinalException;
            }

            return res.Result;
        }
    }
}

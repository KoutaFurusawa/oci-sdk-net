/// <summary>
/// Rest call client Class
/// 
/// author: koutaro furusawa
/// </summary>

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

namespace OCISDK.Core.src.Common
{
    public class RestClientAsync : IRestClientAsync
    {
        public IOciSigner Signer { get; set; }
        
        public IJsonSerializer JsonSerializer { get; set; }
        
        public RestOption Option { get; }

        public RestClientAsync()
        {
            // default
            Option = new RestOption();
        }

        private PolicyWrap<WebResponse> GetPolicies()
        {
            return Policy.WrapAsync(GetRetryPolicy(), GetCircuitBreakerPolicy(), GetFallbackPolicy());
        }

        private Policy<WebResponse> GetRetryPolicy()
        {
            // wait retry 100mSec interval
            var jitter = TimeSpan.FromMilliseconds(RandomProvider.GetThreadRandom().Next(0, 100));
            return Policy<WebResponse>
                .Handle<WebException>(ex => ((HttpWebResponse)ex.Response).StatusCode == HttpStatusCode.InternalServerError)
                .WaitAndRetryAsync(Option.RetryCount, retryAttempt =>
                    TimeSpan.FromSeconds(Math.Pow(Option.SleepDurationSeconds, retryAttempt)) + jitter);
        }

        private Policy<WebResponse> GetCircuitBreakerPolicy()
        {
            return Policy<WebResponse>
                .Handle<WebException>(ex => ((HttpWebResponse)ex.Response).StatusCode == HttpStatusCode.InternalServerError)
                .CircuitBreakerAsync(Option.HandledEventsAllowedBeforeBreaking, TimeSpan.FromSeconds(Option.DurationOfBreakSeconds));
        }

        private Policy<WebResponse> GetFallbackPolicy()
        {
            return Policy<WebResponse>
                .Handle<WebException>(ex => ((HttpWebResponse)ex.Response).StatusCode == HttpStatusCode.InternalServerError)
                .FallbackAsync(new HttpWebResponse());
        }
        
        public async Task<WebResponse> Get(HttpWebRequest request)
        {
            return await GetPolicies().ExecuteAsync(() => request.GetResponseAsync());
        }

        public async Task<WebResponse> Get(Uri targetUri)
        {
            return await Get(targetUri, null);
        }

        public async Task<WebResponse> Get(Uri targetUri, HttpRequestHeaderParam httpRequestHeaderParam)
        {
            return await Get(targetUri, httpRequestHeaderParam, null);
        }

        /// <summary>
        /// Request a resource asynchronously.
        /// </summary>
        /// <param name="targetUri"></param>
        /// <param name="ifMatch"></param>
        /// <param name="ifNoneMatch"></param>
        /// <param name="opcClientRequestId"></param>
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

            return await GetPolicies().ExecuteAsync(() => request.GetResponseAsync());
        }

        public async Task<WebResponse> Post(Uri targetUri)
        {
            return await Post(targetUri, null);
        }

        public async Task<WebResponse> Post(Uri targetUri, object requestBody)
        {
            return await Post(targetUri, requestBody, null);
        }

        /// <summary>
        /// Post a request object to the endpoint represented by the web target and get the response.
        /// </summary>
        /// <param name="TargetUri"></param>
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

            return await GetPolicies().ExecuteAsync(() => request.GetResponseAsync());
        }

        public async Task<WebResponse> Put(Uri targetUri)
        {
            return await Put(targetUri, null);
        }

        public async Task<WebResponse> Put(Uri targetUri, object requestBody)
        {
            return await Put(targetUri, requestBody, null);
        }

        /// <summary>
        /// Put a request object to the endpoint represented by the web target and get the response.
        /// </summary>
        /// <param name="targetUri"></param>
        /// <param name="requestBody"></param>
        /// <param name="ifMatch"></param>
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

            return await GetPolicies().ExecuteAsync(() => request.GetResponseAsync());
        }

        public async Task<WebResponse> Patch(Uri targetUri)
        {
            return await Patch(targetUri, null);
        }

        public async Task<WebResponse> Patch(Uri targetUri, object requestBody)
        {
            return await Patch(targetUri, requestBody, null);
        }

        /// <summary>
        /// Patch a request object to the endpoint represented by the web target and get the response.
        /// </summary>
        /// <param name="targetUri"></param>
        /// <param name="requestBody"></param>
        /// <param name="ifMatch"></param>
        /// <param name="IfUnmodifiedSince"></param>
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

            return await GetPolicies().ExecuteAsync(() => request.GetResponseAsync());
        }

        public async Task<WebResponse> Delete(Uri targetUri)
        {
            return await Delete(targetUri, null);
        }

        public async Task<WebResponse> Delete(Uri targetUri, object requestBody)
        {
            return await Delete(targetUri, requestBody, null);
        }

        /// <summary>
        /// Execute a delete on a resource and get the response.
        /// </summary>
        /// <param name="targetUri"></param>
        /// <param name="ifMatch"></param>
        /// <returns></returns>
        public async Task<WebResponse> Delete(Uri targetUri, object requestBody, HttpRequestHeaderParam httpRequestHeaderParam)
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

            return await GetPolicies().ExecuteAsync(() => request.GetResponseAsync());
        }


        public async Task<WebResponse> Head(Uri targetUri)
        {
            return await Head(targetUri, null);
        }

        /// <summary>
        /// head method
        /// </summary>
        /// <param name="targetUri"></param>
        /// <param name="ifMatch"></param>
        /// <param name="ifNoneMatch"></param>
        /// <param name="OpcClientRequestId"></param>
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

            return await GetPolicies().ExecuteAsync(() => request.GetResponseAsync());
        }
    }
}

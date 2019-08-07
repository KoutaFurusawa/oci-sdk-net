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

namespace OCISDK.Core.src.Common
{
    public class RestClient : IRestClient
    {
        public IOciSigner Signer { get; set; }
        
        public IJsonSerializer JsonSerializer { get; set; }
        
        public RestOption Option { get; }

        public RestClient()
        {
            // default
            Option = new RestOption();
        }

        private PolicyWrap<HttpWebResponse> GetPolicies()
        {
            return Policy.Wrap(GetRetryPolicy(), GetCircuitBreakerPolicy(), GetFallbackPolicy());
        }

        private Policy<HttpWebResponse> GetRetryPolicy()
        {
            // wait retry 100mSec interval
            var jitter = TimeSpan.FromMilliseconds(RandomProvider.GetThreadRandom().Next(0, 100));
            return Policy<HttpWebResponse>
                .HandleResult(r => (int)r.StatusCode >= 500)
                .WaitAndRetry(Option.RetryCount, retryAttempt =>
                    TimeSpan.FromSeconds(Math.Pow(Option.SleepDurationSeconds, retryAttempt)) + jitter);
        }

        private Policy<HttpWebResponse> GetCircuitBreakerPolicy()
        {
            return Policy<HttpWebResponse>
                .HandleResult(r => (int)r.StatusCode >= 500)
                .CircuitBreaker(Option.HandledEventsAllowedBeforeBreaking, TimeSpan.FromSeconds(Option.DurationOfBreakSeconds));
        }

        private Policy<HttpWebResponse> GetFallbackPolicy()
        {
            return Policy<HttpWebResponse>
                .HandleResult(r => (int)r.StatusCode >= 500)
                .Fallback(new HttpWebResponse());
        }

        public HttpWebResponse Get(HttpWebRequest request)
        {
            return GetPolicies().Execute(() => (HttpWebResponse)request.GetResponse());
        }

        /// <summary>
        /// Request a resource asynchronously.
        /// </summary>
        /// <param name="TargetUri"></param>
        /// <returns></returns>
        public HttpWebResponse Get(Uri targetUri, string opcRequestId = "")
        {
            var request = (HttpWebRequest)WebRequest.Create(targetUri);
            request.Method = HttpMethod.Get.Method;
            request.Accept = "application/json";
            request.ReadWriteTimeout = Option.TimeoutSeconds;

            if (!string.IsNullOrEmpty(opcRequestId))
            {
                request.Headers["opc-request-id"] = opcRequestId;
            }

            if (Signer != null)
            {
                Signer.SignRequest(request);
            }

            return GetPolicies().Execute(() => (HttpWebResponse)request.GetResponse());
        }


        public HttpWebResponse GetIfMatch(Uri targetUri, string opcClientRequestId = "")
        {
            return this.GetIfMatch(targetUri, "", "", opcClientRequestId, null);
        }

        /// <summary>
        /// Request a resource asynchronously.
        /// </summary>
        /// <param name="targetUri"></param>
        /// <param name="ifMatch"></param>
        /// <param name="ifNoneMatch"></param>
        /// <param name="opcClientRequestId"></param>
        /// <returns></returns>
        public HttpWebResponse GetIfMatch(Uri targetUri, string ifMatch = "", string ifNoneMatch = "", string opcClientRequestId = "", List<string> fields=null, string range="")
        {
            var request = (HttpWebRequest)WebRequest.Create(targetUri);
            request.Method = HttpMethod.Get.Method;
            request.Accept = "application/json";
            request.ReadWriteTimeout = Option.TimeoutSeconds;

            if (!string.IsNullOrEmpty(ifMatch))
            {
                request.Headers["if-match"] = ifMatch;
            }

            if (!string.IsNullOrEmpty(ifNoneMatch))
            {
                request.Headers["if-none-match"] = ifNoneMatch;
            }

            if (!string.IsNullOrEmpty(opcClientRequestId))
            {
                request.Headers["opc-client-request-id"] = opcClientRequestId;
            }

            if (!string.IsNullOrEmpty(range))
            {
                request.Headers["range"] = range;
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

            return GetPolicies().Execute(() => (HttpWebResponse)request.GetResponse());
        }
        
        /// <summary>
        /// Post a request object to the endpoint represented by the web target and get the response.
        /// </summary>
        /// <param name="TargetUri"></param>
        /// <returns></returns>
        public HttpWebResponse Post(Uri targetUri, Object requestBody=null, string opcRetryToken="", string opcRequestId="", string ifMatch = "")
        {
            var request = (HttpWebRequest)WebRequest.Create(targetUri);
            request.Method = HttpMethod.Post.Method;
            request.Accept = "application/json";
            request.ContentType = "application/json";
            request.ReadWriteTimeout = Option.TimeoutSeconds;
            
            if (!String.IsNullOrEmpty(opcRetryToken))
            {
                request.Headers["opc-retry-token"] = opcRetryToken;
            }

            if (!String.IsNullOrEmpty(opcRequestId))
            {
                request.Headers["opc-request-id"] = opcRequestId;
            }

            if (!String.IsNullOrEmpty(ifMatch))
            {
                request.Headers["if-match"] = ifMatch;
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

            return GetPolicies().Execute(() => (HttpWebResponse)request.GetResponse());
        }

        /// <summary>
        /// Put a request object to the endpoint represented by the web target and get the response.
        /// </summary>
        /// <param name="targetUri"></param>
        /// <param name="requestBody"></param>
        /// <param name="ifMatch"></param>
        /// <returns></returns>
        public HttpWebResponse Put(Uri targetUri, Object requestBody = null, string ifMatch = "", string opcRetryToken = "")
        {
            var request = (HttpWebRequest)WebRequest.Create(targetUri);
            request.Method = HttpMethod.Put.Method;
            request.Accept = "application/json";
            request.ContentType = "application/json";
            request.ReadWriteTimeout = Option.TimeoutSeconds;

            if (!String.IsNullOrEmpty(ifMatch))
            {
                request.Headers["if-match"] = ifMatch;
            }

            if (!String.IsNullOrEmpty(opcRetryToken))
            {
                request.Headers["opc-retry-token"] = opcRetryToken;
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

            return GetPolicies().Execute(() => (HttpWebResponse)request.GetResponse());
        }

        /// <summary>
        /// Execute a delete on a resource and get the response.
        /// </summary>
        /// <param name="targetUri"></param>
        /// <param name="ifMatch"></param>
        /// <returns></returns>
        public HttpWebResponse Delete(Uri targetUri, string ifMatch = "", Object requestBody = null)
        {
            var request = (HttpWebRequest)WebRequest.Create(targetUri);
            request.Method = HttpMethod.Delete.Method;
            request.ReadWriteTimeout = Option.TimeoutSeconds;

            if (!String.IsNullOrEmpty(ifMatch))
            {
                request.Headers["if-match"] = ifMatch;
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

            return GetPolicies().Execute(() => (HttpWebResponse)request.GetResponse());
        }
    }
}

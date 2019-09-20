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
            return await Get(targetUri, "", "", "", null, "", "");
        }

        public async Task<WebResponse> Get(Uri targetUri, string opcRequestId)
        {
            return await Get(targetUri, "", "", "", null, "", opcRequestId);
        }

        public async Task<WebResponse> Get(Uri targetUri, string opcClientRequestId, string opcRequestId)
        {
            return await Get(targetUri, "", "", opcClientRequestId, null, "", opcRequestId);
        }

        /// <summary>
        /// Request a resource asynchronously.
        /// </summary>
        /// <param name="targetUri"></param>
        /// <param name="ifMatch"></param>
        /// <param name="ifNoneMatch"></param>
        /// <param name="opcClientRequestId"></param>
        /// <returns></returns>
        public async Task<WebResponse> Get(Uri targetUri, string ifMatch, string ifNoneMatch, string opcClientRequestId, List<string> fields, string range, string opcRequestId)
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

            if (!string.IsNullOrEmpty(opcRequestId))
            {
                request.Headers["opc-request-id"] = opcRequestId;
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

        /// <summary>
        /// Post a request object to the endpoint represented by the web target and get the response.
        /// </summary>
        /// <param name="TargetUri"></param>
        /// <returns></returns>
        public async Task<WebResponse> Post(Uri targetUri, Object requestBody = null, string opcRetryToken = "", string opcRequestId = "", string ifMatch = "", string OpcClientRequestId = "")
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

            if (!String.IsNullOrEmpty(OpcClientRequestId))
            {
                request.Headers["opc-client-request-id"] = opcRequestId;
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

            return await GetPolicies().ExecuteAsync(() => request.GetResponseAsync());
        }

        /// <summary>
        /// Put a request object to the endpoint represented by the web target and get the response.
        /// </summary>
        /// <param name="targetUri"></param>
        /// <param name="requestBody"></param>
        /// <param name="ifMatch"></param>
        /// <returns></returns>
        public async Task<WebResponse> Put(Uri targetUri, Object requestBody = null, string ifMatch = "", string opcRetryToken = "", string opcRequestId = "")
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

            if (!String.IsNullOrEmpty(opcRequestId))
            {
                request.Headers["opc-request-id"] = opcRequestId;
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

        /// <summary>
        /// Execute a delete on a resource and get the response.
        /// </summary>
        /// <param name="targetUri"></param>
        /// <param name="ifMatch"></param>
        /// <returns></returns>
        public async Task<WebResponse> Delete(Uri targetUri, string ifMatch = "", Object requestBody = null)
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

            return await GetPolicies().ExecuteAsync(() => request.GetResponseAsync());
        }

        /// <summary>
        /// head method
        /// </summary>
        /// <param name="targetUri"></param>
        /// <param name="ifMatch"></param>
        /// <param name="ifNoneMatch"></param>
        /// <param name="OpcClientRequestId"></param>
        /// <returns></returns>
        public async Task<WebResponse> Head(Uri targetUri, string ifMatch = "", string ifNoneMatch = "", string OpcClientRequestId = "")
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
            
            if (Signer != null)
            {
                Signer.SignRequest(request);
            }

            return await GetPolicies().ExecuteAsync(() => request.GetResponseAsync());
        }
    }
}

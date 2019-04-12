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

namespace OCISDK.Core.src.Common
{
    public static class RandomProvider
    {
        private static ThreadLocal<Random> RandomWrapper = new ThreadLocal<Random>(() =>
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var buffer = new byte[sizeof(int)];
                rng.GetBytes(buffer);
                var seed = BitConverter.ToInt32(buffer, 0);
                return new Random(seed);
            }
        });

        public static Random GetThreadRandom()
        {
            return RandomWrapper.Value;
        }
    }

    public class RestOption
    {
        public int TimeoutSeconds { get; set; } = 100;
        public int RetryCount { get; set; } = 3;
        public int SleepDurationSeconds { get; set; } = 2;
        public int HandledEventsAllowedBeforeBreaking { get; set; } = 10;
        public int DurationOfBreakSeconds { get; set; } = 60;
    }

    public interface IRestClient
    {
        HttpWebResponse Get(Uri targetUri, string opcRequestId = "");
        HttpWebResponse Post(Uri targetUri, Object requestBody = null, string opcRetryToken = "");
        HttpWebResponse Put(Uri targetUri, Object requestBody = null, string ifMatch = "", string opcRetryToken = "");
        HttpWebResponse Delete(Uri targetUri, string ifMatch = "", Object requestBody = null);
    }

    public class RestClient : IRestClient
    {
        public Signer Signer { get; set; }

        public ClientConfig Config { get; set; }

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

            Signer.SignRequest(request);

            return GetPolicies().Execute(() => (HttpWebResponse)request.GetResponse());
        }

        /// <summary>
        /// Post a request object to the endpoint represented by the web target and get the response.
        /// </summary>
        /// <param name="TargetUri"></param>
        /// <returns></returns>
        public HttpWebResponse Post(Uri targetUri, Object requestBody = null, string opcRetryToken = "")
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

            Signer.SignRequest(request);

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
            
            Signer.SignRequest(request);

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

            Signer.SignRequest(request);

            return GetPolicies().Execute(() => (HttpWebResponse)request.GetResponse());
        }
    }
}

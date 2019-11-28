using Polly;
using Polly.Wrap;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace OCISDK.Core.Common
{
    /// <summary>
    /// default Polly
    /// </summary>
    public class DefaultWebRequestPolicy : IWebRequestPolicy
    {
        /// <summary>
        /// get
        /// </summary>
        /// <param name="option"></param>
        /// <returns></returns>
        public PolicyWrap<HttpWebResponse> GetPolicies(RestOption option)
        {
            return Policy.Wrap(GetRetryPolicy(option), GetCircuitBreakerPolicy(option), GetFallbackPolicy());
        }

        /// <summary>
        /// retry
        /// </summary>
        /// <param name="option"></param>
        /// <returns></returns>
        public Policy<HttpWebResponse> GetRetryPolicy(RestOption option)
        {
            var jitter = TimeSpan.FromMilliseconds(RandomProvider.GetThreadRandom().Next(0, 100));
            return Policy<HttpWebResponse>
                .Handle<WebException>(r => r.Status == WebExceptionStatus.ProtocolError && ((HttpWebResponse)r.Response).StatusCode >= HttpStatusCode.InternalServerError)
                .OrResult(r => r.StatusCode >= HttpStatusCode.InternalServerError)
                .WaitAndRetry(option.RetryCount, retryAttempt =>
                    TimeSpan.FromSeconds(Math.Pow(option.SleepDurationSeconds, retryAttempt)) + jitter);
        }

        /// <summary>
        /// circuitBreaker
        /// </summary>
        /// <param name="option"></param>
        /// <returns></returns>
        public Policy<HttpWebResponse> GetCircuitBreakerPolicy(RestOption option)
        {
            return Policy<HttpWebResponse>
                .Handle<WebException>(r => r.Status == WebExceptionStatus.ProtocolError && ((HttpWebResponse)r.Response).StatusCode >= HttpStatusCode.InternalServerError)
                .OrResult(r => r.StatusCode >= HttpStatusCode.InternalServerError)
                .CircuitBreaker(option.HandledEventsAllowedBeforeBreaking, TimeSpan.FromSeconds(option.DurationOfBreakSeconds));
        }

        /// <summary>
        /// fallback
        /// </summary>
        /// <returns></returns>
        public Policy<HttpWebResponse> GetFallbackPolicy()
        {
            return Policy<HttpWebResponse>
                .Handle<WebException>(r => r.Status == WebExceptionStatus.ProtocolError && ((HttpWebResponse)r.Response).StatusCode >= HttpStatusCode.InternalServerError)
                .OrResult(r => r.StatusCode >= HttpStatusCode.InternalServerError)
                .Fallback(new HttpWebResponse());
        }

        /// <summary>
        /// get async
        /// </summary>
        /// <param name="option"></param>
        /// <returns></returns>
        public IAsyncPolicy<WebResponse> GetPoliciesAsync (RestOption option)
        {
            return Policy.WrapAsync(GetRetryPolicyAsync(option), GetCircuitBreakerPolicyAsync(option), GetFallbackPolicyAsync());
        }

        /// <summary>
        /// retry async
        /// </summary>
        /// <param name="option"></param>
        /// <returns></returns>
        public IAsyncPolicy<WebResponse> GetRetryPolicyAsync(RestOption option)
        {
            var jitter = TimeSpan.FromMilliseconds(RandomProvider.GetThreadRandom().Next(0, 100));
            return Policy<WebResponse>
                .Handle<WebException>(ex => ((HttpWebResponse)ex.Response).StatusCode == HttpStatusCode.InternalServerError)
                .WaitAndRetryAsync(option.RetryCount, retryAttempt =>
                    TimeSpan.FromSeconds(Math.Pow(option.SleepDurationSeconds, retryAttempt)) + jitter);
        }

        /// <summary>
        /// circuitBreaker async
        /// </summary>
        /// <param name="option"></param>
        /// <returns></returns>
        public IAsyncPolicy<WebResponse> GetCircuitBreakerPolicyAsync(RestOption option)
        {
            return Policy<WebResponse>
                .Handle<WebException>(ex => ((HttpWebResponse)ex.Response).StatusCode == HttpStatusCode.InternalServerError)
                .CircuitBreakerAsync(option.HandledEventsAllowedBeforeBreaking, TimeSpan.FromSeconds(option.DurationOfBreakSeconds));
        }

        /// <summary>
        /// fallback async
        /// </summary>
        /// <returns></returns>
        public IAsyncPolicy<WebResponse> GetFallbackPolicyAsync()
        {
            return Policy<WebResponse>
                .Handle<WebException>(ex => ((HttpWebResponse)ex.Response).StatusCode == HttpStatusCode.InternalServerError)
                .FallbackAsync(new HttpWebResponse());
        }
    }
}

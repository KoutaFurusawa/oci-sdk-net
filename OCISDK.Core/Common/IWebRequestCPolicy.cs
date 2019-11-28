using Polly;
using Polly.Wrap;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace OCISDK.Core.Common
{
    /// <summary>
    /// WebRequestPolicy interface
    /// </summary>
    public interface IWebRequestPolicy
    {
        /// <summary>
        /// GetPolicies
        /// </summary>
        /// <param name="option"></param>
        /// <returns></returns>
        PolicyWrap<HttpWebResponse> GetPolicies(RestOption option);

        /// <summary>
        /// GetRetryPolicy
        /// </summary>
        /// <param name="option"></param>
        /// <returns></returns>
        Policy<HttpWebResponse> GetRetryPolicy(RestOption option);

        /// <summary>
        /// GetCircuitBreakerPolicy
        /// </summary>
        /// <param name="option"></param>
        /// <returns></returns>
        Policy<HttpWebResponse> GetCircuitBreakerPolicy(RestOption option);

        /// <summary>
        /// GetFallbackPolicy
        /// </summary>
        /// <returns></returns>
        Policy<HttpWebResponse> GetFallbackPolicy();

        /// <summary>
        /// GetPoliciesAsync
        /// </summary>
        /// <param name="option"></param>
        /// <returns></returns>
        IAsyncPolicy<WebResponse> GetPoliciesAsync(RestOption option);

        /// <summary>
        /// GetRetryPolicyAsync
        /// </summary>
        /// <param name="option"></param>
        /// <returns></returns>
        IAsyncPolicy<WebResponse> GetRetryPolicyAsync(RestOption option);

        /// <summary>
        /// GetCircuitBreakerPolicyAsync
        /// </summary>
        /// <param name="option"></param>
        /// <returns></returns>
        IAsyncPolicy<WebResponse> GetCircuitBreakerPolicyAsync(RestOption option);

        /// <summary>
        /// GetFallbackPolicyAsync
        /// </summary>
        /// <returns></returns>
        IAsyncPolicy<WebResponse> GetFallbackPolicyAsync();
    }
}

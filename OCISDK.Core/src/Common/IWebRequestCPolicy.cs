using Polly;
using Polly.Wrap;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace OCISDK.Core.src.Common
{
    public interface IWebRequestPolicy
    {
        PolicyWrap<HttpWebResponse> GetPolicies(RestOption option);

        Policy<HttpWebResponse> GetRetryPolicy(RestOption option);

        Policy<HttpWebResponse> GetCircuitBreakerPolicy(RestOption option);

        Policy<HttpWebResponse> GetFallbackPolicy();

        IAsyncPolicy<WebResponse> GetPoliciesAsync(RestOption option);

        IAsyncPolicy<WebResponse> GetRetryPolicyAsync(RestOption option);

        IAsyncPolicy<WebResponse> GetCircuitBreakerPolicyAsync(RestOption option);

        IAsyncPolicy<WebResponse> GetFallbackPolicyAsync();
    }
}

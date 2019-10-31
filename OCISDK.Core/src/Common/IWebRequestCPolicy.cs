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

        PolicyWrap<WebResponse> GetPoliciesAsync(RestOption option);

        Policy<WebResponse> GetRetryPolicyAsync(RestOption option);

        Policy<WebResponse> GetCircuitBreakerPolicyAsync(RestOption option);

        Policy<WebResponse> GetFallbackPolicyAsync();
    }
}

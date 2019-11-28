using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Waas.Model
{
    /// <summary>
    /// The Web Application Firewall configuration for the WAAS policy.
    /// </summary>
    public class WafConfigDetails
    {
        /// <summary>
        /// The access rules applied to the Web Application Firewall. 
        /// Used for defining custom access policies with the combination of ALLOW, DETECT, and BLOCK rules, based on different criteria.
        /// <para>Required: no</para>
        /// </summary>
        public List<AccessRuleDetails> AccessRules { get; set; }

        /// <summary>
        /// The IP address rate limiting settings used to limit the number of requests from an address.
        /// <para>Required: no</para>
        /// </summary>
        public AddressRateLimiting AddressRateLimiting { get; set; }

        /// <summary>
        /// A list of CAPTCHA challenge settings. These are used to challenge requests with a CAPTCHA to block bots.
        /// <para>Required: no</para>
        /// </summary>
        public List<CaptchaDetails> Captchas { get; set; }
    }
}

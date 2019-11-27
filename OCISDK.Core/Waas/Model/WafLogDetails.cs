

using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Waas.Model
{
    /// <summary>
    /// A list of Web Application Firewall log entries. Each entry is a JSON object, including a timestamp property and other fields varying based on log type.
    /// Logs record what rules and countermeasures are triggered by requests and are used as a basis to move request handling into block mode.
    /// For more information about WAF logs, see Logs.
    /// </summary>
    public class WafLogDetails
    {
        /// <summary>
        /// The action taken on the request, either ALLOW, DETECT, or BLOCK.
        /// <para>Required: no</para>
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        /// The CAPTCHA action taken on the request, ALLOW or BLOCK. 
        /// For more information about CAPTCHAs, see UpdateCaptchas.
        /// <para>Required: no</para>
        /// </summary>
        public string CaptchaAction { get; set; }

        /// <summary>
        /// The CAPTCHA challenge answer that was expected.
        /// <para>Required: no</para>
        /// </summary>
        public string CaptchaExpected { get; set; }

        /// <summary>
        /// The CAPTCHA challenge answer that was received.
        /// <para>Required: no</para>
        /// </summary>
        public string CaptchaReceived { get; set; }

        /// <summary>
        /// The number of times the CAPTCHA challenge was failed.
        /// <para>Required: no</para>
        /// </summary>
        public string CaptchaFailCount { get; set; }

        /// <summary>
        /// The IPv4 address of the requesting client.
        /// <para>Required: no</para>
        /// </summary>
        public string ClientAddress { get; set; }

        /// <summary>
        /// The name of the country where the request originated.
        /// <para>Required: no</para>
        /// </summary>
        public string CountryName { get; set; }

        /// <summary>
        /// The value of the request's User-Agent header field.
        /// <para>Required: no</para>
        /// </summary>
        public string UserAgent { get; set; }

        /// <summary>
        /// The Host header data of the request.
        /// <para>Required: no</para>
        /// </summary>
        public string Domain { get; set; }

        /// <summary>
        /// A map of protection rule keys to detection message details.
        /// Detections are requests that matched the criteria of a protection rule but the rule's action was set to DETECT.
        /// <para>Required: no</para>
        /// </summary>
        public object ProtectionRuleDetections { get; set; }

        /// <summary>
        /// The HTTP method of the request.
        /// <para>Required: no</para>
        /// </summary>
        public string HttpMethod { get; set; }

        /// <summary>
        /// The path and query string of the request.
        /// <para>Required: no</para>
        /// </summary>
        public string RequestUrl { get; set; }

        /// <summary>
        /// The map of the request's header names to their respective values.
        /// <para>Required: no</para>
        /// </summary>
        public object HttpHeaders { get; set; }

        /// <summary>
        /// The Referrer header value of the request.
        /// <para>Required: no</para>
        /// </summary>
        public string Referrer { get; set; }

        /// <summary>
        /// The status code of the response.
        /// <para>Required: no</para>
        /// </summary>
        public int? ResponseCode { get; set; }

        /// <summary>
        /// The size in bytes of the response.
        /// <para>Required: no</para>
        /// </summary>
        public int? ResponseSize { get; set; }

        /// <summary>
        /// The incident key of a request. 
        /// An incident key is generated for each request processed by the Web Application Firewall and is used to idenitfy blocked requests in applicable logs.
        /// <para>Required: no</para>
        /// </summary>
        public string IncidentKey { get; set; }

        /// <summary>
        /// The hashed signature of the device's fingerprint.
        /// For more information, see DeviceFingerPrintChallenge.
        /// <para>Required: no</para>
        /// </summary>
        public string Fingerprint { get; set; }

        /// <summary>
        /// The type of device that the request was made from.
        /// <para>Required: no</para>
        /// </summary>
        public string Device { get; set; }

        /// <summary>
        /// ISO 3166-1 alpha-2 code of the country from which the request originated. For a list of codes, see ISO's website.
        /// <para>Required: no</para>
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// A map of header names to values of the request sent to the origin, including any headers appended by the Web Application Firewall.
        /// <para>Required: no</para>
        /// </summary>
        public object RequestHeaders { get; set; }

        /// <summary>
        /// The ThreatFeed key that matched the request. For more information about threat feeds, see UpdateThreatFeeds.
        /// <para>Required: no</para>
        /// </summary>
        public string ThreatFeedKey { get; set; }

        /// <summary>
        /// The AccessRule key that matched the request. For more information about access rules, see UpdateAccessRules.
        /// <para>Required: no</para>
        /// </summary>
        public string AccessRuleKey { get; set; }

        /// <summary>
        /// The AddressRateLimiting key that matched the request.
        /// For more information about address rate limiting, see UpdateWafAddressRateLimiting.
        /// <para>Required: no</para>
        /// </summary>
        public string AddressRateLimitingKey { get; set; }

        /// <summary>
        /// The date and time the Web Application Firewall processed the request and logged it.
        /// <para>Required: no</para>
        /// </summary>
        public string Timestamp { get; set; }

        /// <summary>
        /// The type of log of the request. For more about log types, see Logs.
        /// <para>Required: no</para>
        /// </summary>
        public string LogType { get; set; }

        /// <summary>
        /// The address of the origin server where the request was sent.
        /// <para>Required: no</para>
        /// </summary>
        public string OriginAddress { get; set; }

        /// <summary>
        /// The amount of time it took the origin server to respond to the request, in seconds.
        /// <para>Required: no</para>
        /// </summary>
        public string OriginResponseTime { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Waas.Request
{
    /// <summary>
    /// ListWafLogs request
    /// </summary>
    public class ListWafLogsRequest
    {
        /// <summary>
        /// The unique Oracle-assigned identifier for the request.
        /// If you need to contact Oracle about a particular request, please provide the request ID.
        /// <para>Required: no</para>
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// The OCID of the WAAS policy.
        /// <para>Required: yes</para>
        /// </summary>
        public string WaasPolicyId { get; set; }

        /// <summary>
        /// The maximum number of items to return in a paginated call. In unspecified, defaults to 20.
        /// <para>Required: no</para>
        /// </summary>
        public int? Limit { get; set; }

        /// <summary>
        /// The value of the opc-next-page response header from the previous paginated call.
        /// <para>Required: no</para>
        /// </summary>
        public string Page { get; set; }

        /// <summary>
        /// A filter that matches log entries where the observed event occurred on or after a date and time specified in RFC 3339 format.
        /// If unspecified, defaults to two hours before receipt of the request.
        /// <para>Required: no</para>
        /// </summary>
        public string TimeObservedGreaterThanOrEqualTo { get; set; }

        /// <summary>
        /// A filter that matches log entries where the observed event occurred before a date and time, specified in RFC 3339 format.
        /// <para>Required: no</para>
        /// </summary>
        public string TimeObservedLessThan { get; set; }

        /// <summary>
        /// A full text search for logs.
        /// <para>Required: no</para>
        /// </summary>
        public string TextContains { get; set; }

        /// <summary>
        /// Filters logs by access rule key.
        /// <para>Required: no</para>
        /// </summary>
        public List<string> AccessRuleKey { get; set; }

        /// <summary>
        /// Filters logs by Web Application Firewall action.
        /// <para>Required: no</para>
        /// </summary>
        public List<string> Action { get; set; }

        /// <summary>
        /// Filters logs by client IP address.
        /// <para>Required: no</para>
        /// </summary>
        public List<string> ClientAddress { get; set; }

        /// <summary>
        /// Filters logs by country code. Country codes are in ISO 3166-1 alpha-2 format. For a list of codes, see ISO's website.
        /// <para>Required: no</para>
        /// </summary>
        public List<string> CountryCode { get; set; }

        /// <summary>
        /// Filter logs by country name.
        /// <para>Required: no</para>
        /// </summary>
        public List<string> CountryName { get; set; }

        /// <summary>
        /// Filter logs by device fingerprint.
        /// <para>Required: no</para>
        /// </summary>
        public List<string> Fingerprint { get; set; }

        /// <summary>
        /// Filter logs by HTTP method.
        /// <para>Required: no</para>
        /// </summary>
        public List<string> HttpMethod { get; set; }

        /// <summary>
        /// Filter logs by incident key.
        /// <para>Required: no</para>
        /// </summary>
        public List<string> IncidentKey { get; set; }

        /// <summary>
        /// Filter by log type. For more information about WAF logs, see Logs.
        /// <para>Required: no</para>
        /// </summary>
        public List<string> LogType { get; set; }

        /// <summary>
        /// Filter by origin IP address.
        /// <para>Required: no</para>
        /// </summary>
        public List<string> OriginAddress { get; set; }

        /// <summary>
        /// Filter by referrer.
        /// <para>Required: no</para>
        /// </summary>
        public List<string> Referrer { get; set; }

        /// <summary>
        /// Filter by request URL.
        /// <para>Required: no</para>
        /// </summary>
        public List<string> RequestUrl { get; set; }

        /// <summary>
        /// Filter by response code.
        /// <para>Required: no</para>
        /// </summary>
        public List<string> ResponseCode { get; set; }

        /// <summary>
        /// Filter by threat feed key.
        /// <para>Required: no</para>
        /// </summary>
        public List<string> ThreatFeedKey { get; set; }

        /// <summary>
        /// Filter by user agent.
        /// <para>Required: no</para>
        /// </summary>
        public List<string> UserAgent { get; set; }

        /// <summary>
        /// Filter by protection rule key.
        /// <para>Required: no</para>
        /// </summary>
        public List<string> ProtectionRuleKey { get; set; }

        /// <summary>
        /// option query
        /// </summary>
        /// <returns></returns>
        public string GetOptionQuery()
        {
            StringBuilder sb = new StringBuilder();
            string chainStr = "";

            if (this.Limit.HasValue)
            {
                sb.Append($"limit={this.Limit.Value}");
                chainStr = "&";
            }

            if (!string.IsNullOrEmpty(this.Page))
            {
                sb.Append($"{chainStr}page={this.Page}");
                chainStr = "&";
            }

            if (!string.IsNullOrEmpty(this.TimeObservedGreaterThanOrEqualTo))
            {
                sb.Append($"{chainStr}timeObservedGreaterThanOrEqualTo={this.TimeObservedGreaterThanOrEqualTo}");
                chainStr = "&";
            }

            if (!string.IsNullOrEmpty(this.TimeObservedLessThan))
            {
                sb.Append($"{chainStr}timeObservedLessThan={this.TimeObservedLessThan}");
                chainStr = "&";
            }

            if (!string.IsNullOrEmpty(this.TextContains))
            {
                sb.Append($"{chainStr}textContains={this.TextContains}");
                chainStr = "&";
            }

            if (AccessRuleKey.Count > 0)
            {
                if (AccessRuleKey.Count == 1)
                {
                    sb.Append($"{chainStr}accessRuleKey={AccessRuleKey[0]}");
                    chainStr = "&";
                }
                else
                {
                    foreach (var i in AccessRuleKey)
                    {
                        sb.Append($"{chainStr}accessRuleKey[]={i}");
                        chainStr = "&";
                    }
                }
            }

            if (Action.Count > 0)
            {
                if (Action.Count == 1)
                {
                    sb.Append($"{chainStr}action={Action[0]}");
                    chainStr = "&";
                }
                else
                {
                    foreach (var i in Action)
                    {
                        sb.Append($"{chainStr}action[]={i}");
                        chainStr = "&";
                    }
                }
            }

            if (ClientAddress.Count > 0)
            {
                if (ClientAddress.Count == 1)
                {
                    sb.Append($"{chainStr}clientAddress={ClientAddress[0]}");
                    chainStr = "&";
                }
                else
                {
                    foreach (var i in ClientAddress)
                    {
                        sb.Append($"{chainStr}clientAddress[]={i}");
                        chainStr = "&";
                    }
                }
            }

            if (CountryCode.Count > 0)
            {
                if (ClientAddress.Count == 1)
                {
                    sb.Append($"{chainStr}countryCode={CountryCode[0]}");
                    chainStr = "&";
                }
                else
                {
                    foreach (var i in CountryCode)
                    {
                        sb.Append($"{chainStr}countryCode[]={i}");
                        chainStr = "&";
                    }
                }
            }

            if (CountryName.Count > 0)
            {
                if (CountryName.Count == 1)
                {
                    sb.Append($"{chainStr}countryName={CountryName[0]}");
                    chainStr = "&";
                }
                else
                {
                    foreach (var i in CountryName)
                    {
                        sb.Append($"{chainStr}countryName[]={i}");
                        chainStr = "&";
                    }
                }
            }

            if (Fingerprint.Count > 0)
            {
                if (Fingerprint.Count == 1)
                {
                    sb.Append($"{chainStr}fingerprint={Fingerprint[0]}");
                    chainStr = "&";
                }
                else
                {
                    foreach (var i in Fingerprint)
                    {
                        sb.Append($"{chainStr}fingerprint[]={i}");
                        chainStr = "&";
                    }
                }
            }

            if (HttpMethod.Count > 0)
            {
                if (HttpMethod.Count == 1)
                {
                    sb.Append($"{chainStr}httpMethod={HttpMethod[0]}");
                    chainStr = "&";
                }
                else
                {
                    foreach (var i in HttpMethod)
                    {
                        sb.Append($"{chainStr}httpMethod[]={i}");
                        chainStr = "&";
                    }
                }
            }

            if (IncidentKey.Count > 0)
            {
                if (IncidentKey.Count == 1)
                {
                    sb.Append($"{chainStr}incidentKey={IncidentKey[0]}");
                    chainStr = "&";
                }
                else
                {
                    foreach (var i in IncidentKey)
                    {
                        sb.Append($"{chainStr}incidentKey[]={i}");
                        chainStr = "&";
                    }
                }
            }

            if (LogType.Count > 0)
            {
                if (LogType.Count == 1)
                {
                    sb.Append($"{chainStr}logType={LogType[0]}");
                    chainStr = "&";
                }
                else
                {
                    foreach (var i in LogType)
                    {
                        sb.Append($"{chainStr}logType[]={i}");
                        chainStr = "&";
                    }
                }
            }

            if (OriginAddress.Count > 0)
            {
                if (OriginAddress.Count == 1)
                {
                    sb.Append($"{chainStr}originAddress={OriginAddress[0]}");
                    chainStr = "&";
                }
                else
                {
                    foreach (var i in OriginAddress)
                    {
                        sb.Append($"{chainStr}originAddress[]={i}");
                        chainStr = "&";
                    }
                }
            }

            if (Referrer.Count > 0)
            {
                if (Referrer.Count == 1)
                {
                    sb.Append($"{chainStr}referrer={Referrer[0]}");
                    chainStr = "&";
                }
                else
                {
                    foreach (var i in Referrer)
                    {
                        sb.Append($"{chainStr}referrer[]={i}");
                        chainStr = "&";
                    }
                }
            }

            if (RequestUrl.Count > 0)
            {
                if (RequestUrl.Count == 1)
                {
                    sb.Append($"{chainStr}requestUrl={RequestUrl[0]}");
                    chainStr = "&";
                }
                else
                {
                    foreach (var i in RequestUrl)
                    {
                        sb.Append($"{chainStr}requestUrl[]={i}");
                        chainStr = "&";
                    }
                }
            }

            if (ResponseCode.Count > 0)
            {
                if (ResponseCode.Count == 1)
                {
                    sb.Append($"{chainStr}responseCode={ResponseCode[0]}");
                    chainStr = "&";
                }
                else
                {
                    foreach (var i in ResponseCode)
                    {
                        sb.Append($"{chainStr}responseCode[]={i}");
                        chainStr = "&";
                    }
                }
            }

            if (ThreatFeedKey.Count > 0)
            {
                if (ThreatFeedKey.Count == 1)
                {
                    sb.Append($"{chainStr}threatFeedKey={ThreatFeedKey[0]}");
                    chainStr = "&";
                }
                else
                {
                    foreach (var i in ThreatFeedKey)
                    {
                        sb.Append($"{chainStr}threatFeedKey[]={i}");
                        chainStr = "&";
                    }
                }
            }

            if (UserAgent.Count > 0)
            {
                if (UserAgent.Count == 1)
                {
                    sb.Append($"{chainStr}userAgent={UserAgent[0]}");
                    chainStr = "&";
                }
                else
                {
                    foreach (var i in UserAgent)
                    {
                        sb.Append($"{chainStr}userAgent[]={i}");
                        chainStr = "&";
                    }
                }
            }

            if (ProtectionRuleKey.Count > 0)
            {
                if (ProtectionRuleKey.Count == 1)
                {
                    sb.Append($"{chainStr}protectionRuleKey={ProtectionRuleKey[0]}");
                    chainStr = "&";
                }
                else
                {
                    foreach (var i in ProtectionRuleKey)
                    {
                        sb.Append($"{chainStr}protectionRuleKey[]={i}");
                        chainStr = "&";
                    }
                }
            }

            return sb.ToString();
        }
    }
}

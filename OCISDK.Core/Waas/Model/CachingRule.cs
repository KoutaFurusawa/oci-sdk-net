using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Waas.Model
{
    /// <summary>
    /// CachingRule
    /// </summary>
    public class CachingRule
    {
        /// <summary>
        /// The unique key for the caching rule.
        /// <para>Required: no</para>
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// The name of the caching rule.
        /// <para>Required: yes</para>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The action to take when the criteria of a caching rule are met.
        /// <para>Required: yes</para>
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        /// The duration to cache content for the caching rule, specified in ISO 8601 extended format. Supported units: seconds,
        /// minutes, hours, days, weeks, months. The maximum value that can be set for any unit is 99. Mixing of multiple units 
        /// is not supported.
        /// <para>Required: no</para>
        /// </summary>
        public string CachingDuration { get; set; }

        /// <summary>
        /// Enables or disables client caching. Browsers use the Cache-Control header value for caching content locally in the browser. 
        /// This setting overrides the addition of a Cache-Control header in responses.
        /// <para>Required: no</para>
        /// </summary>
        public bool? IsClientCachingEnabled { get; set; }

        /// <summary>
        /// The duration to cache content in the user's browser, specified in ISO 8601 extended format. Supported units: seconds, minutes, 
        /// hours, days, weeks, months. The maximum value that can be set for any unit is 99. Mixing of multiple units is not supported.
        /// <para>Required: no</para>
        /// </summary>
        public string ClientCachingDuration { get; set; }

        /// <summary>
        /// The array of the rule criteria with condition and value.
        /// <para>Required: yes</para>
        /// </summary>
        public List<CachingRuleCriteria> Criteria { get; set; }
    }
}

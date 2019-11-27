using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Waas.Model
{
    /// <summary>
    /// WafBlockedRequest Reference
    /// </summary>
    public class WafBlockedRequest
    {
        /// <summary>
        /// The date and time the blocked requests were observed, expressed in RFC 3339 timestamp format.
        /// <para>Required: no</para>
        /// </summary>
        public string TimeObserved { get; set; }

        /// <summary>
        /// The number of seconds the data covers.
        /// <para>Required: no</para>
        /// </summary>
        public string TimeRangeInSeconds { get; set; }

        /// <summary>
        /// The specific Web Application Firewall feature that blocked the requests, such as JavaScript Challenge or Access Control.
        /// <para>Required: no</para>
        /// </summary>
        public string WafFeature { get; set; }

        /// <summary>
        /// The count of blocked requests.
        /// <para>Required: no</para>
        /// </summary>
        public int? Count { get; set; }
    }
}

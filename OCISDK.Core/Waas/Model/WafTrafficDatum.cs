using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Waas.Model
{
    /// <summary>
    /// A time series of traffic data for the Web Application Firewall configured for a policy.
    /// </summary>
    public class WafTrafficDatum
    {
        /// <summary>
        /// The date and time the traffic was observed, rounded down to the start of the range, and expressed in RFC 3339 timestamp format.
        /// <para>Required: no</para>
        /// </summary>
        public string TimeObserved { get; set; }

        /// <summary>
        /// The number of seconds this data covers.
        /// <para>Required: no</para>
        /// </summary>
        public int? TimeRangeInSeconds { get; set; }

        /// <summary>
        /// The tenancy OCID of the data.
        /// <para>Required: no</para>
        /// </summary>
        public string TenancyId { get; set; }

        /// <summary>
        /// The policy OCID of the data.
        /// <para>Required: no</para>
        /// </summary>
        public string WaasPolicyId { get; set; }

        /// <summary>
        /// Traffic in bytes.
        /// <para>Required: no</para>
        /// </summary>
        public int? TrafficInBytes { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Monitoring.Model
{
    /// <summary>
    /// An array of metric objects containing raw metric data points to be posted to the Monitoring service.
    /// </summary>
    public class PostMetricDataDetails
    {
        /// <summary>
        /// A metric object containing raw metric data points to be posted to the Monitoring service.
        /// <para>Required: yes</para>
        /// </summary>
        public List<MetricDataDetails> MetricData { get; set; }

        /// <summary>
        /// Batch atomicity behavior. Requires either partial or full pass of input validation for metric objects in PostMetricData requests. 
        /// The default value of NON_ATOMIC requires a partial pass: at least one metric object in the request must pass input validation, 
        /// and any objects that failed validation are identified in the returned summary, 
        /// along with their error messages. A value of ATOMIC requires a full pass: all metric objects in the request must pass input validation.
        /// <para>Required: no</para>
        /// </summary>
        public string BatchAtomicity { get; set; }
    }
}

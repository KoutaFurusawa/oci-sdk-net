using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Notification.Model
{
    /// <summary>
    /// The backoff retry portion of the subscription delivery policy. For information about retry durations for subscriptions, see How Notifications Works.
    /// </summary>
    public class BackoffRetryPolicy
    {
        /// <summary>
        /// The maximum retry duration in milliseconds. Default value is 7200000 (2 hours).
        /// <para>Required: yes</para>
        /// <para>Default: 7200000</para>
        /// <para>Minimum: 60000, Maximum: 7200000</para>
        /// </summary>
        public int MaxRetryDuration { get; set; }

        /// <summary>
        /// The type of delivery policy.
        /// <para>Required: yes</para>
        /// <para>Default: EXPONENTIAL</para>
        /// </summary>
        public string PolicyType { get; set; }
    }
}

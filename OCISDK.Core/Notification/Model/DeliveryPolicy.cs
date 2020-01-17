using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Notification.Model
{
    /// <summary>
    /// The subscription delivery policy.
    /// </summary>
    public class DeliveryPolicy
    {
        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public BackoffRetryPolicy BackoffRetryPolicy { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Notification.Model
{
    /// <summary>
    /// The configuration details for updating the subscription.
    /// </summary>
    public class UpdateSubscriptionDetails
    {
        /// <summary>
        /// The delivery policy of the subscription. Stored as a JSON string.
        /// <para>Required: no</para>
        /// </summary>
        public DeliveryPolicy DeliveryPolicy { get; set; }

        /// <summary>
        /// Free-form tags for this resource. Each tag is a simple key-value pair with no predefined name, type, or namespace. For more information, see Resource Tags.
        /// <para>Required: no</para>
        /// </summary>
        public IDictionary<string, string> FreeformTags { get; set; }

        /// <summary>
        /// Defined tags for this resource. Each key is predefined and scoped to a namespace. For more information, see Resource Tags.
        /// <para>Required: no</para>
        /// </summary>
        public IDictionary<string, IDictionary<string, string>> DefinedTags { get; set; }
    }
}

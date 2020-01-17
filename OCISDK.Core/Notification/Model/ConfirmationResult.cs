using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Notification.Model
{
    /// <summary>
    /// The confirmation details for the specified subscription. For information about confirming subscriptions, see To confirm a subscription.
    /// </summary>
    public class ConfirmationResult
    {
        /// <summary>
        /// The name of the subscribed topic.
        /// <para>Required: yes</para>
        /// </summary>
        public string TopicName { get; set; }

        /// <summary>
        /// The OCID of the topic associated with the specified subscription.
        /// <para>Required: yes</para>
        /// </summary>
        public string TopicId { get; set; }

        /// <summary>
        /// A locator that corresponds to the subscription protocol. For example, an email address for a subscription that uses the 
        /// EMAIL protocol, or a URL for a subscription that uses an HTTP-based protocol.
        /// <para>Required: yes</para>
        /// </summary>
        public string Endpoint { get; set; }

        /// <summary>
        /// The URL for unsubscribing from the topic.
        /// <para>Required: yes</para>
        /// </summary>
        public string UnsubscribeUrl { get; set; }

        /// <summary>
        /// A human-readable string indicating the status of the subscription confirmation.
        /// <para>Required: yes</para>
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// The OCID of the subscription specified in the request.
        /// <para>Required: yes</para>
        /// </summary>
        public string SubscriptionId { get; set; }
    }
}

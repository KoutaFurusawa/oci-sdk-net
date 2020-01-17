using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Notification.Model
{
    /// <summary>
    /// The subscription's configuration summary.
    /// </summary>
    public class SubscriptionSummary
    {
        /// <summary>
        /// The OCID of the subscription.
        /// <para>Required: yes</para>
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The protocol used for the subscription. For information about subscription protocols, see To create a subscription.
        /// <para>Required: yes</para>
        /// </summary>
        public string TopicId { get; set; }

        /// <summary>
        /// The protocol used for the subscription. For information about subscription protocols, see To create a subscription.
        /// <para>Required: yes</para>
        /// </summary>
        public string Protocol { get; set; }

        /// <summary>
        /// A locator that corresponds to the subscription protocol. For example, an email address for a subscription that uses the 
        /// EMAIL protocol, or a URL for a subscription that uses an HTTP-based protocol.
        /// <para>Required: yes</para>
        /// </summary>
        public string Endpoint { get; set; }

        /// <summary>
        /// The lifecycle state of the subscription. 
        /// The status of a new subscription is PENDING; when confirmed, the subscription status changes to ACTIVE.
        /// <para>Required: yes</para>
        /// </summary>
        public string LifecycleState { get; set; }

        /// <summary>
        /// The OCID of the compartment for the subscription.
        /// <para>Required: yes</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// The time when this suscription was created.
        /// <para>Required: no</para>
        /// </summary>
        public long CreatedTime { get; set; }

        /// <summary>
        /// The delivery policy of the subscription. Stored as a JSON string.
        /// <para>Required: no</para>
        /// </summary>
        public string DeliverPolicy { get; set; }

        /// <summary>
        /// For optimistic concurrency control. See if-match.
        /// <para>Required: no</para>
        /// </summary>
        public string Etag { get; set; }

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

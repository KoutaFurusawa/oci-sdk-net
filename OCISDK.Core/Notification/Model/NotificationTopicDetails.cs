using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Notification.Model
{
    /// <summary>
    /// The properties that define a topic. For general information about topics, see Notifications Overview.
    /// https://docs.cloud.oracle.com/iaas/Content/Notification/Concepts/notificationoverview.htm
    /// </summary>
    public class NotificationTopicDetails
    {
        /// <summary>
        /// The name of the topic.
        /// <para>Required: yes</para>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The OCID of the topic.
        /// <para>Required: yes</para>
        /// </summary>
        public string TopicId { get; set; }

        /// <summary>
        /// The OCID of the compartment for the topic.
        /// <para>Required: yes</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// The lifecycle state of the topic.
        /// <para>Required: yes</para>
        /// </summary>
        public string LifecycleState { get; set; }

        /// <summary>
        /// The description of the topic.
        /// <para>Required: no</para>
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The time the topic was created.
        /// <para>Required: yes</para>
        /// </summary>
        public string TimeCreated { get; set; }

        /// <summary>
        /// For optimistic concurrency control. See if-match.
        /// <para>Required: no</para>
        /// </summary>
        public string Etag { get; set; }

        /// <summary>
        /// The endpoint for managing subscriptions or publishing messages to the topic.
        /// <para>Required: yes</para>
        /// </summary>
        public string ApiEndpoint { get; set; }

        /// <summary>
        /// Simple key-value pair that is applied without any predefined name, type or scope. Exists for cross-compatibility only. 
        /// <para>Required: no</para>
        /// </summary>
        public IDictionary<string, string> FreeformTags { get; set; }

        /// <summary>
        /// Usage of predefined tag keys. These predefined keys are scoped to namespaces. 
        /// <para>Required: no</para>
        /// </summary>
        public IDictionary<string, IDictionary<string, string>> DefinedTags { get; set; }

    }
}

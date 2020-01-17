using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Notification.Model
{
    /// <summary>
    /// The response to a PublishMessage call.
    /// </summary>
    public class PublishResult
    {
        /// <summary>
        /// The UUID of the message.
        /// <para>Required: yes</para>
        /// </summary>
        public string MessageId { get; set; }

        /// <summary>
        /// The time that the service received the message.
        /// <para>Required: no</para>
        /// </summary>
        public string TimeStamp { get; set; }
    }
}

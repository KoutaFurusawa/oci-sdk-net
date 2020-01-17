using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Notification.Model
{
    /// <summary>
    /// The content of the message to be published.
    /// </summary>
    public class MessageDetails
    {
        /// <summary>
        /// The title of the message to be published. Avoid entering confidential information.
        /// <para>Required: no</para>
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The body of the message to be published. For messageType of JSON, a default key-value pair is required. 
        /// </summary>
        /// <example>{"default": "Alarm breached", "Email": "Alarm breached: url"}. Avoid entering confidential information.</example>
        public string Body { get; set; }
    }
}

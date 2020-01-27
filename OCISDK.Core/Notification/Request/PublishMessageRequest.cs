using OCISDK.Core.Common;
using OCISDK.Core.Notification.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Notification.Request
{
    /// <summary>
    /// PublishMessage request
    /// </summary>
    public class PublishMessageRequest
    {
        PublishMessageRequest()
        {
            MessageType = MessageTypeParam.JSON;
        }

        /// <summary>
        /// The OCID of the topic.
        /// <para>Required: yes</para>
        /// </summary>
        public string TopicId { get; set; }

        /// <summary>
        /// Unique identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.
        /// <para>Required: no</para>
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// Type of message body in the request.
        /// <para>Required: no</para>
        /// <para>Default: JSON</para>
        /// </summary>
        public MessageTypeParam MessageType { get; set; }

        /// <summary>
        /// SortBy ExpandableEnum
        /// </summary>
        public class MessageTypeParam : ExpandableEnum<MessageTypeParam>
        {
            /// <summary>
            /// SortBy ExpandableEnum
            /// </summary>
            /// <param name="value"></param>
            public MessageTypeParam(string value) : base(value) { }

            /// <summary>
            /// parase
            /// </summary>
            /// <param name="value"></param>
            public static implicit operator MessageTypeParam(string value)
            {
                return Parse(value);
            }

            /// <summary>
            /// JSON
            /// </summary>
            public static readonly MessageTypeParam JSON = new MessageTypeParam("JSON");

            /// <summary>
            /// RAW_TEXT
            /// </summary>
            public static readonly MessageTypeParam RAW_TEXT = new MessageTypeParam("RAW_TEXT");
        }

        /// <summary>
        /// The request body must contain a single MessageDetails resource.
        /// </summary>
        public MessageDetails MessageDetails { get; set; }
    }
}

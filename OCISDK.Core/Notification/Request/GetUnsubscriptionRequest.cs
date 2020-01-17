using OCISDK.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Notification.Request
{
    /// <summary>
    /// GetUnsubscription request
    /// </summary>
    public class GetUnsubscriptionRequest
    {
        /// <summary>
        /// Customer part of the request identifier token. If you need to contact Oracle about a particular request, please provide the complete request ID.
        /// <para>Required: no</para>
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// The OCID of the subscription to unsubscribe from.
        /// <para>Required: yes</para>
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The subscription confirmation token.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 256</para>
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// The protocol used for the subscription.
        /// <para>Required: yes</para>
        /// </summary>
        public ProtocolParam Protocol { get; set; }

        /// <summary>
        /// SortBy ExpandableEnum
        /// </summary>
        public class ProtocolParam : ExpandableEnum<ProtocolParam>
        {
            /// <summary>
            /// SortBy ExpandableEnum
            /// </summary>
            /// <param name="value"></param>
            public ProtocolParam(string value) : base(value) { }

            /// <summary>
            /// parase
            /// </summary>
            /// <param name="value"></param>
            public static implicit operator ProtocolParam(string value)
            {
                return Parse(value);
            }

            /// <summary>
            /// CUSTOM_HTTPS
            /// </summary>
            public static readonly ProtocolParam CUSTOM_HTTPS = new ProtocolParam("CUSTOM_HTTPS");

            /// <summary>
            /// EMAIL
            /// </summary>
            public static readonly ProtocolParam EMAIL = new ProtocolParam("EMAIL");

            /// <summary>
            /// HTTPS
            /// </summary>
            public static readonly ProtocolParam HTTPS = new ProtocolParam("HTTPS");

            /// <summary>
            /// PAGERDUTY
            /// </summary>
            public static readonly ProtocolParam PAGERDUTY = new ProtocolParam("PAGERDUTY");

            /// <summary>
            /// SLACK
            /// </summary>
            public static readonly ProtocolParam SLACK = new ProtocolParam("SLACK");
        }

        /// <summary>
        /// option query
        /// </summary>
        /// <returns></returns>
        public string GetOptionQuery()
        {
            var sb = new StringBuilder();

            sb.Append($"token={this.Token}");

            if (!(Protocol is null))
            {
                sb.Append($"&protocol={Protocol.Value}");
            }

            return sb.ToString();
        }
    }
}

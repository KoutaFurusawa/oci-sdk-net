using OCISDK.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Notification.Model
{
    /// <summary>
    /// The configuration details for creating the subscription.
    /// </summary>
    public class CreateSubscriptionDetails
    {
        /// <summary>
        /// The OCID of the topic for the subscription.
        /// <para>Required: yes</para>
        /// </summary>
        public string TopicId { get; set; }

        /// <summary>
        /// The OCID of the compartment for the subscription.
        /// <para>Required: yes</para>
        /// </summary>
        public string CompartmentId { get; set; }

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
        /// A locator that corresponds to the subscription protocol. For example, an email address for a subscription that uses the 
        /// EMAIL protocol, or a URL for a subscription that uses an HTTP-based protocol.
        /// <para>Required: yes</para>
        /// </summary>
        public string Endpoint { get; set; }

        /// <summary>
        /// Metadata for the subscription.
        /// <para>Required: no</para>
        /// </summary>
        public string Metadata { get; set; }

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

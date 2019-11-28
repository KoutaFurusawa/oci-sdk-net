using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Waas.Model
{
    /// <summary>
    /// A detailed description of your web application's origin host server. An origin must be defined to set up WAF rules.
    /// </summary>
    public class OriginDetails
    {
        /// <summary>
        /// The URI of the origin. Does not support paths. Port numbers should be specified in the httpPort and httpsPort fields.
        /// <para>Required: yes</para>
        /// </summary>
        public string Uri { get; set; }

        /// <summary>
        /// The HTTP port on the origin that the web application listens on. If unspecified, defaults to 80.
        /// <para>Required: no</para>
        /// </summary>
        public int? HttpPort { get; set; }

        /// <summary>
        /// The HTTPS port on the origin that the web application listens on. If unspecified, defaults to 443.
        /// </summary>
        public int HttpsPort { get; set; }

        /// <summary>
        /// A list of HTTP headers to forward to your origin.
        /// <para>Required: no</para>
        /// </summary>
        public List<HeaderDetails> CustomHeaders { get; set; }
    }
}

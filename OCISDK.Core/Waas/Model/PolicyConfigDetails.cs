using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Waas.Model
{
    /// <summary>
    /// The configuration details for the WAAS policy.
    /// </summary>
    public class PolicyConfigDetails
    {
        /// <summary>
        /// The OCID of the SSL certificate to use if HTTPS is supported.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string CertificateId { get; set; }

        /// <summary>
        /// Enable or disable HTTPS support. If true, a certificateId is required. If unspecified, defaults to false.
        /// <para>Required: no</para>
        /// </summary>
        public bool IsHttpsEnabled { get; set; }

        /// <summary>
        /// Force HTTP to HTTPS redirection. If unspecified, defaults to false.
        /// <para>Required: no</para>
        /// </summary>
        public bool IsHttpsForced { get; set; }

        /// <summary>
        /// A list of allowed TLS protocols. Only applicable when HTTPS support is enabled. 
        /// The TLS protocol is negotiated while the request is connecting and the most recent protocol supported by both the edge node and client browser will be selected. 
        /// If no such version exists, the connection will be aborted.
        /// <para>Required: no</para>
        /// </summary>
        public List<string> TlsProtocols { get; set; }

        /// <summary>
        /// Enable or disable GZIP compression of origin responses. 
        /// If enabled, the header Accept-Encoding: gzip is sent to origin, otherwise, the empty Accept-Encoding: header is used.
        /// <para>Required: no</para>
        /// <para>Default: true</para>
        /// </summary>
        public bool IsOriginCompressionEnabled { get; set; }

        /// <summary>
        /// Enabling isBehindCdn allows for the collection of IP addresses from client requests if the WAF is connected to a CDN.
        /// <para>Required: no</para>
        /// <para>Default: false</para>
        /// </summary>
        public bool IsBehindCdn { get; set; }

        /// <summary>
        /// Specifies an HTTP header name which is treated as the connecting client's IP address. Applicable only if isBehindCdn is enabled.
        /// 
        /// The edge node reads this header and its value and sets the client IP address as specified. 
        /// It does not create the header if the header is not present in the request. If the header is not present, the connecting IP address will be used as the client's true IP address. 
        /// It uses the last IP address in the header's value as the true IP address.
        /// <para>Required: no</para>
        /// <para>Default: null</para>
        /// </summary>
        public string ClientAddressHeader { get; set; }

        /// <summary>
        /// Enable or disable automatic content caching based on the response cache-control header. 
        /// This feature enables the origin to act as a proxy cache. Caching is usually defined using cache-control header. 
        /// For example cache-control: max-age=120 means that the returned resource is valid for 120 seconds. Caching rules will overwrite this setting.
        /// <para>Required: no</para>
        /// <para>Default: false</para>
        /// </summary>
        public bool IsCacheControlRespected { get; set; }

        /// <summary>
        /// Enable or disable buffering of responses from the origin. Buffering improves overall stability in case of network issues, but slightly increases Time To First Byte.
        /// <para>Required: no</para>
        /// <para>Default: false</para>
        /// </summary>
        public bool IsResponseBufferingEnabled { get; set; }

        /// <summary>
        /// The set cipher group for the configured TLS protocol. This sets the configuration for the TLS connections between clients and edge nodes only.
        /// <para>Required: no</para>
        /// <para>Default: DEFAULT</para>
        /// </summary>
        public string CipherGroup { get; set; }
    }
}

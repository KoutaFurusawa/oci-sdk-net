using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Waas.Model
{
    /// <summary>
    /// The IP rate limiting configuration. Defines the amount of allowed requests from a unique IP address and the resulting block response code when that threshold is exceeded.
    /// </summary>
    public class AddressRateLimiting
    {
        /// <summary>
        /// Enables or disables the address rate limiting Web Application Firewall feature.
        /// <para>Required: yes</para>
        /// </summary>
        public bool IsEnabled { get; set; }

        /// <summary>
        /// The number of allowed requests per second from one IP address. If unspecified, defaults to 1.
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 9999</para>
        /// </summary>
        public int? AllowedRatePerAddress { get; set; }

        /// <summary>
        /// The maximum number of requests allowed to be queued before subsequent requests are dropped. If unspecified, defaults to 10.
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 9999</para>
        /// </summary>
        public int? MaxDelayedCountPerAddress { get; set; }

        /// <summary>
        /// The response status code returned when a request is blocked. If unspecified, defaults to 503.
        /// <para>Required: no</para>
        /// <para>Minimum: 100, Maximum: 999</para>
        /// </summary>
        public int? BlockResponseCode { get; set; }
    }
}

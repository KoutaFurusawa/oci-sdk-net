using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace OCISDK.Core.Waas.Model
{
    /// <summary>
    /// The device fingerprint challenge settings. 
    /// The device fingerprint challenge generates hashed signatures of both virtual and real browsers to identify and block malicious bots.
    /// </summary>
    public class DeviceFingerprintChallenge
    {
        /// <summary>
        /// Enables or disables the device fingerprint challenge Web Application Firewall feature.
        /// <para>Required: yes</para>
        /// </summary>
        public bool IsEnabled { get; set; }

        /// <summary>
        /// The action to take on requests from detected bots. If unspecified, defaults to DETECT.
        /// <para>Required: no</para>
        /// <para>Allowed values are: DETECT, BLOCK</para>
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        /// The number of failed requests allowed before taking action. If unspecified, defaults to 10.
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 999999</para>
        /// </summary>
        public int? FailureThreshold { get; set; }

        /// <summary>
        /// The number of seconds between challenges for the same IP address. If unspecified, defaults to 60.
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 432000</para>
        /// </summary>
        public int? ActionExpirationInSeconds { get; set; }

        /// <summary>
        /// The number of seconds before the failure threshold resets. If unspecified, defaults to 60.
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 432000</para>
        /// </summary>
        public int? FailureThresholdExpirationInSeconds { get; set; }

        /// <summary>
        /// The maximum number of IP addresses permitted with the same device fingerprint. If unspecified, defaults to 20.
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 9999</para>
        /// </summary>
        public int? MaxAddressCount { get; set; }

        /// <summary>
        /// The number of seconds before the maximum addresses count resets. If unspecified, defaults to 60.
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 432000</para>
        /// </summary>
        public int? MaxAddressCountExpirationInSeconds { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public BlockChallengeSettings ChallengeSettings { get; set; }
    }
}
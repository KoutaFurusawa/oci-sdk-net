using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OCISDK.Core.LoadBalancer.Model
{
    /// <summary>
    /// A listener's SSL handling configuration.
    /// To use SSL, a listener must be associated with a certificate bundle.
    /// 
    /// Warning: Oracle recommends that you avoid using any confidential information when you supply string values using the API.
    /// </summary>
    public class SSLConfiguration
    {
        /// <summary>
        /// A friendly name for the certificate bundle. It must be unique and it cannot be changed. 
        /// Valid certificate bundle names include only alphanumeric characters, dashes, and underscores. 
        /// Certificate bundle names cannot contain spaces. Avoid entering confidential information.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string CertificateName { get; set; }

        /// <summary>
        /// Whether the load balancer listener should verify peer certificates.
        /// <para>Required: yes</para>
        /// </summary>
        public bool VerifyPeerCertificate { get; set; }

        /// <summary>
        /// The maximum depth for peer certificate chain verification.
        /// <para>Required: yes</para>
        /// </summary>
        public int VerifyDepth { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OCISDK.Core.LoadBalancer.Model
{
    /// <summary>
    /// The configuration details of a certificate bundle. For more information on SSL certficate configuration, see Managing SSL Certificates.
    /// 
    /// Warning: Oracle recommends that you avoid using any confidential information when you supply string values using the API.
    /// </summary>
    public class CertificateDetails
    {
        /// <summary>
        /// A friendly name for the certificate bundle. It must be unique and it cannot be changed. Valid certificate bundle names 
        /// include only alphanumeric characters, dashes, and underscores. 
        /// Certificate bundle names cannot contain spaces. Avoid entering confidential information.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string CertificateName { get; set; }

        /// <summary>
        /// The public certificate, in PEM format, that you received from your SSL certificate provider.
        /// <para>Required: yes</para>
        /// </summary>
        public string PublicCertificate { get; set; }

        /// <summary>
        /// The Certificate Authority certificate, or any interim certificate, that you received from your SSL certificate provider.
        /// <para>Required: yes</para>
        /// </summary>
        public string CaCertificate { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.LoadBalancer.Model
{
    /// <summary>
    /// The configuration details for adding a certificate bundle to a listener. For more information on SSL certficate configuration, see Managing SSL Certificates.
    /// 
    /// Warning: Oracle recommends that you avoid using any confidential information when you supply string values using the API.
    /// </summary>
    public class CreateCertificateDetails
    {
        /// <summary>
        /// A passphrase for encrypted private keys. This is needed only if you created your certificate with a passphrase.
        /// <para>Required: no</para>
        /// </summary>
        public string Passphrase { get; set; }

        /// <summary>
        /// The SSL private key for your certificate, in PEM format.
        /// <para>Required: no</para>
        /// </summary>
        public string PrivateKey { get; set; }

        /// <summary>
        /// The public certificate, in PEM format, that you received from your SSL certificate provider.
        /// <para>Required: no</para>
        /// </summary>
        public string PublicCertificate { get; set; }

        /// <summary>
        /// The Certificate Authority certificate, or any interim certificate, that you received from your SSL certificate provider.
        /// <para>Required: no</para>
        /// </summary>
        public string CaCertificate { get; set; }

        /// <summary>
        /// A friendly name for the certificate bundle. It must be unique and it cannot be changed. Valid certificate bundle names 
        /// include only alphanumeric characters, dashes, and underscores. 
        /// Certificate bundle names cannot contain spaces. Avoid entering confidential information.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string CertificateName { get; set; }
    }
}

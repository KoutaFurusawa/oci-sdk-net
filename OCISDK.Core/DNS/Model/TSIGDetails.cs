using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.DNS.Model
{
    /// <summary>
    /// A TSIG key.
    /// </summary>
    public class TSIGDetails
    {
        /// <summary>
        /// A domain name identifying the key for a given pair of hosts.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 254</para>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A base64 string encoding the binary shared secret.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1</para>
        /// </summary>
        public string Secret { get; set; }

        /// <summary>
        /// TSIG Algorithms are encoded as domain names, but most consist of only one non-empty label, which is not required to be explicitly absolute. 
        /// Applicable algorithms include: hmac-sha1, hmac-sha224, hmac-sha256, hmac-sha512. For more information on these algorithms, see RFC 4635.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 254</para>
        /// </summary>
        public string Algorithm { get; set; }
    }
}

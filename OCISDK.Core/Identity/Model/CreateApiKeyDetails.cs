using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Identity.Model
{
    /// <summary>
    /// CreateApiKeyDetails
    /// </summary>
    public class CreateApiKeyDetails
    {
        /// <summary>
        /// The public key. Must be an RSA key in PEM format.
        /// 
        /// Example: "-----BEGIN PUBLIC KEY-----\cmdnMIIBIjANBgkqhkiG9w0BAQEFA...AOCAQ8AMIIBCgKCAQEA7hglbuGudI....."
        /// <para>Required: yes</para>
        /// </summary>
        /// <example>"-----BEGIN PUBLIC KEY-----\cmdnMIIBIjANBgkqhkiG9w0BAQEFA...AOCAQ8AMIIBCgKCAQEA7hglbuGudI....."</example>
        public string Key { get; set; }
    }
}

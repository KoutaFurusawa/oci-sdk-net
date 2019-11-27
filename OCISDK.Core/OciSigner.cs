using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;

//
//  Nuget Package Manager Console: Install-Package BouncyCastle
//  Nuget CLI: nuget install BouncyCastle
//
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;

namespace OCISDK.Core
{
    /// <summary>
    /// OciSigner
    /// </summary>
    public class OciSigner : IOciSigner
    {
        private static readonly IDictionary<string, List<string>> RequiredHeaders = new Dictionary<string, List<string>>
        {
            { "GET", new List<string>{"date", "(request-target)", "host" }},
            { "HEAD", new List<string>{"date", "(request-target)", "host" }},
            { "DELETE", new List<string>{"date", "(request-target)", "host" }},
            { "PUT", new List<string>{"date", "(request-target)", "host", "content-length", "content-type", "x-content-sha256" }},
            { "POST", new List<string>{"date", "(request-target)", "host", "content-length", "content-type", "x-content-sha256" }},
            { "PUT-LESS", new List<string>{"date", "(request-target)", "host" }}
        };

        private readonly string KeyId;
        private readonly ISigner SignerService;
        
        /// <summary>
        /// Adds the necessary authorization header for signed requests to Oracle Cloud Infrastructure services.
        /// Documentation for request signatures can be found here: https://docs.us-phoenix-1.oraclecloud.com/Content/API/Concepts/signingrequests.htm
        /// </summary>
        /// <param name="tenancyId">The tenancy OCID</param>
        /// <param name="userId">The user OCID</param>
        /// <param name="fingerprint">The fingerprint corresponding to the provided key</param>
        /// <param name="fileStream">Stream to a PEM file containing a private key</param>
        /// <param name="privateKeyPassphrase">An optional passphrase for the private key</param>
        public OciSigner(string tenancyId, string userId, string fingerprint, StreamReader fileStream, string privateKeyPassphrase = "")
        {
            // This is the keyId for a key uploaded through the console
            KeyId = $"{tenancyId}/{userId}/{fingerprint}";

            AsymmetricCipherKeyPair keyPair;
            try
            {
                keyPair = (AsymmetricCipherKeyPair)new PemReader(fileStream, new Password(privateKeyPassphrase.ToCharArray())).ReadObject();
            }
            catch (InvalidCipherTextException)
            {
                throw new ArgumentException("Incorrect passphrase for private key");
            }

            RsaKeyParameters privateKeyParams = (RsaKeyParameters)keyPair.Private;
            SignerService = SignerUtilities.GetSigner("SHA-256withRSA");
            SignerService.Init(true, privateKeyParams);
        }

        /// <summary>
        /// SignRequest
        /// </summary>
        /// <param name="request"></param>
        /// <param name="useLessHeadersForPut"></param>
        public void SignRequest(HttpWebRequest request, bool useLessHeadersForPut = false)
        {
            if (request == null) { throw new ArgumentNullException(nameof(request)); }

            // By default, request.Date is DateTime.MinValue, so override to DateTime.UtcNow, but preserve the value if caller has already set the Date
            if (request.Date == DateTime.MinValue) { request.Date = DateTime.UtcNow; }

            var requestMethodUpper = request.Method.ToUpperInvariant();
            var requestMethodKey = useLessHeadersForPut ? requestMethodUpper + "-LESS" : requestMethodUpper;

            List<string> headers;
            if (!RequiredHeaders.TryGetValue(requestMethodKey, out headers))
            {
                throw new ArgumentException($"Don't know how to sign method: {request.Method}");
            }

            // for PUT and POST, if the body is empty we still must explicitly set content-length = 0 and x-content-sha256
            // the caller may already do this, but we shouldn't require it since we can determine it here
            if (request.ContentLength <= 0 && (string.Equals(requestMethodUpper, "POST") || string.Equals(requestMethodUpper, "PUT")))
            {
                request.ContentLength = 0;
                request.Headers["x-content-sha256"] = Convert.ToBase64String(SHA256.Create().ComputeHash(new byte[0]));
            }

            var signingStringBuilder = new StringBuilder();
            var newline = string.Empty;
            foreach (var headerName in headers)
            {
                string value = null;
                switch (headerName)
                {
                    case "(request-target)":
                        value = BuildRequestTarget(request);
                        break;
                    case "host":
                        value = request.Host;
                        break;
                    case "content-length":
                        value = request.ContentLength.ToString();
                        break;
                    default:
                        value = request.Headers[headerName];
                        break;
                }

                if (value == null) { throw new ArgumentException($"Request did not contain required header: {headerName}"); }
                signingStringBuilder.Append(newline).Append($"{headerName}: {value}");
                newline = "\n";
            }

            // generate signature using the private key
            var bytes = Encoding.UTF8.GetBytes(signingStringBuilder.ToString());
            SignerService.BlockUpdate(bytes, 0, bytes.Length);
            var signature = Convert.ToBase64String(SignerService.GenerateSignature());
            var authorization = $@"Signature version=""1"",headers=""{string.Join(" ", headers)}"",keyId=""{KeyId}"",algorithm=""rsa-sha256"",signature=""{signature}""";
            request.Headers["authorization"] = authorization;
        }

        private static string BuildRequestTarget(HttpWebRequest request)
        {
            // ex. get /20160918/instances
            return $"{request.Method.ToLowerInvariant()} {request.RequestUri.PathAndQuery}";
        }
    }

    /// <summary>
    /// Implements Bouncy Castle's IPasswordFinder interface to allow opening password protected private keys.
    /// </summary>
    public class Password : IPasswordFinder
    {
        private readonly char[] password;

        /// <summary>
        /// key password
        /// </summary>
        /// <param name="password"></param>
        public Password(char[] password) { this.password = password; }

        /// <summary>
        /// password getter
        /// </summary>
        /// <returns></returns>
        public char[] GetPassword() { return (char[])password.Clone(); }
    }
}
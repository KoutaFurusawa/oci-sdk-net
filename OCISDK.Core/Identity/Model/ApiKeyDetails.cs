using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Identity.Model
{
    /// <summary>
    /// A PEM-format RSA credential for securing requests to the Oracle Cloud Infrastructure REST API. 
    /// Also known as an API signing key. Specifically, this is the public key from the key pair. 
    /// The private key remains with the user calling the API. For information about generating a key pair in 
    /// the required PEM format, see Required Keys and OCIDs.
    /// 
    /// Important: This is not the SSH key for accessing compute instances.
    /// 
    /// Each user can have a maximum of three API signing keys.
    /// 
    /// For more information about user credentials, see User Credentials.
    /// </summary>
    public class ApiKeyDetails
    {
        /// <summary>
        /// The key's fingerprint (e.g., 12:34:56:78:90:ab:cd:ef:12:34:56:78:90:ab:cd:ef).
        /// <para>Required: no</para>
        /// </summary>
        public string Fingerprint { get; set; }

        /// <summary>
        /// The detailed status of INACTIVE lifecycleState.
        /// <para>Required: no</para>
        /// </summary>
        public int? InactiveStatus { get; set; }

        /// <summary>
        /// An Oracle-assigned identifier for the key, in this format: TENANCY_OCID/USER_OCID/KEY_FINGERPRINT.
        /// <para>Required: no</para>
        /// </summary>
        public string KeyId { get; set; }

        /// <summary>
        /// The key's value.
        /// <para>Required: no</para>
        /// </summary>
        public string KeyValue { get; set; }

        /// <summary>
        /// The API key's current state. After creating an ApiKey object, make sure its lifecycleState changes from CREATING to ACTIVE before using it.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 64</para>
        /// </summary>
        public string LifecycleState { get; set; }

        /// <summary>
        /// Date and time the ApiKey object was created, in the format defined by RFC3339.
        /// <para>Required: no</para>
        /// </summary>
        public string TimeCreated { get; set; }

        /// <summary>
        /// The OCID of the user the key belongs to.
        /// <para>Required: no</para>
        /// </summary>
        public string UserId { get; set; }
    }
}

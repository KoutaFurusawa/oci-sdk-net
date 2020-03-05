using System.Collections.Generic;

namespace OCISDK.Core.Core.Model.Compute
{
    /// <summary>
    /// Credentials Reference
    /// The credentials for a particular instance. Set to default values on compatable
    /// operating systems which require a password to login, such as Windows.
    ///
    /// Warning: Oracle recommends that you avoid using any confidential information when you supply string values using the API.
    /// 
    /// author: calum bird
    /// </summary>
    public class InstanceCredentialsDetails
    {
        /// <summary>
        /// A plain-text password
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// A username
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string Username { get; set; }
    }
}

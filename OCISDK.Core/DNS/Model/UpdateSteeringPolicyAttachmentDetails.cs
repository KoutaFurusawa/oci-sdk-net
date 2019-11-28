using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.DNS.Model
{
    /// <summary>
    /// The body for updating a steering policy attachment.
    /// 
    /// Warning: Oracle recommends that you avoid using any confidential information when you supply string values using the API.
    /// </summary>
    public class UpdateSteeringPolicyAttachmentDetails
    {
        /// <summary>
        /// A user-friendly name for the steering policy attachment. 
        /// Does not have to be unique and can be changed. Avoid entering confidential information.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string DisplayName { get; set; }
    }
}

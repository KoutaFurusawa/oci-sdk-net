using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.DNS.Model
{
    /// <summary>
    /// ChangeSteeringPolicyCompartmentDetails Reference
    /// </summary>
    public class ChangeSteeringPolicyCompartmentDetails
    {
        /// <summary>
        /// The OCID of the compartment into which the steering policy should be moved.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string CompartmentId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Model.VirtualNetwork
{
    /// <summary>
    /// A public IP prefix and its details. With a public virtual circuit, the customer specifies the customer-owned 
    /// public IP prefixes to advertise across the connection. For more information, see FastConnect Overview.
    /// </summary>
    public class VirtualCircuitPublicPrefix
    {
        /// <summary>
        /// Publix IP prefix (CIDR) that the customer specified.
        /// <para>Required: yes</para>
        /// </summary>
        public string CidrBlock { get; set; }

        /// <summary>
        /// Oracle must verify that the customer owns the public IP prefix before traffic for that prefix 
        /// can flow across the virtual circuit. Verification can take a few business days. IN_PROGRESS 
        /// means Oracle is verifying the prefix. COMPLETED means verification succeeded. FAILED means 
        /// verification failed and traffic for this prefix will not flow across the connection.
        /// <para>Required: yes</para>
        /// </summary>
        public string VerificationState { get; set; }
    }
}

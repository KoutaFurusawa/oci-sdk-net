using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.SupportManagement.Model
{
    /// <summary>
    /// Details about the customer's tenancy.
    /// </summary>
    public class TenancyInformationDetails
    {
        /// <summary>
        /// The Customer Support Identifier number associated with the tenancy.
        /// <para>Required: yes</para>
        /// <para>Min Length: 0, Max Length: 20</para>
        /// </summary>
        public string CustomerSupportKey { get; set; }

        /// <summary>
        /// The OCID of the tenancy.
        /// <para>Required: yes</para>
        /// <para>Min Length: 0, Max Length: 80</para>
        /// </summary>
        public string TenancyId { get; set; }
    }
}

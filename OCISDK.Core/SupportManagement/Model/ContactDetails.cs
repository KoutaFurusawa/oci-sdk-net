using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.SupportManagement.Model
{
    /// <summary>
    /// Contact details for the customer.
    /// </summary>
    public class ContactDetails
    {
        /// <summary>
        /// The email of the contact person.
        /// <para>Required: no</para>
        /// </summary>
        public string ContactEmail { get; set; }

        /// <summary>
        /// The name of the contact person.
        /// <para>Required: no</para>
        /// </summary>
        public string ContactName { get; set; }

        /// <summary>
        /// The phone number of the contact person.
        /// <para>Required: no</para>
        /// </summary>
        public string ContactPhone { get; set; }

        /// <summary>
        /// The type of contact, such as primary or alternate.
        /// <para>Required: no</para>
        /// </summary>
        public string ContactType { get; set; }
    }
}

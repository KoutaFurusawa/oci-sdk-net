using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.SupportManagement.Model
{
    /// <summary>
    /// The list of contacts.
    /// <para>Required: yes</para>
    /// </summary>
    public class ContactListDetails
    {
        /// <summary>
        /// The list of contacts.
        /// <para>Required: yes</para>
        /// </summary>
        public List<ContactDetails> ContactList { get; set; }
    }
}

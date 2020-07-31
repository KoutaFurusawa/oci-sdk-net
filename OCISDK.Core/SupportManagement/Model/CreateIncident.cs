using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.SupportManagement.Model
{
    /// <summary>
    /// Details about the creation of the support ticket.
    /// </summary>
    public class CreateIncident
    {
        /// <summary>
        /// The OCID of the tenancy.
        /// <para>Required: yes</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// The list of contacts.
        /// <para>Required: no</para>
        /// </summary>
        public List<ContactDetails> Contacts { get; set; }

        /// <summary>
        /// The Customer Support Identifier number for the support account.
        /// <para>Required: no</para>
        /// </summary>
        public string Csi { get; set; }

        /// <summary>
        /// The kind of support ticket, such as a technical issue request.
        /// <para>Required: yes</para>
        /// </summary>
        public string ProblemType { get; set; }

        /// <summary>
        /// The incident referrer. This value is often the URL that the customer used when creating the support ticket.
        /// <para>Required: no</para>
        /// </summary>
        public string Referrer { get; set; }

        /// <summary>
        /// <para>Required: yes</para>
        /// </summary>
        public CreateTicketDetails Ticket { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.SupportManagement.Model
{
    /// <summary>
    /// Details about the support ticket.
    /// </summary>
    public class IncidentSummary
    {
        /// <summary>
        /// The OCID of the tenacy.
        /// <para>Required: no</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public ContactListDetails ContactList { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public IncidentTypeDetails IncidentType { get; set; }

        /// <summary>
        /// Unique identifier for the support ticket.
        /// <para>Required: yes</para>
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// The kind of support ticket, such as a technical support request.
        /// <para>Required: no</para>
        /// </summary>
        public string ProblemType { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public TenancyInformationDetails TenancyInformation { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public TicketDetails Ticket { get; set; }
    }
}

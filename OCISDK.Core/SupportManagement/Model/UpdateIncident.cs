using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.SupportManagement.Model
{
    /// <summary>
    /// Details about the support ticket being updated.
    /// </summary>
    public class UpdateIncident
    {
        /// <summary>
        /// Required: yes
        /// </summary>
        public UpdateTicketDetails Ticket { get; set; }
    }

    /// <summary>
    /// Details about the ticket updated.
    /// </summary>
    public class UpdateTicketDetails
    {
        /// <summary>
        /// The list of resources.
        /// <para>Required: yes</para>
        /// </summary>
        public List<UpdateResourceDetails> Resource { get; set; }
    }

    /// <summary>
    /// no page
    /// </summary>
    public class UpdateResourceDetails
    { }
}

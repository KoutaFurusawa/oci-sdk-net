using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.SupportManagement.Model
{
    /// <summary>
    /// Details for creating the support ticket.
    /// </summary>
    public class CreateTicketDetails
    {
        /// <summary>
        /// The description of the support ticket.
        /// <para>Required: yes</para>
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The list of resources.
        /// <para>Required: no</para>
        /// </summary>
        public List<CreateResourceDetails> ResourceList { get; set; }

        /// <summary>
        /// The severity of the support ticket.
        /// <para>Required: yes</para>
        /// </summary>
        public string Severity { get; set; }

        /// <summary>
        /// The title of the support ticket.
        /// <para>Required: yes</para>
        /// </summary>
        public string Title { get; set; }
    }
}

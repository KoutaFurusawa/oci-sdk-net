using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.SupportManagement.Model
{
    /// <summary>
    /// Details about the ticket created.
    /// </summary>
    public class TicketDetails
    {
        /// <summary>
        /// The description of the issue addressed in the ticket.
        /// <para>Required: yes</para>
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Additional information about the current lifecycleState.
        /// <para>Required: no</para>
        /// </summary>
        public string LifecycleDetails { get; set; }

        /// <summary>
        /// The current state of the ticket.
        /// <para>Required: no</para>
        /// </summary>
        public string LifecycleState { get; set; }

        /// <summary>
        /// The list of resources associated with the ticket.
        /// <para>Required: no</para>
        /// </summary>
        public List<ResourceDetails> ResourceList { get; set; }

        /// <summary>
        /// The severity assigned to the ticket.
        /// <para>Required: yes</para>
        /// </summary>
        public string Severity { get; set; }

        /// <summary>
        /// Unique identifier for the ticket.
        /// <para>Required: no</para>
        /// </summary>
        public string TicketNumber { get; set; }

        /// <summary>
        /// The time when the ticket was created, in milliseconds since epoch time.
        /// <para>Required: no</para>
        /// </summary>
        public int? TimeCreated { get; set; }

        /// <summary>
        /// The time when the ticket was updated, in milliseconds since epoch time.
        /// <para>Required: no</para>
        /// </summary>
        public int? TimeUpdated { get; set; }

        /// <summary>
        /// The title of the ticket.
        /// <para>Required: yes</para>
        /// </summary>
        public string Title { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.SupportManagement.Model
{
    /// <summary>
    /// Details about the status of the support ticket.
    /// </summary>
    public class StatusDetails
    {
        /// <summary>
        /// The code unique to this ticket status.
        /// <para>Required: yes</para>
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// The status message for this ticket.
        /// <para>Required: yes</para>
        /// </summary>
        public string Message { get; set; }
    }
}

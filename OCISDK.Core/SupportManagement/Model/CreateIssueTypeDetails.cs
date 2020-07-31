using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.SupportManagement.Model
{
    /// <summary>
    /// Details for creating the issue type of the support ticket.
    /// </summary>
    public class CreateIssueTypeDetails
    {
        /// <summary>
        /// Unique identifier for the issue type.
        /// <para>Required: no</para>
        /// </summary>
        public string IssueTypeKey { get; set; }
    }
}

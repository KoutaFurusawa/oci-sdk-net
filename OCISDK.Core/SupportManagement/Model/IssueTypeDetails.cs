using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.SupportManagement.Model
{
    /// <summary>
    /// Details about the issue type associated with the support ticket.
    /// </summary>
    public class IssueTypeDetails
    {
        /// <summary>
        /// Unique identifier for the issue type.
        /// <para>Required: no</para>
        /// </summary>
        public string IssueTypeKey { get; set; }

        /// <summary>
        /// The label for the issue type. For example, Instance Performance.
        /// <para>Required: no</para>
        /// </summary>
        public string Label { get; set; }
    }
}

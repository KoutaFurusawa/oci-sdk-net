using OCISDK.Core.Budgets.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Budgets.Response
{
    /// <summary>
    /// UpdateAlertRule response
    /// </summary>
    public class UpdateAlertRuleResponse
    {
        /// <summary>
        /// Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// For optimistic concurrency control. See if-match.
        /// </summary>
        public string Etag { get; set; }

        /// <summary>
        /// The response body will contain a single AlertRule resource.
        /// </summary>
        public AlertRule AlertRule { get; set; }
    }
}

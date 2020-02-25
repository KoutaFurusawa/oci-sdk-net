using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Budgets.Request
{
    /// <summary>
    /// GetAlertRule request
    /// </summary>
    public class GetAlertRuleRequest
    {
        /// <summary>
        /// The unique Budget OCID
        /// <para>Required: yes</para>
        /// </summary>
        public string BudgetId { get; set; }

        /// <summary>
        /// The unique Alert Rule OCID
        /// <para>Required: yes</para>
        /// </summary>
        public string AlertRuleId { get; set; }

        /// <summary>
        /// The client request ID for tracing.
        /// <para>Required: no</para>
        /// </summary>
        public string OpcRequestId { get; set; }
    }
}

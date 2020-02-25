using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Budgets.Request
{
    /// <summary>
    /// DeleteAlertRule request
    /// </summary>
    public class DeleteAlertRuleRequest
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
        /// For optimistic concurrency control. In the PUT or DELETE call for a resource, set 
        /// the if-match parameter to the value of the etag from a previous GET or POST 
        /// response for that resource. The resource will be updated or deleted only if the 
        /// etag you provide matches the resource's current etag value.
        /// <para>Required: no</para>
        /// </summary>
        public string IfMatch { get; set; }

        /// <summary>
        /// The client request ID for tracing.
        /// <para>Required: no</para>
        /// </summary>
        public string OpcRequestId { get; set; }

    }
}

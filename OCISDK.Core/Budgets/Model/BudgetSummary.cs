using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Budgets.Model
{
    /// <summary>
    /// A budget.
    /// </summary>
    public class BudgetSummary
    {
        /// <summary>
        /// The OCID of the budget
        /// <para>Required: yes</para>
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The OCID of the compartment
        /// <para>Required: yes</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// The OCID of the compartment on which budget is applied
        /// <para>Required: yes</para>
        /// </summary>
        public string TargetCompartmentId { get; set; }

        /// <summary>
        /// The display name of the budget.
        /// <para>Required: yes</para>
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The description of the budget.
        /// <para>Required: no</para>
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The amount of the budget expressed in the currency of the customer's rate card.
        /// <para>Required: yes</para>
        /// </summary>
        public double? Amount { get; set; }

        /// <summary>
        /// The reset period for the budget.
        /// <para>Required: yes</para>
        /// </summary>
        public string ResetPeriod { get; set; }

        /// <summary>
        /// The current state of the budget.
        /// <para>Required: yes</para>
        /// </summary>
        public string LifecycleState { get; set; }

        /// <summary>
        /// Total number of alert rules in the budget
        /// <para>Required: yes</para>
        /// </summary>
        public int AlertRuleCount { get; set; }

        /// <summary>
        /// Version of the budget. Starts from 1 and increments by 1.
        /// <para>Required: no</para>
        /// </summary>
        public int? Version { get; set; }

        /// <summary>
        /// The actual spend in currency for the current budget cycle
        /// <para>Required: no</para>
        /// </summary>
        public double? ActualSpend { get; set; }

        /// <summary>
        /// The forecasted spend in currency by the end of the current budget cycle
        /// <para>Required: no</para>
        /// </summary>
        public double? ForecastedSpend { get; set; }

        /// <summary>
        /// The time that the budget spend was last computed
        /// <para>Required: no</para>
        /// </summary>
        public string TimeSpendComputed { get; set; }

        /// <summary>
        /// Time that budget was created
        /// <para>Required: yes</para>
        /// </summary>
        public string TimeCreated { get; set; }

        /// <summary>
        /// Time that budget was updated
        /// <para>Required: yes</para>
        /// </summary>
        public string TimeUpdated { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public IDictionary<string, string> FreeformTags { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public IDictionary<string, IDictionary<string, string>> DefinedTags { get; set; }
    }
}

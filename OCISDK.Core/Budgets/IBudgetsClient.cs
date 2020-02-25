using OCISDK.Core.Budgets.Request;
using OCISDK.Core.Budgets.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Budgets
{
    /// <summary>
    /// BudgetsClient Interface
    /// </summary>
    public interface IBudgetsClient : IClientSetting
    {
        /// <summary>
        /// Creates a new Alert Rule.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        CreateAlertRuleResponse CreateAlertRule(CreateAlertRuleRequest request);

        /// <summary>
        /// Creates a new Budget.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        CreateBudgetResponse CreateBudget(CreateBudgetRequest request);

        /// <summary>
        /// Deletes a specified Alert Rule resource.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        DeleteAlertRuleResponse DeleteAlertRule(DeleteAlertRuleRequest request);

        /// <summary>
        /// Deletes a specified Budget resource
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        DeleteBudgetResponse DeleteBudget(DeleteBudgetRequest request);

        /// <summary>
        /// Gets an Alert Rule for a specified Budget.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        GetAlertRuleResponse GetAlertRule(GetAlertRuleRequest request);

        /// <summary>
        /// Update an Alert Rule for the budget identified by the OCID.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        UpdateAlertRuleResponse UpdateAlertRule(UpdateAlertRuleRequest request);

        /// <summary>
        /// Returns a list of Alert Rules for a specified Budget.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ListAlertRulesResponse ListAlertRules(ListAlertRulesRequest request);

        /// <summary>
        /// Lists budgets in the specified compartment.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ListBudgetsResponse ListBudgets(ListBudgetsRequest request);
    }
}

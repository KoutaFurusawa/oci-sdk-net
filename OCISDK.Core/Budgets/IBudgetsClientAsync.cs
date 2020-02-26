using OCISDK.Core.Budgets.Request;
using OCISDK.Core.Budgets.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OCISDK.Core.Budgets
{
    /// <summary>
    /// BudgetsClient Interface
    /// </summary>
    public interface IBudgetsClientAsync : IClientSetting
    {
        /// <summary>
        /// Creates a new Alert Rule.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<CreateAlertRuleResponse> CreateAlertRule(CreateAlertRuleRequest request);

        /// <summary>
        /// Creates a new Budget.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<CreateBudgetResponse> CreateBudget(CreateBudgetRequest request);

        /// <summary>
        /// Deletes a specified Alert Rule resource.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<DeleteAlertRuleResponse> DeleteAlertRule(DeleteAlertRuleRequest request);

        /// <summary>
        /// Deletes a specified Budget resource
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<DeleteBudgetResponse> DeleteBudget(DeleteBudgetRequest request);

        /// <summary>
        /// Gets an Alert Rule for a specified Budget.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<GetAlertRuleResponse> GetAlertRule(GetAlertRuleRequest request);

        /// <summary>
        /// Update an Alert Rule for the budget identified by the OCID.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<UpdateAlertRuleResponse> UpdateAlertRule(UpdateAlertRuleRequest request);

        /// <summary>
        /// Returns a list of Alert Rules for a specified Budget.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ListAlertRulesResponse> ListAlertRules(ListAlertRulesRequest request);

        /// <summary>
        /// Lists budgets in the specified compartment.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ListBudgetsResponse> ListBudgets(ListBudgetsRequest request);
    }
}

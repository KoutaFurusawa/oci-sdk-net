using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Budgets.Model
{
    /// <summary>
    /// The create budget details.
    /// 
    /// Client should use 'targetType' and 'targets' to specify the target type and list of targets on which the budget is applied.
    /// 
    /// For backwards compatibility, 'targetCompartmentId' will still be supported for all existing clients. 
    /// However, this is considered deprecreated and all clients be upgraded to use 'targetType' and 'targets'.
    /// 
    /// Specifying both 'targetCompartmentId' and 'targets' will cause a Bad Request.
    /// </summary>
    public class CreateBudgetDetails
    {
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
        public string Amount { get; set; }

        /// <summary>
        /// The reset period for the budget.
        /// <para>Required: yes</para>
        /// </summary>
        public string ResetPeriod { get; set; }
        
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

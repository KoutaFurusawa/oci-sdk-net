using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.UnpublishedService.UsageCosts.Model
{
    /// <summary>
    /// CostDetails
    /// </summary>
    public class CostDetails
    {
        /// <summary>
        /// computeType
        /// </summary>
        public string ComputeType { get; set; }

        /// <summary>
        /// computedQuantity
        /// </summary>
        public decimal? ComputedQuantity { get; set; }

        /// <summary>
        /// computedAmount
        /// </summary>
        public decimal? ComputedAmount { get; set; }

        /// <summary>
        /// unitPrice
        /// </summary>
        public decimal? UnitPrice { get; set; }
    }
}

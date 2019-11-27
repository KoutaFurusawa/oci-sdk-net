using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.UnpublishedService.UsageCosts.Model
{
    /// <summary>
    /// subscriptionInfo
    /// </summary>
    public class SubscriptionInfo
    {
        /// <summary>
        /// tenancyId
        /// </summary>
        public string TenancyId { get; set; }

        /// <summary>
        /// billStart
        /// </summary>
        public string BillStart { get; set; }

        /// <summary>
        /// billEnd
        /// </summary>
        public string BillEnd { get; set; }

        /// <summary>
        /// billModifiedTime
        /// </summary>
        public string BillModifiedTime { get; set; }

        /// <summary>
        /// billTotalBalance
        /// </summary>
        public decimal BillTotalBalance { get; set; }

        /// <summary>
        /// billTotalPurchased
        /// </summary>
        public decimal BillTotalPurchased { get; set; }

        /// <summary>
        /// billCurrency
        /// </summary>
        public string BillCurrency { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.UnpublishedService.UsageCosts.Model
{
    /// <summary>
    /// usagecost
    /// </summary>
    public class UsageCostDetails
    {
        /// <summary>
        /// startTime
        /// </summary>
        public string StartTime { get; set; }

        /// <summary>
        /// endTime
        /// </summary>
        public string EndTime { get; set; }

        /// <summary>
        /// internalResourceName
        /// </summary>
        public string InternalResourceName { get; set; }

        /// <summary>
        /// displayResourceName
        /// </summary>
        public string DisplayResourceName { get; set; }

        /// <summary>
        /// displayUnitName
        /// </summary>
        public string DisplayUnitName { get; set; }

        /// <summary>
        /// serviceName
        /// </summary>
        public string ServiceName { get; set; }

        /// <summary>
        /// currency
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// gsiProductId
        /// </summary>
        public string GsiProductId { get; set; }

        /// <summary>
        /// serviceType
        /// </summary>
        public string ServiceType { get; set; }

        /// <summary>
        /// costs
        /// </summary>
        public List<CostDetails> Costs { get; set; }
    }
}

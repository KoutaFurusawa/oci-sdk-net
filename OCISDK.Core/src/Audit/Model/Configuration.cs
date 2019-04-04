/// <summary>
/// Configuration
/// 
/// author: koutaro furusawa
/// </summary>

using System;

namespace OCISDK.Core.src.Audit.Model
{
    /// <summary>
    /// The retention period setting, specified in days. For more information, see Setting Audit Log Retention Period.
    /// </summary>
    public class Configuration
    {
        /// <summary>
        /// The retention period setting, specified in days. The minimum is 90, the maximum 365.
        /// </summary>
        /// <example>90</example>
        public int RetentionPeriodDays { get; set; }
    }
}

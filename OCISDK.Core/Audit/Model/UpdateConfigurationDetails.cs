using System;

namespace OCISDK.Core.Audit.Model
{
    /// <summary>
    /// The configuration details for the retention period setting, specified in days. 
    /// For more information, see Setting Audit Log Retention Period.
    /// </summary>
    public class UpdateConfigurationDetails
    {
        /// <summary>
        /// The retention period setting, specified in days. The minimum is 90, the maximum 365.
        /// <para>Required: no</para>
        /// <para>Minimum: 90, Maximum: 365</para>
        /// </summary>
        public int RetentionPeriodDays { get; set; }
    }
}

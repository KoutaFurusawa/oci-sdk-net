using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Model.Compute
{
    /// <summary>
    /// Instance agent configuration options to choose for updating the instance
    /// </summary>
    public class UpdateInstanceAgentConfigDetails
    {
        /// <summary>
        /// Whether the agent running on the instance can gather performance metrics and monitor the instance.
        /// <para>Required: no</para>
        /// <para>Default: false</para>
        /// </summary>
        public bool IsMonitoringDisabled { get; set; }
    }
}

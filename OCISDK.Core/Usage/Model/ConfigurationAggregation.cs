using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Usage.Model
{
    /// <summary>
    /// The available configurations.
    /// </summary>
    public class ConfigurationAggregation
    {
        /// <summary>
        /// The list of available configurations.
        /// <para>Required: yes</para>
        /// </summary>
        public List<Configuration> Items { get; set; }
    }
}

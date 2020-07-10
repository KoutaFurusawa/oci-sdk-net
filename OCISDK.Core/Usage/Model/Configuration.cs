using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Usage.Model
{
    /// <summary>
    /// A configuration.
    /// </summary>
    public class Configuration
    {
        /// <summary>
        /// The configuration key.
        /// <para>Required: yes</para>
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// The configuration value.
        /// <para>Required: no</para>
        /// </summary>
        public List<string> Values { get; set; }
    }
}

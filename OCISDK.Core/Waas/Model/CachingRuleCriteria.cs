using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Waas.Model
{
    /// <summary>
    /// CachingRuleCriteria
    /// </summary>
    public class CachingRuleCriteria
    {
        /// <summary>
        /// The condition of the caching rule criteria.
        /// <para>Required: yes</para>
        /// </summary>
        public string Condition { get; set; }

        /// <summary>
        /// The value of the caching rule criteria.
        /// <para>Required: yes</para>
        /// </summary>
        public string Value { get; set; }
    }
}

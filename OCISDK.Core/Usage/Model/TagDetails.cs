using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Usage.Model
{
    /// <summary>
    /// The tag used for filtering.
    /// </summary>
    public class TagDetails
    {
        /// <summary>
        /// The tag key.
        /// <para>Required: no</para>
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// The tag namespace.
        /// <para>Required: no</para>
        /// </summary>
        public string Namespace { get; set; }

        /// <summary>
        /// The tag value.
        /// <para>Required: no</para>
        /// </summary>
        public string Value { get; set; }
    }
}

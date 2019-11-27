using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Waas.Model
{
    /// <summary>
    /// Header Details
    /// </summary>
    public class HeaderDetails
    {
        /// <summary>
        /// The name of the header.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The value of the header.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 5000</para>
        /// </summary>
        public string Value { get; set; }
    }
}

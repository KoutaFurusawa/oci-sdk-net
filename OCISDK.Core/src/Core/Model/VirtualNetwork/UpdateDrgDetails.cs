using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.src.Core.Model.VirtualNetwork
{
    /// <summary>
    /// UpdateDrgDetails Reference
    /// </summary>
    public class UpdateDrgDetails
    {
        /// <summary>
        /// A user-friendly name. Does not have to be unique, and it's changeable.
        /// Avoid entering confidential information.
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public Dictionary<string, string> FreeformTags { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public Dictionary<string, Dictionary<string, string>> DefinedTags { get; set; }
    }
}

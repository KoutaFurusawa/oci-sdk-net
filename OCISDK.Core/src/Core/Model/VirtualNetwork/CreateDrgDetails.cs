using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.src.Core.Model.VirtualNetwork
{
    /// <summary>
    /// CreateDrgDetails Reference
    /// </summary>
    public class CreateDrgDetails
    {
        /// <summary>
        /// The OCID of the compartment containing the DRG.
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string CompartmentId { get; set; }

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

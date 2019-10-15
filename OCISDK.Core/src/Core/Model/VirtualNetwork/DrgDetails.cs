/// <summary>
/// Drg Reference
/// 
/// author: koutaro furusawa
/// </summary>

using System.Collections.Generic;


namespace OCISDK.Core.src.Core.Model.VirtualNetwork
{
    public class DrgDetails
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
        /// The DRG's Oracle ID (OCID).
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The DRG's current state.
        /// <para>Required: yes</para>
        /// </summary>
        public string LifecycleState { get; set; }

        /// <summary>
        /// The date and time the DRG was created, in the format defined by RFC3339.
        /// <para>Required: no</para>
        /// </summary>
        public string TimeCreated { get; set; }

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

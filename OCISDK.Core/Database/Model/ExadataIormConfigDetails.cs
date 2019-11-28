using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Database.Model
{
    /// <summary>
    /// Response details which has IORM Settings for this Exadata System
    /// </summary>
    public class ExadataIormConfigDetails
    {
        /// <summary>
        /// Array of IORM Setting for all the database in this Exadata DB System
        /// <para>Required: no</para>
        /// </summary>
        public List<DbIormConfigDetails> DbPlans { get; set; }

        /// <summary>
        /// Additional information about the current lifecycleState.
        /// <para>Required: no</para>
        /// </summary>
        public string LifecycleDetails { get; set; }

        /// <summary>
        /// The current config state of IORM settings for this Exadata System.
        /// <para>Required: no</para>
        /// </summary>
        public string LifecycleState { get; set; }

        /// <summary>
        /// Value for the IORM objective Default is "Auto"
        /// <para>Required: no</para>
        /// </summary>
        public string Objective { get; set; }
    }
}

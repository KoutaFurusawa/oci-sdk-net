using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace OCISDK.Core.src.Database.Model
{
    /// <summary>
    /// IORM Setting details for this Exadata System to be updated
    /// </summary>
    public class ExadataIormConfigUpdateDetails
    {
        /// <summary>
        /// Array of IORM Setting for all the database in this Exadata DB System
        /// <para>Required: no</para>
        /// </summary>
        public List<DbIormConfigUpdateDetail> DbPlans { get; set; }

        public string Objective { get; set; }

        public enum ObjectiveParam
        {
            [DisplayName("LOW_LATENCY")]
            LOW_LATENCY,
            [DisplayName("HIGH_THROUGHPUT")]
            HIGH_THROUGHPUT,
            [DisplayName("BALANCED")]
            BALANCED,
            [DisplayName("AUTO")]
            AUTO,
            [DisplayName("BASIC")]
            BASIC
        }
    }
}

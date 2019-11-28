using OCISDK.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace OCISDK.Core.Database.Model
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

        /// <summary>
        /// Objective
        /// </summary>
        public ObjectiveParam Objective { get; set; }

        /// <summary>
        /// Objective ExpandableEnum
        /// </summary>
        public class ObjectiveParam : ExpandableEnum<ObjectiveParam>
        {
            /// <summary>
            /// Objective ExpandableEnum
            /// </summary>
            /// <param name="value"></param>
            public ObjectiveParam(string value) : base(value) { }

            /// <summary>
            /// parase
            /// </summary>
            /// <param name="value"></param>
            public static implicit operator ObjectiveParam(string value)
            {
                return Parse(value);
            }

            /// <summary>
            /// LOW_LATENCY
            /// </summary>
            public static readonly ObjectiveParam LOW_LATENCY = new ObjectiveParam("LOW_LATENCY");

            /// <summary>
            /// HIGH_THROUGHPUT
            /// </summary>
            public static readonly ObjectiveParam HIGH_THROUGHPUT = new ObjectiveParam("HIGH_THROUGHPUT");

            /// <summary>
            /// BALANCED
            /// </summary>
            public static readonly ObjectiveParam BALANCED = new ObjectiveParam("BALANCED");

            /// <summary>
            /// AUTO
            /// </summary>
            public static readonly ObjectiveParam AUTO = new ObjectiveParam("AUTO");

            /// <summary>
            /// BASIC
            /// </summary>
            public static readonly ObjectiveParam BASIC = new ObjectiveParam("BASIC");
        }
    }
}

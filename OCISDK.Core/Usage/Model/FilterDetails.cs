using OCISDK.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Usage.Model
{
    /// <summary>
    /// The filter object for query usage.
    /// </summary>
    public class FilterDetails
    {
        /// <summary>
        /// The dimensions to filter on.
        /// <para>Required: no</para>
        /// </summary>
        public DimensionDetails Dimension { get; set; }

        /// <summary>
        /// The nested filter object.
        /// <para>Required: no</para>
        /// </summary>
        public List<FilterDetails> Filters { get; set; }

        /// <summary>
        /// SortBy ExpandableEnum
        /// </summary>
        public class OperatorParam : ExpandableEnum<OperatorParam>
        {
            /// <summary>
            /// Operator ExpandableEnum
            /// </summary>
            /// <param name="value"></param>
            public OperatorParam(string value) : base(value) { }

            /// <summary>
            /// parse
            /// </summary>
            /// <param name="value"></param>
            public static implicit operator OperatorParam(string value)
            {
                return Parse(value);
            }

            /// <summary>
            /// AND
            /// </summary>
            public static readonly OperatorParam AND = new OperatorParam("AND");

            /// <summary>
            /// NOT
            /// </summary>
            public static readonly OperatorParam NOT = new OperatorParam("NOT");

            /// <summary>
            /// OR
            /// </summary>
            public static readonly OperatorParam OR = new OperatorParam("OR");
        }

        /// <summary>
        /// The filter operator. Example: 'AND', 'OR', 'NOT'.
        /// <para>Required: no</para>
        /// </summary>
        public OperatorParam Operator { get; set; }

        /// <summary>
        /// The tags to filter on.
        /// <para>Required: no</para>
        /// </summary>
        public List<TagDetails> Tags { get; set; }
    }
}

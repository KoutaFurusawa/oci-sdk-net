using OCISDK.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace OCISDK.Core.Search.Model
{
    /// <summary>
    /// MatchingContextType ExpandableEnum
    /// </summary>
    public class MatchingContextType : ExpandableEnum<MatchingContextType>
    {
        /// <summary>
        /// SortBy ExpandableEnum
        /// </summary>
        /// <param name="value"></param>
        public MatchingContextType(string value) : base(value) { }

        /// <summary>
        /// parase
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator MatchingContextType(string value)
        {
            return Parse(value);
        }

        /// <summary>
        /// NONE
        /// </summary>
        public static readonly MatchingContextType NONE = new MatchingContextType("NONE");

        /// <summary>
        /// HIGHLIGHTS
        /// </summary>
        public static readonly MatchingContextType HIGHLIGHTS = new MatchingContextType("HIGHLIGHTS");
    }

}

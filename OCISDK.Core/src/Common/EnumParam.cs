/// <summary>
/// Enums
/// 
/// author: koutaro furusawa
/// </summary>
using System.ComponentModel;

namespace OCISDK.Core.src.Common
{
    /// <summary>
    /// SortOrder ExpandableEnum
    /// </summary>
    public class SortOrder : ExpandableEnum<SortOrder>
    {
        public SortOrder(string value) : base(value) { }

        public static implicit operator SortOrder(string value)
        {
            return Parse(value);
        }

        public static readonly SortOrder ASC = new SortOrder("ASC");

        public static readonly SortOrder DESC = new SortOrder("DESC");
    }
}

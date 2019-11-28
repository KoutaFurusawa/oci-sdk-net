namespace OCISDK.Core.Common
{
    /// <summary>
    /// SortOrder ExpandableEnum
    /// </summary>
    public class SortOrder : ExpandableEnum<SortOrder>
    {
        /// <summary>
        /// construct
        /// </summary>
        /// <param name="value"></param>
        public SortOrder(string value) : base(value) { }

        /// <summary>
        /// construct
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator SortOrder(string value)
        {
            return Parse(value);
        }

        /// <summary>
        /// ASC
        /// </summary>
        public static readonly SortOrder ASC = new SortOrder("ASC");

        /// <summary>
        /// DESC
        /// </summary>
        public static readonly SortOrder DESC = new SortOrder("DESC");
    }
}

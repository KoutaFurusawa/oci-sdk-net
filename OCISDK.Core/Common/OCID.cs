using System.Text.RegularExpressions;

namespace OCISDK.Core.Common
{
    /// <summary>
    /// OCI Class
    /// </summary>
    public class OCID
    {
        /// pattern is relaxed other than the required
        private static readonly Regex OCID_PATTERN = new Regex("^([0-9a-zA-Z-_]+[.:])([0-9a-zA-Z-_]*[.:]){3,}([0-9a-zA-Z-_]+)$", 
            RegexOptions.Compiled);

        /// <summary>
        /// OCID validate
        /// </summary>
        /// <param name="ocid"></param>
        /// <returns></returns>
        public static bool IsValid(string ocid)
        {
            return OCID_PATTERN.IsMatch(ocid);
        }
    }
}

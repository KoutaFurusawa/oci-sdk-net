using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Request.Blockstorage
{
    /// <summary>
    /// ListVolumeBackupPolicies Request
    /// </summary>
    public class ListVolumeBackupPoliciesRequest
    {
        /// <summary>
        /// For list pagination. The maximum number of results per page, or items to return in a paginated "List" call. 
        /// For important details about how pagination works, see List Pagination.
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 1000</para>
        /// </summary>
        public int? Limit { get; set; }

        /// <summary>
        /// For list pagination. The value of the opc-next-page response header from the previous "List" call. 
        /// For important details about how pagination works, see List Pagination.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 512</para>
        /// </summary>
        public string Page { get; set; }

        /// <summary>
        /// option query
        /// </summary>
        /// <returns></returns>
        public string GetOptionQuery()
        {
            StringBuilder sb = new StringBuilder();
            var addChr = "";

            if (this.Limit.HasValue)
            {
                sb.Append($"limit={this.Limit.Value}");
                addChr = "&";
            }

            if (!String.IsNullOrEmpty(this.Page))
            {
                sb.Append($"{addChr}page={this.Page}");
            }

            return sb.ToString();
        }
    }
}

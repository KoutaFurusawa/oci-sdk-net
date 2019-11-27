using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Request.Compute
{
    /// <summary>
    /// GetConsoleHistoryContent Request
    /// </summary>
    public class GetConsoleHistoryContentRequest
    {
        /// <summary>
        /// The OCID of the console history.
        /// <para>Required: yes</para>
        /// </summary>
        public string InstanceConsoleHistoryId { get; set; }

        /// <summary>
        /// Offset of the snapshot data to retrieve.
        /// <para>Required: no</para>
        /// </summary>
        public int? Offset { get; set; }

        /// <summary>
        /// Length of the snapshot data to retrieve.
        /// <para>Required: no</para>
        /// </summary>
        public int? Length { get; set; }

        /// <summary>
        /// option query
        /// </summary>
        /// <returns></returns>
        public string GetOptionQuery()
        {
            StringBuilder sb = new StringBuilder();
            var addChr = "";
            
            if (this.Offset.HasValue)
            {
                sb.Append($"offset={this.Offset.Value}");
                addChr = "&";
            }

            if (this.Length.HasValue)
            {
                sb.Append($"{addChr}length={this.Length.Value}");
            }
            
            return sb.ToString();
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Request.VirtualNetwork
{
    /// <summary>
    /// ListDrgAttachments Request
    /// </summary>
    public class ListDrgAttachmentsRequest
    {
        /// <summary>
        /// The OCID of the compartment.
        /// <para>Required: yes</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// The OCID of the VCN.
        /// <para>Required: no</para>
        /// </summary>
        public string VcnId { get; set; }

        /// <summary>
        /// The OCID of the DRG.
        /// <para>Required: no</para>
        /// </summary>
        public string DrgId { get; set; }

        /// <summary>
        /// For list pagination. The maximum number of results per page, or items to return in a paginated "List" call. 
        /// For important details about how pagination works, see List Pagination.
        /// <para>Required: no</para>
        /// </summary>
        public int? Limit { get; set; }

        /// <summary>
        /// For list pagination. The value of the opc-next-page response header from the previous "List" call.
        /// For important details about how pagination works, see List Pagination.
        /// </summary>
        public string Page { get; set; }

        /// <summary>
        /// option query
        /// </summary>
        /// <returns></returns>
        public string GetOptionQuery()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"compartmentId={this.CompartmentId}");
            
            if (!string.IsNullOrEmpty(this.VcnId))
            {
                sb.Append($"&vcnId={this.VcnId}");
            }

            if (!string.IsNullOrEmpty(this.DrgId))
            {
                sb.Append($"&drgId={this.DrgId}");
            }

            if (this.Limit.HasValue)
            {
                sb.Append($"&limit={this.Limit.Value}");
            }

            if (!string.IsNullOrEmpty(this.Page))
            {
                sb.Append($"&page={this.Page}");
            }

            return sb.ToString();
        }
    }
}

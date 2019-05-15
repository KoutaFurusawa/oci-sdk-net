using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.src.Identity.Request
{
    public class ListPoliciesRequest
    {
        public string CompartmentId { get; set; }

        public string Page { get; set; }

        public int? Limit { get; set; }

        public string GetOptionQuery()
        {
            var options = $"compartmentId={this.CompartmentId}";

            if (!String.IsNullOrEmpty(this.Page))
            {
                options += $"&page={this.Page}";
            }
            if (this.Limit.HasValue)
            {
                options += $"&limit={this.Limit.Value}";
            }

            return options;
        }
    }
}

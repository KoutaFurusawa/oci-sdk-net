using System;

namespace OCISDK.Core.Identity.Request
{
    /// <summary>
    /// ListPolicies Request
    /// </summary>
    public class ListPoliciesRequest
    {
        /// <summary>
        /// The OCID of the compartment (remember that the tenancy is simply the root compartment).
        /// <para>Required: yes</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// The value of the opc-next-page response header from the previous "List" call.
        /// <para>Required: no</para>
        /// </summary>
        public string Page { get; set; }

        /// <summary>
        /// The maximum number of items to return in a paginated "List" call.
        /// <para>Required: no</para>
        /// </summary>
        public int? Limit { get; set; }

        /// <summary>
        /// option query
        /// </summary>
        /// <returns></returns>
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

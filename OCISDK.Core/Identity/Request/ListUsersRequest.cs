using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace OCISDK.Core.Identity.Request
{
    /// <summary>
    /// ListUsers Request
    /// </summary>
    public class ListUsersRequest
    {
        /// <summary>
        /// The OCID of the compartment (remember that the tenancy is simply the root compartment).
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// The maximum number of items to return in a paginated "List" call.
        /// <para>Required: no</para>
        /// </summary>
        public int? Limit { get; set; }

        /// <summary>
        /// The value of the opc-next-page response header from the previous "List" call.
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 512</para>
        /// </summary>
        public string Page { get; set; }

        /// <summary>
        /// The id of the identity provider.
        /// <para>Required: no</para>
        /// </summary>
        public string IdentityProviderId { get; set; }

        /// <summary>
        /// The id of a user in the identity provider.
        /// <para>Required: no</para>
        /// </summary>
        public string ExternalIdentifier { get; set; }

        /// <summary>
        /// option quert
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

            if (!String.IsNullOrEmpty(this.IdentityProviderId))
            {
                options += $"&identityProviderId={this.IdentityProviderId}";
            }

            if (!String.IsNullOrEmpty(this.ExternalIdentifier))
            {
                options += $"&externalIdentifier={this.ExternalIdentifier}";
            }

            return options;
        }
    }
}
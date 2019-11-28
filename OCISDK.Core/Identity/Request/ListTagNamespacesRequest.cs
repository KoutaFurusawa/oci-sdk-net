namespace OCISDK.Core.Identity.Request
{
    /// <summary>
    /// ListTagNamespaces Request
    /// </summary>
    public class ListTagNamespacesRequest
    {
        /// <summary>
        /// The OCID of the compartment (remember that the tenancy is simply the root compartment).
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// The value of the opc-next-page response header from the previous "List" call.
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 512</para>
        /// </summary>
        public string Page { get; set; }

        /// <summary>
        /// The maximum number of items to return in a paginated "List" call.
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 1000</para>
        /// </summary>
        public int? Limit { get; set; }

        /// <summary>
        /// An optional boolean parameter indicating whether to retrieve all tag namespaces in subcompartments. 
        /// If this parameter is not specified, only the tag namespaces defined in the specified compartment are retrieved.
        /// <para>Required: no</para>
        /// </summary>
        public bool? IncludeSubcompartments { get; set; }

        /// <summary>
        /// option query
        /// </summary>
        /// <returns></returns>
        public string GetOptionQuery()
        {
            var options = $"compartmentId={this.CompartmentId}";
            if (!string.IsNullOrEmpty(this.Page))
            {
                options += $"&page={this.Page}";
            }
            if (this.Limit.HasValue)
            {
                options += $"&limit={this.Limit.Value}";
            }
            if (this.IncludeSubcompartments.HasValue)
            {
                options += $"&includeSubcompartments={this.IncludeSubcompartments.Value}";
            }

            return options;
        }
    }
}

using System;

namespace OCISDK.Core.Identity.Request
{
    /// <summary>
    /// ListTagDefaults Request
    /// </summary>
    public class ListTagDefaultsRequest
    {
        /// <summary>
        /// A filter to only return resources that match the specified OCID exactly.
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The OCID of the compartment (remember that the tenancy is simply the root compartment).
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// The OCID of the tag definition.
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string TagDefinitionId { get; set; }

        /// <summary>
        /// A filter to only return resources that match the given lifecycle state. The state value is case-insensitive.
        /// <para>Required: no</para>
        /// </summary>
        public string LifecycleState { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 512</para>
        /// </summary>
        public string Page { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 1000</para>
        /// </summary>
        public int? Limit { get; set; }

        /// <summary>
        /// option query
        /// </summary>
        /// <returns></returns>
        public string GetOptionQuery()
        {
            var options = "";

            if (!String.IsNullOrEmpty(this.Id))
            {
                options += $"&id={this.Id}";
            }

            if (!String.IsNullOrEmpty(this.CompartmentId))
            {
                options = $"&compartmentId={this.CompartmentId}";
            }

            if (!String.IsNullOrEmpty(this.TagDefinitionId))
            {
                options = $"&tagDefinitionId={this.TagDefinitionId}";
            }

            if (!String.IsNullOrEmpty(this.LifecycleState))
            {
                options = $"&lifecycleState={this.LifecycleState}";
            }

            if (!String.IsNullOrEmpty(this.Page))
            {
                options += $"&page={this.Page}";
            }

            if (this.Limit.HasValue)
            {
                options += $"&limit={this.Limit.Value}";
            }

            if (!string.IsNullOrEmpty(options))
            {
                options.Remove(0, 1);
            }

            return options;
        }
    }
}

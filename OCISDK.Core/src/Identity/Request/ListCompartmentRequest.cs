/// <summary>
/// ListCompartment Request
/// 
/// author: koutaro furusawa
/// </summary>

using System;
namespace OCISDK.Core.src.Identity.Request
{
    public class ListCompartmentRequest
    {
        /// <summary>
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public int? Limit { get; set; }
        
        /// <summary>
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 512</para>
        /// </summary>
        public string Page { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// <para>Allowed values are:
        /// ANY
        /// , ACCESSIBLE</para>
        /// </summary>
        public string AccessLevel { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// Default is false. 
        /// Can only be set to true when performing ListCompartments on the tenancy (root compartment). 
        /// </summary>
        public bool? CompartmentIdInSubtree { get; set; }

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
            if (!String.IsNullOrEmpty(this.AccessLevel))
            {
                options += $"&accessLevel={this.AccessLevel}";
            }
            if (this.CompartmentIdInSubtree.HasValue)
            {
                options += $"&compartmentIdInSubtree={this.CompartmentIdInSubtree}";
            }

            return options;
        }
    }
}

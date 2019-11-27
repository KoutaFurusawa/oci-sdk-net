using OCISDK.Core.Common;
using System;
using System.ComponentModel;

namespace OCISDK.Core.Identity.Request
{
    /// <summary>
    /// ListCompartment Request
    /// </summary>
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
        public AccessLevels AccessLevel { get; set; }

        /// <summary>
        /// AccessLevel ExpandableEnum
        /// </summary>
        public class AccessLevels : ExpandableEnum<AccessLevels>
        {
            /// <summary>
            /// AccessLevel ExpandableEnum
            /// </summary>
            /// <param name="value"></param>
            public AccessLevels(string value) : base(value) { }

            /// <summary>
            /// parse
            /// </summary>
            /// <param name="value"></param>
            public static implicit operator AccessLevels(string value)
            {
                return Parse(value);
            }

            /// <summary>
            /// ANY
            /// </summary>
            public static readonly AccessLevels ANY = new AccessLevels("ANY");

            /// <summary>
            /// ACCESSIBLE
            /// </summary>
            public static readonly AccessLevels ACCESSIBLE = new AccessLevels("ACCESSIBLE");
        }

        /// <summary>
        /// <para>Required: no</para>
        /// Default is false. 
        /// Can only be set to true when performing ListCompartments on the tenancy (root compartment). 
        /// </summary>
        public bool? CompartmentIdInSubtree { get; set; }

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
            if (!(AccessLevel is null))
            {
                options += $"&accessLevel={AccessLevel.Value}";
            }
            if (this.CompartmentIdInSubtree.HasValue)
            {
                options += $"&compartmentIdInSubtree={this.CompartmentIdInSubtree}";
            }

            return options;
        }
    }
}

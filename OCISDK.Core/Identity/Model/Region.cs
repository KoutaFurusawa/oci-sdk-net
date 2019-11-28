﻿

namespace OCISDK.Core.Identity.Model
{
    /// <summary>
    /// A localized geographic area, such as Phoenix, AZ. 
    /// Oracle Cloud Infrastructure is hosted in regions and Availability Domains. 
    /// A region is composed of several Availability Domains. An Availability Domain is one or more data centers located within a region. 
    /// For more information, see Regions and Availability Domains.
    /// To use any of the API operations, you must be authorized in an IAM policy.If you're not authorized, talk to an administrator. 
    /// If you're an administrator who needs to write policies to give users access, see Getting Started with Policies.
    /// </summary>
    public class Region
    {
        /// <summary>
        /// The key of the region.
        /// <para>Min Length: 1, Max Length: 16</para>
        /// </summary>
        /// <example>Allowed values are: PHX, IAD, FRA, LHR, NRT</example>
        public string Key { get; set; }

        /// <summary>
        /// The name of the region.
        /// <para>Min Length: 1, Max Length: 16</para>
        /// </summary>
        public string Name { get; set; }
    }
}

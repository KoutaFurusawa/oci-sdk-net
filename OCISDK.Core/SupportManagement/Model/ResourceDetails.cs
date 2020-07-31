using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.SupportManagement.Model
{
    /// <summary>
    /// Details about the ticket item object.
    /// </summary>
    public class ResourceDetails
    {
        /// <summary>
        /// The list of available Oracle Cloud Infrastructure availability domains.
        /// <para>Required: no</para>
        /// </summary>
        public string AvailabilityDomain { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public ItemDetails Item { get; set; }

        /// <summary>
        /// The list of available Oracle Cloud Infrastructure regions.
        /// <para>Required: no</para>
        /// </summary>
        public string Region { get; set; }
    }
}

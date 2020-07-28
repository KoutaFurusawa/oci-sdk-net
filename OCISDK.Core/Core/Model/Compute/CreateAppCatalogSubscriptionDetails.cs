using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Model.Compute
{
    /// <summary>
    /// details for creating a subscription for a listing resource version.
    /// </summary>
    public class CreateAppCatalogSubscriptionDetails
    {
        /// <summary>
        /// The compartmentID of the subscription.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// EULA link
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 1024</para>
        /// </summary>
        public string EulaLink { get; set; }

        /// <summary>
        /// The ocid of the listing resource.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string ListingId { get; set; }

        /// <summary>
        /// Listing resource version.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string ListingResourceVersion { get; set; }

        /// <summary>
        /// Oracle TOU link
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: Date and time the agreements were retrieved, in RFC3339 format.</para>
        /// </summary>
        public string OracleTermsOfUseLink { get; set; }

        /// <summary>
        /// A generated signature for this listing resource version retrieved the agreements API.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string Signature { get; set; }

        /// <summary>
        /// Date and time the agreements were retrieved, in RFC3339 format.
        /// <para>Required: yes</para>
        /// </summary>
        /// <example>2018-03-20T12:32:53.532Z</example>
        public string TimeRetrieved { get; set; }
    }
}

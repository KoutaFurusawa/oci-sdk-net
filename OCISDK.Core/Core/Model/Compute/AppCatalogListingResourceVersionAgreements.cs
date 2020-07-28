using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Model.Compute
{
    /// <summary>
    /// Agreements for a listing resource version.
    /// </summary>
    public class AppCatalogListingResourceVersionAgreements
    {
        /// <summary>
        /// EULA link
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 1024</para>
        /// </summary>
        public string EulaLink { get; set; }

        /// <summary>
        /// The OCID of the listing associated with these agreements.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string ListingId { get; set; }

        /// <summary>
        /// Listing resource version associated with these agreements.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 64</para>
        /// </summary>
        public string ListingResourceVersion { get; set; }

        /// <summary>
        /// Oracle TOU link
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 1024</para>
        /// </summary>
        public string OracleTermsOfUseLink { get; set; }

        /// <summary>
        /// A generated signature for this agreement retrieval operation which 
        /// should be used in the create subscription call.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string Signature { get; set; }

        /// <summary>
        /// Date and time the agreements were retrieved, in RFC3339 format.
        /// <para>Required: no</para>
        /// </summary>
        /// <example>2018-03-20T12:32:53.532Z</example>
        public string TimeRetrieved { get; set; }
    }
}

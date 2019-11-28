using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.DNS.Model
{
    /// <summary>
    /// A DNS resource record. For more information, see Supported DNS Resource Record Types.
    /// </summary>
    public class RecordDetails
    {
        /// <summary>
        /// The fully qualified domain name where the record can be located.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 254</para>
        /// </summary>
        public string Domain { get; set; }

        /// <summary>
        /// A unique identifier for the record within its zone.
        /// <para>Required: no</para>
        /// </summary>
        public string RecordHash { get; set; }

        /// <summary>
        /// A Boolean flag indicating whether or not parts of the record are unable to be explicitly managed.
        /// <para>Required: no</para>
        /// </summary>
        public bool? IsProtected { get; set; }

        /// <summary>
        /// The record's data, as whitespace-delimited tokens in type-specific presentation format. 
        /// All RDATA is normalized and the returned presentation of your RDATA may differ from its initial input. 
        /// For more information about RDATA, see Supported DNS Resource Record Types
        /// <para>Required: no</para>
        /// </summary>
        public string Rdata { get; set; }

        /// <summary>
        /// The latest version of the record's zone in which its RRSet differs from the preceding version.
        /// <para>Required: no</para>
        /// </summary>
        public string RrsetVersion { get; set; }

        /// <summary>
        /// The canonical name for the record's type, such as A or CNAME. For more information, see Resource Record (RR) TYPEs.
        /// <para>Required: no</para>
        /// </summary>
        public string Rtype { get; set; }

        /// <summary>
        /// The Time To Live for the record, in seconds.
        /// <para>Required: no</para>
        /// <para>Minimum: 0, Maximum: 604800</para>
        /// </summary>
        public int? Ttl { get; set; }
    }
}

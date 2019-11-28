using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Database.Model
{
    /// <summary>
    /// The Oracle Database software version.
    /// 
    /// To use any of the API operations, you must be authorized in an IAM policy. 
    /// If you're not authorized, talk to an administrator. 
    /// If you're an administrator who needs to write policies to give users access, see Getting Started with Policies.
    /// </summary>
    public class DbVersionSummary
    {
        /// <summary>
        /// True if this version of the Oracle Database software is the latest version for a release.
        /// <para>Required: no</para>
        /// </summary>
        public bool? IsLatestForMajorVersion { get; set; }

        /// <summary>
        /// True if this version of the Oracle Database software supports pluggable databases.
        /// <para>Required: no</para>
        /// </summary>
        public bool? SupportsPdb { get; set; }

        /// <summary>
        /// A valid Oracle Database version.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string Version { get; set; }
    }
}

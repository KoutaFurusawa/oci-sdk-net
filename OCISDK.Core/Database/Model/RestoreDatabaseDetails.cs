using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Database.Model
{
    /// <summary>
    /// RestoreDatabaseDetails
    /// </summary>
    public class RestoreDatabaseDetails
    {
        /// <summary>
        /// Restores using the backup with the System Change Number (SCN) specified.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string DatabaseSCN { get; set; }

        /// <summary>
        /// Restores to the last known good state with the least possible data loss.
        /// <para>Required: no</para>
        /// </summary>
        public bool? Latest { get; set; }

        /// <summary>
        /// Restores to the timestamp specified.
        /// <para>Required: no</para>
        /// </summary>
        public string Timestamp { get; set; }
    }
}

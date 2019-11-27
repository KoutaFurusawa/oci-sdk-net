using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Database.Model
{
    /// <summary>
    /// IORM Config setting response for this database
    /// </summary>
    public class DbIormConfigDetails
    {
        /// <summary>
        /// Database Name. For default DbPlan, the dbName will always be default
        /// <para>Required: no</para>
        /// </summary>
        public string DbName { get; set; }

        /// <summary>
        /// Flash Cache limit, internally configured based on shares
        /// <para>Required: no</para>
        /// </summary>
        public string FlashCacheLimit { get; set; }

        /// <summary>
        /// Relative priority of a database
        /// <para>Required: no</para>
        /// </summary>
        public int? Share { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Database.Model
{
    /// <summary>
    /// IORM Config setting request for this database
    /// </summary>
    public class DbIormConfigUpdateDetail
    {
        /// <summary>
        /// Database Name. For updating default DbPlan, pass in dbName as default
        /// <para>Required: no</para>
        /// </summary>
        public string DbName { get; set; }

        /// <summary>
        /// Relative priority of a database
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 32</para>
        /// </summary>
        public int? Share { get; set; }
    }
}

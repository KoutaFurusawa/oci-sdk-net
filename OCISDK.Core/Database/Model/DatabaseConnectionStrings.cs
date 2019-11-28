using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Database.Model
{
    /// <summary>
    /// Connection strings to connect to an Oracle Database.
    /// </summary>
    public class DatabaseConnectionStrings
    {
        /// <summary>
        /// All connection strings to use to connect to the Database.
        /// <para>Required: no</para>
        /// </summary>
        public object AllConnectionStrings { get; set; }

        /// <summary>
        /// Host name based CDB Connection String.
        /// <para>Required: no</para>
        /// <para>Min Length: 10, Max Length: 255</para>
        /// </summary>
        public string CdbDefault { get; set; }

        /// <summary>
        /// IP based CDB Connection String.
        /// <para>Required: no</para>
        /// <para>Min Length: 10, Max Length: 255</para>
        /// </summary>
        public string CdbIpDefault { get; set; }
    }
}

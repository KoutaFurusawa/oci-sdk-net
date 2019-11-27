using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Database.Model
{
    /// <summary>
    /// Details for creating a database home.
    /// 
    /// Warning: Oracle recommends that you avoid using any confidential information when you supply string values using the API.
    /// </summary>
    public class CreateDbHomeDetails
    {
        /// <summary>
        /// <para>Required: yes</para>
        /// </summary>
        public CreateDatabaseDetails Database { get; set; }

        /// <summary>
        /// A valid Oracle Database version. To get a list of supported versions, use the ListDbVersions operation.
        /// <para>Required: yes</para>
        /// </summary>
        public string DbVersion { get; set; }

        /// <summary>
        /// The user-provided name of the database home.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string DisplayName { get; set; }
    }
}

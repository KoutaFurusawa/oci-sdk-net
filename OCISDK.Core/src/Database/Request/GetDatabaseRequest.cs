using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.src.Database.Request
{
    public class GetDatabaseRequest
    {
        /// <summary>
        /// The database OCID.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string DatabaseId { get; set; }
    }
}

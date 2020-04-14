﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.NoSQL.Request
{
    /// <summary>
    /// GetIndex request
    /// </summary>
    public class GetIndexRequest
    {
        /// <summary>
        /// A table name within the compartment, or a table OCID.
        /// <para>Required: yes</para>
        /// </summary>
        public string TableNameOrId { get; set; }

        /// <summary>
        /// The name of a table's index.
        /// <para>Required: yes</para>
        /// </summary>
        public string IndexName { get; set; }

        /// <summary>
        /// The ID of a table's compartment. When a table is identified by name, the compartmentId is often needed to provide context for interpreting the name.
        /// <para>Required: no</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// The client request ID for tracing.
        /// <para>Required: no</para>
        /// </summary>
        public string OpcRequestId { get; set; }
    }
}

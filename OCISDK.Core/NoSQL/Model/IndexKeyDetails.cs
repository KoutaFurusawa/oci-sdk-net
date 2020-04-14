using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.NoSQL.Model
{
    /// <summary>
    /// Specifies a single key in a secondary index.
    /// </summary>
    public class IndexKeyDetails
    {
        /// <summary>
        /// The name of a column to be included as an index key.
        /// <para>Required: yes</para>
        /// </summary>
        public string ColumnName { get; set; }

        /// <summary>
        /// If the specified column is of type JSON, jsonPath contains a dotted path indicating 
        /// the field within the JSON object that will be the index key.
        /// <para>Required: no</para>
        /// </summary>
        public string JsonPath { get; set; }

        /// <summary>
        /// If the specified column is of type JSON, jsonFieldType contains the type of 
        /// the field indicated by jsonPath.
        /// <para>Required: no</para>
        /// </summary>
        public string JsonFieldType { get; set; }
    }
}

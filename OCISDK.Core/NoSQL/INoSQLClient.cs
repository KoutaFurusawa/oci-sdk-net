using OCISDK.Core.NoSQL.Request;
using OCISDK.Core.NoSQL.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.NoSQL
{
    /// <summary>
    /// NoSQL client interface
    /// </summary>
    public interface INoSQLClient
    {
        /// <summary>
        /// Create a new index on the table identified by tableNameOrId.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        CreateIndexResponse CreateIndex(CreateIndexRequest request);

        /// <summary>
        /// Get information about a single index.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        GetIndexResponse GetIndex(GetIndexRequest request);

        /// <summary>
        /// Get a list of indexes on a table.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ListIndexesResponse ListIndexes(ListIndexesRequest request);

        /// <summary>
        /// Delete an index from the table identified by tableNameOrId.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        DeleteIndexResponse DeleteIndex(DeleteIndexRequest request);
    }
}

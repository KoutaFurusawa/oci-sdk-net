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
        /// Get a single row from the table by primary key.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        GetRowResponse GetRow(GetRowRequest request);

        /// <summary>
        /// Prepare a SQL statement for use in a query with variable substitution.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        PrepareStatementResponse PrepareStatement(PrepareStatementRequest request);

        /// <summary>
        /// Get a list of indexes on a table.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ListIndexesResponse ListIndexes(ListIndexesRequest request);

        /// <summary>
        /// Check the syntax and return a brief summary of a SQL statement.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        SummarizeStatementResponse SummarizeStatement(SummarizeStatementRequest request);

        /// <summary>
        /// Execute a SQL query.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        QueryResponse Query(QueryRequest request);

        /// <summary>
        /// Write a single row into the table.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        UpdateRowResponse UpdateRow(UpdateRowRequest request);

        /// <summary>
        /// Delete an index from the table identified by tableNameOrId.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        DeleteIndexResponse DeleteIndex(DeleteIndexRequest request);

        /// <summary>
        /// Delete a single row from the table, by primary key.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        DeleteRowResponse DeleteRow(DeleteRowRequest request);

        /// <summary>
        /// Change a table's compartment.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ChangeTableCompartmentResponse ChangeTableCompartment(ChangeTableCompartmentRequest request);

        /// <summary>
        /// Create a new table.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        CreateTableResponse CreateTable(CreateTableRequest request);

        /// <summary>
        /// Delete a table by tableNameOrId.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        DeleteTableResponse DeleteTable(DeleteTableRequest request);

        /// <summary>
        /// Get table info by identifier.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        GetTableResponse GetTable(GetTableRequest request);

        /// <summary>
        /// Get a list of tables in a compartment.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ListTablesResponse ListTables(ListTablesRequest request);

        /// <summary>
        /// Get table usage info.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ListTableUsageResponse ListTableUsage(ListTableUsageRequest request);

        /// <summary>
        /// Alter the table identified by tableNameOrId, changing schema, limits, or tags
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        UpdateTableResponse UpdateTable(UpdateTableRequest request);
    }
}

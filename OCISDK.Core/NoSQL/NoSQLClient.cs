using OCISDK.Core.Common;
using OCISDK.Core.NoSQL.Model;
using OCISDK.Core.NoSQL.Request;
using OCISDK.Core.NoSQL.Response;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OCISDK.Core.NoSQL
{
    /// <summary>
    /// NoSQL client
    /// </summary>
    public class NoSQLClient : ServiceClient, INoSQLClient
    {
        private readonly string NoSQLServiceName = "nosql";

        /// <summary>
        /// Constructer
        /// </summary>
        public NoSQLClient(ClientConfig config) : base(config)
        {
            ServiceName = NoSQLServiceName;
        }

        /// <summary>
        /// Constructer
        /// </summary>
        public NoSQLClient(ClientConfig config, IOciSigner ociSigner) : base(config, ociSigner)
        {
            ServiceName = NoSQLServiceName;
        }

        /// <summary>
        /// Constructer
        /// </summary>
        public NoSQLClient(ClientConfigStream config) : base(config)
        {
            ServiceName = NoSQLServiceName;
        }

        /// <summary>
        /// Constructer
        /// </summary>
        public NoSQLClient(ClientConfigStream config, IOciSigner ociSigner) : base(config, ociSigner)
        {
            ServiceName = NoSQLServiceName;
        }

        /// <summary>
        /// Create a new index on the table identified by tableNameOrId.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public CreateIndexResponse CreateIndex(CreateIndexRequest request)
        {
            var uri = new Uri(GetEndPoint(NoSQLServices.Tables, this.Region));

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                OpcRetryToken = request.OpcRetryToken,
                OpcRequestId = request.OpcRequestId
            };
            using (var webResponse = this.RestClient.Post(uri, request.CreateIndexDetails, httpRequestHeaderParam))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new CreateIndexResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcWorkRequestId = webResponse.Headers.Get("opc-work-request-id")
                };
            }
        }

        /// <summary>
        /// Get information about a single index.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public GetIndexResponse GetIndex(GetIndexRequest request)
        {
            var uriStr = $"{GetEndPoint(NoSQLServices.Tables, this.Region)}/{request.TableNameOrId}/{request.IndexName}";
            if (!string.IsNullOrEmpty(request.CompartmentId))
            {
                uriStr = $"{uriStr}?{request.CompartmentId}";
            }

            var uri = new Uri(uriStr);

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                OpcRequestId = request.OpcRequestId
            };
            using (var webResponse = this.RestClient.Get(uri, httpRequestHeaderParam))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new GetIndexResponse()
                {
                    Index = this.JsonSerializer.Deserialize<IndexDetails>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    Etag = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Get a single row from the table by primary key.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public GetRowResponse GetRow(GetRowRequest request)
        {
            var uriStr = $"{GetEndPoint(NoSQLServices.Tables, this.Region)}/{request.TableNameOrId}/rows";
            var optional = request.GetOptionalQuery();
            if (!string.IsNullOrEmpty(optional))
            {
                uriStr = $"{uriStr}?{optional}";
            }
            var uri = new Uri(uriStr);

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                OpcRequestId = request.OpcRequestId
            };
            using (var webResponse = this.RestClient.Get(uri, httpRequestHeaderParam))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new GetRowResponse()
                {
                    Row = this.JsonSerializer.Deserialize<RowDetails>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    Etag = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Prepare a SQL statement for use in a query with variable substitution.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public PrepareStatementResponse PrepareStatement(PrepareStatementRequest request)
        {
            var uriStr = GetEndPoint(NoSQLServices.Prepare, this.Region);
            var optional = request.GetOptionalQuery();
            if (!string.IsNullOrEmpty(optional))
            {
                uriStr = $"{uriStr}?{optional}";
            }

            var uri = new Uri(uriStr);

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                OpcRequestId = request.OpcRequestId
            };
            using (var webResponse = this.RestClient.Get(uri, httpRequestHeaderParam))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new PrepareStatementResponse()
                {
                    PreparedStatement = this.JsonSerializer.Deserialize<PreparedStatement>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Get a list of indexes on a table.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ListIndexesResponse ListIndexes(ListIndexesRequest request)
        {
            var uriStr = $"{GetEndPoint(NoSQLServices.Tables, this.Region)}/{request.TableNameOrId}";
            var optional = request.GetOptionalQuery();

            if (!string.IsNullOrEmpty(optional))
            {
                uriStr = $"{uriStr}?{optional}";
            }

            var uri = new Uri(uriStr);

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                OpcRequestId = request.OpcRequestId
            };
            using (var webResponse = this.RestClient.Get(uri, httpRequestHeaderParam))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListIndexesResponse()
                {
                    IndexCollection = this.JsonSerializer.Deserialize<IndexCollection>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
        }

        /// <summary>
        /// Check the syntax and return a brief summary of a SQL statement.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public SummarizeStatementResponse SummarizeStatement(SummarizeStatementRequest request)
        {
            var uriStr = GetEndPoint(NoSQLServices.Summarize, this.Region);
            var optional = request.GetOptionalQuery();
            var uri = new Uri($"{uriStr}?{optional}");

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                OpcRequestId = request.OpcRequestId
            };
            using (var webResponse = this.RestClient.Get(uri, httpRequestHeaderParam))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new SummarizeStatementResponse()
                {
                    StatementSummary = this.JsonSerializer.Deserialize<StatementSummary>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Execute a SQL query.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public QueryResponse Query(QueryRequest request)
        {
            var uriStr = GetEndPoint(NoSQLServices.Query, this.Region);
            var optional = request.GetOptionalQuery();

            if (!string.IsNullOrEmpty(optional))
            {
                uriStr = $"{uriStr}?{optional}";
            }

            var uri = new Uri(uriStr);

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                OpcRequestId = request.OpcRequestId
            };
            using (var webResponse = this.RestClient.Post(uri, request.QueryDetails, httpRequestHeaderParam))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new QueryResponse()
                {
                    QueryResultCollection = this.JsonSerializer.Deserialize<QueryResultCollection>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
        }

        /// <summary>
        /// Write a single row into the table.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public UpdateRowResponse UpdateRow(UpdateRowRequest request)
        {
            var uri = new Uri($"{GetEndPoint(NoSQLServices.Tables, this.Region)}/{request.TableNameOrId}/rows");

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                IfMatch = request.IfMatch,
                OpcRequestId = request.OpcRequestId
            };
            using (var webResponse = this.RestClient.Put(uri, request.UpdateRowDetails, httpRequestHeaderParam))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new UpdateRowResponse()
                {
                    UpdateRowResult = this.JsonSerializer.Deserialize<UpdateRowResult>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    Etag = webResponse.Headers.Get("etag")
                };
            }
        }

        /// <summary>
        /// Delete an index from the table identified by tableNameOrId.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public DeleteIndexResponse DeleteIndex(DeleteIndexRequest request)
        {
            var uriStr = $"{GetEndPoint(NoSQLServices.Tables, this.Region)}/{request.TableNameOrId}/{request.IndexName}";
            var optional = request.GetOptionalQuery();

            if (!string.IsNullOrEmpty(optional))
            {
                uriStr = $"{uriStr}?{optional}";
            }

            var uri = new Uri(uriStr);

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                IfMatch = request.IfMatch,
                OpcRequestId = request.OpcRequestId
            };
            using (var webResponse = this.RestClient.Delete(uri, httpRequestHeaderParam))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new DeleteIndexResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcWorkRequestId = webResponse.Headers.Get("opc-work-request-id")
                };
            }
        }

        /// <summary>
        /// Delete a single row from the table, by primary key.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public DeleteRowResponse DeleteRow(DeleteRowRequest request)
        {
            var uriStr = $"{GetEndPoint(NoSQLServices.Tables, this.Region)}/{request.TableNameOrId}/rows";
            var optional = request.GetOptionalQuery();

            if (!string.IsNullOrEmpty(optional))
            {
                uriStr = $"{uriStr}?{optional}";
            }

            var uri = new Uri(uriStr);

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                IfMatch = request.IfMatch,
                OpcRequestId = request.OpcRequestId
            };
            using (var webResponse = this.RestClient.Delete(uri, httpRequestHeaderParam))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new DeleteRowResponse()
                {
                    DeleteRowResult = this.JsonSerializer.Deserialize<DeleteRowResult>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Change a table's compartment.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ChangeTableCompartmentResponse ChangeTableCompartment(ChangeTableCompartmentRequest request)
        {
            var uriStr = $"{GetEndPoint(NoSQLServices.Tables, this.Region)}/{request.TableNameOrId}/actions/changeCompartment";
            var uri = new Uri(uriStr);

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                IfMatch = request.IfMatch,
                OpcRequestId = request.OpcRequestId,
                OpcRetryToken = request.OpcRetryToken
            };
            using (var webResponse = this.RestClient.Post(uri, request.ChangeTableCompartmentDetails, httpRequestHeaderParam))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ChangeTableCompartmentResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcWorkRequestId = webResponse.Headers.Get("opc-work-request-id")
                };
            }
        }

        /// <summary>
        /// Create a new table.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public CreateTableResponse CreateTable(CreateTableRequest request)
        {
            var uriStr = $"{GetEndPoint(NoSQLServices.Tables, this.Region)}";
            var uri = new Uri(uriStr);

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                OpcRequestId = request.OpcRequestId,
                OpcRetryToken = request.OpcRetryToken
            };
            using (var webResponse = this.RestClient.Post(uri, request.CreateTableDetails, httpRequestHeaderParam))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new CreateTableResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcWorkRequestId = webResponse.Headers.Get("opc-work-request-id")
                };
            }
        }

        /// <summary>
        /// Delete a table by tableNameOrId.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public DeleteTableResponse DeleteTable(DeleteTableRequest request)
        {
            var uriStr = $"{GetEndPoint(NoSQLServices.Tables, this.Region)}/{request.TableNameOrId}";
            var optional = request.GetOptionalQuery();

            if (!string.IsNullOrEmpty(optional))
            {
                uriStr = $"{uriStr}?{optional}";
            }

            var uri = new Uri(uriStr);

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                IfMatch = request.IfMatch,
                OpcRequestId = request.OpcRequestId
            };
            using (var webResponse = this.RestClient.Delete(uri, httpRequestHeaderParam))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new DeleteTableResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcWorkRequestId = webResponse.Headers.Get("opc-work-request-id")
                };
            }
        }

        /// <summary>
        /// Get table info by identifier.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public GetTableResponse GetTable(GetTableRequest request)
        {
            var uriStr = $"{GetEndPoint(NoSQLServices.Tables, this.Region)}/{request.TableNameOrId}";
            if (!string.IsNullOrEmpty(request.CompartmentId))
            {
                uriStr = $"{uriStr}?compartmentId={request.CompartmentId}";
            }

            var uri = new Uri(uriStr);

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                OpcRequestId = request.OpcRequestId
            };
            using (var webResponse = this.RestClient.Get(uri, httpRequestHeaderParam))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new GetTableResponse()
                {
                    Table = this.JsonSerializer.Deserialize<TableDetails>(response),
                    Etag = webResponse.Headers.Get("etag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Get a list of tables in a compartment.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ListTablesResponse ListTables(ListTablesRequest request)
        {
            var uriStr = GetEndPoint(NoSQLServices.Tables, this.Region);
            var optional = request.GetOptionalQuery();

            if (!string.IsNullOrEmpty(optional))
            {
                uriStr = $"{uriStr}?{optional}";
            }

            var uri = new Uri(uriStr);

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                OpcRequestId = request.OpcRequestId
            };
            using (var webResponse = this.RestClient.Get(uri, httpRequestHeaderParam))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListTablesResponse()
                {
                    TableCollection = this.JsonSerializer.Deserialize<TableCollection>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
        }

        /// <summary>
        /// Get table usage info.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ListTableUsageResponse ListTableUsage(ListTableUsageRequest request)
        {
            var uriStr = $"{GetEndPoint(NoSQLServices.Tables, this.Region)}/{request.TableNameOrId}/usage";
            var optional = request.GetOptionalQuery();

            if (!string.IsNullOrEmpty(optional))
            {
                uriStr = $"{uriStr}?{optional}";
            }

            var uri = new Uri(uriStr);

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                OpcRequestId = request.OpcRequestId
            };
            using (var webResponse = this.RestClient.Get(uri, httpRequestHeaderParam))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListTableUsageResponse()
                {
                    TableUsageCollection = this.JsonSerializer.Deserialize<TableUsageCollection>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
        }

        /// <summary>
        /// Alter the table identified by tableNameOrId, changing schema, limits, or tags
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public UpdateTableResponse UpdateTable(UpdateTableRequest request)
        {
            var uri = new Uri($"{GetEndPoint(NoSQLServices.Tables, this.Region)}/{request.TableNameOrId}");

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                IfMatch = request.IfMatch,
                OpcRequestId = request.OpcRequestId
            };
            using (var webResponse = this.RestClient.Put(uri, request.UpdateTableDetails, httpRequestHeaderParam))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new UpdateTableResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcWorkRequestId = webResponse.Headers.Get("opc-work-request-id")
                };
            }
        }
    }
}

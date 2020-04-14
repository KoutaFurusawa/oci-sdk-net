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
    }
}

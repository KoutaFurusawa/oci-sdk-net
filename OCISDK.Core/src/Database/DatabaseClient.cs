using OCISDK.Core.src.Database.Model;
using OCISDK.Core.src.Database.Request;
using OCISDK.Core.src.Database.Response;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OCISDK.Core.src.Database
{
    public class DatabaseClient : ServiceClient, IDatabaseClient
    {
        private readonly string DatabaseServiceName = "database";
        /// <summary>
        /// Constructer
        /// </summary>
        public DatabaseClient(ClientConfig config) : base(config)
        {
            ServiceName = DatabaseServiceName;
        }

        public DatabaseClient(ClientConfig config, OciSigner ociSigner) : base(config, ociSigner)
        {
            ServiceName = DatabaseServiceName;
        }

        public DatabaseClient(ClientConfigStream config) : base(config)
        {
            ServiceName = DatabaseServiceName;
        }

        public DatabaseClient(ClientConfigStream config, OciSigner ociSigner) : base(config, ociSigner)
        {
            ServiceName = DatabaseServiceName;
        }

        /// <summary>
        /// setter Region
        /// </summary>
        /// <param name="region"></param>
        public void SetRegion(string region)
        {
            Region = region;
        }

        /// <summary>
        /// getter region
        /// </summary>
        /// <returns></returns>
        public string GetRegion()
        {
            return Region;
        }

        /// <summary>
        /// Gets a list of the databases in the specified database home.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ListDatabasesResponse ListDatabases(ListDatabasesRequest request)
        {
            var uri = new Uri($"{GetEndPoint(DatabaseServices.Databases, this.Region)}?{request.GetOptionQuery()}");

            var webResponse = this.RestClient.Get(uri);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListDatabasesResponse()
                {
                    Items = this.JsonSerializer.Deserialize<List<DatabaseSummary>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
        }

        /// <summary>
        /// Gets a list of database homes in the specified DB system and compartment. 
        /// A database home is a directory where Oracle Database software is installed.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ListDbHomesResponse ListDbHomes(ListDbHomesRequest request)
        {
            var uri = new Uri($"{GetEndPoint(DatabaseServices.DbHomes, this.Region)}?{request.GetOptionQuery()}");

            var webResponse = this.RestClient.Get(uri);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListDbHomesResponse()
                {
                    Items = this.JsonSerializer.Deserialize<List<DbHomeSummary>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
        }

        /// <summary>
        /// Gets information about a specific database.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public GetDatabaseResponse GetDatabase(GetDatabaseRequest request)
        {
            var uri = new Uri($"{GetEndPoint(DatabaseServices.Databases, this.Region)}/{request.DatabaseId}");

            var webResponse = this.RestClient.Get(uri);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new GetDatabaseResponse()
                {
                    Database = this.JsonSerializer.Deserialize<DatabaseDetails>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    ETag = webResponse.Headers.Get("ETag")
                };
            }
        }

        /// <summary>
        /// Gets information about the specified database home.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public GetDbHomeResponse GetDbHome(GetDbHomeRequest request)
        {
            var uri = new Uri($"{GetEndPoint(DatabaseServices.DbHomes, this.Region)}/{request.DbHomeId}");

            var webResponse = this.RestClient.Get(uri);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new GetDbHomeResponse()
                {
                    DbHome = this.JsonSerializer.Deserialize<DbHomeDetails>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    ETag = webResponse.Headers.Get("ETag")
                };
            }
        }

        /// <summary>
        /// Restore a Database based on the request parameters you provide.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public RestoreDatabaseResponse RestoreDatabase(RestoreDatabaseRequest request)
        {
            var uri = new Uri($"{GetEndPoint(DatabaseServices.Databases, this.Region)}/{request.DatabaseId}/actions/resto");

            var webResponse = this.RestClient.Post(uri, request.RestoreDatabaseDetails, "", "", request.IfMatch);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new RestoreDatabaseResponse()
                {
                    DatabaseDetails = this.JsonSerializer.Deserialize<DatabaseDetails>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    ETag = webResponse.Headers.Get("ETag")
                };
            }
        }

        /// <summary>
        /// Creates a new database home in the specified DB system based on the request parameters you provide.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public CreateDbHomeWithDbSystemIdResponse CreateDbHome(CreateDbHomeWithDbSystemIdRequest request)
        {
            var uri = new Uri($"{GetEndPoint(DatabaseServices.DbHomes, this.Region)}");

            var webResponse = this.RestClient.Post(uri, request.CreateDbHomeWithDbSystemIdDetails, request.OpcRetryToken, "", "");

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new CreateDbHomeWithDbSystemIdResponse()
                {
                    DbHome = this.JsonSerializer.Deserialize<DbHomeDetails>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    ETag = webResponse.Headers.Get("ETag")
                };
            }
        }

        /// <summary>
        /// Creates a new database home in the specified DB system based on the request parameters you provide.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public CreateDbHomeWithDbSystemIdFromBackupResponse CreateDbHome(CreateDbHomeWithDbSystemIdFromBackupRequest request)
        {
            var uri = new Uri($"{GetEndPoint(DatabaseServices.DbHomes, this.Region)}");

            var webResponse = this.RestClient.Post(uri, request.CreateDbHomeWithDbSystemIdFromBackupDetails, request.OpcRetryToken, "", "");

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new CreateDbHomeWithDbSystemIdFromBackupResponse()
                {
                    DbHome = this.JsonSerializer.Deserialize<DbHomeDetails>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    ETag = webResponse.Headers.Get("ETag")
                };
            }
        }

        /// <summary>
        /// Update a Database based on the request parameters you provide.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public UpdateDatabaseResponse UpdateDatabase(UpdateDatabaseRequest request)
        {
            var uri = new Uri($"{GetEndPoint(DatabaseServices.Databases, this.Region)}/{request.DatabaseId}");

            var webResponse = this.RestClient.Put(uri, request.UpdateDatabaseDetails, request.IfMatch);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new UpdateDatabaseResponse()
                {
                    DatabaseDetails = this.JsonSerializer.Deserialize<DatabaseDetails>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    ETag = webResponse.Headers.Get("ETag")
                };
            }
        }

        /// <summary>
        /// Patches the specified dbHome.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public UpdateDbHomeResponse UpdateDbHome(UpdateDbHomeRequest request)
        {
            var uri = new Uri($"{GetEndPoint(DatabaseServices.DbHomes, this.Region)}/{request.DbHomeId}");

            var webResponse = this.RestClient.Put(uri, request.UpdateDbHomeDetails, request.IfMatch);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new UpdateDbHomeResponse()
                {
                    DbHome = this.JsonSerializer.Deserialize<DbHomeDetails>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    ETag = webResponse.Headers.Get("ETag")
                };
            }
        }

        /// <summary>
        /// Deletes a DB Home. The DB Home and its database data are local to the DB system and will be lost when it is deleted.
        /// Oracle recommends that you back up any data in the DB system prior to deleting it.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public DeleteDbHomeRsponse DeleteDbHome(DeleteDbHomeRequest request)
        {
            var uri = new Uri($"{GetEndPoint(DatabaseServices.DbHomes, this.Region)}/{request.DbHomeId}?performFinalBackup={request.PerformFinalBackup}");

            var webResponse = this.RestClient.Delete(uri, request.IfMatch);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new DeleteDbHomeRsponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }
    }
}

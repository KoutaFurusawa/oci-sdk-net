using OCISDK.Core.Common;
using OCISDK.Core.Database.Model;
using OCISDK.Core.Database.Request;
using OCISDK.Core.Database.Response;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace OCISDK.Core.Database
{
    /// <summary>
    /// DatabaseClientAsync
    /// </summary>
    public class DatabaseClientAsync : ServiceClient, IDatabaseClientAsync
    {
        private readonly string DatabaseServiceName = "database";

        /// <summary>
        /// Constructer
        /// </summary>
        public DatabaseClientAsync(ClientConfig config) : base(config)
        {
            ServiceName = DatabaseServiceName;
        }

        /// <summary>
        /// Constructer
        /// </summary>
        public DatabaseClientAsync(ClientConfig config, OciSigner ociSigner) : base(config, ociSigner)
        {
            ServiceName = DatabaseServiceName;
        }

        /// <summary>
        /// Constructer
        /// </summary>
        public DatabaseClientAsync(ClientConfigStream config) : base(config)
        {
            ServiceName = DatabaseServiceName;
        }

        /// <summary>
        /// Constructer
        /// </summary>
        public DatabaseClientAsync(ClientConfigStream config, OciSigner ociSigner) : base(config, ociSigner)
        {
            ServiceName = DatabaseServiceName;
        }
        
        /// <summary>
        /// Gets a list of the databases in the specified database home.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ListDatabasesResponse> ListDatabases(ListDatabasesRequest request)
        {
            var uri = new Uri($"{GetEndPoint(DatabaseServices.Databases, this.Region)}?{request.GetOptionQuery()}");

            var webResponse = await this.RestClientAsync.Get(uri);

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
        public async Task<ListDbHomesResponse> ListDbHomes(ListDbHomesRequest request)
        {
            var uri = new Uri($"{GetEndPoint(DatabaseServices.DbHomes, this.Region)}?{request.GetOptionQuery()}");

            var webResponse = await this.RestClientAsync.Get(uri);

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
        /// Gets a list of database nodes in the specified DB system and compartment. A database node is a server running database software.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ListDbNodesResponse> ListDbNodes(ListDbNodesRequest request)
        {
            var uri = new Uri($"{GetEndPoint(DatabaseServices.DbNodes, this.Region)}?{request.GetOptionQuery()}");

            var webResponse = await this.RestClientAsync.Get(uri);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListDbNodesResponse()
                {
                    Items = this.JsonSerializer.Deserialize<List<DbNodeSummary>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
        }

        /// <summary>
        /// Gets a list of the DB systems in the specified compartment. 
        /// You can specify a backupId to list only the DB systems that support creating a database using this backup in this compartment.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ListDbSystemsResponse> ListDbSystems(ListDbSystemsRequest request)
        {
            var uri = new Uri($"{GetEndPoint(DatabaseServices.DbSystems, this.Region)}?{request.GetOptionQuery()}");

            var webResponse = await this.RestClientAsync.Get(uri);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListDbSystemsResponse()
                {
                    Items = this.JsonSerializer.Deserialize<List<DbSystemSummary>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
        }

        /// <summary>
        /// Gets a list of supported Oracle Database versions.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ListDbVersionsResponse> ListDbVersions(ListDbVersionsRequest request)
        {
            var uri = new Uri($"{GetEndPoint(DatabaseServices.DbVersions, this.Region)}?{request.GetOptionQuery()}");

            var webResponse = await this.RestClientAsync.Get(uri);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListDbVersionsResponse()
                {
                    Items = this.JsonSerializer.Deserialize<List<DbVersionSummary>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
        }

        /// <summary>
        /// Gets a list of the shapes that can be used to launch a new DB system. 
        /// The shape determines resources to allocate to the DB system - CPU cores and memory for VM shapes; CPU cores, memory and storage for non-VM (or bare metal) shapes.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ListDbSystemShapesResponse> ListDbSystemShapes(ListDbSystemShapesRequest request)
        {
            var uri = new Uri($"{GetEndPoint(DatabaseServices.DbSystemShapes, this.Region)}?{request.GetOptionQuery()}");

            var webResponse = await this.RestClientAsync.Get(uri);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListDbSystemShapesResponse()
                {
                    Items = this.JsonSerializer.Deserialize<List<DbSystemShapeSummary>>(response),
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
        public async Task<GetDatabaseResponse> GetDatabase(GetDatabaseRequest request)
        {
            var uri = new Uri($"{GetEndPoint(DatabaseServices.Databases, this.Region)}/{request.DatabaseId}");

            var webResponse = await this.RestClientAsync.Get(uri);

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
        public async Task<GetDbHomeResponse> GetDbHome(GetDbHomeRequest request)
        {
            var uri = new Uri($"{GetEndPoint(DatabaseServices.DbHomes, this.Region)}/{request.DbHomeId}");

            var webResponse = await this.RestClientAsync.Get(uri);

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
        /// Gets information about the specified database node.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<GetDbNodeResponse> GetDbNode(GetDbNodeRequest request)
        {
            var uri = new Uri($"{GetEndPoint(DatabaseServices.DbNodes, this.Region)}/{request.DbNodeId}");

            var webResponse = await this.RestClientAsync.Get(uri);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new GetDbNodeResponse()
                {
                    DbNode = this.JsonSerializer.Deserialize<DbNodeDetails>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    ETag = webResponse.Headers.Get("ETag")
                };
            }
        }

        /// <summary>
        /// Gets information about the specified DB system.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<GetDbSystemResponse> GetDbSystem(GetDbSystemRequest request)
        {
            var uri = new Uri($"{GetEndPoint(DatabaseServices.DbSystems, this.Region)}/{request.DbSystemId}");

            var webResponse = await this.RestClientAsync.Get(uri);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new GetDbSystemResponse()
                {
                    DbSystem = this.JsonSerializer.Deserialize<DbSystemDetails>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    ETag = webResponse.Headers.Get("ETag")
                };
            }
        }

        /// <summary>
        /// Gets IORM Setting for the requested Exadata DB System. The default IORM Settings is pre-created in all the Exadata DB System.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<GetExadataIormConfigResponse> GetExadataIormConfig(GetExadataIormConfigRequest request)
        {
            var uri = new Uri($"{GetEndPoint(DatabaseServices.DbSystems, this.Region)}/{request.DbSystemId}/ExadataIormConfig");

            var webResponse = await this.RestClientAsync.Get(uri, new HttpRequestHeaderParam() { OpcRequestId = request.OpcRequestId });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new GetExadataIormConfigResponse()
                {
                    ExadataIormConfig = this.JsonSerializer.Deserialize<ExadataIormConfigDetails>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Move the DB system and its dependent resources to the specified compartment. 
        /// For more information about moving DB systems, see Moving Database Resources to a Different Compartment.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ChangeDbSystemCompartmentResponse> ChangeDbSystemCompartment(ChangeDbSystemCompartmentRequest request)
        {
            var uri = new Uri($"{GetEndPoint(DatabaseServices.DbSystems, this.Region)}/{request.DbSystemId}/actions/changeCompartment");

            var httpRequestHeaderParam = new HttpRequestHeaderParam() {
                OpcRetryToken = request.OpcRetryToken,
                OpcRequestId = request.OpcRequestId,
                IfMatch = request.IfMatch
            };
            var webResponse = await this.RestClientAsync.Post(uri, request.ChangeCompartmentDetails, httpRequestHeaderParam);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ChangeDbSystemCompartmentResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcWorkRequestId = webResponse.Headers.Get("opc-work-request-id"),
                    ETag = webResponse.Headers.Get("ETag")
                };
            }
        }

        /// <summary>
        /// Restore a Database based on the request parameters you provide.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<RestoreDatabaseResponse> RestoreDatabase(RestoreDatabaseRequest request)
        {
            var uri = new Uri($"{GetEndPoint(DatabaseServices.Databases, this.Region)}/{request.DatabaseId}/actions/resto");

            var webResponse = await this.RestClientAsync.Post(uri, request.RestoreDatabaseDetails, new HttpRequestHeaderParam() { IfMatch = request.IfMatch });

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
        public async Task<CreateDbHomeWithDbSystemIdResponse> CreateDbHome(CreateDbHomeWithDbSystemIdRequest request)
        {
            var uri = new Uri($"{GetEndPoint(DatabaseServices.DbHomes, this.Region)}");

            var webResponse = await this.RestClientAsync.Post(uri, request.CreateDbHomeWithDbSystemIdDetails, new HttpRequestHeaderParam() { OpcRetryToken = request.OpcRetryToken });

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
        public async Task<CreateDbHomeWithDbSystemIdResponse> CreateDbHome(CreateDbHomeWithDbSystemIdFromBackupRequest request)
        {
            var uri = new Uri($"{GetEndPoint(DatabaseServices.DbHomes, this.Region)}");

            var webResponse = await this.RestClientAsync.Post(uri, request.CreateDbHomeWithDbSystemIdFromBackupDetails, new HttpRequestHeaderParam() { OpcRetryToken = request.OpcRetryToken });

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
        /// Stopping a node affects billing differently, depending on the type of DB system:
        /// Bare metal and Exadata DB systems - The stop state has no effect on the resources you consume.Billing 
        /// continues for DB nodes that you stop, and related resources continue to apply against any relevant quotas.
        /// You must terminate the DB system (TerminateDbSystem) to remove its resources from billing and quotas.
        /// Virtual machine DB systems - Stopping a node stops billing for all OCPUs associated with that node, 
        /// and billing resumes when you restart the node.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<DbNodeActionResponse> DbNodeAction(DbNodeActionRequest request)
        {
            var uri = new Uri($"{GetEndPoint(DatabaseServices.DbNodes, this.Region)}/{request.DbNodeId}?action={request.Action.Value}");

            var headParam = new HttpRequestHeaderParam()
            {
                OpcRetryToken = request.OpcRetryToken,
                IfMatch = request.IfMatch
            };
            var webResponse = await this.RestClientAsync.Post(uri, null, headParam);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new DbNodeActionResponse()
                {
                    DbNode = this.JsonSerializer.Deserialize<DbNodeDetails>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    ETag = webResponse.Headers.Get("ETag")
                };
            }
        }

        /// <summary>
        /// Launches a new DB system in the specified compartment and availability domain.
        /// The Oracle Database edition that you specify applies to all the databases on that DB system. The selected edition cannot be changed.
        /// 
        /// An initial database is created on the DB system based on the request parameters you provide and some default options.
        /// For more information, see Default Options for the Initial Database.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<LaunchDbSystemResponse> LaunchDbSystem(LaunchDbSystemRequest request)
        {
            var uri = new Uri($"{GetEndPoint(DatabaseServices.DbSystems, this.Region)}");

            var webResponse = await this.RestClientAsync.Post(uri, request.LaunchDbSystemDetails, new HttpRequestHeaderParam() { OpcRetryToken = request.OpcRetryToken });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new LaunchDbSystemResponse()
                {
                    DbSystem = this.JsonSerializer.Deserialize<DbSystemDetails>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    ETag = webResponse.Headers.Get("ETag")
                };
            }
        }

        /// <summary>
        /// Launches a new DB system in the specified compartment and availability domain.
        /// The Oracle Database edition that you specify applies to all the databases on that DB system. The selected edition cannot be changed.
        /// 
        /// An initial database is created on the DB system based on the request parameters you provide and some default options.
        /// For more information, see Default Options for the Initial Database.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<LaunchDbSystemResponse> LaunchDbSystemFromBackup(LaunchDbSystemFromBackupRequest request)
        {
            var uri = new Uri($"{GetEndPoint(DatabaseServices.DbSystems, this.Region)}");

            var webResponse = await this.RestClientAsync.Post(uri, request.LaunchDbSystemFromBackupDetails, new HttpRequestHeaderParam() { OpcRetryToken = request.OpcRetryToken });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new LaunchDbSystemResponse()
                {
                    DbSystem = this.JsonSerializer.Deserialize<DbSystemDetails>(response),
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
        public async Task<UpdateDatabaseResponse> UpdateDatabase(UpdateDatabaseRequest request)
        {
            var uri = new Uri($"{GetEndPoint(DatabaseServices.Databases, this.Region)}/{request.DatabaseId}");

            var webResponse = await this.RestClientAsync.Put(uri, request.UpdateDatabaseDetails, new HttpRequestHeaderParam() { IfMatch = request.IfMatch });

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
        public async Task<UpdateDbHomeResponse> UpdateDbHome(UpdateDbHomeRequest request)
        {
            var uri = new Uri($"{GetEndPoint(DatabaseServices.DbHomes, this.Region)}/{request.DbHomeId}");

            var webResponse = await this.RestClientAsync.Put(uri, request.UpdateDbHomeDetails, new HttpRequestHeaderParam() { IfMatch = request.IfMatch });

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
        /// Updates the properties of a DB system, such as the CPU core count.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<UpdateDbSystemResponse> UpdateDbSystem(UpdateDbSystemRequest request)
        {
            var uri = new Uri($"{GetEndPoint(DatabaseServices.DbSystems, this.Region)}/{request.DbSystemId}");

            var webResponse = await this.RestClientAsync.Put(uri, request.UpdateDbSystemDetails, new HttpRequestHeaderParam() { IfMatch = request.IfMatch });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new UpdateDbSystemResponse()
                {
                    DbSystem = this.JsonSerializer.Deserialize<DbSystemDetails>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    ETag = webResponse.Headers.Get("ETag")
                };
            }
        }

        /// <summary>
        /// Update IORM Settings for the requested Exadata DB System.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<UpdateExadataIormConfigResponse> UpdateExadataIormConfig(UpdateExadataIormConfigRequest request)
        {
            var uri = new Uri($"{GetEndPoint(DatabaseServices.DbSystems, this.Region)}/{request.DbSystemId}/ExadataIormConfig");

            var httpRequestHeaderParam = new HttpRequestHeaderParam() {
                IfMatch = request.IfMatch,
                OpcRequestId = request.OpcRequestId
            };
            var webResponse = await this.RestClientAsync.Put(uri, request.ExadataIormConfigUpdateDetails, httpRequestHeaderParam);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new UpdateExadataIormConfigResponse()
                {
                    ExadataIormConfig = this.JsonSerializer.Deserialize<ExadataIormConfigDetails>(response),
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
        public async Task<DeleteDbHomeResponse> DeleteDbHome(DeleteDbHomeRequest request)
        {
            var uri = new Uri($"{GetEndPoint(DatabaseServices.DbHomes, this.Region)}/{request.DbHomeId}?performFinalBackup={request.PerformFinalBackup}");

            var webResponse = await this.RestClientAsync.Delete(uri, new HttpRequestHeaderParam() { IfMatch = request.IfMatch });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new DeleteDbHomeResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Terminates a DB system and permanently deletes it and any databases running on it, and any storage volumes attached to it. 
        /// The database data is local to the DB system and will be lost when the system is terminated. 
        /// Oracle recommends that you back up any data in the DB system prior to terminating it.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<TerminateDbSystemResponse> TerminateDbSystem(TerminateDbSystemRequest request)
        {
            var uri = new Uri($"{GetEndPoint(DatabaseServices.DbSystems, this.Region)}/{request.DbSystemId}");

            var webResponse = await this.RestClientAsync.Delete(uri, new HttpRequestHeaderParam() { IfMatch = request.IfMatch });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new TerminateDbSystemResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }
    }
}

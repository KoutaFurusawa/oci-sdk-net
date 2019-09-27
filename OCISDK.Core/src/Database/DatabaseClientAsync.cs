﻿using OCISDK.Core.src.Database.Model;
using OCISDK.Core.src.Database.Request;
using OCISDK.Core.src.Database.Response;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace OCISDK.Core.src.Database
{
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

        public DatabaseClientAsync(ClientConfig config, OciSigner ociSigner) : base(config, ociSigner)
        {
            ServiceName = DatabaseServiceName;
        }

        public DatabaseClientAsync(ClientConfigStream config) : base(config)
        {
            ServiceName = DatabaseServiceName;
        }

        public DatabaseClientAsync(ClientConfigStream config, OciSigner ociSigner) : base(config, ociSigner)
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

            var webResponse = await this.RestClientAsync.Get(uri, request.OpcRequestId);

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

            var webResponse = await this.RestClientAsync.Post(uri, request.ChangeCompartmentDetails, request.OpcRetryToken, request.OpcRequestId, request.IfMatch);

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

            var webResponse = await this.RestClientAsync.Post(uri, request.RestoreDatabaseDetails, "", "", request.IfMatch);

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

            var webResponse = await this.RestClientAsync.Post(uri, request.CreateDbHomeWithDbSystemIdDetails, request.OpcRetryToken, "", "");

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

            var webResponse = await this.RestClientAsync.Post(uri, request.CreateDbHomeWithDbSystemIdFromBackupDetails, request.OpcRetryToken, "", "");

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

            var webResponse = await this.RestClientAsync.Post(uri, request.LaunchDbSystemDetails, request.OpcRetryToken, "", "");

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

            var webResponse = await this.RestClientAsync.Post(uri, request.LaunchDbSystemFromBackupDetails, request.OpcRetryToken, "", "");

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

            var webResponse = await this.RestClientAsync.Put(uri, request.UpdateDatabaseDetails, request.IfMatch);

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

            var webResponse = await this.RestClientAsync.Put(uri, request.UpdateDbHomeDetails, request.IfMatch);

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

            var webResponse = await this.RestClientAsync.Put(uri, request.UpdateDbSystemDetails, request.IfMatch);

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

            var webResponse = await this.RestClientAsync.Put(uri, request.ExadataIormConfigUpdateDetails, request.IfMatch, request.OpcRequestId);

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
        public async Task<DeleteDbHomeRsponse> DeleteDbHome(DeleteDbHomeRequest request)
        {
            var uri = new Uri($"{GetEndPoint(DatabaseServices.DbHomes, this.Region)}/{request.DbHomeId}?performFinalBackup={request.PerformFinalBackup}");

            var webResponse = await this.RestClientAsync.Delete(uri, request.IfMatch);

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

            var webResponse = await this.RestClientAsync.Delete(uri, request.IfMatch);

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
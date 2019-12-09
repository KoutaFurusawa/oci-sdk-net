using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OCISDK.Core.Database.Request;
using OCISDK.Core.Database.Response;

namespace OCISDK.Core.Database
{
    /// <summary>
    /// IDatabaseClient Async interface
    /// </summary>
    public interface IDatabaseClientAsync : IClientSetting
    {
        /// <summary>
        /// Gets a list of the databases in the specified database home.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ListDatabasesResponse> ListDatabases(ListDatabasesRequest request);

        /// <summary>
        /// Gets a list of database homes in the specified DB system and compartment. 
        /// A database home is a directory where Oracle Database software is installed.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ListDbHomesResponse> ListDbHomes(ListDbHomesRequest request);

        /// <summary>
        /// Gets a list of database nodes in the specified DB system and compartment. A database node is a server running database software.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ListDbNodesResponse> ListDbNodes(ListDbNodesRequest request);

        /// <summary>
        /// Gets a list of the DB systems in the specified compartment. 
        /// You can specify a backupId to list only the DB systems that support creating a database using this backup in this compartment.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ListDbSystemsResponse> ListDbSystems(ListDbSystemsRequest request);

        /// <summary>
        /// Gets a list of supported Oracle Database versions.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ListDbVersionsResponse> ListDbVersions(ListDbVersionsRequest request);

        /// <summary>
        /// Gets a list of the shapes that can be used to launch a new DB system. 
        /// The shape determines resources to allocate to the DB system - CPU cores and memory for VM shapes; CPU cores, memory and storage for non-VM (or bare metal) shapes.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ListDbSystemShapesResponse> ListDbSystemShapes(ListDbSystemShapesRequest request);

        /// <summary>
        /// Gets information about a specific database.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<GetDatabaseResponse> GetDatabase(GetDatabaseRequest request);

        /// <summary>
        /// Gets information about the specified database home.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<GetDbHomeResponse> GetDbHome(GetDbHomeRequest request);

        /// <summary>
        /// Gets information about the specified database node.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<GetDbNodeResponse> GetDbNode(GetDbNodeRequest request);

        /// <summary>
        /// Gets information about the specified DB system.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<GetDbSystemResponse> GetDbSystem(GetDbSystemRequest request);

        /// <summary>
        /// Gets IORM Setting for the requested Exadata DB System. The default IORM Settings is pre-created in all the Exadata DB System.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<GetExadataIormConfigResponse> GetExadataIormConfig(GetExadataIormConfigRequest request);

        /// <summary>
        /// Move the DB system and its dependent resources to the specified compartment. 
        /// For more information about moving DB systems, see Moving Database Resources to a Different Compartment.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ChangeDbSystemCompartmentResponse> ChangeDbSystemCompartment(ChangeDbSystemCompartmentRequest request);

        /// <summary>
        /// Restore a Database based on the request parameters you provide.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<RestoreDatabaseResponse> RestoreDatabase(RestoreDatabaseRequest request);

        /// <summary>
        /// Creates a new database home in the specified DB system based on the request parameters you provide.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<CreateDbHomeWithDbSystemIdResponse> CreateDbHome(CreateDbHomeWithDbSystemIdRequest request);

        /// <summary>
        /// Creates a new database home in the specified DB system based on the request parameters you provide.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<CreateDbHomeWithDbSystemIdResponse> CreateDbHome(CreateDbHomeWithDbSystemIdFromBackupRequest request);

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
        Task<DbNodeActionResponse> DbNodeAction(DbNodeActionRequest request);

        /// <summary>
        /// Launches a new DB system in the specified compartment and availability domain.
        /// The Oracle Database edition that you specify applies to all the databases on that DB system. The selected edition cannot be changed.
        /// 
        /// An initial database is created on the DB system based on the request parameters you provide and some default options.
        /// For more information, see Default Options for the Initial Database.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<LaunchDbSystemResponse> LaunchDbSystem(LaunchDbSystemRequest request);

        /// <summary>
        /// Launches a new DB system in the specified compartment and availability domain.
        /// The Oracle Database edition that you specify applies to all the databases on that DB system. The selected edition cannot be changed.
        /// 
        /// An initial database is created on the DB system based on the request parameters you provide and some default options.
        /// For more information, see Default Options for the Initial Database.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<LaunchDbSystemResponse> LaunchDbSystemFromBackup(LaunchDbSystemFromBackupRequest request);

        /// <summary>
        /// Update a Database based on the request parameters you provide.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<UpdateDatabaseResponse> UpdateDatabase(UpdateDatabaseRequest request);

        /// <summary>
        /// Patches the specified dbHome.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<UpdateDbHomeResponse> UpdateDbHome(UpdateDbHomeRequest request);

        /// <summary>
        /// Updates the properties of a DB system, such as the CPU core count.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<UpdateDbSystemResponse> UpdateDbSystem(UpdateDbSystemRequest request);

        /// <summary>
        /// Update IORM Settings for the requested Exadata DB System.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<UpdateExadataIormConfigResponse> UpdateExadataIormConfig(UpdateExadataIormConfigRequest request);

        /// <summary>
        /// Deletes a DB Home. The DB Home and its database data are local to the DB system and will be lost when it is deleted.
        /// Oracle recommends that you back up any data in the DB system prior to deleting it.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<DeleteDbHomeResponse> DeleteDbHome(DeleteDbHomeRequest request);

        /// <summary>
        /// Terminates a DB system and permanently deletes it and any databases running on it, and any storage volumes attached to it. 
        /// The database data is local to the DB system and will be lost when the system is terminated. 
        /// Oracle recommends that you back up any data in the DB system prior to terminating it.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<TerminateDbSystemResponse> TerminateDbSystem(TerminateDbSystemRequest request);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using OCISDK.Core.src.Database.Request;
using OCISDK.Core.src.Database.Response;

namespace OCISDK.Core.src.Database
{
    public interface IDatabaseClient
    {
        /// <summary>
        /// Gets a list of the databases in the specified database home.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ListDatabasesResponse ListDatabases(ListDatabasesRequest request);

        /// <summary>
        /// Gets a list of database homes in the specified DB system and compartment. 
        /// A database home is a directory where Oracle Database software is installed.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ListDbHomesResponse ListDbHomes(ListDbHomesRequest request);

        /// <summary>
        /// Gets a list of the DB systems in the specified compartment. 
        /// You can specify a backupId to list only the DB systems that support creating a database using this backup in this compartment.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ListDbSystemsResponse ListDbSystems(ListDbSystemsRequest request);

        /// <summary>
        /// Gets a list of supported Oracle Database versions.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ListDbVersionsResponse ListDbVersions(ListDbVersionsRequest request);

        /// <summary>
        /// Gets information about a specific database.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        GetDatabaseResponse GetDatabase(GetDatabaseRequest request);

        /// <summary>
        /// Gets information about the specified database home.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        GetDbHomeResponse GetDbHome(GetDbHomeRequest request);

        /// <summary>
        /// Gets information about the specified DB system.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        GetDbSystemResponse GetDbSystem(GetDbSystemRequest request);

        /// <summary>
        /// Gets IORM Setting for the requested Exadata DB System. The default IORM Settings is pre-created in all the Exadata DB System.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        GetExadataIormConfigResponse GetExadataIormConfig(GetExadataIormConfigRequest request);

        /// <summary>
        /// Move the DB system and its dependent resources to the specified compartment. 
        /// For more information about moving DB systems, see Moving Database Resources to a Different Compartment.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ChangeDbSystemCompartmentResponse ChangeDbSystemCompartment(ChangeDbSystemCompartmentRequest request);

        /// <summary>
        /// Restore a Database based on the request parameters you provide.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        RestoreDatabaseResponse RestoreDatabase(RestoreDatabaseRequest request);
        
        /// <summary>
        /// Creates a new database home in the specified DB system based on the request parameters you provide.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        CreateDbHomeWithDbSystemIdResponse CreateDbHome(CreateDbHomeWithDbSystemIdRequest request);

        /// <summary>
        /// Creates a new database home in the specified DB system based on the request parameters you provide.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        CreateDbHomeWithDbSystemIdResponse CreateDbHome(CreateDbHomeWithDbSystemIdFromBackupRequest request);

        /// <summary>
        /// Launches a new DB system in the specified compartment and availability domain.
        /// The Oracle Database edition that you specify applies to all the databases on that DB system. The selected edition cannot be changed.
        /// 
        /// An initial database is created on the DB system based on the request parameters you provide and some default options.
        /// For more information, see Default Options for the Initial Database.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        LaunchDbSystemResponse LaunchDbSystem(LaunchDbSystemRequest request);

        /// <summary>
        /// Launches a new DB system in the specified compartment and availability domain.
        /// The Oracle Database edition that you specify applies to all the databases on that DB system. The selected edition cannot be changed.
        /// 
        /// An initial database is created on the DB system based on the request parameters you provide and some default options.
        /// For more information, see Default Options for the Initial Database.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        LaunchDbSystemResponse LaunchDbSystemFromBackup(LaunchDbSystemFromBackupRequest request);

        /// <summary>
        /// Update a Database based on the request parameters you provide.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        UpdateDatabaseResponse UpdateDatabase(UpdateDatabaseRequest request);

        /// <summary>
        /// Patches the specified dbHome.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        UpdateDbHomeResponse UpdateDbHome(UpdateDbHomeRequest request);

        /// <summary>
        /// Updates the properties of a DB system, such as the CPU core count.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        UpdateDbSystemResponse UpdateDbSystem(UpdateDbSystemRequest request);

        /// <summary>
        /// Update IORM Settings for the requested Exadata DB System.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        UpdateExadataIormConfigResponse UpdateExadataIormConfig(UpdateExadataIormConfigRequest request);

        /// <summary>
        /// Deletes a DB Home. The DB Home and its database data are local to the DB system and will be lost when it is deleted.
        /// Oracle recommends that you back up any data in the DB system prior to deleting it.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        DeleteDbHomeRsponse DeleteDbHome(DeleteDbHomeRequest request);

        /// <summary>
        /// Terminates a DB system and permanently deletes it and any databases running on it, and any storage volumes attached to it. 
        /// The database data is local to the DB system and will be lost when the system is terminated. 
        /// Oracle recommends that you back up any data in the DB system prior to terminating it.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        TerminateDbSystemResponse TerminateDbSystem(TerminateDbSystemRequest request);
    }
}

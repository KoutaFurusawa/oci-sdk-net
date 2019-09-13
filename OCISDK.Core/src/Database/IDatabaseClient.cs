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
        CreateDbHomeWithDbSystemIdFromBackupResponse CreateDbHome(CreateDbHomeWithDbSystemIdFromBackupRequest request);

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
        /// Deletes a DB Home. The DB Home and its database data are local to the DB system and will be lost when it is deleted.
        /// Oracle recommends that you back up any data in the DB system prior to deleting it.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        DeleteDbHomeRsponse DeleteDbHome(DeleteDbHomeRequest request);
    }
}

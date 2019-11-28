using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Database
{
    /// <summary>
    /// Database Services
    /// </summary>
    public class DatabaseServices
    {
        /// <summary>
        /// autonomousContainerDatabases
        /// </summary>
        public readonly static string AutonomousContainerDatabases = "autonomousContainerDatabases";
        /// <summary>
        /// autonomousDatabases
        /// </summary>
        public readonly static string AutonomousDatabases = "autonomousDatabases";
        /// <summary>
        /// autonomousDatabaseBackups
        /// </summary>
        public readonly static string AutonomousDatabaseBackups = "autonomousDatabaseBackups";
        /// <summary>
        /// autonomousDataWarehouses
        /// </summary>
        public readonly static string AutonomousDataWarehouses = "autonomousDataWarehouses";
        /// <summary>
        /// autonomousDataWarehouseBackups
        /// </summary>
        public readonly static string AutonomousDataWarehouseBackups = "autonomousDataWarehouseBackups";
        /// <summary>
        /// autonomousDbPreviewVersions
        /// </summary>
        public readonly static string AutonomousDbPreviewVersions = "autonomousDbPreviewVersions";
        /// <summary>
        /// autonomousExadataInfrastructures
        /// </summary>
        public readonly static string AutonomousExadataInfrastructures = "autonomousExadataInfrastructures";
        /// <summary>
        /// autonomousExadataInfrastructureShapes
        /// </summary>
        public readonly static string AutonomousExadataInfrastructureShapes = "autonomousExadataInfrastructureShapes";
        /// <summary>
        /// backups
        /// </summary>
        public readonly static string Backups = "backups";
        /// <summary>
        /// databases
        /// </summary>
        public readonly static string Databases = "databases";
        /// <summary>
        /// dbHomes
        /// </summary>
        public readonly static string DbHomes = "dbHomes";
        /// <summary>
        /// dbNodes
        /// </summary>
        public readonly static string DbNodes = "dbNodes";
        /// <summary>
        /// dbSystems
        /// </summary>
        public readonly static string DbSystems = "dbSystems";
        /// <summary>
        /// dbSystemShapes
        /// </summary>
        public readonly static string DbSystemShapes = "dbSystemShapes";
        /// <summary>
        /// dbVersions
        /// </summary>
        public readonly static string DbVersions = "dbVersions";
        /// <summary>
        /// externalBackupJobs
        /// </summary>
        public readonly static string ExternalBackupJobs = "externalBackupJobs";
        /// <summary>
        /// maintenanceRuns
        /// </summary>
        public readonly static string MaintenanceRuns = "maintenanceRuns";

        /// <summary>
        /// DataGuardAssociations endpoint
        /// </summary>
        /// <param name="databaseId"></param>
        /// <returns></returns>
        public static string DataGuardAssociations(string databaseId) {
            return $"databases/{databaseId}/dataGuardAssociations";
        }

        /// <summary>
        /// Patches endpoint
        /// </summary>
        /// <param name="dbSystemId"></param>
        /// <returns></returns>
        public static string Patches(string dbSystemId) {
            return $"dbSystems/{dbSystemId}/patches";
        }

        /// <summary>
        /// PatchHistoryEntries endpoint
        /// </summary>
        /// <param name="dbHomeId"></param>
        /// <returns></returns>
        public static string PatchHistoryEntries(string dbHomeId)
        {
            return $"dbHomes/{dbHomeId}/patchHistoryEntries";
        }
    }
}

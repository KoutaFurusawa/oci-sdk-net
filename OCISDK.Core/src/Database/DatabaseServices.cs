using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.src.Database
{
    public class DatabaseServices
    {
        public readonly static string AutonomousContainerDatabases = "autonomousContainerDatabases";
        public readonly static string AutonomousDatabases = "autonomousDatabases";
        public readonly static string AutonomousDatabaseBackups = "autonomousDatabaseBackups";
        public readonly static string AutonomousDataWarehouses = "autonomousDataWarehouses";
        public readonly static string AutonomousDataWarehouseBackups = "autonomousDataWarehouseBackups";
        public readonly static string AutonomousDbPreviewVersions = "autonomousDbPreviewVersions";
        public readonly static string AutonomousExadataInfrastructures = "autonomousExadataInfrastructures";
        public readonly static string AutonomousExadataInfrastructureShapes = "autonomousExadataInfrastructureShapes";
        public readonly static string Backups = "backups";
        public readonly static string Databases = "databases";
        public readonly static string DbHomes = "dbHomes";
        public readonly static string DbNodes = "dbNodes";
        public readonly static string DbSystems = "dbSystems";
        public readonly static string DbSystemShapes = "dbSystemShapes";
        public readonly static string DbVersions = "dbVersions";
        public readonly static string ExternalBackupJobs = "externalBackupJobs";
        public readonly static string MaintenanceRuns = "maintenanceRuns";

        public static string DataGuardAssociations(string databaseId) {
            return $"databases/{databaseId}/dataGuardAssociations";
        }

        public static string Patches(string dbSystemId) {
            return $"dbSystems/{dbSystemId}/patches";
        }

        public static string PatchHistoryEntries(string dbHomeId)
        {
            return $"dbHomes/{dbHomeId}/patchHistoryEntries";
        }
    }
}

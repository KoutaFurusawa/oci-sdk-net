using OCISDK.Core;
using OCISDK.Core.Common;
using OCISDK.Core.Database;
using OCISDK.Core.Database.Request;
using OCISDK.Core.Identity;
using OCISDK.Core.Identity.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace Example
{
    class DatabaseExample
    {
        public static void DatabaseConsoleDisplay(ClientConfig config)
        {
            var identityClient = new IdentityClient(config)
            {
                Region = Regions.US_ASHBURN_1
            };

            var databaseClient = new DatabaseClient(config);

            var listCompartmentRequest = new ListCompartmentRequest() {
                CompartmentId = config.TenancyId,
                CompartmentIdInSubtree = true,
                AccessLevel = ListCompartmentRequest.AccessLevels.ACCESSIBLE
            };
            var compartments = identityClient.ListCompartment(listCompartmentRequest).Items;

            Console.WriteLine("* Database------------------------");
            foreach (var com in compartments)
            {
                if (com.LifecycleState != "ACTIVE") {
                    continue;
                }
                var listDbHomesRequest = new ListDbHomesRequest() {
                    CompartmentId = com.Id,
                    
                };
                var dbHomes = databaseClient.ListDbHomes(listDbHomesRequest).Items;

                foreach (var home in dbHomes)
                {
                    Console.WriteLine($" DatabaseHome: {home.DisplayName}");
                    var listDatabasesRequest = new ListDatabasesRequest()
                    {
                        CompartmentId = com.Id,
                        DbHomeId = home.Id
                    };
                    var databases = databaseClient.ListDatabases(listDatabasesRequest).Items;

                    foreach (var database in databases)
                    {
                        Console.WriteLine($"\t|- name: {database.DbName}");
                        Console.WriteLine($"\t|  state: {database.LifecycleState}");
                        Console.WriteLine($"\t|  lifecycle: {database.LifecycleDetails}");
                        Console.WriteLine($"\t|  time: {database.TimeCreated}");
                    }
                }
            }

            Console.WriteLine("* DatabaseShapes------------------------");
            foreach (var com in compartments)
            {
                if (com.LifecycleState != "ACTIVE")
                {
                    continue;
                }

                var listDbSystemShapesRequest = new ListDbSystemShapesRequest()
                {
                    CompartmentId = com.Id
                };
                var dbShapes = databaseClient.ListDbSystemShapes(listDbSystemShapesRequest).Items;

                foreach (var shape in dbShapes)
                {
                    Console.WriteLine($"\t|- name: {shape.Name}");
                    Console.WriteLine($"\t|  shape: {shape.Shape}");
                    Console.WriteLine($"\t|  shapeFamily: {shape.ShapeFamily}");
                    Console.WriteLine($"\t|  availableCoreCount: {shape.AvailableCoreCount}");
                    Console.WriteLine($"\t|  coreCountIncrement: {shape.CoreCountIncrement}");
                    Console.WriteLine($"\t|  maximumNodeCount: {shape.MaximumNodeCount}");
                    Console.WriteLine($"\t|  minimumCoreCount: {shape.MinimumCoreCount}");
                    Console.WriteLine($"\t|  minimumNodeCount: {shape.MinimumNodeCount}");
                }
            }

            Console.WriteLine("* DatabaseVersions------------------------");
            foreach (var com in compartments)
            {
                if (com.LifecycleState != "ACTIVE")
                {
                    continue;
                }

                var listDbVersionsRequest = new ListDbVersionsRequest() {
                    CompartmentId = com.Id
                };
                var dbVersions = databaseClient.ListDbVersions(listDbVersionsRequest).Items;

                foreach (var version in dbVersions)
                {
                    Console.WriteLine($"\t|- version: {version.Version}");
                    Console.WriteLine($"\t|  supportsPdb: {version.SupportsPdb}");
                    Console.WriteLine($"\t|  isLatestForMajorVersion: {version.IsLatestForMajorVersion}");
                }
            }
        }
    }
}

using OCISDK.Core;
using OCISDK.Core.Common;
using OCISDK.Core.Identity;
using OCISDK.Core.Identity.Model;
using OCISDK.Core.Identity.Request;
using OCISDK.Core.ObjectStorage;
using OCISDK.Core.ObjectStorage.IO;
using OCISDK.Core.ObjectStorage.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace Example
{
    class ObjectStorageDirectoryInfoExample
    {
        public static void Example(ClientConfig config)
        {
            ThreadSafeSigner threadSafeSigner = new ThreadSafeSigner(new OciSigner(config));
            var client = new ObjectStorageClient(config, threadSafeSigner)
            {
                Region = Regions.AP_TOKYO_1
            };

            var identityClient = new IdentityClient(config, threadSafeSigner)
            {
                Region = Regions.AP_TOKYO_1
            };

            var nameSpaceName = client.GetNamespace(new GetNamespaceRequest());

            // Compartment required only to get a bucket
            var listCompartmentRequest = new ListCompartmentRequest()
            {
                CompartmentId = config.TenancyId,
                CompartmentIdInSubtree = true,
                AccessLevel = ListCompartmentRequest.AccessLevels.ACCESSIBLE
            };
            /*var compartments = identityClient.ListCompartment(listCompartmentRequest).Items;
            // root(tenant) add
            compartments.Add(new OCISDK.Core.Identity.Model.Compartment { Id = config.TenancyId, Name = "root" });*/
            List<Compartment> compartments = new List<Compartment>();
            compartments.Add(identityClient.GetCompartment(new GetCompartmentRequest { CompartmentId = "ocid1.compartment.oc1..aaaaaaaaibq365qp5tws2vhuvd3vhzwphtwx4zlhybjrrvwarjrmeud4jiya" }).Compartment);

            foreach (var compartment in compartments)
            {
                ListBucketsRequest listBucketsRequest = new ListBucketsRequest
                {
                    NamespaceName = nameSpaceName,
                    CompartmentId = compartment.Id,
                    Limit = 10
                };
                var bukcets = client.ListBuckets(listBucketsRequest);

                foreach (var bukcet in bukcets.Items)
                {
                    ObjectStorageDirectoryInfo directoryInfo = new ObjectStorageDirectoryInfo(client, nameSpaceName, bukcet.Name);

                    Console.WriteLine($"* {bukcet.Name}");

                    // top files
                    var files = directoryInfo.EnumerateFiles("*", System.IO.SearchOption.TopDirectoryOnly);
                    foreach (var file in files)
                    {
                        Console.WriteLine($"\t|- {file.Name}");
                    }

                    // top directories and files
                    var topDirs = directoryInfo.EnumerateDirectories("*", System.IO.SearchOption.TopDirectoryOnly);

                    foreach (var dir in topDirs)
                    {
                        Console.WriteLine($"\t|- {dir.Name}");
                        files = dir.EnumerateFiles("*", System.IO.SearchOption.TopDirectoryOnly);

                        foreach (var file in files)
                        {
                            Console.WriteLine($"\t|\t|- {file.Name}");
                        }

                        // sub directories and files
                        var subDirInfo = new ObjectStorageDirectoryInfo(client, nameSpaceName, bukcet.Name, dir.Name+"/");
                        var subDirs = subDirInfo.EnumerateDirectories("*", System.IO.SearchOption.TopDirectoryOnly);

                        foreach (var sub in subDirs)
                        {
                            Console.WriteLine($"\t|\t|- {sub.Name}");
                            files = sub.EnumerateFiles("*", System.IO.SearchOption.TopDirectoryOnly);

                            foreach (var file in files)
                            {
                                Console.WriteLine($"\t|\t|\t|- {file.Name}");
                            }
                        }
                    }

                    foreach (var dir in topDirs)
                    {
                        // prefix directories
                        Console.WriteLine("TopDirectoryOnly prefix-----[" + dir.Name + "]");
                        var preDir = new ObjectStorageDirectoryInfo(client, nameSpaceName, bukcet.Name, dir.Name);
                        var preFiles = preDir.EnumerateFiles("*", System.IO.SearchOption.TopDirectoryOnly);

                        foreach (var file in preFiles)
                        {
                            Console.WriteLine($"\t|- {file.FullName}");
                        }
                    }


                    foreach (var dir in topDirs)
                    {
                        // prefix directories
                        Console.WriteLine("AllDirectories prefix-----[" + dir.Name + "]");
                        var preDir = new ObjectStorageDirectoryInfo(client, nameSpaceName, bukcet.Name, dir.Name);
                        var preFiles = preDir.EnumerateFiles("*", System.IO.SearchOption.AllDirectories);

                        foreach (var file in preFiles)
                        {
                            Console.WriteLine($"\t|- {file.FullName}");
                        }
                    }
                }
            }
        }
    }
}

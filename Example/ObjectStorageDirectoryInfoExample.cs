using OCISDK.Core;
using OCISDK.Core.Common;
using OCISDK.Core.Identity;
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
            var compartments = identityClient.ListCompartment(listCompartmentRequest).Items;
            // root(tenant) add
            compartments.Add(new OCISDK.Core.Identity.Model.Compartment { Id = config.TenancyId, Name = "root" });

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

                    // all directories
                    var topDirs = directoryInfo.EnumerateDirectories("*", System.IO.SearchOption.AllDirectories);

                    foreach (var dir in topDirs)
                    {
                        Console.WriteLine($"\t|- Dir name:{dir.Name}");
                        files = dir.EnumerateFiles("*", System.IO.SearchOption.TopDirectoryOnly);

                        foreach (var file in files)
                        {
                            Console.WriteLine($"\t|\t|- {file.Name}");
                        }
                    }
                }
            }
        }
    }
}

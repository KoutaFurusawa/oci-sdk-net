using OCISDK.Core;
using OCISDK.Core.Common;
using OCISDK.Core.Identity;
using OCISDK.Core.Identity.Request;
using OCISDK.Core.ObjectStorage;
using OCISDK.Core.ObjectStorage.Model;
using OCISDK.Core.ObjectStorage.Request;
using OCISDK.Core.ObjectStorage.Response;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Example
{
    class ObjectStorageExample
    {
        public static void DisplayObjectStorage(ClientConfig config)
        {
            var client = new ObjectStorageClient(config)
            {
                Region = Regions.US_ASHBURN_1
            };

            var identityClient = new IdentityClient(config)
            {
                Region = Regions.US_ASHBURN_1
            };

            // get namespace
            GetNamespaceRequest getNamespaceRequest = new GetNamespaceRequest();
            var namespaceName = client.GetNamespace(getNamespaceRequest);

            // get namespace metadata
            GetNamespaceMetadataRequest getNamespaceMetadataRequest = new GetNamespaceMetadataRequest()
            {
                NamespaceName = namespaceName
            };
            var namespaceMetadata = client.GetNamespaceMetadata(getNamespaceMetadataRequest).NamespaceMetadata;
            Console.WriteLine("* Namespace------------------------");
            Console.WriteLine($" namespace : {namespaceMetadata.Namespace}");
            Console.WriteLine($" defaultS3CompartmentId : {namespaceMetadata.DefaultS3CompartmentId}");
            Console.WriteLine($" defaultSwiftCompartmentId : {namespaceMetadata.DefaultSwiftCompartmentId}");

            Console.WriteLine();
            Console.WriteLine("ObjectStorage Example Menu");
            Console.WriteLine("[1]: Display List");
            Console.WriteLine("[2]: Upload Example");
            Console.WriteLine("[3]: UsageReport Example");
            Console.WriteLine("[ESC] or [E(e)] : Back Example Menu");
            Console.WriteLine();

            var presskey = Console.ReadKey(true);
            if (presskey.Key == ConsoleKey.Escape || presskey.KeyChar == 'E' || presskey.KeyChar == 'e')
            {
                Console.WriteLine("Back Example Menu");
                return;
            }
            var select = presskey.KeyChar;
            if (!int.TryParse(select.ToString(), out int mode))
            {
                Console.WriteLine("Incorrect input...");
                return;
            }

            if (mode == 1)
            {
                DisplayBucketAndObject(config, namespaceName, client, identityClient);
            }
            else if (mode == 2)
            {
                PutObject(config, namespaceName, client);
            }
            else if (mode == 3)
            {
                DisplayUsageReport(config, client);
            }
            else
            {
                Console.WriteLine("Incorrect input...");
                return;
            }
        }

        public static void PutObject(ClientConfig config, string namespaceName, ObjectStorageClient client)
        {
            string targetBucketName = "TestBucket";
            string fileName = "HelloWorld.txt";

            // Test file create
            using (var streamWriter = new StreamWriter(fileName))
            {
                streamWriter.WriteLine("hello world");
            }

            // put
            PutObjectRequest putObjectRequest = new PutObjectRequest
            {
                NamespaceName = namespaceName,
                BucketName = targetBucketName,
                ObjectName = fileName
            };
            PutObjectResponse updateRes;
            using (FileStream stream = new FileStream(fileName, FileMode.Open))
            {
                putObjectRequest.UploadPartBody = stream;

                updateRes = client.PutObject(putObjectRequest);
            }

            // rename
            RenameObjectRequest renameObjectRequest = new RenameObjectRequest
            {
                NamespaceName = namespaceName,
                BucketName = targetBucketName,
                RenameObjectDetails = new RenameObjectDetails { 
                    SourceName = fileName,
                    NewName = "NewName.txt"
                }
            };
            var renameRes = client.RenameObject(renameObjectRequest);

            // delete
            DeleteObjectRequest deleteObjectRequest = new DeleteObjectRequest
            {
                NamespaceName = namespaceName,
                BucketName = targetBucketName,
                ObjectName = "NewName.txt",
                IfMatch = renameRes.ETag
            };
            var deleteRes = client.DeleteObject(deleteObjectRequest);
        }

        public static void DisplayBucketAndObject(ClientConfig config, string namespaceName, ObjectStorageClient client, IdentityClient identityClient)
        {
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
                Console.WriteLine($"## Compartment<{compartment.Name}>--------");

                // list bucket
                ListBucketsRequest listBucketsRequest = new ListBucketsRequest()
                {
                    NamespaceName = namespaceName,
                    CompartmentId = compartment.Id
                };
                var listBucket = client.ListBuckets(listBucketsRequest);
                Console.WriteLine($"* Bucket------------------------");
                Console.WriteLine($" namespace : {namespaceName}");
                Console.WriteLine($" comaprtment : {config.TenancyId}");

                listBucket.Items.ForEach(bucket =>
                {
                    HeadBucketRequest headBucketRequest = new HeadBucketRequest()
                    {
                        NamespaceName = bucket.Namespace,
                        BucketName = bucket.Name
                    };
                    var buckethead = client.HeadBucket(headBucketRequest);

                    // get bucket details
                    GetBucketRequest getBucketRequest = new GetBucketRequest()
                    {
                        NamespaceName = bucket.Namespace,
                        BucketName = bucket.Name,
                        IfMatch = buckethead.ETag
                    };
                    var bucketDetail = client.GetBucket(getBucketRequest);
                    Console.WriteLine($"\t|- * name : {bucketDetail.Bucket.Name}");
                    Console.WriteLine($"\t|    timeCreated : {bucketDetail.Bucket.TimeCreated}");

                    // Bucket workrequests
                    ListWorkRequestsRequest listWorkRequestsRequest = new ListWorkRequestsRequest
                    {
                        CompartmentId = bucketDetail.Bucket.CompartmentId,
                        BucketName = bucket.Name
                    };
                    var wrs = client.ListWorkRequests(listWorkRequestsRequest);
                    Console.WriteLine($"\t|* WorkRequest------------------------");
                    foreach (var wr in wrs.Items)
                    {
                        Console.WriteLine($"\t|\t|- name : {wr.OperationType}");
                        Console.WriteLine($"\t|\t|- status : {wr.Status}");
                        Console.WriteLine($"\t|\t|- start : {wr.TimeStarted}");
                        Console.WriteLine($"\t|\t|- finish : {wr.TimeFinished}");
                    }

                    // objects
                    Console.WriteLine($"\t|* Object------------------------");
                    ListObjectsRequest listObjectsRequest = new ListObjectsRequest()
                    {
                        NamespaceName = bucketDetail.Bucket.Namespace,
                        BucketName = bucketDetail.Bucket.Name,
                        Fields = new List<string> { "size", "timeCreated", "md5" }
                    };
                    var Objs = client.ListObjects(listObjectsRequest);
                    Objs.ListObjects.Objects.ForEach(obj =>
                    {
                        Console.WriteLine($"\t|\t|- name : {obj.Name}");

                        GetObjectRequest getObjectRequest = new GetObjectRequest()
                        {
                            NamespaceName = bucketDetail.Bucket.Namespace,
                            BucketName = bucketDetail.Bucket.Name,
                            ObjectName = obj.Name,
                        };
                        var ObjDetails = client.GetObject(getObjectRequest);
                        Console.WriteLine($"\t|\t|- contentLength : {ObjDetails.ContentLength}");

                        // download
                        /*if (!Directory.Exists("./ExampleDownload"))
                        {
                            Directory.CreateDirectory("./ExampleDownload");
                        }
                        if (!File.Exists($"./ExampleDownload/{obj.Name.Replace('/', '_')}"))
                        {
                            client.DownloadObject(getObjectRequest, "./ExampleDownload/", obj.Name.Replace('/', '_'));
                        }*/
                    });
                });
            }
        }

        public static void DisplayUsageReport(ClientConfig config, ObjectStorageClient client)
        {
            // UsageReport
            // Example policy:
            // define tenancy usage-report as ocid1.tenancy.oc1..aaaaaaaaned4fkpkisbwjlr56u7cj63lf3wffbilvqknstgtvzub7vhqkggq
            // endorse group group_name to read objects in tenancy usage-report
            try
            {
                var reports = GetUsageReportNames(config, client);
                Console.WriteLine($"* UsageReport------------------------");
                reports.ForEach(r =>
                {
                    Console.WriteLine($"  {r.Name}");
                    /*
                    // download object
                    if (!Directory.Exists("./ExampleDownload/report"))
                    {
                        Directory.CreateDirectory("./ExampleDownload/report");
                    }

                    if (!File.Exists($"./ExampleDownload/report/{r.Name.Replace('/', '_')}"))
                    {
                        var getObjectRequest = new GetObjectRequest()
                        {
                            NamespaceName = "bling",
                            BucketName = config.TenancyId,
                            ObjectName = r.Name,
                        };
                        client.DownloadObject(getObjectRequest, "./ExampleDownload/report/", r.Name.Replace('/', '_'));
                    }*/
                });
            }
            catch (Exception e)
            {
                Console.WriteLine($"Does not meet UsageReport usage requirements. message:{e.Message}");
            }
        }

        public static List<ObjectSummary> GetUsageReportNames(ClientConfig config, ObjectStorageClient client, string startName = "")
        {
            List<ObjectSummary> res = new List<ObjectSummary>();
            client.SetRegion(Regions.US_ASHBURN_1);
            var listORequest = new ListObjectsRequest()
            {
                NamespaceName = "bling",
                BucketName = config.TenancyId,
                Fields = new List<string>() { "name" },
                Start = startName,
                Limit = 10
            };
            var reports = client.ListObjects(listORequest);

            res.AddRange(reports.ListObjects.Objects);

            if (!string.IsNullOrEmpty(reports.ListObjects.NextStartWith)) {
                res.AddRange(GetUsageReportNames(config, client, reports.ListObjects.NextStartWith));
            }

            return res;
        }
    }
}

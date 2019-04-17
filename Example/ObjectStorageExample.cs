using OCISDK.Core.src;
using OCISDK.Core.src.Common;
using OCISDK.Core.src.ObjectStorage;
using OCISDK.Core.src.ObjectStorage.Request;
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

            // list bucket
            ListBucketsRequest listBucketsRequest = new ListBucketsRequest()
            {
                NamespaceName = namespaceName,
                CompartmentId = config.TenancyId
            };
            var listBucket = client.ListBuckets(listBucketsRequest);
            Console.WriteLine($"* Bucket------------------------");
            Console.WriteLine($" namespace : {namespaceName}");
            Console.WriteLine($" comaprtment : {config.TenancyId}");

            listBucket.Items.ForEach(bucket=> {
                // get bucket details
                GetBucketRequest getBucketRequest = new GetBucketRequest()
                {
                    NamespaceName = bucket.Namespace,
                    BucketName = bucket.Name
                };
                var bucketDetail = client.GetBucket(getBucketRequest);
                Console.WriteLine($"\t|- name : {bucketDetail.Bucket.Name}");
                Console.WriteLine($"\t|  timeCreated : {bucketDetail.Bucket.TimeCreated}");

                Console.WriteLine($"\t|* Object------------------------");
                ListObjectsRequest listObjectsRequest = new ListObjectsRequest()
                {
                    NamespaceName = bucketDetail.Bucket.Namespace,
                    BucketName = bucketDetail.Bucket.Name
                };
                var Objs = client.ListObjects(listObjectsRequest);
                Objs.ListObjects.Objects.ForEach(obj => {
                    Console.WriteLine($"\t|\t|- name : {obj.Name}");

                    GetObjectRequest getObjectRequest = new GetObjectRequest()
                    {
                        NamespaceName = bucketDetail.Bucket.Namespace,
                        BucketName = bucketDetail.Bucket.Name,
                        ObjectName = obj.Name,
                    };
                    var ObjDetails = client.GetObject(getObjectRequest);
                    Console.WriteLine($"\t|\t|- contentLength : {ObjDetails.ContentLength}");

                    // download files
                    if (!Directory.Exists("./ExampleDownload"))
                    {
                        Directory.CreateDirectory("./ExampleDownload");
                    }
                    WebClient wc = new WebClient();
                    wc.DownloadFile(ObjDetails.FileURL, $"./ExampleDownload/{obj.Name}");
                    wc.Dispose();
                });
            });

            // UsageReport
            // Example policy:
            // define tenancy usage-report as ocid1.tenancy.oc1..aaaaaaaaned4fkpkisbwjlr56u7cj63lf3wffbilvqknstgtvzub7vhqkggq
            // endorse group group_name to read objects in tenancy usage-report
            try
            {
                var listORequest = new ListObjectsRequest()
                {
                    NamespaceName = "bling",
                    BucketName = config.TenancyId
                };
                var reports = client.ListObjects(listORequest);
                Console.WriteLine($"* UsageReport------------------------");
                reports.ListObjects.Objects.ForEach(r =>
                {
                    Console.WriteLine($"  {r.Name}");
                });
            } catch (Exception)
            {
                Console.WriteLine("Does not meet UsageReport usage requirements");
            }
        }
    }
}

using OCISDK.Core.src;
using OCISDK.Core.src.Common;
using OCISDK.Core.src.Core;
using OCISDK.Core.src.Core.Request.Blockstorage;
using OCISDK.Core.src.Identity;
using OCISDK.Core.src.Identity.Request;
using System;

namespace Example
{
    class BlockStorageExample
    {
        public static void BootVolumeConsoleDisplay(ClientConfig config)
        {
            // create client
            BlockstorageClient blockstorageClient = new BlockstorageClient(config)
            {
                Region = Regions.US_ASHBURN_1
            };

            // get list BootVolumes
            IdentityClient identityClient = new IdentityClient(config)
            {
                Region = Regions.US_ASHBURN_1
            };
            // get ADs
            ListAvailabilityDomainsRequest listADsRequest = new ListAvailabilityDomainsRequest()
            {
                CompartmentId = config.TenancyId
            };
            var ads = identityClient.ListAvailabilityDomains(listADsRequest);
            ads.Items.ForEach(ad=> {
                Console.WriteLine("* List BootVolumes-------------------" + ad.Name);
                var listBootVolumesRequest = new ListBootVolumesRequest()
                {
                    // target compartment is root compartment(tenancy)
                    CompartmentId = config.TenancyId,
                    AvailabilityDomain = ad.Name,
                    Limit = 10,
                };
                var listBV = blockstorageClient.ListBootVolumes(listBootVolumesRequest);
                listBV.Items.ForEach(bv =>
                {
                    Console.WriteLine(" |-" + bv.DisplayName);
                    Console.WriteLine(" | id: " + bv.Id);
                    Console.WriteLine(" | lifecycle: " + bv.LifecycleState);
                    Console.WriteLine(" | sizeInMBs: " + bv.SizeInMBs);
                    Console.WriteLine(" | VolumeGroupId: " + bv.VolumeGroupId);
                });
            });
        }
    }
}

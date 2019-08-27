using OCISDK.Core.src;
using OCISDK.Core.src.Common;
using OCISDK.Core.src.Core;
using OCISDK.Core.src.Core.Request.Blockstorage;
using OCISDK.Core.src.Identity;
using OCISDK.Core.src.Identity.Request;
using System;
using System.Collections.Generic;

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
                    Console.WriteLine(" | sizeInGBs: " + bv.SizeInGBs);
                    Console.WriteLine(" | VolumeGroupId: " + bv.VolumeGroupId);
                });
            });

            ListCompartmentRequest listCompartmentRequest = new ListCompartmentRequest() {
                CompartmentId = config.TenancyId,
                CompartmentIdInSubtree = true,
                AccessLevel = ListCompartmentRequest.AccessLevels.ACCESSIBLE
            };
            var listCom = identityClient.ListCompartment(listCompartmentRequest);

            Console.WriteLine("* List VolumeBackup-------------------");
            listCom.Items.ForEach(com =>{

                ListVolumeBackupsRequest listVolumeBackupsRequest = new ListVolumeBackupsRequest()
                {
                    CompartmentId = com.Id
                };
                var listVolumeBackup = blockstorageClient.ListVolumeBackups(listVolumeBackupsRequest);
                listVolumeBackup.Items.ForEach(vB =>
                {
                    Console.WriteLine(" |-" + vB.DisplayName);
                    Console.WriteLine(" | id: " + vB.Id);
                    Console.WriteLine(" | lifecycle: " + vB.LifecycleState);
                    Console.WriteLine(" | type: " + vB.Type);
                });
            });

            Console.WriteLine("* List Volume-------------------");
            listCom.Items.ForEach(com => {

                ListVolumesRequest listVolumesRequest = new ListVolumesRequest()
                {
                    CompartmentId = com.Id
                };
                var listVolume = blockstorageClient.ListVolumes(listVolumesRequest);
                listVolume.Items.ForEach(vol =>
                {
                    Console.WriteLine(" |-" + vol.DisplayName);
                    Console.WriteLine(" | id: " + vol.Id);
                    Console.WriteLine(" | lifecycle: " + vol.LifecycleState);
                    Console.WriteLine(" | sizeInGBs: " + vol.SizeInGBs);
                });
            });
        }
    }
}

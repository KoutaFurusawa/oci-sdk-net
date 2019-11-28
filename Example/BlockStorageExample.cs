using OCISDK.Core;
using OCISDK.Core.Common;
using OCISDK.Core.Core;
using OCISDK.Core.Core.Request.Blockstorage;
using OCISDK.Core.Identity;
using OCISDK.Core.Identity.Request;
using System;
using System.Collections.Generic;
using System.Net;

namespace Example
{
    class BlockStorageExample
    {
        public static void BlockStoragesConsoleDisplay(ClientConfig config)
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

                Console.WriteLine("* List VolumeGroups-------------------" + ad.Name);
                var listVolumeGroupsRequest = new ListVolumeGroupsRequest()
                {
                    // target compartment is root compartment(tenancy)
                    CompartmentId = config.TenancyId,
                    AvailabilityDomain = ad.Name,
                    Limit = 10,
                };
                var listVolGroups = blockstorageClient.ListVolumeGroups(listVolumeGroupsRequest);
                listVolGroups.Items.ForEach(vg =>
                {
                    Console.WriteLine(" |-" + vg.DisplayName);
                    Console.WriteLine(" | id: " + vg.Id);
                    Console.WriteLine(" | lifecycle: " + vg.LifecycleState);
                    Console.WriteLine(" | sizeInGBs: " + vg.SizeInGBs);
                });
            });

            ListCompartmentRequest listCompartmentRequest = new ListCompartmentRequest() {
                CompartmentId = config.TenancyId,
                CompartmentIdInSubtree = true,
                AccessLevel = ListCompartmentRequest.AccessLevels.ACCESSIBLE
            };
            var listCom = identityClient.ListCompartment(listCompartmentRequest);

            Console.WriteLine("* List BootVolumeBackup-------------------");
            listCom.Items.ForEach(com => {

                ListBootVolumeBackupsRequest listBootVolumeBackupsRequest = new ListBootVolumeBackupsRequest()
                {
                    CompartmentId = com.Id,
                    SortOrder = SortOrder.ASC
                };
                var listBootVolumeBackup = blockstorageClient.ListBootVolumeBackups(listBootVolumeBackupsRequest);
                listBootVolumeBackup.Items.ForEach(bvB =>
                {
                    Console.WriteLine(" |-" + bvB.DisplayName);
                    Console.WriteLine(" | id: " + bvB.Id);
                    Console.WriteLine(" | lifecycle: " + bvB.LifecycleState);
                    Console.WriteLine(" | type: " + bvB.Type);
                });
            });

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

                    var getVolumeKmsKeyRequest = new GetVolumeKmsKeyRequest() {
                        VolumeId = vol.Id
                    };
                    try
                    {
                        var kms = blockstorageClient.GetVolumeKmsKey(getVolumeKmsKeyRequest);
                        Console.WriteLine(" | kms: " + kms.VolumeKmsKey.KmsKeyId);
                    }
                    catch (WebException we)
                    {
                        if (we.Status.Equals(WebExceptionStatus.ProtocolError))
                        {
                            var code = ((HttpWebResponse)we.Response).StatusCode;
                            if (code != HttpStatusCode.NotFound) {
                                throw we;
                            }
                        }
                    }
                });
            });

            Console.WriteLine("* List VolumeGroupBackUp-------------------");
            listCom.Items.ForEach(com => {

                var listVolumeGroupBackupsRequest = new ListVolumeGroupBackupsRequest()
                {
                    CompartmentId = com.Id
                };
                var listVolumeGroupB = blockstorageClient.ListVolumeGroupBackups(listVolumeGroupBackupsRequest);
                listVolumeGroupB.Items.ForEach(vol =>
                {
                    Console.WriteLine(" |-" + vol.DisplayName);
                    Console.WriteLine(" | id: " + vol.Id);
                    Console.WriteLine(" | lifecycle: " + vol.LifecycleState);
                    Console.WriteLine(" | sizeInGBs: " + vol.SizeInGBs);
                });
            });

            Console.WriteLine("* List VolumeBackUpPolicy-------------------");
            var listVolumeBackupPoliciesRequest = new ListVolumeBackupPoliciesRequest() {
                Limit = 10
            };
            var backupPolicies = blockstorageClient.ListVolumeBackupPolicies(listVolumeBackupPoliciesRequest);
            backupPolicies.Items.ForEach(policy =>
            {
                Console.WriteLine(" |-" + policy.DisplayName);
                Console.WriteLine(" | id: " + policy.Id);
                Console.WriteLine(" | timeCreated: " + policy.TimeCreated);
            });
            
        }
    }
}

using OCISDK.Core;
using OCISDK.Core.Common;
using OCISDK.Core.Core;
using OCISDK.Core.Core.Request.Compute;
using OCISDK.Core.Core.Request.Blockstorage;
using OCISDK.Core.Core.Request.VirtualNetwork;
using System;
using OCISDK.Core.Core.Model.Compute;
using OCISDK.Core.Identity.Request;
using OCISDK.Core.Identity;
using OCISDK.Core.Core.Model.VirtualNetwork;

namespace Example
{
    class CoreInstanceExample
    {
        public static void InstanceConsoleDisplay(ClientConfig config)
        {
            // create client
            ComputeClient computeClient = new ComputeClient(config)
            {
                Region = Regions.US_ASHBURN_1
            };
            
            BlockstorageClient blockstorageClient = new BlockstorageClient(config)
            {
                Region = Regions.US_ASHBURN_1
            };

            VirtualNetworkClient networkingClient = new VirtualNetworkClient(config)
            {
                Region = Regions.US_ASHBURN_1
            };
            
            // get instanse list(RUNNING only)
            Console.WriteLine("* List Instance------------------------");
            var listInstanceRequest = new ListInstancesRequest()
            {
                // target compartment is root compartment(tenancy)
                CompartmentId = computeClient.Config.TenancyId,
                Limit = 50,
                LifecycleState = ListInstancesRequest.LifecycleStates.RUNNING,
                SortOrder = SortOrder.ASC,
                SortBy = ListInstancesRequest.SortByParam.TIMECREATED
            };
            // get instance
            var listInstance = computeClient.ListInstances(listInstanceRequest);
            listInstance.Items.ForEach(instance => {
                GetInstanceRequest getInstanceRequest = new GetInstanceRequest()
                {
                    InstanceId = instance.Id
                };
                var insDetail = computeClient.GetInstance(getInstanceRequest).Instance;
                Console.WriteLine(" |-" + insDetail.DisplayName);
                Console.WriteLine(" | id: " + insDetail.Id);
                Console.WriteLine(" | AD: " + insDetail.AvailabilityDomain);
                Console.WriteLine(" | shape: " + insDetail.Shape);
                Console.WriteLine(" | state: " + insDetail.LifecycleState);
                Console.WriteLine(" |\t|- * SourceDetails");
                Console.WriteLine(" |\t|\t type: "+ insDetail.SourceDetails.SourceType);
                if ("image".Equals(insDetail.SourceDetails.SourceType))
                {
                    Console.WriteLine(" |\t|\t id: " + insDetail.SourceDetails.ImageId);

                    // get sourceDetail machine image
                    GetImageRequest getImageRequest = new GetImageRequest() {
                        ImageId = insDetail.SourceDetails.ImageId
                    };
                    var machineimage = computeClient.GetImage(getImageRequest);
                    Console.WriteLine(" |\t|\t name: " + machineimage.Image.DisplayName);
                    Console.WriteLine(" |\t|\t sizeInMBs: " + machineimage.Image.SizeInMBs);
                }
                else
                {
                    Console.WriteLine(" |\t|\t id: " + insDetail.SourceDetails.BootVolumeId);

                    // get sourceDetail bootVolume
                    GetBootVolumeRequest getBootVolumeRequest = new GetBootVolumeRequest()
                    {
                        BootVolumeId = insDetail.SourceDetails.BootVolumeId
                    };
                    var bootvol = blockstorageClient.GetBootVolume(getBootVolumeRequest);
                    Console.WriteLine(" |\t|\t name: " + bootvol.BootVolume.DisplayName);
                    Console.WriteLine(" |\t|\t sizeInGBs: " + bootvol.BootVolume.SizeInGBs.Value);
                }

                // get instance atattch bootvolumes
                var bootvolumeAtattch = new ListBootVolumeAttachmentsRequest()
                {
                    InstanceId = instance.Id,
                    CompartmentId = instance.CompartmentId,
                    AvailabilityDomain = instance.AvailabilityDomain,
                    Limit = 50
                };
                var listBvAtattch = computeClient.ListBootVolumeAttachments(bootvolumeAtattch);
                listBvAtattch.Items.ForEach(bootVolAtt => {
                    Console.WriteLine(" |\t|- * BootVolume");

                    // get bootvolume
                    var getBootVolumeRequest = new GetBootVolumeRequest() {
                        BootVolumeId = bootVolAtt.BootVolumeId
                    };
                    var bv = blockstorageClient.GetBootVolume(getBootVolumeRequest);
                    Console.WriteLine(" |\t|\t name:" + bv.BootVolume.DisplayName);
                    Console.WriteLine(" |\t|\t id:" + bv.BootVolume.Id);
                    Console.WriteLine(" |\t|\t state:" + bv.BootVolume.LifecycleState);
                    Console.WriteLine(" |\t|\t sizeInGBs:" + bv.BootVolume.SizeInGBs.Value);
                });
                
                // get instance atattch vnics
                var vnicAtattch = new ListVnicAttachmentsRequest()
                {
                    InstanceId = instance.Id,
                    CompartmentId = instance.CompartmentId,
                    AvailabilityDomain = instance.AvailabilityDomain,
                    Limit = 50
                };
                var listVnicAtattch = computeClient.ListVnicAttachments(vnicAtattch);
                listVnicAtattch.Items.ForEach(vnicA=> {
                    Console.WriteLine(" |\t|- * Vnic");
                    GetVnicRequest getVnicRequest = new GetVnicRequest() {
                        VnicId = vnicA.VnicId
                    };
                    var vnic = networkingClient.GetVnic(getVnicRequest);
                    Console.WriteLine(" |\t|\t name:" + vnic.Vnic.DisplayName);
                    Console.WriteLine(" |\t|\t id:" + vnic.Vnic.Id);
                    Console.WriteLine(" |\t|\t state:" + vnic.Vnic.LifecycleState);
                    Console.WriteLine(" |\t|\t privateIp:" + vnic.Vnic.PrivateIp);
                    Console.WriteLine(" |\t|\t publicIp:" + vnic.Vnic.PublicIp);
                });

                // get instance atattch volumes
                var volumeAtattch = new ListVolumeAttachmentsRequest()
                {
                    InstanceId = instance.Id,
                    CompartmentId = instance.CompartmentId,
                    AvailabilityDomain = instance.AvailabilityDomain,
                    Limit = 50
                };
                var listVolAtattch = computeClient.ListVolumeAttachments(volumeAtattch);
                listVolAtattch.Items.ForEach(volAtt => {
                    Console.WriteLine(" |\t|- * Volume");

                    // get bootvolume
                    var getVolumeRequest = new GetVolumeRequest()
                    {
                        VolumeId = volAtt.VolumeId
                    };
                    var vol = blockstorageClient.GetVolume(getVolumeRequest);
                    Console.WriteLine(" |\t|\t name:" + vol.Volume.DisplayName);
                    Console.WriteLine(" |\t|\t id:" + vol.Volume.Id);
                    Console.WriteLine(" |\t|\t state:" + vol.Volume.LifecycleState);
                    Console.WriteLine(" |\t|\t sizeInGBs:" + vol.Volume.SizeInGBs.Value);
                });
            });

            // get list Machine Images
            Console.WriteLine();
            Console.WriteLine("* List Image------------------------ max 10");
            var listImagesRequest = new ListImagesRequest()
            {
                // target compartment is root compartment(tenancy)
                CompartmentId = config.TenancyId,
                Limit = 10,
                LifecycleState = ListImagesRequest.LifecycleStates.AVAILABLE,
                SortOrder = SortOrder.ASC,
                SortBy = ListImagesRequest.SortByParam.TIMECREATED
            };
            // get instance
            var listImage = computeClient.ListImages(listImagesRequest);
            listImage.Items.ForEach(image =>
            {
                Console.WriteLine(" |-" + image.DisplayName);
                Console.WriteLine(" | id: " + image.Id);
                Console.WriteLine(" | os: " + image.OperatingSystem);
                Console.WriteLine(" | os ver: " + image.OperatingSystemVersion);
                Console.WriteLine(" | lifecycle: " + image.LifecycleState);
                Console.WriteLine(" | sizeInMBs: " + image.SizeInMBs);
                Console.WriteLine(" | BaseMachineId: " + image.BaseImageId);
            });
        }
    }
}

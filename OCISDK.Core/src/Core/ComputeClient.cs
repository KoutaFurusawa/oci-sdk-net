/// <summary>
/// Compute Service Client
/// 
/// author: koutaro furusawa
/// </summary>

using OCISDK.Core.src.Common;
using OCISDK.Core.src.Core.Model.Compute;
using OCISDK.Core.src.Core.Request.Compute;
using OCISDK.Core.src.Core.Response.Compute;
using System;
using System.Collections.Generic;
using System.IO;

namespace OCISDK.Core.src.Core
{
    public class ComputeClient : ServiceClient, IComputeClient
    {
        /// <summary>
        /// Constructer
        /// </summary>
        public ComputeClient(ClientConfig config) : base(config)
        {
            ServiceName = "core";
        }

        public ComputeClient(ClientConfig config, OciSigner ociSigner) : base(config, ociSigner)
        {
            ServiceName = "core";
        }

        public ComputeClient(ClientConfigStream config) : base(config)
        {
            ServiceName = "core";
        }

        public ComputeClient(ClientConfigStream config, OciSigner ociSigner) : base(config, ociSigner)
        {
            ServiceName = "core";
        }

        /// <summary>
        /// setter Region
        /// </summary>
        /// <param name="region"></param>
        public void SetRegion(string region)
        {
            Region = region;
        }

        /// <summary>
        /// getter region
        /// </summary>
        /// <returns></returns>
        public string GetRegion()
        {
            return Region;
        }

        /// <summary>
        /// Lists the instances in the specified compartment and the specified availability domain.
        /// You can filter the results by specifying an instance name (the list will include all the identically-named
        /// instances in the compartment).
        /// </summary>
        /// <param name="listRequest"></param>
        /// <returns></returns>
        public ListInstancesResponse ListInstances(ListInstancesRequest listRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.Instance, this.Region)}?{listRequest.GetOptionQuery()}");
            
            var webResponse = this.RestClient.Get(uri);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListInstancesResponse()
                {
                    Items = this.JsonSerializer.Deserialize<List<Instance>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
        }

        /// <summary>
        /// Lists the available images in the specified compartment, including both Oracle-provided 
        /// images and custom images that have been created. 
        /// The list of images returned is ordered to first show all Oracle-provided images, then all 
        /// custom images.
        /// 
        /// The order of images returned may change when new images are released.
        /// </summary>
        /// <param name="listRequest"></param>
        /// <returns></returns>
        public ListImagesResponse ListImages(ListImagesRequest listRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.Image, this.Region)}?{listRequest.GetOptionQuery()}");
            
            var webResponse = this.RestClient.Get(uri);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return  new ListImagesResponse()
                {
                    Items = this.JsonSerializer.Deserialize<List<Image>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
        }

        /// <summary>
        /// Lists the VNIC attachments in the specified compartment.
        /// A VNIC attachment resides in the same compartment as the attached instance.
        /// The list can be filtered by instance, VNIC, or availability domain.
        /// </summary>
        /// <param name="listRequest"></param>
        /// <returns></returns>
        public ListBootVolumeAttachmentsResponse ListBootVolumeAttachments(ListBootVolumeAttachmentsRequest listRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.BootVolumeAttachment, this.Region)}?{listRequest.GetOptionQuery()}");
            
            var webResponse = this.RestClient.Get(uri);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListBootVolumeAttachmentsResponse()
                {
                    Items = this.JsonSerializer.Deserialize<List<BootVolumeAttachment>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
        }

        /// <summary>
        /// Lists the shapes that can be used to launch an instance within the specified compartment. 
        /// You can filter the list by compatibility with a specific image.
        /// </summary>
        /// <param name="listRequest"></param>
        /// <returns></returns>
        public ListShapesResponse ListShapes(ListShapesRequest listRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.Shape, this.Region)}?{listRequest.GetOptionQuery()}");
            
            var webResponse = this.RestClient.Get(uri);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListShapesResponse()
                {
                    Items = this.JsonSerializer.Deserialize<List<ShapeModel>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
        }

        /// <summary>
        /// Lists the VNIC attachments in the specified compartment. 
        /// A VNIC attachment resides in the same compartment as the attached instance. 
        /// The list can be filtered by instance, VNIC, or availability domain.
        /// </summary>
        /// <param name="listRequest"></param>
        /// <returns></returns>
        public ListVnicAttachmentsResponse ListVnicAttachments(ListVnicAttachmentsRequest listRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.VNICAttachment, this.Region)}?{listRequest.GetOptionQuery()}");
            
            var webResponse = this.RestClient.Get(uri);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListVnicAttachmentsResponse()
                {
                    Items = this.JsonSerializer.Deserialize<List<VnicAttachment>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
        }

        /// <summary>
        /// Gets information about the specified instance.
        /// </summary>
        /// <param name="getRequest"></param>
        /// <returns></returns>
        public GetInstanceResponse GetInstance(GetInstanceRequest getRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.Instance, this.Region)}/{getRequest.InstanceId}");
            
            var webResponse = this.RestClient.Get(uri);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new GetInstanceResponse()
                {
                    Instance = this.JsonSerializer.Deserialize<Instance>(response),
                    ETag = webResponse.Headers.Get("etag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Gets the specified image.
        /// </summary>
        /// <param name="getRequest"></param>
        /// <returns></returns>
        public GetImageResponse GetImage(GetImageRequest getRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.Image, this.Region)}/{getRequest.ImageId}");
            
            var webResponse = this.RestClient.Get(uri);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new GetImageResponse()
                {
                    Image = this.JsonSerializer.Deserialize<Image>(response),
                    ETag = webResponse.Headers.Get("etag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Gets information about the specified boot volume attachment.
        /// </summary>
        /// <param name="getRequest"></param>
        /// <returns></returns>
        public GetBootVolumeAttachmentResponse GetBootVolumeAttachment(GetBootVolumeAttachmentRequest getRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.BootVolumeAttachment, this.Region)}/{getRequest.BootVolumeAttachmentId}");
            
            var webResponse = this.RestClient.Get(uri);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new GetBootVolumeAttachmentResponse()
                {
                    Attachment = this.JsonSerializer.Deserialize<BootVolumeAttachment>(response),
                    ETag = webResponse.Headers.Get("etag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Gets the information for the specified VNIC attachment.
        /// </summary>
        /// <param name="getRequest"></param>
        /// <returns></returns>
        public GetVnicAttachmentResponse GetVnicAttachment(GetVnicAttachmentRequest getRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.VNICAttachment, this.Region)}/{getRequest.VnicAttachmentId}");
            
            var webResponse = this.RestClient.Get(uri);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new GetVnicAttachmentResponse()
                {
                    Attachment = this.JsonSerializer.Deserialize<VnicAttachment>(response),
                    ETag = webResponse.Headers.Get("etag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Attaches the specified boot volume to the specified instance.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public AttachBootVolumeResponse AttachBootVolume(AttachBootVolumeRequest request)
        {
            var uri = new Uri(GetEndPoint(CoreServices.BootVolumeAttachment, this.Region));
            
            var webResponse = this.RestClient.Post(uri, request.AttachBootVolumeDetails, request.OpcRetryToken);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new AttachBootVolumeResponse()
                {
                    BootVolumeAttachment = this.JsonSerializer.Deserialize<BootVolumeAttachment>(response),
                    ETag = webResponse.Headers.Get("etag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Creates a secondary VNIC and attaches it to the specified instance. 
        /// For more information about secondary VNICs, see Virtual Network Interface Cards (VNICs).
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public AttachVnicResponse AttachVnic(AttachVnicRequest request)
        {
            var uri = new Uri(GetEndPoint(CoreServices.VNICAttachment, this.Region));
            
            var webResponse = this.RestClient.Post(uri, request.AttachVnicDetails, request.OpcRetryToken);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new AttachVnicResponse()
                {
                    VnicAttachment = this.JsonSerializer.Deserialize<VnicAttachment>(response),
                    ETag = webResponse.Headers.Get("etag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Moves an instance into a different compartment within the same tenancy. 
        /// For information about moving resources between compartments, see Moving Resources to a Different Compartment.
        /// 
        /// When you move an instance to a different compartment, associated resources such as boot volumes and VNICs are not moved.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public ChangeInstanceCompartmentResponse ChangeInstanceCompartment(ChangeInstanceCompartmentRequest param)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.Instance, this.Region)}/{param.InstanceId}/actions/changeCompartment");

            var webResponse = this.RestClient.Post(uri, param.ChangeInstanceCompartmentDetails, param.OpcRetryToken, param.OpcRequestId, param.IfMatch);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ChangeInstanceCompartmentResponse()
                {
                    ETag = webResponse.Headers.Get("etag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Moves an image into a different compartment within the same tenancy. 
        /// For information about moving resources between compartments, see Moving Resources to a Different Compartment.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public ChangeImageCompartmentResponse ChangeImageCompartment(ChangeImageCompartmentRequest param)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.Image, this.Region)}/{param.ImageId}/actions/changeCompartment");

            var webResponse = this.RestClient.Post(uri, param.ChangeImageCompartmentDetails, param.OpcRetryToken, param.OpcRequestId, param.IfMatch);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ChangeImageCompartmentResponse()
                {
                    ETag = webResponse.Headers.Get("etag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Creates a new instance in the specified compartment and the specified availability domain. 
        /// For general information about instances, see Overview of the Compute Service.
        /// For information about access control and compartments, see Overview of the IAM Service.
        /// For information about availability domains, see Regions and Availability Domains. 
        /// To get a list of availability domains, use the ListAvailabilityDomains operation in the 
        /// Identity and Access Management Service API.
        /// All Oracle Cloud Infrastructure resources, including instances, get an Oracle-assigned, 
        /// unique ID called an Oracle Cloud Identifier (OCID). When you create a resource, you can 
        /// find its OCID in the response. You can also retrieve a resource's OCID by using a List API 
        /// operation on that resource type, or by viewing the resource in the Console.
        /// To launch an instance using an image or a boot volume use the sourceDetails parameter in 
        /// LaunchInstanceDetails.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public LaunchInstanceResponse LaunchInstance(LaunchInstanceRequest request)
        {
            var uri = new Uri(GetEndPoint(CoreServices.Instance, this.Region));
            
            var webResponse = this.RestClient.Post(uri, request.LaunchInstanceDetails, request.OpcRetryToken);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new LaunchInstanceResponse()
                {
                    Instance = this.JsonSerializer.Deserialize<Instance>(response),
                    ETag = webResponse.Headers.Get("etag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcWorkRequestId = webResponse.Headers.Get("opc-work-request-id")
                };
            }
        }

        /// <summary>
        /// Updates certain fields on the specified instance.
        /// Fields that are not provided in the request will not be updated.
        /// Avoid entering confidential information.
        /// </summary>
        /// <param name="updateRequest"></param>
        /// <returns></returns>
        public UpdateInstanceResponse UpdateInstance(UpdateInstanceRequest updateRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.Instance, this.Region)}/{updateRequest.InstanceId}");
            
            var webResponse = this.RestClient.Put(uri, 
                updateRequest.UpdateInstanceDetails, 
                updateRequest.IfMatch, 
                updateRequest.OpcRetryToken);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new UpdateInstanceResponse()
                {
                    Instance = this.JsonSerializer.Deserialize<Instance>(response),
                    ETag = webResponse.Headers.Get("etag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Terminates the specified instance. 
        /// Any attached VNICs and volumes are automatically detached when the instance terminates.
        /// To preserve the boot volume associated with the instance, specify true for PreserveBootVolumeQueryParam.To delete 
        /// the boot volume when the instance is deleted, specify false or do not specify a value for PreserveBootVolumeQueryParam.
        /// This is an asynchronous operation.The instance's lifecycleState will change to TERMINATING temporarily until the instance 
        /// is completely removed.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public TerminateInstanceResponse TerminateInstance(TerminateInstanceRequest deleteRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.Instance, this.Region)}/{deleteRequest.InstanceId}");
            
            var webResponse = this.RestClient.Delete(uri, deleteRequest.IfMatch, deleteRequest.PreserveBootVolume);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new TerminateInstanceResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Detaches a boot volume from an instance. You must specify the OCID of the boot volume attachment.
        ///This is an asynchronous operation.The attachment's lifecycleState will change to DETACHING 
        ///temporarily until the attachment is completely removed.
        /// </summary>
        /// <param name="detachBootVolumeRequest"></param>
        /// <returns></returns>
        public DetachBootVolumeResponse DetachBootVolume(DetachBootVolumeRequest detachBootVolumeRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.BootVolumeAttachment, this.Region)}/{detachBootVolumeRequest.BootVolumeAttachmentId}");
            
            var webResponse = this.RestClient.Delete(uri, detachBootVolumeRequest.IfMatch);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new DetachBootVolumeResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }
    }
}

﻿/// <summary>
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
    public class ComputeClient : ServiceClient
    {
        private string _region;
        public string Region
        {
            get { return _region; }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _region = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        private RestClient RestClient { get; set; }

        /// <summary>
        /// Constructer
        /// </summary>
        public ComputeClient(ClientConfig config) : base(config)
        {
            ServiceName = "core";

            this.RestClient = new RestClient()
            {
                Signer = Signer,
                Config = config
            };
        }

        public ComputeClient(ClientConfig config, RestClient restClient) : base(config)
        {
            ServiceName = "core";

            this.RestClient = new RestClient()
            {
                Signer = Signer,
                Config = config
            };

            RestClient = restClient;
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

            try
            {
                var webResponse = this.RestClient.Get(uri);

                var response = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();

                return new ListInstancesResponse()
                {
                    Items = this.JsonSerializer.Deserialize<List<Instance>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
            catch (Exception)
            {
                throw;
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

            try
            {
                var webResponse = this.RestClient.Get(uri);

                var response = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();

                var res = new ListImagesResponse()
                {
                    Items = this.JsonSerializer.Deserialize<List<Image>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
                
                return res;
            }
            catch (Exception)
            {
                throw;
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

            try
            {
                var webResponse = this.RestClient.Get(uri);

                var response = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();

                return new ListBootVolumeAttachmentsResponse()
                {
                    Items = this.JsonSerializer.Deserialize<List<BootVolumeAttachment>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
            catch (Exception)
            {
                throw;
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

            try
            {
                var webResponse = this.RestClient.Get(uri);

                var response = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();

                return new ListShapesResponse()
                {
                    Items = this.JsonSerializer.Deserialize<List<ShapeModel>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
            catch (Exception)
            {
                throw;
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

            try
            {
                var webResponse = this.RestClient.Get(uri);

                var response = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();

                return new ListVnicAttachmentsResponse()
                {
                    Items = this.JsonSerializer.Deserialize<List<VnicAttachment>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
            catch (Exception)
            {
                throw;
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

            try
            {
                var webResponse = this.RestClient.Get(uri);

                var response = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();

                return new GetInstanceResponse()
                {
                    Instance = this.JsonSerializer.Deserialize<Instance>(response),
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
            catch (Exception)
            {
                throw;
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

            try
            {
                var webResponse = this.RestClient.Get(uri);

                var response = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();

                return new GetImageResponse()
                {
                    Image = this.JsonSerializer.Deserialize<Image>(response),
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
            catch (Exception)
            {
                throw;
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

            try
            {
                var webResponse = this.RestClient.Get(uri);

                var response = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();

                return new GetBootVolumeAttachmentResponse()
                {
                    Attachment = this.JsonSerializer.Deserialize<BootVolumeAttachment>(response),
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
            catch (Exception)
            {
                throw;
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

            try
            {
                var webResponse = this.RestClient.Get(uri);

                var response = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();

                return new GetVnicAttachmentResponse()
                {
                    Attachment = this.JsonSerializer.Deserialize<VnicAttachment>(response),
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
            catch (Exception)
            {
                throw;
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

            try
            {
                var webResponse = this.RestClient.Post(uri, request.AttachBootVolumeDetails, request.OpcRetryToken);

                var response = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();

                return new AttachBootVolumeResponse()
                {
                    BootVolumeAttachment = this.JsonSerializer.Deserialize<BootVolumeAttachment>(response),
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
            catch (Exception)
            {
                throw;
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

            try
            {
                var webResponse = this.RestClient.Post(uri, request.AttachVnicDetails, request.OpcRetryToken);

                var response = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();

                return new AttachVnicResponse()
                {
                    VnicAttachment = this.JsonSerializer.Deserialize<VnicAttachment>(response),
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
            catch (Exception)
            {
                throw;
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

            try
            {
                var webResponse = this.RestClient.Post(uri, request.LaunchInstanceDetails, request.OpcRetryToken);

                var response = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();

                return new LaunchInstanceResponse()
                {
                    Instance = this.JsonSerializer.Deserialize<Instance>(response),
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
            catch (Exception)
            {
                throw;
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

            try
            {
                var webResponse = this.RestClient.Put(uri, 
                    updateRequest.UpdateInstanceDetails, 
                    updateRequest.IfMatch, 
                    updateRequest.OpcRetryToken);

                var response = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();

                return new UpdateInstanceResponse()
                {
                    Instance = this.JsonSerializer.Deserialize<Instance>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    ETag = webResponse.Headers.Get("etag")
                };
            }
            catch (Exception)
            {
                throw;
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

            try
            {
                var webResponse = this.RestClient.Delete(uri, deleteRequest.IfMatch, deleteRequest.PreserveBootVolume);

                var response = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();

                return new TerminateInstanceResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
            catch (Exception)
            {
                throw;
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
            var uri = new Uri(
                $"{GetEndPoint(CoreServices.BootVolumeAttachment, this.Region)}/{detachBootVolumeRequest.BootVolumeAttachmentId}");

            try
            {
                var webResponse = this.RestClient.Delete(uri, detachBootVolumeRequest.IfMatch);

                var response = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();

                return new DetachBootVolumeResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

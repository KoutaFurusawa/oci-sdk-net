﻿using OCISDK.Core.Common;
using OCISDK.Core.Core.Model.Compute;
using OCISDK.Core.Core.Request.Compute;
using OCISDK.Core.Core.Response.Compute;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace OCISDK.Core.Core
{
    /// <summary>
    /// Compute Service Client
    /// </summary>
    public class ComputeClientAsync : ServiceClient, IComputeClientAsync
    {
        /// <summary>
        /// Constructer
        /// </summary>
        public ComputeClientAsync(ClientConfig config) : base(config)
        {
            ServiceName = CoreServices.CoreServiceName;
        }

        /// <summary>
        /// Constructer
        /// </summary>
        public ComputeClientAsync(ClientConfig config, IOciSigner ociSigner) : base(config, ociSigner)
        {
            ServiceName = CoreServices.CoreServiceName;
        }

        /// <summary>
        /// Constructer
        /// </summary>
        public ComputeClientAsync(ClientConfigStream config) : base(config)
        {
            ServiceName = CoreServices.CoreServiceName;
        }

        /// <summary>
        /// Constructer
        /// </summary>
        public ComputeClientAsync(ClientConfigStream config, IOciSigner ociSigner) : base(config, ociSigner)
        {
            ServiceName = CoreServices.CoreServiceName;
        }

        /// <summary>
        /// Gets all resource versions for a particular listing.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ListAppCatalogListingResourceVersionsResponse> ListAppCatalogListingResourceVersions(ListAppCatalogListingResourceVersionsRequest request)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.AppCatalogListings, this.Region)}/{request.ListingId}/resourceVersions?{request.GetOptionQuery()}");

            using (var webResponse = await this.RestClientAsync.Get(uri))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

                return new ListAppCatalogListingResourceVersionsResponse()
                {
                    Items = this.JsonSerializer.Deserialize<List<AppCatalogListingResourceVersionSummary>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page"),
                    ETag = webResponse.Headers.Get("etag")
                };
            }
        }

        /// <summary>
        /// Lists the published listings.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ListAppCatalogListingsResponse> ListAppCatalogListings(ListAppCatalogListingsRequest request)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.AppCatalogListings, this.Region)}?{request.GetOptionQuery()}");

            using (var webResponse = await this.RestClientAsync.Get(uri))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

                return new ListAppCatalogListingsResponse()
                {
                    Items = this.JsonSerializer.Deserialize<List<AppCatalogListingSummary>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
        }

        /// <summary>
        /// Lists subscriptions for a compartment.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ListAppCatalogSubscriptionsResponse> ListAppCatalogSubscriptions(ListAppCatalogSubscriptionsRequest request)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.AppCatalogSubscriptions, this.Region)}?{request.GetOptionQuery()}");

            using (var webResponse = await this.RestClientAsync.Get(uri))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

                return new ListAppCatalogSubscriptionsResponse()
                {
                    Items = this.JsonSerializer.Deserialize<List<AppCatalogSubscriptionSummary>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
        }

        /// <summary>
        /// Lists the instances in the specified compartment and the specified availability domain.
        /// You can filter the results by specifying an instance name (the list will include all the identically-named
        /// instances in the compartment).
        /// </summary>
        /// <param name="listRequest"></param>
        /// <returns></returns>
        public async Task<ListInstancesResponse> ListInstances(ListInstancesRequest listRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.Instance, this.Region)}?{listRequest.GetOptionQuery()}");

            using (var webResponse = await this.RestClientAsync.Get(uri))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

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
        public async Task<ListImagesResponse> ListImages(ListImagesRequest listRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.Image, this.Region)}?{listRequest.GetOptionQuery()}");

            using (var webResponse = await this.RestClientAsync.Get(uri))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

                return new ListImagesResponse()
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
        public async Task<ListBootVolumeAttachmentsResponse> ListBootVolumeAttachments(ListBootVolumeAttachmentsRequest listRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.BootVolumeAttachment, this.Region)}?{listRequest.GetOptionQuery()}");

            using (var webResponse = await this.RestClientAsync.Get(uri))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

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
        public async Task<ListShapesResponse> ListShapes(ListShapesRequest listRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.Shape, this.Region)}?{listRequest.GetOptionQuery()}");

            using (var webResponse = await this.RestClientAsync.Get(uri))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

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
        public async Task<ListVnicAttachmentsResponse> ListVnicAttachments(ListVnicAttachmentsRequest listRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.VNICAttachment, this.Region)}?{listRequest.GetOptionQuery()}");

            using (var webResponse = await this.RestClientAsync.Get(uri))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

                return new ListVnicAttachmentsResponse()
                {
                    Items = this.JsonSerializer.Deserialize<List<VnicAttachment>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
        }

        /// <summary>
        /// Lists the console history metadata for the specified compartment or instance.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<ListConsoleHistoriesResponse> ListConsoleHistories(ListConsoleHistoriesRequest param)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.InstanceConsoleHistory, this.Region)}?{param.GetOptionQuery()}");

            using (var webResponse = await this.RestClientAsync.Get(uri))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

                return new ListConsoleHistoriesResponse()
                {
                    Items = this.JsonSerializer.Deserialize<List<ConsoleHistory>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
        }

        /// <summary>
        /// Gets the specified listing.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<GetAppCatalogListingResponse> GetAppCatalogListing(GetAppCatalogListingRequest request)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.AppCatalogListings, this.Region)}/{request.ListingId}");

            using (var webResponse = await this.RestClientAsync.Get(uri))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

                return new GetAppCatalogListingResponse()
                {
                    AppCatalogListing = this.JsonSerializer.Deserialize<AppCatalogListing>(response),
                    ETag = webResponse.Headers.Get("etag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Gets the specified listing resource version.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<GetAppCatalogListingResourceVersionResponse> GetAppCatalogListingResourceVersion(GetAppCatalogListingResourceVersionRequest request)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.AppCatalogListings, this.Region)}/{request.ListingId}/resourceVersions/{request.ResourceVersion}");

            using (var webResponse = await this.RestClientAsync.Get(uri))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

                return new GetAppCatalogListingResourceVersionResponse()
                {
                    AppCatalogListingResourceVersion = this.JsonSerializer.Deserialize<AppCatalogListingResourceVersion>(response),
                    ETag = webResponse.Headers.Get("etag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Retrieves the agreements for a particular resource version of a listing.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<GetAppCatalogListingAgreementsResponse> GetAppCatalogListingAgreements(GetAppCatalogListingAgreementsRequest request)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.AppCatalogListings, this.Region)}/{request.ListingId}/resourceVersions/{request.ResourceVersion}/agreements");

            using (var webResponse = await this.RestClientAsync.Get(uri))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

                return new GetAppCatalogListingAgreementsResponse()
                {
                    AppCatalogListingResourceVersionAgreements = this.JsonSerializer.Deserialize<AppCatalogListingResourceVersionAgreements>(response),
                    ETag = webResponse.Headers.Get("etag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Gets information about the specified instance.
        /// </summary>
        /// <param name="getRequest"></param>
        /// <returns></returns>
        public async Task<GetInstanceResponse> GetInstance(GetInstanceRequest getRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.Instance, this.Region)}/{getRequest.InstanceId}");

            using (var webResponse = await this.RestClientAsync.Get(uri))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

                return new GetInstanceResponse()
                {
                    Instance = this.JsonSerializer.Deserialize<Instance>(response),
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Gets the default credentials of the specified instance
        /// </summary>
        /// <param name="getRequest"></param>
        /// <returns></returns>
        public async Task<GetInstanceDefaultCredentialsResponse> GetInstanceDefaultCredentials(GetInstanceDefaultCredentialsRequest getRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.Instance, this.Region)}/{getRequest.InstanceId}/defaultCredentials");

            using (var webResponse = await this.RestClientAsync.Get(uri))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

                return new GetInstanceDefaultCredentialsResponse()
                {
                    InstanceCredentialsDetails = this.JsonSerializer.Deserialize<InstanceCredentialsDetails>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Gets the specified image.
        /// </summary>
        /// <param name="getRequest"></param>
        /// <returns></returns>
        public async Task<GetImageResponse> GetImage(GetImageRequest getRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.Image, this.Region)}/{getRequest.ImageId}");

            using (var webResponse = await this.RestClientAsync.Get(uri))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

                return new GetImageResponse()
                {
                    Image = this.JsonSerializer.Deserialize<Image>(response),
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Gets information about the specified boot volume attachment.
        /// </summary>
        /// <param name="getRequest"></param>
        /// <returns></returns>
        public async Task<GetBootVolumeAttachmentResponse> GetBootVolumeAttachment(GetBootVolumeAttachmentRequest getRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.BootVolumeAttachment, this.Region)}/{getRequest.BootVolumeAttachmentId}");

            using (var webResponse = await this.RestClientAsync.Get(uri))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

                return new GetBootVolumeAttachmentResponse()
                {
                    Attachment = this.JsonSerializer.Deserialize<BootVolumeAttachment>(response),
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Gets the information for the specified VNIC attachment.
        /// </summary>
        /// <param name="getRequest"></param>
        /// <returns></returns>
        public async Task<GetVnicAttachmentResponse> GetVnicAttachment(GetVnicAttachmentRequest getRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.VNICAttachment, this.Region)}/{getRequest.VnicAttachmentId}");

            using (var webResponse = await this.RestClientAsync.Get(uri))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

                return new GetVnicAttachmentResponse()
                {
                    Attachment = this.JsonSerializer.Deserialize<VnicAttachment>(response),
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Shows the metadata for the specified console history. See CaptureConsoleHistory for details about using the console history operations.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<GetConsoleHistoryResponse> GetConsoleHistory(GetConsoleHistoryRequest param)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.InstanceConsoleHistory, this.Region)}/{param.InstanceConsoleHistoryId}");

            using (var webResponse = await this.RestClientAsync.Get(uri))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

                return new GetConsoleHistoryResponse()
                {
                    ConsoleHistory = this.JsonSerializer.Deserialize<ConsoleHistory>(response),
                    ETag = webResponse.Headers.Get("etag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Gets the actual console history data (not the metadata). See CaptureConsoleHistory for details about using the console history operations.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<GetConsoleHistoryContentResponse> GetConsoleHistoryContent(GetConsoleHistoryContentRequest param)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.InstanceConsoleHistory, this.Region)}/{param.InstanceConsoleHistoryId}/data?{param.GetOptionQuery()}");

            using (var webResponse = await this.RestClientAsync.Get(uri))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

                return new GetConsoleHistoryContentResponse()
                {
                    Contents = response,
                    OpcBytesRemaining = webResponse.Headers.Get("opc-bytes-remaining"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Attaches the specified boot volume to the specified instance.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<AttachBootVolumeResponse> AttachBootVolume(AttachBootVolumeRequest request)
        {
            var uri = new Uri(GetEndPoint(CoreServices.BootVolumeAttachment, this.Region));

            using (var webResponse = await this.RestClientAsync.Post(uri, request.AttachBootVolumeDetails, new HttpRequestHeaderParam() { OpcRetryToken = request.OpcRetryToken }))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

                return new AttachBootVolumeResponse()
                {
                    BootVolumeAttachment = this.JsonSerializer.Deserialize<BootVolumeAttachment>(response),
                    ETag = webResponse.Headers.Get("ETag"),
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
        public async Task<AttachVnicResponse> AttachVnic(AttachVnicRequest request)
        {
            var uri = new Uri(GetEndPoint(CoreServices.VNICAttachment, this.Region));

            using (var webResponse = await this.RestClientAsync.Post(uri, request.AttachVnicDetails, new HttpRequestHeaderParam() { OpcRetryToken = request.OpcRetryToken }))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

                return new AttachVnicResponse()
                {
                    VnicAttachment = this.JsonSerializer.Deserialize<VnicAttachment>(response),
                    ETag = webResponse.Headers.Get("ETag"),
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
        public async Task<ChangeInstanceCompartmentResponse> ChangeInstanceCompartment(ChangeInstanceCompartmentRequest param)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.Instance, this.Region)}/{param.InstanceId}/actions/changeCompartment");

            var httpRequestHeaderParam = new HttpRequestHeaderParam() {
                OpcRetryToken = param.OpcRetryToken,
                OpcRequestId = param.OpcRequestId,
                IfMatch = param.IfMatch
            };
            using (var webResponse = await this.RestClientAsync.Post(uri, param.ChangeInstanceCompartmentDetails, httpRequestHeaderParam))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

                return new ChangeInstanceCompartmentResponse()
                {
                    ETag = webResponse.Headers.Get("ETag"),
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
        public async Task<ChangeImageCompartmentResponse> ChangeImageCompartment(ChangeImageCompartmentRequest param)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.Image, this.Region)}/{param.ImageId}/actions/changeCompartment");

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                OpcRetryToken = param.OpcRetryToken,
                OpcRequestId = param.OpcRequestId,
                IfMatch = param.IfMatch
            };
            using (var webResponse = await this.RestClientAsync.Post(uri, param.ChangeImageCompartmentDetails, httpRequestHeaderParam))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

                return new ChangeImageCompartmentResponse()
                {
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Create a subscription for listing resource version for a compartment. It will take some time to propagate to all regions.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CreateAppCatalogSubscriptionResponse> CreateAppCatalogSubscription(CreateAppCatalogSubscriptionRequest request)
        {
            var uri = new Uri(GetEndPoint(CoreServices.AppCatalogSubscriptions, this.Region));

            using (var webResponse = await this.RestClientAsync.Post(uri, request.CreateAppCatalogSubscriptionDetails, new HttpRequestHeaderParam { OpcRetryToken = request.OpcRetryToken }))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

                return new CreateAppCatalogSubscriptionResponse()
                {
                    AppCatalogSubscription = this.JsonSerializer.Deserialize<AppCatalogSubscription>(response),
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
        public async Task<LaunchInstanceResponse> LaunchInstance(LaunchInstanceRequest request)
        {
            var uri = new Uri(GetEndPoint(CoreServices.Instance, this.Region));

            using (var webResponse = await this.RestClientAsync.Post(uri, request.LaunchInstanceDetails, new HttpRequestHeaderParam() { OpcRetryToken = request.OpcRetryToken }))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

                return new LaunchInstanceResponse()
                {
                    Instance = this.JsonSerializer.Deserialize<Instance>(response),
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Captures the most recent serial console data (up to a megabyte) for the specified instance.
        /// The CaptureConsoleHistory operation works with the other console history operations as described below.
        /// 1. Use CaptureConsoleHistory to request the capture of up to a megabyte of the most recent console history. 
        ///    This call returns a ConsoleHistory object. The object will have a state of REQUESTED.
        /// 2. Wait for the capture operation to succeed by polling GetConsoleHistory with the identifier of the console history metadata. 
        ///    The state of the ConsoleHistory object will go from REQUESTED to GETTING-HISTORY and then SUCCEEDED (or FAILED).
        /// 3. Use GetConsoleHistoryContent to get the actual console history data (not the metadata).
        /// 4. Optionally, use DeleteConsoleHistory to delete the console history metadata and the console history data.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<CaptureConsoleHistoryResponse> CaptureConsoleHistory(CaptureConsoleHistoryRequest param)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.InstanceConsoleHistory, this.Region)}");

            using (var webResponse = await this.RestClientAsync.Post(uri, param.CaptureConsoleHistoryDetails, new HttpRequestHeaderParam() { OpcRetryToken = param.OpcRetryToken }))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

                return new CaptureConsoleHistoryResponse()
                {
                    ConsoleHistory = this.JsonSerializer.Deserialize<ConsoleHistory>(response),
                    ETag = webResponse.Headers.Get("etag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
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
        public async Task<UpdateInstanceResponse> UpdateInstance(UpdateInstanceRequest updateRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.Instance, this.Region)}/{updateRequest.InstanceId}");

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                OpcRetryToken = updateRequest.OpcRetryToken,
                IfMatch = updateRequest.IfMatch
            };
            using (var webResponse = await this.RestClientAsync.Put(uri, updateRequest.UpdateInstanceDetails, httpRequestHeaderParam))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

                return new UpdateInstanceResponse()
                {
                    Instance = this.JsonSerializer.Deserialize<Instance>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    ETag = webResponse.Headers.Get("etag")
                };
            }
        }

        /// <summary>
        /// Performs one of the following power actions on the specified instance:
        ///  * START - Powers on the instance.
        ///  * STOP - Powers off the instance.
        ///  * RESET - Powers off the instance and then powers it back on.
        ///  * SOFTSTOP - Gracefully shuts down the instance by sending a shutdown command to the 
        ///               operating system. If the applications that run on the instance take a 
        ///               long time to shut down, they could be improperly stopped, resulting in 
        ///               data corruption. To avoid this, shut down the instance using the commands 
        ///               available in the OS before you softstop the instance.
        /// * SOFTRESET - Gracefully reboots the instance by sending a shutdown command to the 
        ///               operating system, and then powers the instance back on.
        ///               
        /// For more information, see Stopping and Starting an Instance.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<InstanceActionResponse> InstanceAction(InstanceActionRequest request)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.Instance, this.Region)}/{request.InstanceId}?{request.Action.Value}");

            var headers = new HttpRequestHeaderParam
            {
                OpcRetryToken = request.OpcRetryToken,
                IfMatch = request.IfMatch
            };
            using (var webResponse = await this.RestClientAsync.Post(uri, null, headers))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

                return new InstanceActionResponse()
                {
                    Instance = this.JsonSerializer.Deserialize<Instance>(response),
                    ETag = webResponse.Headers.Get("etag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Updates the specified console history metadata.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<UpdateConsoleHistoryResponse> UpdateConsoleHistory(UpdateConsoleHistoryRequest param)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.InstanceConsoleHistory, this.Region)}/{param.InstanceConsoleHistoryId}");

            using (var webResponse = await this.RestClientAsync.Put(uri, param.UpdateConsoleHistoryDetails, new HttpRequestHeaderParam() { IfMatch = param.IfMatch }))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

                return new UpdateConsoleHistoryResponse()
                {
                    ConsoleHistory = this.JsonSerializer.Deserialize<ConsoleHistory>(response),
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
        /// <param name="deleteRequest"></param>
        /// <returns></returns>
        public async Task<TerminateInstanceResponse> TerminateInstance(TerminateInstanceRequest deleteRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.Instance, this.Region)}/{deleteRequest.InstanceId}");

            using (var webResponse = await this.RestClientAsync.Delete(uri, new HttpRequestHeaderParam() { IfMatch = deleteRequest.IfMatch }, deleteRequest.PreserveBootVolume))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

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
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<DetachBootVolumeResponse> DetachBootVolume(DetachBootVolumeRequest request)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.BootVolumeAttachment, this.Region)}/{request.BootVolumeAttachmentId}");

            using (var webResponse = await this.RestClientAsync.Delete(uri, new HttpRequestHeaderParam() { IfMatch = request.IfMatch }))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

                return new DetachBootVolumeResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Delete a subscription for a listing resource version for a compartment.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<DeleteAppCatalogSubscriptionResponse> DeleteAppCatalogSubscription(DeleteAppCatalogSubscriptionRequest request)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.AppCatalogSubscriptions, this.Region)}?{request.GetQuery()}");

            using (var webResponse = await this.RestClientAsync.Delete(uri))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

                return new DeleteAppCatalogSubscriptionResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Deletes the specified console history metadata and the console history data.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<DeleteConsoleHistoryResponse> DeleteConsoleHistory(DeleteConsoleHistoryRequest param)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.InstanceConsoleHistory, this.Region)}/{param.InstanceConsoleHistoryId}");

            using (var webResponse = await this.RestClientAsync.Delete(uri, new HttpRequestHeaderParam() { IfMatch = param.IfMatch }))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

                return new DeleteConsoleHistoryResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }
    }
}

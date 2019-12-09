using OCISDK.Core.Core.Request.Compute;
using OCISDK.Core.Core.Response.Compute;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core
{
    /// <summary>
    /// ComputeClient interface
    /// </summary>
    public interface IComputeClient : IClientSetting
    {
        /// <summary>
        /// Lists the instances in the specified compartment and the specified availability domain.
        /// You can filter the results by specifying an instance name (the list will include all the identically-named
        /// instances in the compartment).
        /// </summary>
        /// <param name="listRequest"></param>
        /// <returns></returns>
        ListInstancesResponse ListInstances(ListInstancesRequest listRequest);

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
        ListImagesResponse ListImages(ListImagesRequest listRequest);

        /// <summary>
        /// Lists the VNIC attachments in the specified compartment.
        /// A VNIC attachment resides in the same compartment as the attached instance.
        /// The list can be filtered by instance, VNIC, or availability domain.
        /// </summary>
        /// <param name="listRequest"></param>
        /// <returns></returns>
        ListBootVolumeAttachmentsResponse ListBootVolumeAttachments(ListBootVolumeAttachmentsRequest listRequest);

        /// <summary>
        /// Lists the shapes that can be used to launch an instance within the specified compartment. 
        /// You can filter the list by compatibility with a specific image.
        /// </summary>
        /// <param name="listRequest"></param>
        /// <returns></returns>
        ListShapesResponse ListShapes(ListShapesRequest listRequest);

        /// <summary>
        /// Lists the VNIC attachments in the specified compartment. 
        /// A VNIC attachment resides in the same compartment as the attached instance. 
        /// The list can be filtered by instance, VNIC, or availability domain.
        /// </summary>
        /// <param name="listRequest"></param>
        /// <returns></returns>
        ListVnicAttachmentsResponse ListVnicAttachments(ListVnicAttachmentsRequest listRequest);

        /// <summary>
        /// Lists the volume attachments in the specified compartment. You can filter the list by specifying an instance OCID, volume OCID, or both.
        /// </summary>
        /// <param name="listRequest"></param>
        /// <returns></returns>
        ListVolumeAttachmentsResponse ListVolumeAttachments(ListVolumeAttachmentsRequest listRequest);

        /// <summary>
        /// Lists the console history metadata for the specified compartment or instance.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        ListConsoleHistoriesResponse ListConsoleHistories(ListConsoleHistoriesRequest param);

        /// <summary>
        /// Gets information about the specified instance.
        /// </summary>
        /// <param name="getRequest"></param>
        /// <returns></returns>
        GetInstanceResponse GetInstance(GetInstanceRequest getRequest);

        /// <summary>
        /// Gets the specified image.
        /// </summary>
        /// <param name="getRequest"></param>
        /// <returns></returns>
        GetImageResponse GetImage(GetImageRequest getRequest);

        /// <summary>
        /// Gets information about the specified boot volume attachment.
        /// </summary>
        /// <param name="getRequest"></param>
        /// <returns></returns>
        GetBootVolumeAttachmentResponse GetBootVolumeAttachment(GetBootVolumeAttachmentRequest getRequest);

        /// <summary>
        /// Gets the information for the specified VNIC attachment.
        /// </summary>
        /// <param name="getRequest"></param>
        /// <returns></returns>
        GetVnicAttachmentResponse GetVnicAttachment(GetVnicAttachmentRequest getRequest);

        /// <summary>
        /// Gets information about the specified volume attachment.
        /// </summary>
        /// <param name="getRequest"></param>
        /// <returns></returns>
        GetVolumeAttachmentResponse GetVolumeAttachment(GetVolumeAttachmentRequest getRequest);

        /// <summary>
        /// Shows the metadata for the specified console history. See CaptureConsoleHistory for details about using the console history operations.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        GetConsoleHistoryResponse GetConsoleHistory(GetConsoleHistoryRequest param);

        /// <summary>
        /// Gets the actual console history data (not the metadata). See CaptureConsoleHistory for details about using the console history operations.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        GetConsoleHistoryContentResponse GetConsoleHistoryContent(GetConsoleHistoryContentRequest param);

        /// <summary>
        /// Attaches the specified boot volume to the specified instance.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        AttachBootVolumeResponse AttachBootVolume(AttachBootVolumeRequest request);

        /// <summary>
        /// Creates a secondary VNIC and attaches it to the specified instance. 
        /// For more information about secondary VNICs, see Virtual Network Interface Cards (VNICs).
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        AttachVnicResponse AttachVnic(AttachVnicRequest request);

        /// <summary>
        /// Attaches the specified storage volume to the specified instance.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        AttachVolumeResponse AttachVolume(AttachVolumeRequest request);

        /// <summary>
        /// Moves an instance into a different compartment within the same tenancy. 
        /// For information about moving resources between compartments, see Moving Resources to a Different Compartment.
        /// 
        /// When you move an instance to a different compartment, associated resources such as boot volumes and VNICs are not moved.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        ChangeInstanceCompartmentResponse ChangeInstanceCompartment(ChangeInstanceCompartmentRequest param);

        /// <summary>
        /// Moves an image into a different compartment within the same tenancy. 
        /// For information about moving resources between compartments, see Moving Resources to a Different Compartment.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        ChangeImageCompartmentResponse ChangeImageCompartment(ChangeImageCompartmentRequest param);

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
        LaunchInstanceResponse LaunchInstance(LaunchInstanceRequest request);

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
        CaptureConsoleHistoryResponse CaptureConsoleHistory(CaptureConsoleHistoryRequest param);

        /// <summary>
        /// Updates certain fields on the specified instance.
        /// Fields that are not provided in the request will not be updated.
        /// Avoid entering confidential information.
        /// </summary>
        /// <param name="updateRequest"></param>
        /// <returns></returns>
        UpdateInstanceResponse UpdateInstance(UpdateInstanceRequest updateRequest);

        /// <summary>
        /// Updates the specified console history metadata.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        UpdateConsoleHistoryResponse UpdateConsoleHistory(UpdateConsoleHistoryRequest param);

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
        TerminateInstanceResponse TerminateInstance(TerminateInstanceRequest deleteRequest);

        /// <summary>
        /// Detaches a boot volume from an instance. You must specify the OCID of the boot volume attachment.
        ///This is an asynchronous operation.The attachment's lifecycleState will change to DETACHING 
        ///temporarily until the attachment is completely removed.
        /// </summary>
        /// <param name="detachRequest"></param>
        /// <returns></returns>
        DetachBootVolumeResponse DetachBootVolume(DetachBootVolumeRequest detachRequest);

        /// <summary>
        /// Detaches a storage volume from an instance. You must specify the OCID of the volume attachment.
        /// 
        /// This is an asynchronous operation. The attachment's lifecycleState will change to DETACHING temporarily until the attachment is completely removed.
        /// </summary>
        /// <param name="detachRequest"></param>
        /// <returns></returns>
        DetachVolumeResponse DetachVolume(DetachVolumeRequest detachRequest);

        /// <summary>
        /// Deletes the specified console history metadata and the console history data.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        DeleteConsoleHistoryResponse DeleteConsoleHistory(DeleteConsoleHistoryRequest param);
    }
}

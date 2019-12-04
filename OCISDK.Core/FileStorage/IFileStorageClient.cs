using System;
using System.Collections.Generic;
using System.Text;
using OCISDK.Core.FileStorage.Request;
using OCISDK.Core.FileStorage.Response;

namespace OCISDK.Core.FileStorage
{
    /// <summary>
    /// FileStorageClient interface
    /// </summary>
    public interface IFileStorageClient : IClientSetting
    {
        /// <summary>
        /// Moves a file system and its associated snapshots into a different compartment within the same tenancy. 
        /// For information about moving resources between compartments, see Moving Resources to a Different Compartment
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ChangeFileSystemCompartmentResponse ChangeFileSystemCompartment(ChangeFileSystemCompartmentRequest request);

        /// <summary>
        /// Creates a new file system in the specified compartment and availability domain. Instances can mount file 
        /// systems in another availability domain, but doing so might increase latency when compared to mounting 
        /// instances in the same availability domain.
        /// 
        /// After you create a file system, you can associate it with a mount target. Instances can then mount the file 
        /// system by connecting to the mount target's IP address. You can associate a file system with more than one 
        /// mount target at a time.
        /// 
        /// For information about access control and compartments, see Overview of the IAM Service.
        /// 
        /// For information about availability domains, see Regions and Availability Domains. To get a list of availability 
        /// domains, use the ListAvailabilityDomains operation in the Identity and Access Management Service API.
        /// 
        /// All Oracle Cloud Infrastructure resources, including file systems, get an Oracle-assigned, unique ID called an 
        /// Oracle Cloud Identifier (OCID). When you create a resource, you can find its OCID in the response. You can 
        /// also retrieve a resource's OCID by using a List API operation on that resource type or by viewing the resource 
        /// in the Console.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        CreateFileSystemResponse CreateFileSystem(CreateFileSystemRequest request);

        /// <summary>
        /// Updates the specified file system's information. You can use this operation to rename a file system.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        UpdateFileSystemResponse UpdateFileSystem(UpdateFileSystemRequest request);

        /// <summary>
        /// Gets the specified file system's information.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        GetFileSystemResponse GetFileSystem(GetFileSystemRequest request);

        /// <summary>
        /// Lists the file system resources in the specified compartment.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ListFileSystemsResponse ListFileSystems(ListFileSystemsRequest request);

        /// <summary>
        /// Deletes the specified file system. Before you delete the file system, verify that no remaining export resources 
        /// still reference it. Deleting a file system also deletes all of its snapshots.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        DeleteFileSystemResponse DeleteFileSystem(DeleteFileSystemRequest request);
    }
}

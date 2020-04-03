using OCISDK.Core.ObjectStorage.Request;
using OCISDK.Core.ObjectStorage.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.ObjectStorage
{
    /// <summary>
    /// ObjectStorageClient interface
    /// </summary>
    public interface IObjectStorageClient : IClientSetting
    {
        /// <summary>
        /// Each Oracle Cloud Infrastructure tenant is assigned one unique and uneditable Object Storage namespace.
        /// The namespace is a system-generated string assigned during account creation. For some older tenancies, 
        /// the namespace string may be the tenancy name in all lower-case letters. You cannot edit a namespace.
        ///GetNamespace returns the name of the Object Storage namespace for the user making the request.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        string GetNamespace(GetNamespaceRequest request);

        /// <summary>
        /// Gets the metadata for the Object Storage namespace, which contains defaultS3CompartmentId and defaultSwiftCompartmentId.
        /// Any user with the NAMESPACE_READ permission will be able to see the current metadata. 
        /// If you are not authorized, talk to an administrator. If you are an administrator who needs to write policies to give users access, 
        /// see Getting Started with Policies.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        GetNamespaceMetadataResponse GetNamespaceMetadata(GetNamespaceMetadataRequest request);

        /// <summary>
        /// Gets the current representation of the given bucket in the given Object Storage namespace.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        GetBucketResponse GetBucket(GetBucketRequest request);

        /// <summary>
        /// Efficiently checks to see if a bucket exists and gets the current entity tag (ETag) for the bucket.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        HeadBucketResponse HeadBucket(HeadBucketRequest request);

        /// <summary>
        /// Gets the metadata and body of an object.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        GetObjectResponse GetObject(GetObjectRequest request);

        /// <summary>
        /// Gets the object lifecycle policy for the bucket.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        GetObjectLifecyclePolicyResponse GetObjectLifecyclePolicy(GetObjectLifecyclePolicyRequest request);

        /// <summary>
        /// Gets the pre-authenticated request for the bucket.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        GetPreauthenticatedRequestResponse GetPreauthenticatedRequest(GetPreauthenticatedRequestRequest request);

        /// <summary>
        /// Download Object
        /// </summary>
        /// <param name="request"></param>
        /// <param name="savePath"></param>
        bool? DownloadObject(GetObjectRequest request, string savePath);

        /// <summary>
        /// Download Object
        /// </summary>
        /// <param name="request"></param>
        /// <param name="savePath"></param>
        /// <param name="filename"></param>
        bool? DownloadObject(GetObjectRequest request, string savePath, string filename);

        /// <summary>
        /// Gets a list of all BucketSummary items in a compartment. A BucketSummary contains only summary fields for the bucket and does not 
        /// contain fields like the user-defined metadata.
        /// To use this and other API operations, you must be authorized in an IAM policy. If you are not authorized, talk to an administrator. 
        /// If you are an administrator who needs to write policies to give users access, see Getting Started with Policies.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ListBucketsResponse ListBuckets(ListBucketsRequest request);

        /// <summary>
        /// To use this and other API operations, you must be authorized in an IAM policy. If you are not authorized, talk to an administrator. 
        /// If you are an administrator who needs to write policies to give users access, see Getting Started with Policies.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ListObjectsResponse ListObjects(ListObjectsRequest request);

        /// <summary>
        /// Lists the parts of an in-progress multipart upload.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ListMultipartUploadPartsResponse ListMultipartUploadParts(ListMultipartUploadPartsRequest request);

        /// <summary>
        /// Lists all of the in-progress multipart uploads for the given bucket in the given Object Storage namespace.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ListMultipartUploadsResponse ListMultipartUploads(ListMultipartUploadsRequest request);

        /// <summary>
        /// Lists pre-authenticated requests for the bucket.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ListPreauthenticatedRequestsResponse ListPreauthenticatedRequests(ListPreauthenticatedRequestsRequest request);

        /// <summary>
        /// Creates a bucket in the given namespace with a bucket name and optional user-defined metadata. Avoid entering confidential information in bucket names.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        CreateBucketResponse CreateBucket(CreateBucketRequest request);

        /// <summary>
        /// Rename an object in the given Object Storage namespace.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        RenameObjectResponse RenameObject(RenameObjectRequest request);

        /// <summary>
        /// Restores one or more objects specified by the objectName parameter. By default objects will be restored for 24 hours. Duration can be configured using the hours parameter.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        RestoreObjectsResponse RestoreObjects(RestoreObjectsRequest request);

        /// <summary>
        /// By default, buckets created using the Amazon S3 Compatibility API or the Swift API are created in the root compartment of the Oracle Cloud Infrastructure tenancy.
        /// 
        /// You can change the default Swift/Amazon S3 compartmentId designation to a different compartmentId. 
        /// All subsequent bucket creations will use the new default compartment, but no previously created buckets will be modified. 
        /// A user must have OBJECTSTORAGE_NAMESPACE_UPDATE permission to make changes to the default compartments for Amazon S3 and Swift.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        UpdateNamespaceMetadataResponse UpdateNamespaceMetadata(UpdateNamespaceMetadataRequest request);

        /// <summary>
        /// Performs a partial or full update of a bucket's user-defined metadata.
        /// 
        /// Use UpdateBucket to move a bucket from one compartment to another within the same tenancy. 
        /// Supply the compartmentID of the compartment that you want to move the bucket to. 
        /// For more information about moving resources between compartments, see Moving Resources to a Different Compartment.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        UpdateBucketResponse UpdateBucket(UpdateBucketRequest request);

        /// <summary>
        /// Creates a new object or overwrites an existing object with the same name. The maximum object size allowed by PutObject is 50 GiB.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        PutObjectResponse PutObject(PutObjectRequest request);

        /// <summary>
        /// Uploads a single part of a multipart upload.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        UploadPartResponse UploadPart(UploadPartRequest request);

        /// <summary>
        /// Creates or replaces the object lifecycle policy for the bucket.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        PutObjectLifecyclePolicyResponse PutObjectLifecyclePolicy(PutObjectLifecyclePolicyRequest request);

        /// <summary>
        /// Re-encrypts the unique data encryption key that encrypts each object written to the bucket by using the most recent version of the master encryption key assigned to the bucket.
        /// (All data encryption keys are encrypted by a master encryption key. Master encryption keys are assigned to buckets and managed by Oracle by default, but you can assign a key that 
        /// you created and control through the Oracle Cloud Infrastructure Key Management service.) The kmsKeyId property of the bucket determines which master encryption key is assigned to the 
        /// bucket. If you assigned a different Key Management master encryption key to the bucket, you can call this API to re-encrypt all data encryption keys with the newly assigned key. 
        /// Similarly, you might want to re-encrypt all data encryption keys if the assigned key has been rotated to a new key version since objects were last added to the bucket. If you call this 
        /// API and there is no kmsKeyId associated with the bucket, the call will fail.
        /// 
        /// Calling this API starts a work request task to re-encrypt the data encryption key of all objects in the bucket. Only objects created before the time of the API call will be re-encrypted. 
        /// The call can take a long time, depending on how many objects are in the bucket and how big they are. This API returns a work request ID that you can use to retrieve the status of the 
        /// work request task.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ReencryptBucketResponse ReencryptBucket(ReencryptBucketRequest request);

        /// <summary>
        /// Starts a new multipart upload to a specific object in the given bucket in the given namespace.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        CreateMultipartUploadResponse CreateMultipartUpload(CreateMultipartUploadRequest request);

        /// <summary>
        /// Commits a multipart upload, which involves checking part numbers and entity tags (ETags) of the parts, to create an aggregate object.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        CommitMultipartUploadResponse CommitMultipartUpload(CommitMultipartUploadRequest request);

        /// <summary>
        /// Creates a pre-authenticated request specific to the bucket.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        CreatePreauthenticatedRequestResponse CreatePreauthenticatedRequest(CreatePreauthenticatedRequestRequest request);

        /// <summary>
        /// Deletes a bucket if the bucket is already empty. 
        /// If the bucket is not empty, use DeleteObject first. 
        /// In addition, you cannot delete a bucket that has a multipart upload in progress or a pre-authenticated request associated with that bucket.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        DeleteBucketResponse DeleteBucket(DeleteBucketRequest request);

        /// <summary>
        /// Deletes an object.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        DeleteObjectResponse DeleteObject(DeleteObjectRequest request);

        /// <summary>
        /// Deletes an objects.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        DeleteObjectsResponse DeleteObjects(DeleteObjectsRequest request);

        /// <summary>
        /// Deletes the object lifecycle policy for the bucket.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        DeleteObjectLifecyclePolicyResponse DeleteObjectLifecyclePolicy(DeleteObjectLifecyclePolicyRequest request);

        /// <summary>
        /// Deletes the pre-authenticated request for the bucket.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        DeletePreauthenticatedRequestResponse DeletePreauthenticatedRequest(DeletePreauthenticatedRequestRequest request);

        /// <summary>
        /// Aborts an in-progress multipart upload and deletes all parts that have been uploaded.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        AbortMultipartUploadResponse AbortMultipartUpload(AbortMultipartUploadRequest request);

        /// <summary>
        /// Gets the status of the work request for the given ID.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        GetWorkRequestResponse GetWorkRequest(GetWorkRequestRequest request);

        /// <summary>
        /// Lists the work requests in a compartment.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ListWorkRequestsResponse ListWorkRequests(ListWorkRequestsRequest request);

        /// <summary>
        /// Cancels a work request.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        CancelWorkRequestResponse CancelWorkRequest(CancelWorkRequestRequest request);

        /// <summary>
        /// Lists the errors of the work request with the given ID.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ListWorkRequestErrorsResponse ListWorkRequestErrors(ListWorkRequestErrorsRequest request);

        /// <summary>
        /// Lists the logs of the work request with the given ID.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ListWorkRequestLogsResponse ListWorkRequestLogs(ListWorkRequestLogsRequest request);
    }
}

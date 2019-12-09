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
        /// Download Object
        /// </summary>
        /// <param name="request"></param>
        /// <param name="savePath"></param>
        /// <param name="filename"></param>
        void DownloadObject(GetObjectRequest request, string savePath, string filename);

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
        /// Creates a bucket in the given namespace with a bucket name and optional user-defined metadata. Avoid entering confidential information in bucket names.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        CreateBucketResponse CreateBucket(CreateBucketRequest request);

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
        /// Deletes a bucket if the bucket is already empty. 
        /// If the bucket is not empty, use DeleteObject first. 
        /// In addition, you cannot delete a bucket that has a multipart upload in progress or a pre-authenticated request associated with that bucket.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        DeleteBucketResponse DeleteBucket(DeleteBucketRequest request);
    }
}

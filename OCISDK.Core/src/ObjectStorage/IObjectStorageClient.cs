using OCISDK.Core.src.ObjectStorage.Request;
using OCISDK.Core.src.ObjectStorage.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.src.ObjectStorage
{
    interface IObjectStorageClient
    {
        /// <summary>
        /// setter region
        /// </summary>
        /// <param name="region"></param>
        void SetRegion(string region);

        /// <summary>
        /// getter region
        /// </summary>
        /// <returns></returns>
        string GetRegion();

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
        /// Gets the metadata and body of an object.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        GetObjectResponse GetObject(GetObjectRequest request);

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
    }
}

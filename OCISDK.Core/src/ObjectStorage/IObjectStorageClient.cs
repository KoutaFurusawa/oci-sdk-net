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
        /// Gets the current representation of the given bucket in the given Object Storage namespace.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        GetBucketResponse GetBucket(GetBucketRequest request);
    }
}

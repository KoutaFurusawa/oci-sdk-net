using OCISDK.Core.src.Audit;
using OCISDK.Core.src.Core;
using OCISDK.Core.src.Identity;
using OCISDK.Core.src.ObjectStorage;
using OCISDK.Core.src.Search;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.src
{
    public interface IOciSession
    {
        /// <summary>
        /// Get IdentityClinet
        /// </summary>
        /// <returns></returns>
        IIdentityClient GetIdentityClient();

        /// <summary>
        /// Get ComputeClient
        /// </summary>
        /// <returns></returns>
        IComputeClient GetComputeClient();

        /// <summary>
        /// Get BlockstorageClient
        /// </summary>
        /// <returns></returns>
        IBlockstorageClient GetBlockstorageClient();

        /// <summary>
        /// Get VirtualNetworkClient
        /// </summary>
        /// <returns></returns>
        IVirtualNetworkClient GetVirtualNetworkClient();

        /// <summary>
        /// Get AuditClient
        /// </summary>
        /// <returns></returns>
        IAuditClient GetAuditClient();

        /// <summary>
        /// Get ObjectStorageClient
        /// </summary>
        /// <returns></returns>
        IObjectStorageClient GetObjectStorageClient();

        /// <summary>
        /// Get SearchClient
        /// </summary>
        /// <returns></returns>
        ISearchClient GetSearchClient();

        /// <summary>
        /// Get WorkRequestClient
        /// </summary>
        /// <returns></returns>
        IWorkRequestClient GetWorkRequestClient();

        /// <summary>
        /// Get IdentityClinet Async
        /// </summary>
        /// <returns></returns>
        IIdentityClientAsync GetIdentityClientAsync();
    }
}

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
        /// Get IdentityClinet Async
        /// </summary>
        /// <returns></returns>
        IIdentityClientAsync GetIdentityClientAsync();

        /// <summary>
        /// Get ComputeClient
        /// </summary>
        /// <returns></returns>
        IComputeClient GetComputeClient();

        /// <summary>
        /// Get ComputeClient Async
        /// </summary>
        /// <returns></returns>
        IComputeClientAsync GetComputeClientAsync();

        /// <summary>
        /// Get BlockstorageClient
        /// </summary>
        /// <returns></returns>
        IBlockstorageClient GetBlockstorageClient();

        /// <summary>
        /// Get BlockstorageClient Async
        /// </summary>
        /// <returns></returns>
        IBlockstorageClientAsync GetBlockstorageClientAsync();

        /// <summary>
        /// Get VirtualNetworkClient
        /// </summary>
        /// <returns></returns>
        IVirtualNetworkClient GetVirtualNetworkClient();

        /// <summary>
        /// Get VirtualNetworkClient Async
        /// </summary>
        /// <returns></returns>
        IVirtualNetworkClientAsync GetVirtualNetworkClientAsync();

        /// <summary>
        /// Get AuditClient
        /// </summary>
        /// <returns></returns>
        IAuditClient GetAuditClient();

        /// <summary>
        /// Get AuditClient Async
        /// </summary>
        /// <returns></returns>
        IAuditClientAsync GetAuditClientAsync();

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
        /// Get SearchClient Async
        /// </summary>
        /// <returns></returns>
        ISearchClientAsync GetSearchClientAsync();

        /// <summary>
        /// Get WorkRequestClient
        /// </summary>
        /// <returns></returns>
        IWorkRequestClient GetWorkRequestClient();

        /// <summary>
        /// Get WorkRequestClient Async
        /// </summary>
        /// <returns></returns>
        IWorkRequestClientAsync GetWorkRequestClientAsync();

    }
}

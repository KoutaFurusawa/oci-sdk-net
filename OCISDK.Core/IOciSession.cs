using OCISDK.Core.Audit;
using OCISDK.Core.Core;
using OCISDK.Core.Database;
using OCISDK.Core.DNS;
using OCISDK.Core.FileStorage;
using OCISDK.Core.Identity;
using OCISDK.Core.LoadBalancer;
using OCISDK.Core.Notification;
using OCISDK.Core.Monitoring;
using OCISDK.Core.ObjectStorage;
using OCISDK.Core.Search;
using OCISDK.Core.UnpublishedService.Commercial;
using OCISDK.Core.UnpublishedService.UsageCosts;
using OCISDK.Core.Waas;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core
{
    /// <summary>
    /// OciSession interface
    /// </summary>
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
        /// Get ComputeClient
        /// </summary>
        /// <returns></returns>
        IComputeManagementClient GetComputeManagementClient();

        /// <summary>
        /// Get ComputeClient Async
        /// </summary>
        /// <returns></returns>
        IComputeManagementClientAsync GetComputeManagementClientAsync();

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
        /// Get FileStorageClient
        /// </summary>
        /// <returns></returns>
        IFileStorageClient GetFileStorageClient();

        /// <summary>
        /// Get FileStorageClient Async
        /// </summary>
        /// <returns></returns>
        IFileStorageClientAsync GetFileStorageClientAsync();

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

        /// <summary>
        /// Get DatabaseClient
        /// </summary>
        /// <returns></returns>
        IDatabaseClient GetDatabaseClient();

        /// <summary>
        /// Get DatabaseClient Async
        /// </summary>
        /// <returns></returns>
        IDatabaseClientAsync GetDatabaseClientAsync();

        /// <summary>
        /// Get LoadBalancerClient
        /// </summary>
        /// <returns></returns>
        ILoadBalancerClient GetLoadBalancerClient();

        /// <summary>
        /// Get LoadBalancerClient Async
        /// </summary>
        /// <returns></returns>
        ILoadBalancerClientAsync GetLoadBalancerClientAsync();

        /// <summary>
        /// Get MonitoringClient
        /// </summary>
        /// <returns></returns>
        IMonitoringClient GetMonitoringClient();

        /// <summary>
        /// Get MonitoringClient Async
        /// </summary>
        /// <returns></returns>
        IMonitoringClientAsync GetMonitoringClientAsync();

        /// <summary>
        /// Get NotificationClient
        /// </summary>
        /// <returns></returns>
        INotificationClient GetNotificationClient();

        /// <summary>
        /// Get NotificationClient Async
        /// </summary>
        /// <returns></returns>
        INotificationClientAsync GetNotificationClientAsync();

        /// <summary>
        /// Get DNSClient
        /// </summary>
        /// <returns></returns>
        IDNSClient GetDNSClient();

        /// <summary>
        /// Get DNSClient Async
        /// </summary>
        /// <returns></returns>
        IDNSClientAsync GetDNSClientAsync();

        /// <summary>
        /// Get WaasClient
        /// </summary>
        /// <returns></returns>
        IWaasClient GetWaasClient();

        /// <summary>
        /// Get WaasClient Async
        /// </summary>
        /// <returns></returns>
        IWaasClientAsync GetWaasClientAsync();

        /// <summary>
        /// Get CommercialClient
        /// 
        /// The client officially uses an unpublished API.
        /// </summary>
        /// <returns></returns>
        ICommercialClient GetCommercialClient();

        /// <summary>
        /// Get UsageCostsClient
        /// 
        /// The client officially uses an unpublished API.
        /// </summary>
        /// <returns></returns>
        IUsageCostsClient GetUsageCostsClient();
    }
}

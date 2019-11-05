using OCISDK.Core.src.Audit;
using OCISDK.Core.src.Core;
using OCISDK.Core.src.Database;
using OCISDK.Core.src.DNS;
using OCISDK.Core.src.Identity;
using OCISDK.Core.src.LoadBalancer;
using OCISDK.Core.src.Monitoring;
using OCISDK.Core.src.ObjectStorage;
using OCISDK.Core.src.Search;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OCISDK.Core.src
{
    /// <summary>
    /// Oci Session Class
    /// </summary>
    public class OciSession : IOciSession
    {
        public readonly OciSigner OciSigner;

        public readonly ClientConfigStream ClientConfigStream;

        public OciSession(ClientConfig config)
        {
            var streamConfig = new ClientConfigStream
            {
                AccountId = config.AccountId,
                DomainName = config.DomainName,
                Fingerprint = config.Fingerprint,
                HomeRegion = config.HomeRegion,
                IdentityDomain = config.IdentityDomain,
                Password = config.Password,
                PrivateKeyPassphrase = config.PrivateKeyPassphrase,
                TenancyId = config.TenancyId,
                UserId = config.UserId,
                UserName = config.UserName
            };

            using (var key = File.OpenText(config.PrivateKey))
            {
                streamConfig.PrivateKey = key;
            }

            OciSigner = new OciSigner(
                streamConfig.TenancyId,
                streamConfig.UserId,
                streamConfig.Fingerprint,
                streamConfig.PrivateKey,
                streamConfig.PrivateKeyPassphrase
            );

            ClientConfigStream = streamConfig;

        }

        public OciSession(ClientConfigStream config)
        {
            OciSigner = new OciSigner(
                config.TenancyId,
                config.UserId,
                config.Fingerprint,
                config.PrivateKey,
                config.PrivateKeyPassphrase
            );

            ClientConfigStream = config;
        }

        /// <summary>
        /// Get IdentityClinet
        /// </summary>
        /// <returns></returns>
        public IIdentityClient GetIdentityClient()
        {
            return new IdentityClient(ClientConfigStream, OciSigner);
        }

        /// <summary>
        /// Get IdentityClinet Async
        /// </summary>
        /// <returns></returns>
        public IIdentityClientAsync GetIdentityClientAsync()
        {
            return new IdentityClientAsync(ClientConfigStream, OciSigner);
        }

        /// <summary>
        /// Get ComputeClient
        /// </summary>
        /// <returns></returns>
        public IComputeClient GetComputeClient()
        {
            return new ComputeClient(ClientConfigStream, OciSigner);
        }

        /// <summary>
        /// Get ComputeClient Async
        /// </summary>
        /// <returns></returns>
        public IComputeClientAsync GetComputeClientAsync()
        {
            return new ComputeClientAsync(ClientConfigStream, OciSigner);
        }

        /// <summary>
        /// Get BlockstorageClient
        /// </summary>
        /// <returns></returns>
        public IBlockstorageClient GetBlockstorageClient()
        {
            return new BlockstorageClient(ClientConfigStream, OciSigner);
        }

        /// <summary>
        /// Get BlockstorageClient Async
        /// </summary>
        /// <returns></returns>
        public IBlockstorageClientAsync GetBlockstorageClientAsync()
        {
            return new BlockstorageClientAsync(ClientConfigStream, OciSigner);
        }

        /// <summary>
        /// Get VirtualNetworkClient
        /// </summary>
        /// <returns></returns>
        public IVirtualNetworkClient GetVirtualNetworkClient()
        {
            return new VirtualNetworkClient(ClientConfigStream, OciSigner);
        }

        /// <summary>
        /// Get VirtualNetworkClient Async
        /// </summary>
        /// <returns></returns>
        public IVirtualNetworkClientAsync GetVirtualNetworkClientAsync()
        {
            return new VirtualNetworkClientAsync(ClientConfigStream, OciSigner);
        }

        /// <summary>
        /// Get AuditClient
        /// </summary>
        /// <returns></returns>
        public IAuditClient GetAuditClient()
        {
            return new AuditClient(ClientConfigStream, OciSigner);
        }

        /// <summary>
        /// Get AuditClient Async
        /// </summary>
        /// <returns></returns>
        public IAuditClientAsync GetAuditClientAsync()
        {
            return new AuditClientAsync(ClientConfigStream, OciSigner);
        }

        /// <summary>
        /// Get ObjectStorageClient
        /// </summary>
        /// <returns></returns>
        public IObjectStorageClient GetObjectStorageClient()
        {
            return new ObjectStorageClient(ClientConfigStream, OciSigner);
        }

        /// <summary>
        /// Get SearchClient
        /// </summary>
        /// <returns></returns>
        public ISearchClient GetSearchClient()
        {
            return new SearchClient(ClientConfigStream, OciSigner);
        }

        /// <summary>
        /// Get SearchClient Async
        /// </summary>
        /// <returns></returns>
        public ISearchClientAsync GetSearchClientAsync()
        {
            return new SearchClientAsync(ClientConfigStream, OciSigner);
        }

        /// <summary>
        /// Get WorkRequestClient
        /// </summary>
        /// <returns></returns>
        public IWorkRequestClient GetWorkRequestClient()
        {
            return new WorkRequestClient(ClientConfigStream, OciSigner);
        }

        /// <summary>
        /// Get WorkRequestClient Async
        /// </summary>
        /// <returns></returns>
        public IWorkRequestClientAsync GetWorkRequestClientAsync()
        {
            return new WorkRequestClientAsync(ClientConfigStream, OciSigner);
        }

        /// <summary>
        /// Get DatabaseClient
        /// </summary>
        /// <returns></returns>
        public IDatabaseClient GetDatabaseClient()
        {
            return new DatabaseClient(ClientConfigStream, OciSigner);
        }

        /// <summary>
        /// Get DatabaseClient Async
        /// </summary>
        /// <returns></returns>
        public IDatabaseClientAsync GetDatabaseClientAsync()
        {
            return new DatabaseClientAsync(ClientConfigStream, OciSigner);
        }

        /// <summary>
        /// Get DNSClient
        /// </summary>
        /// <returns></returns>
        public IDNSClient GetDNSClient()
        {
            return new DNSClient(ClientConfigStream, OciSigner);
        }

        /// <summary>
        /// Get DNSClient Async
        /// </summary>
        /// <returns></returns>
        public IDNSClientAsync GetDNSClientAsync()
        {
            return new DNSClientAsync(ClientConfigStream, OciSigner);
        }

        /// <summary>
        /// Get LoadBalancerClient
        /// </summary>
        /// <returns></returns>
        public ILoadBalancerClient GetLoadBalancerClient()
        {
            return new LoadBalancerClient(ClientConfigStream, OciSigner);
        }

        /// <summary>
        /// Get LoadBalancerClient Async
        /// </summary>
        /// <returns></returns>
        public ILoadBalancerClientAsync GetLoadBalancerClientAsync()
        {
            return new LoadBalancerClientAsync(ClientConfigStream, OciSigner);
        }

        /// <summary>
        /// Get MonitoringClient
        /// </summary>
        /// <returns></returns>
        public IMonitoringClient GetMonitoringClient()
        {
            return new MonitoringClient(ClientConfigStream, OciSigner);
        }

        /// <summary>
        /// Get MonitoringClient Async
        /// </summary>
        /// <returns></returns>
        public IMonitoringClientAsync GetMonitoringClientAsync()
        {
            return new MonitoringClientAsync(ClientConfigStream, OciSigner);
        }
    }
}

using OCISDK.Core.src.Audit;
using OCISDK.Core.src.Core;
using OCISDK.Core.src.Identity;
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
        
        public IdentityClient GetIdentityClient()
        {
            return new IdentityClient(ClientConfigStream, OciSigner);
        }

        public ComputeClient GetComputeClient()
        {
            return new ComputeClient(ClientConfigStream, OciSigner);
        }

        public BlockstorageClient GetBlockstorageClient()
        {
            return new BlockstorageClient(ClientConfigStream, OciSigner);
        }

        public VirtualNetworkClient GetVirtualNetworkClient()
        {
            return new VirtualNetworkClient(ClientConfigStream, OciSigner);
        }

        public AuditClient GetAuditClient()
        {
            return new AuditClient(ClientConfigStream, OciSigner);
        }

        public ObjectStorageClient GetObjectStorageClient()
        {
            return new ObjectStorageClient(ClientConfigStream, OciSigner);
        }
        
        public SearchClient GetSearchClient()
        {
            return new SearchClient(ClientConfigStream, OciSigner);
        }

        public WorkRequestClient GetWorkRequestClient()
        {
            return new WorkRequestClient(ClientConfigStream, OciSigner);
        }
    }
}

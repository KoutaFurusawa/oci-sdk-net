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
        IdentityClient GetIdentityClient();

        ComputeClient GetComputeClient();

        BlockstorageClient GetBlockstorageClient();

        VirtualNetworkClient GetVirtualNetworkClient();

        AuditClient GetAuditClient();

        ObjectStorageClient GetObjectStorageClient();

        SearchClient GetSearchClient();

        WorkRequestClient GetWorkRequestClient();
    }
}

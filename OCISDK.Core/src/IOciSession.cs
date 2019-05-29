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
        IIdentityClient GetIdentityClient();

        IComputeClient GetComputeClient();

        IBlockstorageClient GetBlockstorageClient();

        IVirtualNetworkClient GetVirtualNetworkClient();

        IAuditClient GetAuditClient();

        IObjectStorageClient GetObjectStorageClient();

        ISearchClient GetSearchClient();
    }
}

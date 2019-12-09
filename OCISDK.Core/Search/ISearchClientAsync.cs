using OCISDK.Core.Search.Request;
using OCISDK.Core.Search.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OCISDK.Core.Search
{
    /// <summary>
    /// SearchClientAsync interface
    /// </summary>
    public interface ISearchClientAsync : IClientSetting
    {
        /// <summary>
        /// Queries any and all compartments in the tenancy to find resources that match the specified criteria.
        /// Results include resources that you have permission to view and can span different resource types.
        /// You can also sort results based on a specified resource attribute.
        /// </summary>
        /// <param name="searchResourcesRequest"></param>
        /// <returns></returns>
        Task<SearchResourcesResponse> SearchResources(SearchResourcesRequest searchResourcesRequest);
    }
}

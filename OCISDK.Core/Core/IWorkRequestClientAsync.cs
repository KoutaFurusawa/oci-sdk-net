using OCISDK.Core.Core.Request.WorkRequest;
using OCISDK.Core.Core.Response.WorkRequest;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OCISDK.Core.Core
{
    /// <summary>
    /// WorkRequestClientAsync interface
    /// </summary>
    public interface IWorkRequestClientAsync : IClientSetting
    {
        /// <summary>
        /// Lists the work requests in a compartment or for a specified resource.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        Task<ListWorkRequestsResponse> ListWorkRequests(ListWorkRequestsRequest param);

        /// <summary>
        /// Gets the errors for a work request.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        Task<ListWorkRequestErrorsResponse> ListWorkRequestErrors(ListWorkRequestErrorsRequest param);

        /// <summary>
        /// Gets the logs for a work request.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        Task<ListWorkRequestLogsResponse> ListWorkRequestLogs(ListWorkRequestLogsRequest param);

        /// <summary>
        /// Gets the details of a work request.
        /// </summary>
        /// <param name="getRequest"></param>
        /// <returns></returns>
        Task<GetWorkRequestResponse> GetWorkRequest(GetWorkRequestRequest getRequest);
    }
}

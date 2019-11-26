using OCISDK.Core.src.Core.Request.WorkRequest;
using OCISDK.Core.src.Core.Response.WorkRequest;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.src.Core
{
    /// <summary>
    /// WorkRequestClient interface
    /// </summary>
    public interface IWorkRequestClient
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
        /// Lists the work requests in a compartment or for a specified resource.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        ListWorkRequestsResponse ListWorkRequests(ListWorkRequestsRequest param);

        /// <summary>
        /// Gets the errors for a work request.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        ListWorkRequestErrorsResponse ListWorkRequestErrors(ListWorkRequestErrorsRequest param);

        /// <summary>
        /// Gets the logs for a work request.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        ListWorkRequestLogsResponse ListWorkRequestLogs(ListWorkRequestLogsRequest param);

        /// <summary>
        /// Gets the details of a work request.
        /// </summary>
        /// <param name="getRequest"></param>
        /// <returns></returns>
        GetWorkRequestResponse GetWorkRequest(GetWorkRequestRequest getRequest);
    }
}

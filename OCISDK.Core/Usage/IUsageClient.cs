using OCISDK.Core.Usage.Request;
using OCISDK.Core.Usage.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OCISDK.Core.Usage
{
    /// <summary>
    /// UsageClient interface
    /// </summary>
    public interface IUsageClient : IClientSetting
    {
        /// <summary>
        /// Returns the configurations list for the UI drop-down list.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        RequestSummarizedConfigurationsResponse RequestSummarizedConfigurations(RequestSummarizedConfigurationsRequest request);

        /// <summary>
        /// Returns the configurations list for the UI drop-down list.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<RequestSummarizedConfigurationsResponse> RequestSummarizedConfigurationsAsync(RequestSummarizedConfigurationsRequest request);

        /// <summary>
        /// Returns usage for the given account.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        RequestSummarizedUsagesResponse RequestSummarizedUsages(RequestSummarizedUsagesRequest request);

        /// <summary>
        /// Returns usage for the given account.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<RequestSummarizedUsagesResponse> RequestSummarizedUsagesAsync(RequestSummarizedUsagesRequest request);
    }
}

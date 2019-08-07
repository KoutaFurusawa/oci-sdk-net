using OCISDK.Core.src.Audit.Request;
using OCISDK.Core.src.Audit.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OCISDK.Core.src.Audit
{
    public interface IAuditClientAsync
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
        /// Returns all the audit events processed for the specified compartment within the specified time range.
        /// </summary>
        /// <param name="listRequest"></param>
        /// <returns></returns>
        Task<ListEventsResponse> ListEvents(ListEventsRequest listRequest);

        /// <summary>
        /// Get the configuration
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<GetConfigurationResponse> GetConfiguration(GetConfigurationRequest request);

        /// <summary>
        /// Update the configuration
        /// </summary>
        /// <param name="updateRequest"></param>
        /// <returns></returns>
        Task<UpdateConfigurationResponse> UpdateConfiguration(UpdateConfigurationRequest updateRequest);

    }
}

using OCISDK.Core.Audit.Request;
using OCISDK.Core.Audit.Response;
using OCISDK.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Audit
{
    /// <summary>
    /// AuditClient interface
    /// </summary>
    public interface IAuditClient : IClientSetting
    {
        /// <summary>
        /// Returns all the audit events processed for the specified compartment within the specified time range.
        /// </summary>
        /// <param name="listRequest"></param>
        /// <returns></returns>
        ListEventsResponse ListEvents(ListEventsRequest listRequest);

        /// <summary>
        /// Get the configuration
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        GetConfigurationResponse GetConfiguration(GetConfigurationRequest request);

        /// <summary>
        /// Update the configuration
        /// </summary>
        /// <param name="updateRequest"></param>
        /// <returns></returns>
        UpdateConfigurationResponse UpdateConfiguration(UpdateConfigurationRequest updateRequest);


    }
}

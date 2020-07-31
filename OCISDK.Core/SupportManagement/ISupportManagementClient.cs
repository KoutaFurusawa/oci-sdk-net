using OCISDK.Core.SupportManagement.Request;
using OCISDK.Core.SupportManagement.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.SupportManagement
{
    /// <summary>
    /// SupportManagementClient interface
    /// </summary>
    public interface ISupportManagementClient : IClientSetting
    {
        /// <summary>
        /// Enables the customer to create an support ticket.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        CreateIncidentResponse CreateIncident(CreateIncidentRequest request);

        /// <summary>
        /// Gets the details of the support ticket.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        GetIncidentResponse GetIncident(GetIncidentRequest request);

        /// <summary>
        /// Gets the status of the service.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        GetStatusResponse GetStatus(GetStatusRequest request);

        /// <summary>
        /// During support ticket creation, returns the list of all possible products that Oracle Cloud Infrastructure supports.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ListIncidentResourceTypesResponse ListIncidentResourceTypes(ListIncidentResourceTypesRequest request);

        /// <summary>
        /// Returns the list of support tickets raised by the tenancy.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ListIncidentsResponse ListIncidents(ListIncidentsRequest request);
    }
}

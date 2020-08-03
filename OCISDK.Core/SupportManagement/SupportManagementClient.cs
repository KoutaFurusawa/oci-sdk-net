using OCISDK.Core.Common;
using OCISDK.Core.SupportManagement.Model;
using OCISDK.Core.SupportManagement.Request;
using OCISDK.Core.SupportManagement.Response;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OCISDK.Core.SupportManagement
{
    /// <summary>
    /// SupportManagement service Client.
    /// Use the Support Management API to manage support requests. For more information, see Getting Help and 
    /// Contacting Support. Note: Before you can create service requests with this API, you need to have an Oracle Single 
    /// Sign On (SSO) account, and you need to register your Customer Support Identifier (CSI) with My Oracle Support.
    /// 
    /// Use the table of contents and search tool to explore the Support Management API.
    /// </summary>
    public class SupportManagementClient : ServiceClient, ISupportManagementClient
    {
        private readonly string SupportManagementServiceName = "support-management";

        /// <summary>
        /// Constructer
        /// </summary>
        public SupportManagementClient(ClientConfig config) : base(config)
        {
            ServiceName = SupportManagementServiceName;
        }

        /// <summary>
        /// Constructer
        /// </summary>
        public SupportManagementClient(ClientConfig config, IOciSigner ociSigner) : base(config, ociSigner)
        {
            ServiceName = SupportManagementServiceName;
        }

        /// <summary>
        /// Constructer
        /// </summary>
        public SupportManagementClient(ClientConfigStream config) : base(config)
        {
            ServiceName = SupportManagementServiceName;
        }

        /// <summary>
        /// Constructer
        /// </summary>
        public SupportManagementClient(ClientConfigStream config, IOciSigner ociSigner) : base(config, ociSigner)
        {
            ServiceName = SupportManagementServiceName;
        }

        /// <summary>
        /// Enables the customer to create an support ticket.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public CreateIncidentResponse CreateIncident(CreateIncidentRequest request)
        {
            var uri = new Uri($"{GetEndPoint(SupportManagementServices.Incidents, this.Region)}");

            var headers = new HttpRequestHeaderParam() {
                OpcRetryToken = request.OpcRetryToken,
                OpcRequestId = request.OpcRequestId
            };
            headers.FreeHeader.Add("ocid", request.Ocid);
            if (!string.IsNullOrEmpty(request.Homeregion))
            {
                headers.FreeHeader.Add("homeregion", request.Homeregion);
            }
            using (var webResponse = this.RestClient.Post(uri, request.CreateIncident, headers))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new CreateIncidentResponse()
                {
                    Incident = this.JsonSerializer.Deserialize<IncidentDetails>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    ETag = webResponse.Headers.Get("ETag")
                };
            }
        }

        /// <summary>
        /// Create user to request Customer Support Identifier(CSI) to Customer User Administrator(CUA).
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public CreateUserResponse CreateUser(CreateUserRequest request)
        {
            var uri = new Uri($"{GetEndPoint(SupportManagementServices.Users, this.Region)}");

            var headers = new HttpRequestHeaderParam()
            {
                OpcRetryToken = request.OpcRetryToken,
                OpcRequestId = request.OpcRequestId
            };
            headers.FreeHeader.Add("ocid", request.Ocid);
            if (!string.IsNullOrEmpty(request.Homeregion))
            {
                headers.FreeHeader.Add("homeregion", request.Homeregion);
            }
            using (var webResponse = this.RestClient.Post(uri, request.CreateUserDetails, headers))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new CreateUserResponse()
                {
                    User = this.JsonSerializer.Deserialize<UserDetails>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    ETag = webResponse.Headers.Get("ETag")
                };
            }
        }

        /// <summary>
        /// Checks whether the requested user is valid.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ValidateUserResponse ValidateUser(ValidateUserRequest request)
        {
            var uri = new Uri($"{GetEndPoint(SupportManagementServices.Incidents, this.Region)}/user/validate?{request.ProblemType}");

            var headers = new HttpRequestHeaderParam()
            {
                OpcRequestId = request.OpcRequestId
            };
            headers.FreeHeader.Add("csi", request.Csi);
            headers.FreeHeader.Add("ocid", request.Ocid);
            if (!string.IsNullOrEmpty(request.Homeregion))
            {
                headers.FreeHeader.Add("homeregion", request.Homeregion);
            }
            using (var webResponse = this.RestClient.Get(uri, headers))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ValidateUserResponse()
                {
                    ValidationResponse = this.JsonSerializer.Deserialize<ValidationResponseDetails>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    ETag = webResponse.Headers.Get("ETag")
                };
            }
        }

        /// <summary>
        /// Gets the details of the support ticket.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public GetIncidentResponse GetIncident(GetIncidentRequest request)
        {
            var uri = new Uri($"{GetEndPoint(SupportManagementServices.Incidents, this.Region)}/{request.IncidentKey}");

            var headers = new HttpRequestHeaderParam()
            {
                OpcRequestId = request.OpcRequestId
            };
            headers.FreeHeader.Add("csi", request.Csi);
            headers.FreeHeader.Add("ocid", request.Ocid);
            if (!string.IsNullOrEmpty(request.Homeregion))
            {
                headers.FreeHeader.Add("homeregion", request.Homeregion);
            }
            using (var webResponse = this.RestClient.Get(uri, headers))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new GetIncidentResponse()
                {
                    Incident = this.JsonSerializer.Deserialize<IncidentDetails>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    ETag = webResponse.Headers.Get("ETag")
                };
            }
        }

        /// <summary>
        /// Gets the status of the service.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public GetStatusResponse GetStatus(GetStatusRequest request)
        {
            var uri = new Uri($"{GetEndPoint(SupportManagementServices.Incidents, this.Region)}/status/{request.Source}");

            var headers = new HttpRequestHeaderParam()
            {
                OpcRequestId = request.OpcRequestId
            };
            headers.FreeHeader.Add("ocid", request.Ocid);
            if (!string.IsNullOrEmpty(request.Homeregion))
            {
                headers.FreeHeader.Add("homeregion", request.Homeregion);
            }
            using (var webResponse = this.RestClient.Get(uri, headers))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new GetStatusResponse()
                {
                    Status = this.JsonSerializer.Deserialize<StatusDetails>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    ETag = webResponse.Headers.Get("ETag")
                };
            }
        }

        /// <summary>
        /// During support ticket creation, returns the list of all possible products that Oracle Cloud Infrastructure supports.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ListIncidentResourceTypesResponse ListIncidentResourceTypes(ListIncidentResourceTypesRequest request)
        {
            var uri = new Uri($"{GetEndPoint(SupportManagementServices.Incidents, this.Region)}/incidentResourceTypes?{request.GetOptionQuery()}");

            var headers = new HttpRequestHeaderParam()
            {
                OpcRequestId = request.OpcRequestId
            };
            headers.FreeHeader.Add("csi", request.Csi);
            headers.FreeHeader.Add("ocid", request.Ocid);
            if (!string.IsNullOrEmpty(request.Homeregion))
            {
                headers.FreeHeader.Add("homeregion", request.Homeregion);
            }
            using (var webResponse = this.RestClient.Get(uri, headers))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListIncidentResourceTypesResponse()
                {
                    Items = this.JsonSerializer.Deserialize<List<IncidentResourceType>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page"),
                    ETag = webResponse.Headers.Get("ETag")
                };
            }
        }

        /// <summary>
        /// Returns the list of support tickets raised by the tenancy.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ListIncidentsResponse ListIncidents(ListIncidentsRequest request)
        {
            var uri = new Uri($"{GetEndPoint(SupportManagementServices.Incidents, this.Region)}?{request.GetOptionQuery()}");

            var headers = new HttpRequestHeaderParam()
            {
                OpcRequestId = request.OpcRequestId
            };
            headers.FreeHeader.Add("csi", request.Csi);
            headers.FreeHeader.Add("ocid", request.Ocid);
            if (!string.IsNullOrEmpty(request.Homeregion))
            {
                headers.FreeHeader.Add("homeregion", request.Homeregion);
            }
            using (var webResponse = this.RestClient.Get(uri, headers))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListIncidentsResponse()
                {
                    Items = this.JsonSerializer.Deserialize<List<IncidentSummary>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page"),
                    ETag = webResponse.Headers.Get("ETag")
                };
            }
        }
    }
}

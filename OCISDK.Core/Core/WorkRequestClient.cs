using OCISDK.Core.Common;
using OCISDK.Core.Core.Model.WorkRequest;
using OCISDK.Core.Core.Request.WorkRequest;
using OCISDK.Core.Core.Response.WorkRequest;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OCISDK.Core.Core
{
    /// <summary>
    /// WorkRequestClient
    /// </summary>
    public class WorkRequestClient : ServiceClient, IWorkRequestClient
    {
        private readonly string WorkRequestServiceName = "core";

        /// <summary>
        /// Constructer
        /// </summary>
        public WorkRequestClient(ClientConfig config) : base(config)
        {
            ServiceName = WorkRequestServiceName;
        }

        /// <summary>
        /// Constructer
        /// </summary>
        public WorkRequestClient(ClientConfig config, OciSigner ociSigner) : base(config, ociSigner)
        {
            ServiceName = WorkRequestServiceName;
        }

        /// <summary>
        /// Constructer
        /// </summary>
        public WorkRequestClient(ClientConfigStream config) : base(config)
        {
            ServiceName = WorkRequestServiceName;
        }

        /// <summary>
        /// Constructer
        /// </summary>
        public WorkRequestClient(ClientConfigStream config, OciSigner ociSigner) : base(config, ociSigner)
        {
            ServiceName = WorkRequestServiceName;
        }
        
        /// <summary>
        /// Lists the work requests in a compartment or for a specified resource.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public ListWorkRequestsResponse ListWorkRequests(ListWorkRequestsRequest param)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.WorkRequests, this.Region)}?{param.GetOptionQuery()}");

            var webResponse = this.RestClient.Get(uri, new HttpRequestHeaderParam { OpcRequestId = param.OpcRequestId });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListWorkRequestsResponse()
                {
                    Items = JsonSerializer.Deserialize<List<WorkRequestSummary>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
        }

        /// <summary>
        /// Gets the errors for a work request.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public ListWorkRequestErrorsResponse ListWorkRequestErrors(ListWorkRequestErrorsRequest param)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.WorkRequests, this.Region)}/{param.WorkRequestId}/errors?{param.GetOptionQuery()}");

            var webResponse = this.RestClient.Get(uri, new HttpRequestHeaderParam { OpcRequestId = param.OpcRequestId });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListWorkRequestErrorsResponse()
                {
                    Items = JsonSerializer.Deserialize<List<WorkRequestError>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
        }

        /// <summary>
        /// Gets the logs for a work request.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public ListWorkRequestLogsResponse ListWorkRequestLogs(ListWorkRequestLogsRequest param)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.WorkRequests, this.Region)}/{param.WorkRequestId}/logs?{param.GetOptionQuery()}");

            var webResponse = this.RestClient.Get(uri, new HttpRequestHeaderParam { OpcRequestId = param.OpcRequestId });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListWorkRequestLogsResponse()
                {
                    Items = JsonSerializer.Deserialize<List<WorkRequestLogEntry>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
        }

        /// <summary>
        /// Gets the details of a work request.
        /// </summary>
        /// <param name="getRequest"></param>
        /// <returns></returns>
        public GetWorkRequestResponse GetWorkRequest(GetWorkRequestRequest getRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.WorkRequests, this.Region)}/{getRequest.WorkRequestId}");

            var webResponse = this.RestClient.Get(uri);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new GetWorkRequestResponse()
                {
                    WorkRequest = JsonSerializer.Deserialize<WorkRequestModel>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

    }
}

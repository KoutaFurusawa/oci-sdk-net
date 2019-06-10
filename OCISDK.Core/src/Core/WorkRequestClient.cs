using OCISDK.Core.src.Core.Model.WorkRequest;
using OCISDK.Core.src.Core.Request.WorkRequest;
using OCISDK.Core.src.Core.Response.WorkRequest;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OCISDK.Core.src.Core
{
    public class WorkRequestClient : ServiceClient, IWorkRequestClient
    {
        /// <summary>
        /// Constructer
        /// </summary>
        public WorkRequestClient(ClientConfig config) : base(config)
        {
            ServiceName = "core";
        }

        public WorkRequestClient(ClientConfig config, OciSigner ociSigner) : base(config, ociSigner)
        {
            ServiceName = "core";
        }

        public WorkRequestClient(ClientConfigStream config) : base(config)
        {
            ServiceName = "core";
        }

        public WorkRequestClient(ClientConfigStream config, OciSigner ociSigner) : base(config, ociSigner)
        {
            ServiceName = "core";
        }

        /// <summary>
        /// setter Region
        /// </summary>
        /// <param name="region"></param>
        public void SetRegion(string region)
        {
            Region = region;
        }

        /// <summary>
        /// getter region
        /// </summary>
        /// <returns></returns>
        public string GetRegion()
        {
            return Region;
        }

        /// <summary>
        /// Lists the work requests in a compartment or for a specified resource.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public ListWorkRequestsResponse ListWorkRequests(ListWorkRequestsRequest param)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.WorkRequests, this.Region)}?{param.GetOptionQuery()}");

            var webResponse = this.RestClient.Get(uri, param.OpcRequestId);

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
    }
}

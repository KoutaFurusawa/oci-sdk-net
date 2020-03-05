using OCISDK.Core.Common;
using OCISDK.Core.UnpublishedService.ConsoleIdcs.Model;
using OCISDK.Core.UnpublishedService.ConsoleIdcs.Request;
using OCISDK.Core.UnpublishedService.ConsoleIdcs.Response;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OCISDK.Core.UnpublishedService.ConsoleIdcs
{
    /// <summary>
    /// ConsoleIdcsClient
    /// </summary>
    public class ConsoleIdcsClient : ServiceClient, IConsoleIdcsClient
    {
        private readonly string UsageCostsServiceName = "console-idcs";

        /// <summary>
        /// Constructer
        /// </summary>
        public ConsoleIdcsClient(ClientConfig config) : base(config)
        {
            ServiceName = UsageCostsServiceName;
        }

        /// <summary>
        /// Constructer
        /// </summary>
        public ConsoleIdcsClient(ClientConfig config, OciSigner ociSigner) : base(config, ociSigner)
        {
            ServiceName = UsageCostsServiceName;
        }

        /// <summary>
        /// Constructer
        /// </summary>
        public ConsoleIdcsClient(ClientConfigStream config) : base(config)
        {
            ServiceName = UsageCostsServiceName;
        }

        /// <summary>
        /// Constructer
        /// </summary>
        public ConsoleIdcsClient(ClientConfigStream config, OciSigner ociSigner) : base(config, ociSigner)
        {
            ServiceName = UsageCostsServiceName;
        }

        /// <summary>
        /// GetIdcsUser
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public GetIdcsUserResponse GetIdcsUser(GetIdcsUserRequest request)
        {
            var uri = new Uri(GetEndPoint(ConsoleIdcsServices.Users, this.Region));

            //var uri = new Uri("https://" +
            //    "console.us-ashburn-1.oraclecloud.com/a/identity/federations");

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                OpcRequestId = request.OpcRequestId
            };
            var webResponse = this.RestClient.Get(uri, httpRequestHeaderParam);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new GetIdcsUserResponse()
                {
                    IdcsUsers = this.JsonSerializer.Deserialize<List<IdcsUser>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }
    }
}

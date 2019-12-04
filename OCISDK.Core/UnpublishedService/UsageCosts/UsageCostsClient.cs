using OCISDK.Core.Common;
using OCISDK.Core.UnpublishedService.UsageCosts.Model;
using OCISDK.Core.UnpublishedService.UsageCosts.Request;
using OCISDK.Core.UnpublishedService.UsageCosts.Response;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OCISDK.Core.UnpublishedService.UsageCosts
{
    /// <summary>
    /// UsageCosts Client
    /// 
    /// In the future, these methods will move or change the namespace.
    /// </summary>
    public class UsageCostsClient : ServiceClient, IUsageCostsClient
    {
        private readonly string UsageCostsServiceName = "usagecost";

        /// <summary>
        /// Constructer
        /// </summary>
        public UsageCostsClient(ClientConfig config) : base(config)
        {
            ServiceName = UsageCostsServiceName;
        }

        /// <summary>
        /// Constructer
        /// </summary>
        public UsageCostsClient(ClientConfig config, OciSigner ociSigner) : base(config, ociSigner)
        {
            ServiceName = UsageCostsServiceName;
        }

        /// <summary>
        /// Constructer
        /// </summary>
        public UsageCostsClient(ClientConfigStream config) : base(config)
        {
            ServiceName = UsageCostsServiceName;
        }

        /// <summary>
        /// Constructer
        /// </summary>
        public UsageCostsClient(ClientConfigStream config, OciSigner ociSigner) : base(config, ociSigner)
        {
            ServiceName = UsageCostsServiceName;
        }
        
        /// <summary>
        /// GetSubscriptionInfo
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public GetSubscriptionInfoResponse GetSubscriptionInfo(GetSubscriptionInfoRequest request)
        {
            var uri = new Uri($"{GetEndPoint(UsageCostsServices.Usagecost, this.Region)}/{request.TenancyId}/subscriptionInfo");

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                OpcRequestId = request.OpcRequestId
            };
            var webResponse = this.RestClient.Get(uri, httpRequestHeaderParam);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new GetSubscriptionInfoResponse()
                {
                    SubscriptionInfo = this.JsonSerializer.Deserialize<SubscriptionInfo>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }
    }
}

using OCISDK.Core.src.Common;
using OCISDK.Core.src.Waas.Model;
using OCISDK.Core.src.Waas.Request;
using OCISDK.Core.src.Waas.Response;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace OCISDK.Core.src.Waas
{
    /// <summary>
    /// WaasClientAsync
    /// </summary>
    public class WaasClientAsync : ServiceClient, IWaasClientAsync
    {
        private readonly string WaasServiceName = "waas";

        /// <summary>
        /// Constructer
        /// </summary>
        public WaasClientAsync(ClientConfig config) : base(config)
        {
            ServiceName = WaasServiceName;
        }

        /// <summary>
        /// Constructer
        /// </summary>
        public WaasClientAsync(ClientConfig config, OciSigner ociSigner) : base(config, ociSigner)
        {
            ServiceName = WaasServiceName;
        }

        /// <summary>
        /// Constructer
        /// </summary>
        public WaasClientAsync(ClientConfigStream config) : base(config)
        {
            ServiceName = WaasServiceName;
        }

        /// <summary>
        /// Constructer
        /// </summary>
        public WaasClientAsync(ClientConfigStream config, OciSigner ociSigner) : base(config, ociSigner)
        {
            ServiceName = WaasServiceName;
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
        /// Moves WAAS policy into a different compartment. When provided, If-Match is checked against ETag values of the WAAS policy. 
        /// For information about moving resources between compartments, see Moving Resources to a Different Compartment.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ChangeWaasPolicyCompartmentResponse> ChangeWaasPolicyCompartment(ChangeWaasPolicyCompartmentRequest request)
        {
            var uri = new Uri($"{GetEndPoint(WaasServices.WaasPolicies, this.Region)}/{request.WaasPolicyId}/actions/changeCompartment");

            var httpRequestHeaderParam = new HttpRequestHeaderParam() {
                OpcRetryToken = request.OpcRetryToken,
                OpcRequestId = request.OpcRequestId,
                IfMatch = request.IfMatch
            };
            var webResponse = await this.RestClientAsync.Post(uri, request.ChangeWaasPolicyCompartmentDetails, httpRequestHeaderParam);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ChangeWaasPolicyCompartmentResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Creates a new Web Application Acceleration and Security (WAAS) policy in the specified compartment. 
        /// A WAAS policy must be established before creating Web Application Firewall (WAF) rules. 
        /// To use WAF rules, your web application's origin servers must defined in the WaasPolicy schema.
        /// 
        /// A domain name must be specified when creating a WAAS policy. 
        /// The domain name should be different from the origins specified in your WaasPolicy. Once domain name is entered and stored, it is unchangeable.
        /// 
        /// Use the record data returned in the cname field of the WaasPolicy object to create a CNAME record in your DNS configuration that will direct your domain's traffic through the WAF.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CreateWaasPolicyResponse> CreateWaasPolicy(CreateWaasPolicyRequest request)
        {
            var uri = new Uri(GetEndPoint(WaasServices.WaasPolicies, this.Region));

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                OpcRetryToken = request.OpcRetryToken,
                OpcRequestId = request.OpcRequestId
            };
            var webResponse = await this.RestClientAsync.Post(uri, request.CreateWaasPolicyDetails, httpRequestHeaderParam);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new CreateWaasPolicyResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcWorkRequestId = webResponse.Headers.Get("opc-work-request-id"),
                    ETag = webResponse.Headers.Get("etag")
                };
            }
        }


        /// <summary>
        /// Updates the details of a WAAS policy, including origins and tags. 
        /// Only the fields specified in the request body will be updated; all other properties will remain unchanged. 
        /// To update platform provided resources such as GoodBots, ProtectionRules, and ThreatFeeds, first retrieve the list of available resources with the related list operation such as 
        /// GetThreatFeeds or GetProtectionRules. 
        /// The returned list will contain objects with key properties that can be used to update the resource during the UpdateWaasPolicy request.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<UpdateWaasPolicyResponse> UpdateWaasPolicy(UpdateWaasPolicyRequest request)
        {
            var uri = new Uri($"{GetEndPoint(WaasServices.WaasPolicies, this.Region)}/{request.WaasPolicyId}");

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                OpcRetryToken = request.OpcRetryToken,
                OpcRequestId = request.OpcRequestId,
                IfMatch = request.IfMatch
            };
            var webResponse = await this.RestClientAsync.Put(uri, request.UpdateWaasPolicyDetails, httpRequestHeaderParam);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new UpdateWaasPolicyResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcWorkRequestId = webResponse.Headers.Get("opc-work-request-id")
                };
            }
        }

        /// <summary>
        /// Gets a list of WAAS policies.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ListWaasPoliciesResponse> ListWaasPolicies(ListWaasPoliciesRequest request)
        {
            var uri = new Uri($"{GetEndPoint(WaasServices.WaasPolicies, this.Region)}?{request.GetOptionQuery()}");

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                OpcRequestId = request.OpcRequestId
            };
            var webResponse = await this.RestClientAsync.Get(uri, httpRequestHeaderParam);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListWaasPoliciesResponse()
                {
                    Items = this.JsonSerializer.Deserialize<List<WaasPolicySummary>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Gets the number of blocked requests by a Web Application Firewall feature in five minute blocks, sorted by timeObserved in ascending order (starting from oldest data).
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ListWafBlockedRequestsResponse> ListWafBlockedRequests(ListWafBlockedRequestsRequest request)
        {
            var uri = new Uri($"{GetEndPoint(WaasServices.WaasPolicies, this.Region)}/{request.WaasPolicyId}/reports/waf/blocked?{request.GetOptionQuery()}");

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                OpcRequestId = request.OpcRequestId
            };
            var webResponse = await this.RestClientAsync.Get(uri, httpRequestHeaderParam);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListWafBlockedRequestsResponse()
                {
                    Items = this.JsonSerializer.Deserialize<List<WafBlockedRequest>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Gets structured Web Application Firewall event logs for a WAAS policy. Sorted by the timeObserved in ascending order (starting from the oldest recorded event).
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ListWafLogsResponse> ListWafLogs(ListWafLogsRequest request)
        {
            var uri = new Uri($"{GetEndPoint(WaasServices.WaasPolicies, this.Region)}/{request.WaasPolicyId}/wafLogs?{request.GetOptionQuery()}");

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                OpcRequestId = request.OpcRequestId
            };
            var webResponse = await this.RestClientAsync.Get(uri, httpRequestHeaderParam);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListWafLogsResponse()
                {
                    Items = this.JsonSerializer.Deserialize<List<WafLogDetails>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Gets the details of a WAAS policy.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<GetWaasPolicyResponse> GetWaasPolicy(GetWaasPolicyRequest request)
        {
            var uri = new Uri($"{GetEndPoint(WaasServices.WaasPolicies, this.Region)}/{request.WaasPolicyId}");

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                OpcRequestId = request.OpcRequestId
            };
            var webResponse = await this.RestClientAsync.Get(uri, httpRequestHeaderParam);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new GetWaasPolicyResponse()
                {
                    WaasPolicy = this.JsonSerializer.Deserialize<WaasPolicyDetails>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    ETag = webResponse.Headers.Get("etag")
                };
            }
        }

        /// <summary>
        /// Deletes a policy.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<DeleteWaasPolicyResponse> DeleteWaasPolicy(DeleteWaasPolicyRequest request)
        {
            var uri = new Uri($"{GetEndPoint(WaasServices.WaasPolicies, this.Region)}/{request.WaasPolicyId}");

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                OpcRequestId = request.OpcRequestId,
                OpcRetryToken = request.OpcRetryToken,
                IfMatch = request.IfMatch
            };
            var webResponse = await this.RestClientAsync.Delete(uri, httpRequestHeaderParam);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new DeleteWaasPolicyResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcWorkRequestId = webResponse.Headers.Get("opc-work-request-id")
                };
            }
        }
    }
}

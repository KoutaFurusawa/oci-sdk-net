using OCISDK.Core.Common;
using OCISDK.Core.Waas.Model;
using OCISDK.Core.Waas.Request;
using OCISDK.Core.Waas.Response;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace OCISDK.Core.Waas
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
        /// Updates the list of IP addresses that bypass the Web Application Firewall for a WAAS policy. Supports both single IP addresses or subnet masks (CIDR notation).
        /// 
        /// This operation can create, delete, update, and/or reorder whitelists depending on the structure of the request body.
        /// 
        /// Whitelists can be updated by changing the properties of the whitelist object with the rule's key specified in the key field. Whitelists can be reordered by changing the order of 
        /// the whitelists in the list of objects when updating.
        /// 
        /// Whitelists can be created by adding a new whitelist object to the list without a key property specified. A key will be generated for the new whitelist upon update.
        /// 
        /// Whitelists can be deleted by removing the existing whitelist object from the list. Any existing whitelists that are not specified with a key in the list of access rules will be 
        /// deleted upon update.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<UpdateWhitelistsResponse> UpdateWhitelists(UpdateWhitelistsRequest request)
        {
            var uri = new Uri($"{GetEndPoint(WaasServices.WaasPolicies, this.Region)}/{request.WaasPolicyId}/wafConfig/whitelists");

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

                return new UpdateWhitelistsResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcWorkRequestId = webResponse.Headers.Get("opc-work-request-id")
                };
            }
        }

        /// <summary>
        /// Updates the configuration for each specified caching rule.
        /// 
        /// Caching rules WAF policies allow you to selectively cache content on Oracle Cloud Infrastructure's edge servers, such as webpages or certain file types. For more information about 
        /// caching rules, see Caching Rules.
        /// 
        /// This operation can create, delete, update, and/or reorder caching rules depending on the structure of the request body. Caching rules can be updated by changing the properties of 
        /// the caching rule object with the rule's key specified in the key field. Any existing caching rules that are not specified with a key in the list of access rules will be deleted upon update.
        /// 
        /// The order the caching rules are specified in is important. The rules are processed in the order they are specified and the first matching rule will be used when processing a request. 
        /// Use ListCachingRules to view a list of all available caching rules in a compartment.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<UpdateCachingRulesResponse> UpdateCachingRules(UpdateCachingRulesRequest request)
        {
            var uri = new Uri($"{GetEndPoint(WaasServices.WaasPolicies, this.Region)}/{request.WaasPolicyId}/wafConfig/cachingRules");

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

                return new UpdateCachingRulesResponse()
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
        /// Gets the Web Application Firewall traffic data for a WAAS policy. Sorted by timeObserved in ascending order (starting from oldest data).
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ListWafTrafficResponse> ListWafTraffic(ListWafTrafficRequest request)
        {
            var uri = new Uri($"{GetEndPoint(WaasServices.WaasPolicies, this.Region)}/{request.WaasPolicyId}/reports/waf/traffic?{request.GetOptionQuery()}");

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                OpcRequestId = request.OpcRequestId
            };
            var webResponse = await this.RestClientAsync.Get(uri, httpRequestHeaderParam);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListWafTrafficResponse()
                {
                    Items = this.JsonSerializer.Deserialize<List<WafTrafficDatum>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Gets the list of whitelists defined in the Web Application Firewall configuration for a WAAS policy.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ListWhitelistsResponse> ListWhitelists(ListWhitelistsRequest request)
        {
            var uri = new Uri($"{GetEndPoint(WaasServices.WaasPolicies, this.Region)}/{request.WaasPolicyId}/wafConfig/whitelists?{request.GetOptionQuery()}");

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                OpcRequestId = request.OpcRequestId
            };
            var webResponse = await this.RestClientAsync.Get(uri, httpRequestHeaderParam);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListWhitelistsResponse()
                {
                    Items = this.JsonSerializer.Deserialize<List<WhitelistDetails>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-request-id"),
                    ETag = webResponse.Headers.Get("etag")
                };
            }
        }

        /// <summary>
        /// Gets the currently configured caching rules for the Web Application Firewall configuration of a specified WAAS policy. The rules are processed in the order they are 
        /// specified in and the first matching rule will be used when processing a request.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ListCachingRulesResponse> ListCachingRules(ListCachingRulesRequest request)
        {
            var uri = new Uri($"{GetEndPoint(WaasServices.WaasPolicies, this.Region)}/{request.WaasPolicyId}/wafConfig/cachingRules?{request.GetOptionQuery()}");

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                OpcRequestId = request.OpcRequestId
            };
            var webResponse = await this.RestClientAsync.Get(uri, httpRequestHeaderParam);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListCachingRulesResponse()
                {
                    Items = this.JsonSerializer.Deserialize<List<CachingRuleSummary>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-request-id"),
                    ETag = webResponse.Headers.Get("etag")
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

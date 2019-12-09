using OCISDK.Core.Waas.Request;
using OCISDK.Core.Waas.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OCISDK.Core.Waas
{
    /// <summary>
    /// IWaasClientAsync interface
    /// </summary>
    public interface IWaasClientAsync : IClientSetting
    {
        /// <summary>
        /// Moves WAAS policy into a different compartment. When provided, If-Match is checked against ETag values of the WAAS policy. 
        /// For information about moving resources between compartments, see Moving Resources to a Different Compartment.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ChangeWaasPolicyCompartmentResponse> ChangeWaasPolicyCompartment(ChangeWaasPolicyCompartmentRequest request);

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
        Task<CreateWaasPolicyResponse> CreateWaasPolicy(CreateWaasPolicyRequest request);

        /// <summary>
        /// Updates the details of a WAAS policy, including origins and tags. 
        /// Only the fields specified in the request body will be updated; all other properties will remain unchanged. 
        /// To update platform provided resources such as GoodBots, ProtectionRules, and ThreatFeeds, first retrieve the list of available resources with the related list operation such as 
        /// GetThreatFeeds or GetProtectionRules. 
        /// The returned list will contain objects with key properties that can be used to update the resource during the UpdateWaasPolicy request.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<UpdateWaasPolicyResponse> UpdateWaasPolicy(UpdateWaasPolicyRequest request);

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
        Task<UpdateWhitelistsResponse> UpdateWhitelists(UpdateWhitelistsRequest request);

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
        Task<UpdateCachingRulesResponse> UpdateCachingRules(UpdateCachingRulesRequest request);

        /// <summary>
        /// Gets a list of WAAS policies.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ListWaasPoliciesResponse> ListWaasPolicies(ListWaasPoliciesRequest request);

        /// <summary>
        /// Gets the number of blocked requests by a Web Application Firewall feature in five minute blocks, sorted by timeObserved in ascending order (starting from oldest data).
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ListWafBlockedRequestsResponse> ListWafBlockedRequests(ListWafBlockedRequestsRequest request);

        /// <summary>
        /// Gets structured Web Application Firewall event logs for a WAAS policy. Sorted by the timeObserved in ascending order (starting from the oldest recorded event).
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ListWafLogsResponse> ListWafLogs(ListWafLogsRequest request);

        /// <summary>
        /// Gets the Web Application Firewall traffic data for a WAAS policy. Sorted by timeObserved in ascending order (starting from oldest data).
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ListWafTrafficResponse> ListWafTraffic(ListWafTrafficRequest request);

        /// <summary>
        /// Gets the list of whitelists defined in the Web Application Firewall configuration for a WAAS policy.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ListWhitelistsResponse> ListWhitelists(ListWhitelistsRequest request);

        /// <summary>
        /// Gets the currently configured caching rules for the Web Application Firewall configuration of a specified WAAS policy. The rules are processed in the order they are 
        /// specified in and the first matching rule will be used when processing a request.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ListCachingRulesResponse> ListCachingRules(ListCachingRulesRequest request);

        /// <summary>
        /// Gets the details of a WAAS policy.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<GetWaasPolicyResponse> GetWaasPolicy(GetWaasPolicyRequest request);

        /// <summary>
        /// Deletes a policy.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<DeleteWaasPolicyResponse> DeleteWaasPolicy(DeleteWaasPolicyRequest request);
    }
}

using OCISDK.Core.Waas.Request;
using OCISDK.Core.Waas.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Waas
{
    /// <summary>
    /// WaasClient interface
    /// </summary>
    public interface IWaasClient
    {
        /// <summary>
        /// setter region
        /// </summary>
        /// <param name="region"></param>
        void SetRegion(string region);

        /// <summary>
        /// getter region
        /// </summary>
        /// <returns></returns>
        string GetRegion();

        /// <summary>
        /// Moves WAAS policy into a different compartment. When provided, If-Match is checked against ETag values of the WAAS policy. 
        /// For information about moving resources between compartments, see Moving Resources to a Different Compartment.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ChangeWaasPolicyCompartmentResponse ChangeWaasPolicyCompartment(ChangeWaasPolicyCompartmentRequest request);

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
        CreateWaasPolicyResponse CreateWaasPolicy(CreateWaasPolicyRequest request);

        /// <summary>
        /// Updates the details of a WAAS policy, including origins and tags. 
        /// Only the fields specified in the request body will be updated; all other properties will remain unchanged. 
        /// To update platform provided resources such as GoodBots, ProtectionRules, and ThreatFeeds, first retrieve the list of available resources with the related list operation such as 
        /// GetThreatFeeds or GetProtectionRules. 
        /// The returned list will contain objects with key properties that can be used to update the resource during the UpdateWaasPolicy request.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        UpdateWaasPolicyResponse UpdateWaasPolicy(UpdateWaasPolicyRequest request);

        /// <summary>
        /// Gets a list of WAAS policies.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ListWaasPoliciesResponse ListWaasPolicies(ListWaasPoliciesRequest request);

        /// <summary>
        /// Gets the number of blocked requests by a Web Application Firewall feature in five minute blocks, sorted by timeObserved in ascending order (starting from oldest data).
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ListWafBlockedRequestsResponse ListWafBlockedRequests(ListWafBlockedRequestsRequest request);

        /// <summary>
        /// Gets structured Web Application Firewall event logs for a WAAS policy. Sorted by the timeObserved in ascending order (starting from the oldest recorded event).
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ListWafLogsResponse ListWafLogs(ListWafLogsRequest request);

        /// <summary>
        /// Gets the details of a WAAS policy.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        GetWaasPolicyResponse GetWaasPolicy(GetWaasPolicyRequest request);

        /// <summary>
        /// Deletes a policy.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        DeleteWaasPolicyResponse DeleteWaasPolicy(DeleteWaasPolicyRequest request);
    }
}

using OCISDK.Core.src.Waas.Request;
using OCISDK.Core.src.Waas.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OCISDK.Core.src.Waas
{
    public interface IWaasClientAsync
    {
        /// <summary>
        /// Moves WAAS policy into a different compartment. When provided, If-Match is checked against ETag values of the WAAS policy. 
        /// For information about moving resources between compartments, see Moving Resources to a Different Compartment.
        /// </summary>
        /// <param name="param"></param>
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
        /// Gets a list of WAAS policies.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ListWaasPoliciesResponse> ListWaasPolicies(ListWaasPoliciesRequest request);

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

using OCISDK.Core.src.Identity.Request;
using OCISDK.Core.src.Identity.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OCISDK.Core.src.Identity
{
    public interface IIdentityClientAsync
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
        /// Lists all the regions offered by Oracle Cloud Infrastructure.
        /// </summary>
        /// <returns></returns>
        Task<ListRegionsResponse> ListRegions();

        /// <summary>
        /// Lists the region subscriptions for the specified tenancy.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        Task<ListRegionSubscriptionsResponse> ListRegionSubscriptions(ListRegionSubscriptionsRequest param);

        /// <summary>
        /// Lists the policies in the specified compartment (either the tenancy or another of your compartments). 
        /// See Where to Get the Tenancy's OCID and User's OCID.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        Task<ListPoliciesResponse> ListPolicies(ListPoliciesRequest param);

        /// <summary>
        /// Get the specified tenancy's information.
        /// </summary>
        /// <param name="getRequest"></param>
        /// <returns></returns>
        Task<GetTenancyResponse> GetTenancy(GetTenancyRequest getRequest);

        /// <summary>
        /// Gets the specified tag namespace's information.
        /// </summary>
        /// <param name="getRequest"></param>
        /// <returns></returns>
        Task<GetTagNamespaceResponse> GetTagNamespace(GetTagNamespaceRequest getRequest);

        /// <summary>
        /// Gets the specified policy's information.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        Task<GetPolicyResponse> GetPolicy(GetPolicyRequest param);

        /// <summary>
        /// Lists the compartments in a specified compartment.
        /// The members of the list returned depends on the values set for several parameters.
        /// </summary>
        /// <param name="listRequest"></param>
        /// <returns></returns>
        Task<ListCompartmentResponse> ListCompartment(ListCompartmentRequest listRequest);

        /// <summary>
        /// Lists the availability domains in your tenancy. 
        /// Specify the OCID of either the tenancy or another of your compartments as the value for 
        /// the compartment ID (remember that the tenancy is simply the root compartment). See Where 
        /// to Get the Tenancy's OCID and User's OCID. Note that the order of the results returned can 
        /// change if availability domains are added or removed; therefore, do not create a dependency 
        /// on the list order.
        /// </summary>
        /// <param name="listRequest"></param>
        /// <returns></returns>
        Task<ListAvailabilityDomainsResponse> ListAvailabilityDomains(ListAvailabilityDomainsRequest listRequest);

        /// <summary>
        /// Lists the tag namespaces in the specified compartment.
        /// </summary>
        /// <param name="listRequest"></param>
        /// <returns></returns>
        Task<ListTagNamespacesResponse> ListTagNamespaces(ListTagNamespacesRequest listRequest);

        /// <summary>
        /// Lists all the tags enabled for cost-tracking in the specified tenancy. 
        /// For information about cost-tracking tags, see Using Cost-tracking Tags.
        /// </summary>
        /// <param name="listRequest"></param>
        /// <returns></returns>
        Task<ListCostTrackingTagsResponse> ListCostTrackingTags(ListCostTrackingTagsRequest listRequest);

        /// <summary>
        /// Lists the tag definitions in the specified tag namespace.
        /// </summary>
        /// <param name="listRequest"></param>
        /// <returns></returns>
        Task<ListTagsResponse> ListTags(ListTagsRequest listRequest);

        /// <summary>
        /// Lists the tag defaults for tag definitions in the specified compartment.
        /// </summary>
        /// <param name="listRequest"></param>
        /// <returns></returns>
        Task<ListTagDefaultsResponse> ListTagDefaults(ListTagDefaultsRequest listRequest);

        /// <summary>
        /// Gets the specified compartment's information.
        /// </summary>
        /// <param name="getRequest"></param>
        /// <returns></returns>
        Task<GetCompartmentResponse> GetCompartment(GetCompartmentRequest getRequest);

        /// <summary>
        /// Gets the specified tag's information.
        /// </summary>
        /// <param name="getRequest"></param>
        /// <returns></returns>
        Task<GetTagResponse> GetTag(GetTagRequest getRequest);

        /// <summary>
        /// Retrieves the specified tag default.
        /// </summary>
        /// <param name="getRequest"></param>
        /// <returns></returns>
        Task<GetTagDefaultResponse> GetTagDefault(GetTagDefaultRequest getRequest);

        /// <summary>
        /// Creates a new compartment in the specified compartment.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<CreateCompartmentResponse> CreateCompartment(CreateCompartmentRequest createRequest);

        /// <summary>
        /// Creates a new tag namespace in the specified compartment.
        /// You must specify the compartment ID in the request object (remember that the tenancy is simply the root compartment).
        /// </summary>
        /// <param name="createRequest"></param>
        /// <returns></returns>
        Task<CreateTagNamespaceResponse> CreateTagNamespace(CreateTagNamespaceRequest createRequest);

        /// <summary>
        /// Creates a new tag in the specified tag namespace.
        /// You must specify either the OCID or the name of the tag namespace that will contain this tag definition.
        /// 
        /// You must also specify a name for the tag, which must be unique across all tags in the tag namespace and cannot be changed. 
        /// The name can contain any ASCII character except the space (_) or period (.) characters. Names are case insensitive. 
        /// That means, for example, "myTag" and "mytag" are not allowed in the same namespace. If you specify a name that's already in 
        /// use in the tag namespace, a 409 error is returned.
        /// 
        /// You must also specify a description for the tag. It does not have to be unique, and you can change it with UpdateTag.
        /// </summary>
        /// <param name="createRequest"></param>
        /// <returns></returns>
        Task<CreateTagResponse> CreateTag(CreateTagRequest createRequest);

        /// <summary>
        /// Creates a new policy in the specified compartment (either the tenancy or another of your compartments). 
        /// If you're new to policies, see Getting Started with Policies.
        /// You must specify a name for the policy, which must be unique across all policies in your tenancy and cannot be changed.
        /// </summary>
        /// <param name="createPolicyRequest"></param>
        /// <returns></returns>
        Task<CreatePolicyResponse> CreatePolicy(CreatePolicyRequest createPolicyRequest);

        /// <summary>
        /// Moves the specified tag namespace to the specified compartment within the same tenancy.
        /// 
        /// To move the tag namespace, you must have the manage tag-namespaces permission on both compartments. 
        /// For more information about IAM policies, see Details for IAM.
        /// 
        /// Moving a tag namespace moves all the tag key definitions contained in the tag namespace.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ChangeTagNamespaceCompartmentResponse> ChangeTagNamespaceCompartment(ChangeTagNamespaceCompartmentRequest request);

        /// <summary>
        /// Updates the specified compartment's description or name. You can't update the root compartment.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<UpdateCompartmentResponse> UpdateCompartment(UpdateCompartmentRequest updateRequest);

        /// <summary>
        /// Updates the the specified tag namespace. You can't update the namespace name.
        /// 
        /// Updating isRetired to 'true' retires the namespace and all the tag definitions in the namespace. 
        /// Reactivating a namespace (changing isRetired from 'true' to 'false') does not reactivate tag definitions. 
        /// To reactivate the tag definitions, you must reactivate each one indvidually after you reactivate the namespace, 
        /// using UpdateTag. For more information about retiring tag namespaces, see Retiring Key Definitions and Namespace Definitions.
        /// 
        /// You can't add a namespace with the same name as a retired namespace in the same tenancy.
        ///
        /// </summary>
        /// <param name="updateRequest"></param>
        /// <returns></returns>
        Task<UpdateTagNamespaceResponse> UpdateTagNamespace(UpdateTagNamespaceRequest updateRequest);

        /// <summary>
        /// Updates the the specified tag definition. You can update description, and isRetired.
        /// </summary>
        /// <param name="updateRequest"></param>
        /// <returns></returns>
        Task<UpdateTagResponse> UpdateTag(UpdateTagRequest updateRequest);

        /// <summary>
        /// Updates the specified policy. You can update the description or the policy statements themselves.
        /// Policy changes take effect typically within 10 seconds.
        /// </summary>
        /// <param name="updatePolicyRequest"></param>
        /// <returns></returns>
        Task<UpdatePolicyResponse> UpdatePolicy(UpdatePolicyRequest updatePolicyRequest);

        /// <summary>
        /// Deletes the specified compartment. The compartment must be empty.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<DeleteCompartmentResponse> DeleteCompartment(DeleteCompartmentRequest deleteRequest);

        /// <summary>
        /// Deletes the specified policy.
        /// The deletion takes effect typically within 10 seconds.
        /// </summary>
        /// <param name="deletePolicyRequest"></param>
        /// <returns></returns>
        Task<DeletePolicyResponse> DeletePolicy(DeletePolicyRequest deletePolicyRequest);
    }
}

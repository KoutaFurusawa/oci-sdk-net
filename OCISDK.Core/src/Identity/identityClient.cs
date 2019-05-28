/// <summary>
/// IdentityService Client
/// 
/// author: koutaro furusawa
/// </summary>

using OCISDK.Core.src.Common;
using OCISDK.Core.src.Identity.Model;
using OCISDK.Core.src.Identity.Request;
using OCISDK.Core.src.Identity.Response;
using System;
using System.Collections.Generic;
using System.IO;

namespace OCISDK.Core.src.Identity
{
    public class IdentityClient : ServiceClient, IIdentityClient
    {
        /// <summary>
        /// Constructer
        /// </summary>
        public IdentityClient(ClientConfig config) : base(config)
        {
            ServiceName = "identity";
        }

        public IdentityClient(ClientConfigStream config) : base(config)
        {
            ServiceName = "identity";
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
        /// Lists all the regions offered by Oracle Cloud Infrastructure.
        /// </summary>
        /// <returns></returns>
        public ListRegionsResponse ListRegions()
        {
            var uri = new Uri($"{GetEndPoint(IdentityServices.Region, this.Region)}");

            var webResponse = this.RestClient.Get(uri);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListRegionsResponse()
                {
                    Items = JsonSerializer.Deserialize<List<Region>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Lists the region subscriptions for the specified tenancy.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public ListRegionSubscriptionsResponse ListRegionSubscriptions(ListRegionSubscriptionsRequest param)
        {
            var uri = new Uri($"{GetEndPoint(IdentityServices.Tenancy, this.Region)}/{param.TenancyId}/regionSubscriptions");

            var webResponse = this.RestClient.Get(uri);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListRegionSubscriptionsResponse()
                {
                    Items = JsonSerializer.Deserialize<List<RegionSubscription>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Lists the policies in the specified compartment (either the tenancy or another of your compartments). See Where to Get the Tenancy's OCID and User's OCID.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public ListPoliciesResponse ListPolicies(ListPoliciesRequest param)
        {
            var uri = new Uri($"{GetEndPoint(IdentityServices.Policiy, this.Region)}?{param.GetOptionQuery()}");

            var webResponse = this.RestClient.Get(uri);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListPoliciesResponse()
                {
                    Items = JsonSerializer.Deserialize<List<Policy>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
        }

        /// <summary>
        /// Get the specified tenancy's information.
        /// </summary>
        /// <param name="getRequest"></param>
        /// <returns></returns>
        public GetTenancyResponse GetTenancy(GetTenancyRequest getRequest)
        {
            var uri = new Uri($"{GetEndPoint(IdentityServices.Tenancy, this.Region)}/{getRequest.TenancyId}");
            
            var webResponse = this.RestClient.Get(uri);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new GetTenancyResponse()
                {
                    Tenancy = JsonSerializer.Deserialize<Tenancy>(response),
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Gets the specified tag namespace's information.
        /// </summary>
        /// <param name="getRequest"></param>
        /// <returns></returns>
        public GetTagNamespaceResponse GetTagNamespace(GetTagNamespaceRequest getRequest)
        {
            var uri = new Uri($"{GetEndPoint(IdentityServices.TagNamespaces, this.Region)}/{getRequest.TagNamespaceId}");
            
            var webResponse = this.RestClient.Get(uri);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new GetTagNamespaceResponse()
                {
                    TagNamespace = JsonSerializer.Deserialize<TagNamespace>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Gets the specified policy's information.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public GetPolicyResponse GetPolicy(GetPolicyRequest param)
        {
            var uri = new Uri($"{GetEndPoint(IdentityServices.Policiy, this.Region)}/{param.PolicyId}");

            var webResponse = this.RestClient.Get(uri);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new GetPolicyResponse()
                {
                    Policy = JsonSerializer.Deserialize<Policy>(response),
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Lists the compartments in a specified compartment.
        /// The members of the list returned depends on the values set for several parameters.
        /// </summary>
        /// <param name="listRequest"></param>
        /// <returns></returns>
        public ListCompartmentResponse ListCompartment(ListCompartmentRequest listRequest)
        {
            var uri = new Uri($"{GetEndPoint(IdentityServices.Compartment, this.Region)}?{listRequest.GetOptionQuery()}");
            
            var webResponse = this.RestClient.Get(uri);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListCompartmentResponse()
                {
                    Items = JsonSerializer.Deserialize<List<Compartment>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
        }

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
        public ListAvailabilityDomainsResponse ListAvailabilityDomains(ListAvailabilityDomainsRequest listRequest)
        {
            var uri = new Uri($"{GetEndPoint(IdentityServices.AvailabilityDomain, this.Region)}?{listRequest.GetOptionQuery()}");
            
            var webResponse = this.RestClient.Get(uri);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListAvailabilityDomainsResponse()
                {
                    Items = JsonSerializer.Deserialize<List<AvailabilityDomain>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
        }

        /// <summary>
        /// Lists the tag namespaces in the specified compartment.
        /// </summary>
        /// <param name="listRequest"></param>
        /// <returns></returns>
        public ListTagNamespacesResponse ListTagNamespaces(ListTagNamespacesRequest listRequest)
        {
            var uri = new Uri($"{GetEndPoint(IdentityServices.TagNamespaces, this.Region)}?{listRequest.GetOptionQuery()}");
            
            var webResponse = this.RestClient.Get(uri);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListTagNamespacesResponse()
                {
                    Items = JsonSerializer.Deserialize<List<TagNamespaceSummary>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
        }

        /// <summary>
        /// Lists all the tags enabled for cost-tracking in the specified tenancy. 
        /// For information about cost-tracking tags, see Using Cost-tracking Tags.
        /// </summary>
        /// <param name="listRequest"></param>
        /// <returns></returns>
        public ListCostTrackingTagsResponse ListCostTrackingTags(ListCostTrackingTagsRequest listRequest)
        {
            var uri = new Uri(
                $"{GetEndPoint(IdentityServices.TagNamespaces, this.Region)}/actions/listCostTrackingTags?" +
                $"{listRequest.GetOptionQuery()}");
            
            var webResponse = this.RestClient.Get(uri);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListCostTrackingTagsResponse()
                {
                    Items = JsonSerializer.Deserialize<List<Tag>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Lists the tag definitions in the specified tag namespace.
        /// </summary>
        /// <param name="listRequest"></param>
        /// <returns></returns>
        public ListTagsResponse ListTags(ListTagsRequest listRequest)
        {
            var uri = new Uri(
                $"{GetEndPoint(IdentityServices.TagNamespaces, this.Region)}/{listRequest.TagNamespaceId}/tags?" +
                $"{listRequest.GetOptionQuery()}");
            
            var webResponse = this.RestClient.Get(uri);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListTagsResponse()
                {
                    Items = JsonSerializer.Deserialize<List<TagSummary>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
        }

        /// <summary>
        /// Lists the tag defaults for tag definitions in the specified compartment.
        /// </summary>
        /// <param name="listRequest"></param>
        /// <returns></returns>
        public ListTagDefaultsResponse ListTagDefaults(ListTagDefaultsRequest listRequest)
        {
            var uri = new Uri($"{GetEndPoint(IdentityServices.TagDefault, this.Region)}/?{listRequest.GetOptionQuery()}");
            
            var webResponse = this.RestClient.Get(uri);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListTagDefaultsResponse()
                {
                    Items = JsonSerializer.Deserialize<List<TagDefaultSummary>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
        }

        /// <summary>
        /// Gets the specified compartment's information.
        /// </summary>
        /// <param name="getRequest"></param>
        /// <returns></returns>
        public GetCompartmentResponse GetCompartment(GetCompartmentRequest getRequest)
        {
            var uri = new Uri($"{GetEndPoint(IdentityServices.Compartment, this.Region)}/{getRequest.CompartmentId}");
            
            var webResponse = this.RestClient.Get(uri);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new GetCompartmentResponse()
                {
                    Compartment = JsonSerializer.Deserialize<Compartment>(response),
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Gets the specified tag's information.
        /// </summary>
        /// <param name="getRequest"></param>
        /// <returns></returns>
        public GetTagResponse GetTag(GetTagRequest getRequest)
        {
            var uri = new Uri(
                $"{GetEndPoint(IdentityServices.TagNamespaces, this.Region)}/" +
                $"{getRequest.TagNamespaceId}/tags/{getRequest.TagName}");
            
            var webResponse = this.RestClient.Get(uri);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new GetTagResponse()
                {
                    Tag = JsonSerializer.Deserialize<Tag>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Retrieves the specified tag default.
        /// </summary>
        /// <param name="getRequest"></param>
        /// <returns></returns>
        public GetTagDefaultResponse GetTagDefault(GetTagDefaultRequest getRequest)
        {
            var uri = new Uri(
                $"{GetEndPoint(IdentityServices.TagDefault, this.Region)}/{getRequest.TagDefaultId}");
            
            var webResponse = this.RestClient.Get(uri);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new GetTagDefaultResponse()
                {
                    TagDefault = JsonSerializer.Deserialize<TagDefault>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    ETag = webResponse.Headers.Get("ETag")
                };
            }
        }

        /// <summary>
        /// Creates a new compartment in the specified compartment.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public CreateCompartmentResponse CreateCompartment(CreateCompartmentRequest createRequest)
        {
            var uri = new Uri(GetEndPoint(IdentityServices.Compartment, this.Region));
            
            var webResponse = this.RestClient.Post(uri, createRequest.CreateCompartmentDetails, createRequest.OpcRetryToken);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new CreateCompartmentResponse()
                {
                    Compartment = JsonSerializer.Deserialize<Compartment>(response),
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Creates a new tag namespace in the specified compartment.
        /// You must specify the compartment ID in the request object (remember that the tenancy is simply the root compartment).
        /// </summary>
        /// <param name="createRequest"></param>
        /// <returns></returns>
        public CreateTagNamespaceResponse CreateTagNamespace(CreateTagNamespaceRequest createRequest)
        {
            var uri = new Uri(GetEndPoint(IdentityServices.TagNamespaces, this.Region));
            
            var webResponse = this.RestClient.Post(uri, createRequest.CreateTagNamespaceDetails, createRequest.OpcRetryToken);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new CreateTagNamespaceResponse()
                {
                    TagNamespace = JsonSerializer.Deserialize<TagNamespace>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

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
        public CreateTagResponse CreateTag(CreateTagRequest createRequest)
        {
            var uri = new Uri($"{GetEndPoint(IdentityServices.TagNamespaces, this.Region)}/{createRequest.TagNamespaceId}/tags");
            
            var webResponse = this.RestClient.Post(uri, createRequest.CreateTagDetails, createRequest.OpcRetryToken);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new CreateTagResponse()
                {
                    Tag = JsonSerializer.Deserialize<Tag>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Creates a new policy in the specified compartment (either the tenancy or another of your compartments). 
        /// If you're new to policies, see Getting Started with Policies.
        /// You must specify a name for the policy, which must be unique across all policies in your tenancy and cannot be changed.
        /// </summary>
        /// <param name="createPolicyRequest"></param>
        /// <returns></returns>
        public CreatePolicyResponse CreatePolicy(CreatePolicyRequest createPolicyRequest)
        {
            var uri = new Uri($"{GetEndPoint(IdentityServices.Policiy, this.Region)}/");

            var webResponse = this.RestClient.Post(uri, createPolicyRequest.CreatePolicyDetails, createPolicyRequest.OpcRetryToken);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new CreatePolicyResponse()
                {
                    Policy = JsonSerializer.Deserialize<Policy>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    ETag = webResponse.Headers.Get("etag")
                };
            }
        }

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
        public ChangeTagNamespaceCompartmentResponse ChangeTagNamespaceCompartment(ChangeTagNamespaceCompartmentRequest request)
        {
            var uri = new Uri($"{GetEndPoint(IdentityServices.Compartment, this.Region)}/actions/changeCompartment");
            
            var webResponse = this.RestClient.Post(uri, request.ChangeTagNamespaceCompartmentDetail, request.OpcRetryToken);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ChangeTagNamespaceCompartmentResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Updates the specified compartment's description or name. You can't update the root compartment.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public UpdateCompartmentResponse UpdateCompartment(UpdateCompartmentRequest updateRequest)
        {
            var uri = new Uri($"{GetEndPoint(IdentityServices.Compartment, this.Region)}/{updateRequest.CompartmentId}");
            
            var webResponse = this.RestClient.Put(uri, updateRequest.UpdateCompartmentDetails, updateRequest.IfMatch);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new UpdateCompartmentResponse()
                {
                    Compartment = JsonSerializer.Deserialize<Compartment>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    ETag = webResponse.Headers.Get("etag")
                };
            }
        }

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
        public UpdateTagNamespaceResponse UpdateTagNamespace(UpdateTagNamespaceRequest updateRequest)
        {
            var uri = new Uri($"{GetEndPoint(IdentityServices.TagNamespaces, this.Region)}/{updateRequest.TagNamespaceId}");
            
            var webResponse = this.RestClient.Put(uri, updateRequest.UpdateTagNamespaceDetails);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new UpdateTagNamespaceResponse()
                {
                    TagNamespace = JsonSerializer.Deserialize<TagNamespace>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Updates the the specified tag definition. You can update description, and isRetired.
        /// </summary>
        /// <param name="updateRequest"></param>
        /// <returns></returns>
        public UpdateTagResponse UpdateTag(UpdateTagRequest updateRequest)
        {
            var uri = new Uri(
                $"{GetEndPoint(IdentityServices.TagNamespaces, this.Region)}/{updateRequest.TagNamespaceId}/tags/" +
                $"{updateRequest.TagName}");
            
            var webResponse = this.RestClient.Put(uri, updateRequest.UpdateTagDetails);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new UpdateTagResponse()
                {
                    Tag = JsonSerializer.Deserialize<Tag>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Updates the specified policy. You can update the description or the policy statements themselves.
        /// Policy changes take effect typically within 10 seconds.
        /// </summary>
        /// <param name="updatePolicyRequest"></param>
        /// <returns></returns>
        public UpdatePolicyResponse UpdatePolicy(UpdatePolicyRequest updatePolicyRequest)
        {
            var uri = new Uri(
                $"{GetEndPoint(IdentityServices.Policiy, this.Region)}/{updatePolicyRequest.PolicyId}");

            var webResponse = this.RestClient.Put(uri, updatePolicyRequest.UpdatePolicyDetails);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new UpdatePolicyResponse()
                {
                    Policy = JsonSerializer.Deserialize<Policy>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    ETag = webResponse.Headers.Get("etag")
                };
            }
        }

        /// <summary>
        /// Deletes the specified compartment. The compartment must be empty.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public DeleteCompartmentResponse DeleteCompartment(DeleteCompartmentRequest deleteRequest)
        {
            var uri = new Uri($"{GetEndPoint(IdentityServices.Compartment, this.Region)}/{deleteRequest.CompartmentId}");
            
            var webResponse = this.RestClient.Delete(uri, deleteRequest.IfMatch);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new DeleteCompartmentResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    opcWorkRequestId = webResponse.Headers.Get("opc-work-request-id")
                };
            }
        }

        /// <summary>
        /// Deletes the specified policy.
        /// The deletion takes effect typically within 10 seconds.
        /// </summary>
        /// <param name="deletePolicyRequest"></param>
        /// <returns></returns>
        public DeletePolicyResponse DeletePolicy(DeletePolicyRequest deletePolicyRequest)
        {
            var uri = new Uri($"{GetEndPoint(IdentityServices.Policiy, this.Region)}/{deletePolicyRequest.PolicyId}");

            var webResponse = this.RestClient.Delete(uri, deletePolicyRequest.IfMatch);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new DeletePolicyResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }
    }
}

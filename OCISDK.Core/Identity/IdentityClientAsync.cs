using OCISDK.Core.Common;
using OCISDK.Core.Identity.Model;
using OCISDK.Core.Identity.Request;
using OCISDK.Core.Identity.Response;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace OCISDK.Core.Identity
{
    /// <summary>
    /// IdentityService Client
    /// </summary>
    public class IdentityClientAsync : ServiceClient, IIdentityClientAsync
    {
        private readonly string identityServiceName = "identity";

        /// <summary>
        /// Constructer
        /// </summary>
        public IdentityClientAsync(ClientConfig config) : base(config)
        {
            ServiceName = identityServiceName;
        }

        /// <summary>
        /// Constructer
        /// </summary>
        public IdentityClientAsync(ClientConfig config, OciSigner ociSigner) : base(config, ociSigner)
        {
            ServiceName = identityServiceName;
        }

        /// <summary>
        /// Constructer
        /// </summary>
        public IdentityClientAsync(ClientConfigStream config) : base(config)
        {
            ServiceName = identityServiceName;
        }

        /// <summary>
        /// Constructer
        /// </summary>
        public IdentityClientAsync(ClientConfigStream config, OciSigner ociSigner) : base(config, ociSigner)
        {
            ServiceName = identityServiceName;
        }
        
        /// <summary>
        /// Lists all the regions offered by Oracle Cloud Infrastructure.
        /// </summary>
        /// <returns></returns>
        public async Task<ListRegionsResponse> ListRegions()
        {
            var uri = new Uri($"{GetEndPoint(IdentityServices.Region, this.Region)}");

            var webResponse = await this.RestClientAsync.Get(uri);

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
        public async Task<ListRegionSubscriptionsResponse> ListRegionSubscriptions(ListRegionSubscriptionsRequest param)
        {
            var uri = new Uri($"{GetEndPoint(IdentityServices.Tenancy, this.Region)}/{param.TenancyId}/regionSubscriptions");

            var webResponse = await this.RestClientAsync.Get(uri);

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
        public async Task<ListPoliciesResponse> ListPolicies(ListPoliciesRequest param)
        {
            var uri = new Uri($"{GetEndPoint(IdentityServices.Policiy, this.Region)}?{param.GetOptionQuery()}");

            var webResponse = await this.RestClientAsync.Get(uri);

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
        public async Task<GetTenancyResponse> GetTenancy(GetTenancyRequest getRequest)
        {
            var uri = new Uri($"{GetEndPoint(IdentityServices.Tenancy, this.Region)}/{getRequest.TenancyId}");
            
            var webResponse = await this.RestClientAsync.Get(uri);

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
        public async Task<GetTagNamespaceResponse> GetTagNamespace(GetTagNamespaceRequest getRequest)
        {
            var uri = new Uri($"{GetEndPoint(IdentityServices.TagNamespaces, this.Region)}/{getRequest.TagNamespaceId}");
            
            var webResponse = await this.RestClientAsync.Get(uri);

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
        public async Task<GetPolicyResponse> GetPolicy(GetPolicyRequest param)
        {
            var uri = new Uri($"{GetEndPoint(IdentityServices.Policiy, this.Region)}/{param.PolicyId}");

            var webResponse = await this.RestClientAsync.Get(uri);

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
        public async Task<ListCompartmentResponse> ListCompartment(ListCompartmentRequest listRequest)
        {
            var uriStr = $"{GetEndPoint(IdentityServices.Compartment, this.Region)}";
            var querys = listRequest.GetOptionQuery();

            if (!string.IsNullOrEmpty(querys))
            {
                uriStr = $"{uriStr}?{querys}";
            }

            var uri = new Uri(uriStr);

            var webResponse = await this.RestClientAsync.Get(uri);

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
        public async Task<ListAvailabilityDomainsResponse> ListAvailabilityDomains(ListAvailabilityDomainsRequest listRequest)
        {
            var uriStr = $"{GetEndPoint(IdentityServices.AvailabilityDomain, this.Region)}";
            var querys = listRequest.GetOptionQuery();

            if (!string.IsNullOrEmpty(querys))
            {
                uriStr = $"{uriStr}?{querys}";
            }

            var uri = new Uri(uriStr);

            var webResponse = await this.RestClientAsync.Get(uri);

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
        public async Task<ListTagNamespacesResponse> ListTagNamespaces(ListTagNamespacesRequest listRequest)
        {
            var uriStr = $"{GetEndPoint(IdentityServices.TagNamespaces, this.Region)}";
            var querys = listRequest.GetOptionQuery();

            if (!string.IsNullOrEmpty(querys))
            {
                uriStr = $"{uriStr}?{querys}";
            }

            var uri = new Uri(uriStr);

            var webResponse = await this.RestClientAsync.Get(uri);

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
        public async Task<ListCostTrackingTagsResponse> ListCostTrackingTags(ListCostTrackingTagsRequest listRequest)
        {
            var uriStr = $"{GetEndPoint(IdentityServices.TagNamespaces, this.Region)}/actions/listCostTrackingTags";
            var querys = listRequest.GetOptionQuery();

            if (!string.IsNullOrEmpty(querys))
            {
                uriStr = $"{uriStr}?{querys}";
            }

            var uri = new Uri(uriStr);

            var webResponse = await this.RestClientAsync.Get(uri);

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
        public async Task<ListTagsResponse> ListTags(ListTagsRequest listRequest)
        {
            var uriStr = $"{GetEndPoint(IdentityServices.TagNamespaces, this.Region)}/{listRequest.TagNamespaceId}/tags";
            var querys = listRequest.GetOptionQuery();

            if (!string.IsNullOrEmpty(querys))
            {
                uriStr = $"{uriStr}?{querys}";
            }

            var uri = new Uri(uriStr);

            var webResponse = await this.RestClientAsync.Get(uri);

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
        public async Task<ListTagDefaultsResponse> ListTagDefaults(ListTagDefaultsRequest listRequest)
        {
            var uriStr = $"{GetEndPoint(IdentityServices.TagDefault, this.Region)}";
            var querys = listRequest.GetOptionQuery();

            if (!string.IsNullOrEmpty(querys))
            {
                uriStr = $"{uriStr}?{querys}";
            }

            var uri = new Uri(uriStr);

            var webResponse = await this.RestClientAsync.Get(uri);

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
        /// Lists the users in your tenancy. 
        /// You must specify your tenancy's OCID as the value for the compartment ID (remember that the tenancy is simply the root compartment). 
        /// See Where to Get the Tenancy's OCID and User's OCID.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ListUsersResponse> ListUsers(ListUsersRequest request)
        {
            var uriStr = $"{GetEndPoint(IdentityServices.Users, this.Region)}";
            var querys = request.GetOptionQuery();

            if (!string.IsNullOrEmpty(querys))
            {
                uriStr = $"{uriStr}?{querys}";
            }

            var uri = new Uri(uriStr);

            var webResponse = await this.RestClientAsync.Get(uri);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListUsersResponse()
                {
                    Items = JsonSerializer.Deserialize<List<UserDetails>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
        }

        /// <summary>
        /// Lists the UserGroupMembership objects in your tenancy. 
        /// You must specify your tenancy's OCID as the value for the compartment ID (see Where to Get the Tenancy's OCID and User's OCID). 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ListUserGroupMembershipsResponse> ListUserGroupMemberships(ListUserGroupMembershipsRequest request)
        {
            var uriStr = $"{GetEndPoint(IdentityServices.UserGroupMemberships, this.Region)}";
            var querys = request.GetOptionQuery();

            if (!string.IsNullOrEmpty(querys))
            {
                uriStr = $"{uriStr}?{querys}";
            }

            var uri = new Uri(uriStr);

            var webResponse = await this.RestClientAsync.Get(uri);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListUserGroupMembershipsResponse()
                {
                    Items = JsonSerializer.Deserialize<List<UserGroupMembership>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
        }

        /// <summary>
        /// Lists all the identity providers in your tenancy. You must specify the identity provider type (e.g., SAML2 for identity providers using the SAML2.0 protocol). 
        /// You must specify your tenancy's OCID as the value for the compartment ID (remember that the tenancy is simply the root compartment). 
        /// See Where to Get the Tenancy's OCID and User's OCID.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ListIdentityProvidersResponse> ListIdentityProviders(ListIdentityProvidersRequest request)
        {
            var uriStr = $"{GetEndPoint(IdentityServices.IdentityProviders, this.Region)}?{request.GetOptionQuery()}";
            var uri = new Uri(uriStr);

            var webResponse = await this.RestClientAsync.Get(uri);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListIdentityProvidersResponse()
                {
                    Items = JsonSerializer.Deserialize<List<IdentityProvider>>(response),
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
        public async Task<GetCompartmentResponse> GetCompartment(GetCompartmentRequest getRequest)
        {
            var uri = new Uri($"{GetEndPoint(IdentityServices.Compartment, this.Region)}/{getRequest.CompartmentId}");
            
            var webResponse = await this.RestClientAsync.Get(uri);

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
        public async Task<GetTagResponse> GetTag(GetTagRequest getRequest)
        {
            var uri = new Uri(
                $"{GetEndPoint(IdentityServices.TagNamespaces, this.Region)}/" +
                $"{getRequest.TagNamespaceId}/tags/{getRequest.TagName}");
            
            var webResponse = await this.RestClientAsync.Get(uri);

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
        public async Task<GetTagDefaultResponse> GetTagDefault(GetTagDefaultRequest getRequest)
        {
            var uri = new Uri(
                $"{GetEndPoint(IdentityServices.TagDefault, this.Region)}/{getRequest.TagDefaultId}");
            
            var webResponse = await this.RestClientAsync.Get(uri);

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
        /// Gets the specified user's information.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<GetUserResponse> GetUser(GetUserRequest request)
        {
            var uri = new Uri($"{GetEndPoint(IdentityServices.Users, this.Region)}/{request.UserId}");

            var webResponse = await this.RestClientAsync.Get(uri);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new GetUserResponse()
                {
                    User = JsonSerializer.Deserialize<UserDetails>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    ETag = webResponse.Headers.Get("ETag")
                };
            }
        }

        /// <summary>
        /// Gets the specified UserGroupMembership's information.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<GetUserGroupMembershipResponse> GetUserGroupMembership(GetUserGroupMembershipRequest request)
        {
            var uri = new Uri($"{GetEndPoint(IdentityServices.UserGroupMemberships, this.Region)}/{request.UserGroupMembershipId}");

            var webResponse = await this.RestClientAsync.Get(uri);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new GetUserGroupMembershipResponse()
                {
                    UserGroupMembership = JsonSerializer.Deserialize<UserGroupMembership>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    ETag = webResponse.Headers.Get("ETag")
                };
            }
        }

        /// <summary>
        /// Gets the specified identity provider's information.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<GetIdentityProviderResponse> GetIdentityProvider(GetIdentityProviderRequest request)
        {
            var uri = new Uri($"{GetEndPoint(IdentityServices.IdentityProviders, this.Region)}/{request.IdentityProviderId}");

            var webResponse = await this.RestClientAsync.Get(uri);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new GetIdentityProviderResponse()
                {
                    IdentityProvider = JsonSerializer.Deserialize<IdentityProvider>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    ETag = webResponse.Headers.Get("ETag")
                };
            }
        }

        /// <summary>
        /// Creates a new compartment in the specified compartment.
        /// </summary>
        /// <param name="createRequest"></param>
        /// <returns></returns>
        public async Task<CreateCompartmentResponse> CreateCompartment(CreateCompartmentRequest createRequest)
        {
            var uri = new Uri(GetEndPoint(IdentityServices.Compartment, this.Region));
            
            var webResponse = await this.RestClientAsync.Post(uri, createRequest.CreateCompartmentDetails, new HttpRequestHeaderParam() { OpcRetryToken = createRequest.OpcRetryToken });

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
        public async Task<CreateTagNamespaceResponse> CreateTagNamespace(CreateTagNamespaceRequest createRequest)
        {
            var uri = new Uri(GetEndPoint(IdentityServices.TagNamespaces, this.Region));
            
            var webResponse = await this.RestClientAsync.Post(uri, createRequest.CreateTagNamespaceDetails, new HttpRequestHeaderParam() { OpcRetryToken = createRequest.OpcRetryToken });

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
        public async Task<CreateTagResponse> CreateTag(CreateTagRequest createRequest)
        {
            var uri = new Uri($"{GetEndPoint(IdentityServices.TagNamespaces, this.Region)}/{createRequest.TagNamespaceId}/tags");
            
            var webResponse = await this.RestClientAsync.Post(uri, createRequest.CreateTagDetails, new HttpRequestHeaderParam() { OpcRetryToken = createRequest.OpcRetryToken });

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
        /// Creates a new Console one-time password for the specified user. For more information about user credentials, see User Credentials.
        /// 
        /// Use this operation after creating a new user, or if a user forgets their password. 
        /// The new one-time password is returned to you in the response, and you must securely deliver it to the user. 
        /// They'll be prompted to change this password the next time they sign in to the Console. 
        /// If they don't change it within 7 days, the password will expire and you'll need to create a new one-time password for the user.
        /// 
        /// Note: The user's Console login is the unique name you specified when you created the user (see CreateUser).
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CreateOrResetUIPasswordResponse> CreateOrResetUIPassword(CreateOrResetUIPasswordRequest request)
        {
            var uri = new Uri($"{GetEndPoint(IdentityServices.Users, this.Region)}/{request.UserId}/uiPassword");

            var webResponse = await this.RestClientAsync.Post(uri, null, new HttpRequestHeaderParam() { OpcRetryToken = request.OpcRetryToken });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new CreateOrResetUIPasswordResponse()
                {
                    UIPassword = JsonSerializer.Deserialize<UIPasswordDetails>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    ETag = webResponse.Headers.Get("etag")
                };
            }
        }

        /// <summary>
        /// Creates a new user in your tenancy. For conceptual information about users, your tenancy, and other IAM Service components, see Overview of the IAM Service.
        /// 
        /// You must specify your tenancy's OCID as the compartment ID in the request object (remember that the tenancy is simply the root compartment). 
        /// Notice that IAM resources (users, groups, compartments, and some policies) reside within the tenancy itself, unlike cloud resources such as compute instances, 
        /// which typically reside within compartments inside the tenancy. For information about OCIDs, see Resource Identifiers.
        /// 
        /// You must also specify a name for the user, which must be unique across all users in your tenancy and cannot be changed. 
        /// Allowed characters: No spaces. Only letters, numerals, hyphens, periods, underscores, +, and @. If you specify a name that's already in use, you'll get a 409 error. 
        /// This name will be the user's login to the Console. You might want to pick a name that your company's own identity system (e.g., Active Directory, LDAP, etc.) already uses. 
        /// If you delete a user and then create a new user with the same name, they'll be considered different users because they have different OCIDs.
        /// 
        /// After you send your request, the new object's lifecycleState will temporarily be CREATING. Before using the object, first make sure its lifecycleState has changed to ACTIVE.
        /// 
        /// A new user has no permissions until you place the user in one or more groups (see AddUserToGroup). 
        /// If the user needs to access the Console, you need to provide the user a password (see CreateOrResetUIPassword). 
        /// If the user needs to access the Oracle Cloud Infrastructure REST API, you need to upload a public API signing key for that user (see Required Keys and OCIDs and also UploadApiKey).
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CreateUserResponse> CreateUser(CreateUserRequest request)
        {
            var uri = new Uri($"{GetEndPoint(IdentityServices.Users, this.Region)}");

            var webResponse = await this.RestClientAsync.Post(uri, request.CreateUserDetails, new HttpRequestHeaderParam() { OpcRetryToken = request.OpcRetryToken });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new CreateUserResponse()
                {
                    User = JsonSerializer.Deserialize<UserDetails>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    ETag = webResponse.Headers.Get("ETag")
                };
            }
        }

        /// <summary>
        /// Creates a new identity provider in your tenancy. For more information, see Identity Providers and Federation.
        /// 
        /// You must specify your tenancy's OCID as the compartment ID in the request object. Remember that the tenancy 
        /// is simply the root compartment. For information about OCIDs, see Resource Identifiers.
        /// 
        /// You must also specify a name for the IdentityProvider, which must be unique across all IdentityProvider objects 
        /// in your tenancy and cannot be changed.
        /// 
        /// You must also specify a description for the IdentityProvider (although it can be an empty string). It does not 
        /// have to be unique, and you can change it anytime with UpdateIdentityProvider.
        /// 
        /// After you send your request, the new object's lifecycleState will temporarily be CREATING. Before using the object, 
        /// first make sure its lifecycleState has changed to ACTIVE.
        /// </summary>
        public async Task<CreateIdentityProviderResponse> CreateIdentityProvider(CreateIdentityProviderRequest request)
        {
            var uri = new Uri($"{GetEndPoint(IdentityServices.IdentityProviders, this.Region)}");

            var webResponse = await this.RestClientAsync.Post(uri, request.CreateIdentityProviderDetails, new HttpRequestHeaderParam() { OpcRetryToken = request.OpcRetryToken });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new CreateIdentityProviderResponse()
                {
                    IdentityProvider = JsonSerializer.Deserialize<IdentityProvider>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    ETag = webResponse.Headers.Get("ETag")
                };
            }
        }

        /// <summary>
        /// Adds the specified user to the specified group and returns a UserGroupMembership object with its own OCID.
        /// 
        /// After you send your request, the new object's lifecycleState will temporarily be CREATING. 
        /// Before using the object, first make sure its lifecycleState has changed to ACTIVE.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<AddUserToGroupResponse> AddUserToGroup(AddUserToGroupRequest request)
        {
            var uri = new Uri($"{GetEndPoint(IdentityServices.UserGroupMemberships, this.Region)}");

            var webResponse = await this.RestClientAsync.Post(uri, request.AddUserToGroupDetails, new HttpRequestHeaderParam() { OpcRetryToken = request.OpcRetryToken });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new AddUserToGroupResponse()
                {
                    UserGroupMembership = JsonSerializer.Deserialize<UserGroupMembership>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    ETag = webResponse.Headers.Get("ETag")
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
        public async Task<CreatePolicyResponse> CreatePolicy(CreatePolicyRequest createPolicyRequest)
        {
            var uri = new Uri($"{GetEndPoint(IdentityServices.Policiy, this.Region)}/");

            var webResponse = await this.RestClientAsync.Post(uri, createPolicyRequest.CreatePolicyDetails, new HttpRequestHeaderParam() { OpcRetryToken = createPolicyRequest.OpcRetryToken });

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
        public async Task<ChangeTagNamespaceCompartmentResponse> ChangeTagNamespaceCompartment(ChangeTagNamespaceCompartmentRequest request)
        {
            var uri = new Uri($"{GetEndPoint(IdentityServices.Compartment, this.Region)}/actions/changeCompartment");
            
            var webResponse = await this.RestClientAsync.Post(uri, request.ChangeTagNamespaceCompartmentDetail, new HttpRequestHeaderParam() { OpcRetryToken = request.OpcRetryToken });

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
        /// <param name="updateRequest"></param>
        /// <returns></returns>
        public async Task<UpdateCompartmentResponse> UpdateCompartment(UpdateCompartmentRequest updateRequest)
        {
            var uri = new Uri($"{GetEndPoint(IdentityServices.Compartment, this.Region)}/{updateRequest.CompartmentId}");
            
            var webResponse = await this.RestClientAsync.Put(uri, updateRequest.UpdateCompartmentDetails, new HttpRequestHeaderParam() { IfMatch = updateRequest.IfMatch });

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
        public async Task<UpdateTagNamespaceResponse> UpdateTagNamespace(UpdateTagNamespaceRequest updateRequest)
        {
            var uri = new Uri($"{GetEndPoint(IdentityServices.TagNamespaces, this.Region)}/{updateRequest.TagNamespaceId}");
            
            var webResponse = await this.RestClientAsync.Put(uri, updateRequest.UpdateTagNamespaceDetails);

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
        public async Task<UpdateTagResponse> UpdateTag(UpdateTagRequest updateRequest)
        {
            var uri = new Uri(
                $"{GetEndPoint(IdentityServices.TagNamespaces, this.Region)}/{updateRequest.TagNamespaceId}/tags/" +
                $"{updateRequest.TagName}");
            
            var webResponse = await this.RestClientAsync.Put(uri, updateRequest.UpdateTagDetails);

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
        /// Updates the description of the specified user.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<UpdateUserResponse> UpdateUser(UpdateUserRequest request)
        {
            var uri = new Uri($"{GetEndPoint(IdentityServices.Users, this.Region)}/{request.UserId}");

            var webResponse = await this.RestClientAsync.Put(uri, request.UpdateUserDetails, new HttpRequestHeaderParam() { IfMatch = request.IfMatch });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new UpdateUserResponse()
                {
                    User = JsonSerializer.Deserialize<UserDetails>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    ETag = webResponse.Headers.Get("ETag")
                };
            }
        }

        /// <summary>
        /// Updates the capabilities of the specified user.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<UpdateUserCapabilitiesResponse> UpdateUserCapabilities(UpdateUserCapabilitiesRequest request)
        {
            var uri = new Uri($"{GetEndPoint(IdentityServices.Users, this.Region)}/{request.UserId}/capabilities/");

            var webResponse = await this.RestClientAsync.Put(uri, request.UpdateUserCapabilitiesDetails, new HttpRequestHeaderParam() { IfMatch = request.IfMatch });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new UpdateUserCapabilitiesResponse()
                {
                    User = JsonSerializer.Deserialize<UserDetails>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    ETag = webResponse.Headers.Get("ETag")
                };
            }
        }

        /// <summary>
        /// Updates the state of the specified user.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<UpdateUserStateResponse> UpdateUserState(UpdateUserStateRequest request)
        {
            var uri = new Uri($"{GetEndPoint(IdentityServices.Users, this.Region)}/{request.UserId}/state/");

            var webResponse = await this.RestClientAsync.Put(uri, request.UpdateStateDetails, new HttpRequestHeaderParam() { IfMatch = request.IfMatch });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new UpdateUserStateResponse()
                {
                    User = JsonSerializer.Deserialize<UserDetails>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    ETag = webResponse.Headers.Get("ETag")
                };
            }
        }

        /// <summary>
        /// Updates the specified policy. You can update the description or the policy statements themselves.
        /// Policy changes take effect typically within 10 seconds.
        /// </summary>
        /// <param name="updatePolicyRequest"></param>
        /// <returns></returns>
        public async Task<UpdatePolicyResponse> UpdatePolicy(UpdatePolicyRequest updatePolicyRequest)
        {
            var uri = new Uri(
                $"{GetEndPoint(IdentityServices.Policiy, this.Region)}/{updatePolicyRequest.PolicyId}");

            var webResponse = await this.RestClientAsync.Put(uri, updatePolicyRequest.UpdatePolicyDetails);

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
        /// Updates the specified identity provider.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<UpdateIdentityProviderResponse> UpdateIdentityProvider(UpdateIdentityProviderRequest request)
        {
            var uri = new Uri($"{GetEndPoint(IdentityServices.IdentityProviders, this.Region)}/{request.IdentityProviderId}");

            var webResponse = await this.RestClientAsync.Put(uri, request.UpdateIdentityProviderDetails, 
                new HttpRequestHeaderParam() { IfMatch = request.IfMatch });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new UpdateIdentityProviderResponse()
                {
                    IdentityProvider = JsonSerializer.Deserialize<IdentityProvider>(response),
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
        public async Task<DeleteCompartmentResponse> DeleteCompartment(DeleteCompartmentRequest request)
        {
            var uri = new Uri($"{GetEndPoint(IdentityServices.Compartment, this.Region)}/{request.CompartmentId}");
            
            var webResponse = await this.RestClientAsync.Delete(uri, new HttpRequestHeaderParam() { IfMatch = request.IfMatch });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new DeleteCompartmentResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcWorkRequestId = webResponse.Headers.Get("opc-work-request-id")
                };
            }
        }

        /// <summary>
        /// Deletes the specified user. The user must not be in any groups.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<DeleteUserResponse> DeleteUser(DeleteUserRequest request)
        {
            var uri = new Uri($"{GetEndPoint(IdentityServices.Users, this.Region)}/{request.UserId}");

            var webResponse = await this.RestClientAsync.Delete(uri, new HttpRequestHeaderParam() { IfMatch = request.IfMatch });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new DeleteUserResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Removes a user from a group by deleting the corresponding UserGroupMembership.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<RemoveUserFromGroupResponse> RemoveUserFromGroup(RemoveUserFromGroupRequest request)
        {
            var uri = new Uri($"{GetEndPoint(IdentityServices.UserGroupMemberships, this.Region)}/{request.UserGroupMembershipId}");

            var webResponse = await this.RestClientAsync.Delete(uri, new HttpRequestHeaderParam() { IfMatch = request.IfMatch });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new RemoveUserFromGroupResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Deletes the specified policy.
        /// The deletion takes effect typically within 10 seconds.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<DeletePolicyResponse> DeletePolicy(DeletePolicyRequest request)
        {
            var uri = new Uri($"{GetEndPoint(IdentityServices.Policiy, this.Region)}/{request.PolicyId}");

            var webResponse = await this.RestClientAsync.Delete(uri, new HttpRequestHeaderParam() { IfMatch = request.IfMatch });

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

        /// <summary>
        /// Deletes the specified identity provider. The identity provider must not have any group mappings (see IdpGroupMapping).
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<DeleteIdentityProviderResponse> DeleteIdentityProvider(DeleteIdentityProviderRequest request)
        {
            var uri = new Uri($"{GetEndPoint(IdentityServices.IdentityProviders, this.Region)}/{request.IdentityProviderId}");

            var webResponse = await this.RestClientAsync.Delete(uri, new HttpRequestHeaderParam() { IfMatch = request.IfMatch });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new DeleteIdentityProviderResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }
    }
}

/// <summary>
/// IdentityService Client
/// 
/// author: koutaro furusawa
/// </summary>

using Newtonsoft.Json;
using OCISDK.Core.src.Common;
using OCISDK.Core.src.Identity.Model;
using OCISDK.Core.src.Identity.Request;
using OCISDK.Core.src.Identity.Response;
using System;
using System.Collections.Generic;
using System.IO;

namespace OCISDK.Core.src.Identity
{
    public class IdentityClient : ServiceClient
    {
        private string _region;
        public string Region
        {
            get { return _region; }
            set
            {
                // the region is not null and registered to endpoints.json
                if (!String.IsNullOrEmpty(value) && Config.ContainRegion(value))
                {
                    _region = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        private RestClient RestClient { get; set; }

        /// <summary>
        /// Constructer
        /// </summary>
        public IdentityClient(ClientConfig config) : base(config)
        {
            ServiceName = "identity";

            this.RestClient = new RestClient()
            {
                Signer = Signer,
                Config = config
            };
        }

        /// <summary>
        /// Get the specified tenancy's information.
        /// </summary>
        /// <param name="getRequest"></param>
        /// <returns></returns>
        public GetTenancyResponse GetTenancy(GetTenancyRequest getRequest)
        {
            var uri = new Uri($"{GetEndPoint(IdentityServices.Tenancy, this.Region)}/{getRequest.TenancyId}");

            try
            {
                var webResponse = this.RestClient.Get(uri);

                var response = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();

                return new GetTenancyResponse()
                {
                    Tenancy = JsonConvert.DeserializeObject<Tenancy>(response),
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
            catch (Exception)
            {
                throw;
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

            try
            {
                var webResponse = this.RestClient.Get(uri);

                var response = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();

                return new GetTagNamespaceResponse()
                {
                    TagNamespace = JsonConvert.DeserializeObject<TagNamespace>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
            catch (Exception)
            {
                throw;
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

            try
            {
                var webResponse = this.RestClient.Get(uri);

                var response = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();

                return new ListCompartmentResponse()
                {
                    Items = JsonConvert.DeserializeObject<List<Compartment>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
            catch (Exception)
            {
                throw;
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

            try
            {
                var webResponse = this.RestClient.Get(uri);

                var response = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();

                return new ListAvailabilityDomainsResponse()
                {
                    Items = JsonConvert.DeserializeObject<List<AvailabilityDomain>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
            catch (Exception)
            {
                throw;
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

            try
            {
                var webResponse = this.RestClient.Get(uri);

                var response = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();

                return new ListTagNamespacesResponse()
                {
                    Items = JsonConvert.DeserializeObject<List<TagNamespaceSummary>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
            catch (Exception)
            {
                throw;
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

            try
            {
                var webResponse = this.RestClient.Get(uri);

                var response = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();

                return new ListCostTrackingTagsResponse()
                {
                    Items = JsonConvert.DeserializeObject<List<Tag>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
            catch (Exception)
            {
                throw;
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

            try
            {
                var webResponse = this.RestClient.Get(uri);

                var response = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();

                return new ListTagsResponse()
                {
                    Items = JsonConvert.DeserializeObject<List<TagSummary>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
            catch (Exception)
            {
                throw;
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

            try
            {
                var webResponse = this.RestClient.Get(uri);

                var response = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();

                return new ListTagDefaultsResponse()
                {
                    Items = JsonConvert.DeserializeObject<List<TagDefaultSummary>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
            catch (Exception)
            {
                throw;
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

            try
            {
                var webResponse = this.RestClient.Get(uri);

                var response = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();

                return new GetCompartmentResponse()
                {
                    Compartment = JsonConvert.DeserializeObject<Compartment>(response),
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
            catch (Exception)
            {
                throw;
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

            try
            {
                var webResponse = this.RestClient.Get(uri);

                var response = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();

                return new GetTagResponse()
                {
                    Tag = JsonConvert.DeserializeObject<Tag>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
            catch (Exception)
            {
                throw;
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

            try
            {
                var webResponse = this.RestClient.Get(uri);

                var response = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();

                return new GetTagDefaultResponse()
                {
                    TagDefault = JsonConvert.DeserializeObject<TagDefault>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    ETag = webResponse.Headers.Get("ETag")
                };
            }
            catch (Exception)
            {
                throw;
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

            try
            {
                var webResponse = this.RestClient.Post(uri, createRequest.CreateCompartmentDetails, createRequest.OpcRetryToken);

                var response = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();

                return new CreateCompartmentResponse()
                {
                    Compartment = JsonConvert.DeserializeObject<Compartment>(response),
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Creates a new tag namespace in the specified compartment.
        /// You must specify the compartment ID in the request object (remember that the tenancy is simply the root compartment).
        /// </summary>
        /// <param name="createRequest"></param>
        /// <returns></returns>
        CreateTagNamespaceResponse CreateTagNamespace(CreateTagNamespaceRequest createRequest)
        {
            var uri = new Uri(GetEndPoint(IdentityServices.TagNamespaces, this.Region));

            try
            {
                var webResponse = this.RestClient.Post(uri, createRequest.CreateTagNamespaceDetails, createRequest.OpcRetryToken);

                var response = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();

                return new CreateTagNamespaceResponse()
                {
                    TagNamespace = JsonConvert.DeserializeObject<TagNamespace>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
            catch (Exception)
            {
                throw;
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

            try
            {
                var webResponse = this.RestClient.Post(uri, createRequest.CreateTagDetails, createRequest.OpcRetryToken);

                var response = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();

                return new CreateTagResponse()
                {
                    Tag = JsonConvert.DeserializeObject<Tag>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
            catch (Exception)
            {
                throw;
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

            try
            {
                var webResponse = this.RestClient.Post(uri, request.ChangeTagNamespaceCompartmentDetail, request.OpcRetryToken);

                var response = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();

                return new ChangeTagNamespaceCompartmentResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
            catch (Exception)
            {
                throw;
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

            try
            {
                var webResponse = this.RestClient.Put(uri, updateRequest.UpdateCompartmentDetails, updateRequest.IfMatch);

                var response = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();

                return new UpdateCompartmentResponse()
                {
                    Compartment = JsonConvert.DeserializeObject<Compartment>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    ETag = webResponse.Headers.Get("etag")
                };
            }
            catch (Exception)
            {
                throw;
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

            try
            {
                var webResponse = this.RestClient.Put(uri, updateRequest.UpdateTagNamespaceDetails);

                var response = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();

                return new UpdateTagNamespaceResponse()
                {
                    TagNamespace = JsonConvert.DeserializeObject<TagNamespace>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
            catch (Exception)
            {
                throw;
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

            try
            {
                var webResponse = this.RestClient.Put(uri, updateRequest.UpdateTagDetails);

                var response = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();

                return new UpdateTagResponse()
                {
                    Tag = JsonConvert.DeserializeObject<Tag>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
            catch (Exception)
            {
                throw;
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

            try
            {
                var webResponse = this.RestClient.Delete(uri, deleteRequest.IfMatch);

                var response = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();

                return new DeleteCompartmentResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    opcWorkRequestId = webResponse.Headers.Get("opc-work-request-id")
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

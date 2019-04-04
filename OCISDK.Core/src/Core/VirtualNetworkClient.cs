/// <summary>
/// VirtualNetwork Service Client
/// 
/// author: koutaro furusawa
/// </summary>

using System;
using System.Collections.Generic;
using System.IO;

using OCISDK.Core.src;
using OCISDK.Core.src.Common;
using OCISDK.Core.src.Core;
using OCISDK.Core.src.Core.Model.VirtualNetwork;
using OCISDK.Core.src.Core.Request.VirtualNetwork;
using OCISDK.Core.src.Core.Response.VirtualNetwork;

namespace OCISDK.Core
{
    public class VirtualNetworkClient : ServiceClient
    {
        private string _region;
        public string Region
        {
            get { return _region; }
            set {
                if (!String.IsNullOrEmpty(value))
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
        public VirtualNetworkClient(ClientConfig config) : base(config)
        {
            ServiceName = "core";

            this.RestClient = new RestClient() {
                Signer = Signer,
                Config = config,
                JsonSerializer = JsonSerializer
            };
        }

        public VirtualNetworkClient(ClientConfig config, RestClient restClient) : base(config)
        {
            ServiceName = "core";
            
            RestClient = restClient;
        }

        /// <summary>
        /// Lists the sets of DHCP options in the specified VCN and specified compartment.
        /// The response includes the default set of options that automatically comes with each VCN,
        /// plus any other sets you've created.
        /// </summary>
        /// <param name="listRequest"></param>
        /// <returns></returns>
        public ListDhcpResponse ListDhcpOptions(ListDhcpOptionsRequest listRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.DHCP, this.Region)}?{listRequest.GetOptionQuery()}");

            try
            {
                var webResponse = this.RestClient.Get(uri);

                var response = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();

                return new ListDhcpResponse()
                {
                    Items = JsonSerializer.Deserialize<List<DhcpOptions>>(response),
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
        /// Lists the route tables in the specified VCN and specified compartment.
        /// The response includes the default route table that automatically comes with each VCN, 
        /// plus any route tables you've created.
        /// </summary>
        /// <param name="listRequest"></param>
        /// <returns></returns>
        public ListRouteTableResponse ListRouteTableOptions(ListRouteTableRequest listRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.RouteTable, this.Region)}?{listRequest.GetOptionQuery()}");

            try
            {
                var webResponse = this.RestClient.Get(uri);

                var response = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();

                return new ListRouteTableResponse()
                {
                    Items = JsonSerializer.Deserialize<List<RouteTable>>(response),
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
        /// Lists the internet gateways in the specified VCN and the specified compartment.
        /// </summary>
        /// <param name="listRequest"></param>
        /// <returns></returns>
        public ListInternetGatewaysResponse ListInternetGateways(ListInternetGatewaysRequest listRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.InternetGateway, this.Region)}?{listRequest.GetOptionQuery()}");

            try
            {
                var webResponse = this.RestClient.Get(uri);

                var response = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();

                return new ListInternetGatewaysResponse()
                {
                    Items = JsonSerializer.Deserialize<List<InternetGateway>>(response),
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
        /// Lists the security lists in the specified VCN and compartment.
        /// </summary>
        /// <param name="listRequest"></param>
        /// <returns></returns>
        public ListSecurityListsResponse ListSecurityLists(ListSecurityListsRequest listRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.SecurityList, this.Region)}?{listRequest.GetOptionQuery()}");

            try
            {
                var webResponse = this.RestClient.Get(uri);

                var response = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();

                return new ListSecurityListsResponse()
                {
                    Items = JsonSerializer.Deserialize<List<SecurityList>>(response),
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
        /// Lists the virtual cloud networks (VCNs) in the specified compartment.
        /// </summary>
        /// <param name="listRequest"></param>
        /// <returns></returns>
        public ListVcnResponse ListVcn(ListVcnRequest listRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.VCN, this.Region)}?{listRequest.GetOptionQuery()}");
            
            try
            {
                var webResponse = this.RestClient.Get(uri);

                var response = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();

                return new ListVcnResponse()
                {
                    Items = JsonSerializer.Deserialize<List<Vcn>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
            catch(Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Lists the subnets in the specified VCN and the specified compartment.
        /// </summary>
        /// <param name="listRequest"></param>
        /// <returns></returns>
        public ListSubnetsResponse ListSubnets(ListSubnetsRequest listRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.Subnet, this.Region)}?{listRequest.GetOptionQuery()}");

            try
            {
                var webResponse = this.RestClient.Get(uri);

                var response = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();

                return new ListSubnetsResponse()
                {
                    Items = JsonSerializer.Deserialize<List<Subnet>>(response),
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
        /// Gets the specified set of DHCP options.
        /// </summary>
        /// <param name="getRequest"></param>
        /// <returns></returns>
        public GetDhcpResponse GetDhcp(GetDhcpRequest getDhcpRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.DHCP, this.Region)}/{getDhcpRequest.DhcpId}");

            try
            {
                var webResponse = this.RestClient.Get(uri);

                var response = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();

                return new GetDhcpResponse()
                {
                    DhcpOptions = JsonSerializer.Deserialize<DhcpOptions>(response),
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
        /// Gets the specified route table's information.
        /// </summary>
        /// <param name="getRtRequest"></param>
        /// <returns></returns>
        public GetRouteTableResponse GetRouteTable(GetRouteTableRequest getRtRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.RouteTable, this.Region)}/{getRtRequest.RtId}");

            try
            {
                var webResponse = this.RestClient.Get(uri);

                var response = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();

                return new GetRouteTableResponse()
                {
                    RouteTable = JsonSerializer.Deserialize<RouteTable>(response),
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
        /// Gets the specified internet gateway's information.
        /// </summary>
        /// <param name="getRequest"></param>
        /// <returns></returns>
        public GetInternetGatewayResponse GetInternetGateway(GetInternetGatewayRequest getRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.InternetGateway, this.Region)}/{getRequest.IgId}");

            try
            {
                var webResponse = this.RestClient.Get(uri);

                var response = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();

                return new GetInternetGatewayResponse()
                {
                    InternetGateway = JsonSerializer.Deserialize<InternetGateway>(response),
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
        /// Gets the specified security list's information.
        /// </summary>
        /// <param name="getSecurityListRequest"></param>
        /// <returns></returns>
        public GetSecurityListRespons GetSecurityList(GetSecurityListRequest getSecurityListRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.SecurityList, this.Region)}/{getSecurityListRequest.SecurityListId}");

            try
            {
                var webResponse = this.RestClient.Get(uri);

                var response = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();

                return new GetSecurityListRespons()
                {
                    SecurityList = JsonSerializer.Deserialize<SecurityList>(response),
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
        /// Gets the specified VCN's information.
        /// </summary>
        /// <param name="getRequest"></param>
        /// <returns></returns>
        public GetVcnResponse GetVcn(GetVcnRequest getVcnRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.VCN, this.Region)}/{getVcnRequest.VcnId}");

            try
            {
                var webResponse = this.RestClient.Get(uri);

                var response = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();

                return new GetVcnResponse()
                {
                    Vcn = JsonSerializer.Deserialize<Vcn>(response),
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
        /// Gets the information for the specified virtual network interface card (VNIC).
        /// You can get the VNIC OCID from the ListVnicAttachments operation.
        /// </summary>
        /// <param name="getVcnRequest"></param>
        /// <returns></returns>
        public GetVnicResponse GetVnic(GetVnicRequest getRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.VNIC, this.Region)}/{getRequest.VnicId}");

            try
            {
                var webResponse = this.RestClient.Get(uri);

                var response = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();

                return new GetVnicResponse()
                {
                    Vnic = JsonSerializer.Deserialize<Vnic>(response),
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
        /// Gets the specified subnet's information.
        /// </summary>
        /// <param name="getRequest"></param>
        /// <returns></returns>
        public GetSubnetResponse GetSubnet(GetSubnetRequest getRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.Subnet, this.Region)}/{getRequest.SubnetId}");

            try
            {
                var webResponse = this.RestClient.Get(uri);

                var response = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();

                return new GetSubnetResponse()
                {
                    Subnet = JsonSerializer.Deserialize<Subnet>(response),
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
        /// Creates a new internet gateway for the specified VCN. For more information, see Access to the Internet.
        /// </summary>
        /// <param name="createRequest"></param>
        /// <returns></returns>
        public CreateInternetGatewayResponse CreateInternetGateway(CreateInternetGatewayRequest createRequest)
        {
            var uri = new Uri(GetEndPoint(CoreServices.InternetGateway, this.Region));

            try
            {
                var webResponse = this.RestClient.Post(uri, createRequest.CreateInternetGatewayDetails, createRequest.OpcRetryToken);

                var response = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();

                return new CreateInternetGatewayResponse()
                {
                    InternetGateway = JsonSerializer.Deserialize<InternetGateway>(response),
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
        /// Creates a new set of DHCP options for the specified VCN. For more information, see DhcpOptions.
        /// </summary>
        /// <param name="createRequest"></param>
        /// <returns></returns>
        public CreateDhcpOptionsResponse CreateDhcpOptions(CreateDhcpOptionsRequest createRequest)
        {
            var uri = new Uri(GetEndPoint(CoreServices.DHCP, this.Region));

            try
            {
                var webResponse = this.RestClient.Post(uri, createRequest.CreateDhcpDetails, createRequest.OpcRetryToken);

                var response = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();

                return new CreateDhcpOptionsResponse()
                {
                    DhcpOptions = JsonSerializer.Deserialize<DhcpOptions>(response),
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
        /// Creates a new security list for the specified VCN. 
        /// For more information about security lists, see Security Lists. 
        /// For information on the number of rules you can have in a security list, see Service Limits.
        /// </summary>
        /// <param name="createRequest"></param>
        /// <returns></returns>
        public CreateSecurityListResponse CreateSecurityList(CreateSecurityListRequest createRequest)
        {
            var uri = new Uri(GetEndPoint(CoreServices.SecurityList, this.Region));

            try
            {
                var webResponse = this.RestClient.Post(uri, createRequest.CreateSecurityListDetails, createRequest.OpcRetryToken);

                var response = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();

                return new CreateSecurityListResponse()
                {
                    SecurityList = JsonSerializer.Deserialize<SecurityList>(response),
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
        /// Creates a new virtual cloud network (VCN). For more information, see VCNs and Subnets.
        /// </summary>
        /// <param name="createRequest">create VCN Request parameter</param>
        /// <returns></returns>
        public CreateVcnResponse CreateVcn(CreateVcnRequest createRequest)
        {
            var uri = new Uri(GetEndPoint(CoreServices.VCN, this.Region));

            try
            {
                var webResponse = this.RestClient.Post(uri, createRequest.CreateVcnDetails, createRequest.OpcRetryToken?? createRequest.OpcRetryToken);

                var response = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();

                return new CreateVcnResponse()
                {
                    Vcn = JsonSerializer.Deserialize<Vcn>(response),
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
        /// Creates a new subnet in the specified VCN. You can't change the size of the subnet after creation,
        /// so it's important to think about the size of subnets you need before creating them. For more 
        /// information, see VCNs and Subnets. For information on the number of subnets you can have in a 
        /// VCN, see Service Limits.
        /// </summary>
        /// <param name="createRequest"></param>
        /// <returns></returns>
        public CreateSubnetResponse CreateSubnet(CreateSubnetRequest createRequest)
        {
            var uri = new Uri(GetEndPoint(CoreServices.Subnet, this.Region));

            try
            {
                var webResponse = this.RestClient.Post(uri, createRequest.CreateSubnetDetails, createRequest.OpcRetryToken);

                var response = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();

                return new CreateSubnetResponse()
                {
                    Subnet = JsonSerializer.Deserialize<Subnet>(response),
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
        /// Updates the specified VCN.
        /// </summary>
        /// <param name="updateRequest"></param>
        /// <returns></returns>
        public UpdateVcnResponse UpdateVcn(UpdateVcnRequest updateRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.VCN, this.Region)}/{updateRequest.VcnId}");

            try
            {
                var webResponse = this.RestClient.Put(uri, updateRequest.UpdateVcnDetails, updateRequest.IfMatch);

                var response = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();

                return new UpdateVcnResponse()
                {
                    Vcn = JsonSerializer.Deserialize<Vcn>(response),
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
        /// Updates the specified VNIC.
        /// </summary>
        /// <param name="updateRequest"></param>
        /// <returns></returns>
        public UpdateVnicResponse UpdateVnic(UpdateVnicRequest updateRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.VNIC, this.Region)}/{updateRequest.VnicId}");

            try
            {
                var webResponse = this.RestClient.Put(uri, updateRequest.UpdateVnicDetails, updateRequest.IfMatch);

                var response = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();

                return new UpdateVnicResponse()
                {
                    Vnic = JsonSerializer.Deserialize<Vnic>(response),
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
        /// Updates the specified internet gateway.
        /// You can disable/enable it, or change its display name or tags.
        /// Avoid entering confidential information.
        /// </summary>
        /// <param name="updateRequest"></param>
        /// <returns></returns>
        public UpdateInternetGatewayResponse UpdateInternetGateway(UpdateInternetGatewayRequest updateRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.InternetGateway, this.Region)}/{updateRequest.IgId}");

            try
            {
                var webResponse = this.RestClient.Put(uri, updateRequest.UpdateInternetGatewayDetails, updateRequest.IfMatch);

                var response = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();

                return new UpdateInternetGatewayResponse()
                {
                    InternetGateway = JsonSerializer.Deserialize<InternetGateway>(response),
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
        /// Updates the specified set of DHCP options. 
        /// You can update the display name or the options themselves. Avoid entering confidential information.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public UpdateDhcpOptionsResponse UpdateDhcpOptions(UpdateDhcpOptionsRequest updateRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.DHCP, this.Region)}/{updateRequest.DhcpId}");

            try
            {
                var webResponse = this.RestClient.Put(uri, updateRequest.UpdateDhcpDetails, updateRequest.IfMatch);

                var response = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();

                return new UpdateDhcpOptionsResponse()
                {
                    DhcpOptions = JsonSerializer.Deserialize<DhcpOptions>(response),
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
        /// Updates the specified security list's display name or rules. Avoid entering confidential information.
        /// </summary>
        /// <param name="updateRequest"></param>
        /// <returns></returns>
        public UpdateSecurityListResponse UpdateSecurityList(UpdateSecurityListRequest updateRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.SecurityList, this.Region)}/{updateRequest.SecurityListId}");

            try
            {
                var webResponse = this.RestClient.Put(uri, updateRequest.UpdateSecurityListDetails, updateRequest.IfMatch);

                var response = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();

                return new UpdateSecurityListResponse()
                {
                    SecurityList = JsonSerializer.Deserialize<SecurityList>(response),
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
        /// Updates the specified subnet.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public UpdateSubnetResponse UpdateSubnet(UpdateSubnetRequest updateRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.Subnet, this.Region)}/{updateRequest.SubnetId}");

            try
            {
                var webResponse = this.RestClient.Put(uri, updateRequest.UpdateSubnetDetails, updateRequest.IfMatch);

                var response = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();

                return new UpdateSubnetResponse()
                {
                    Subnet = JsonSerializer.Deserialize<Subnet>(response),
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
        /// Deletes the specified VCN. The VCN must be empty and have no attached gateways.
        /// This is an asynchronous operation.
        /// The VCN's lifecycleState will change to TERMINATING temporarily until the VCN is completely removed.
        /// </summary>
        /// <param name="deleteRequest"></param>
        /// <returns></returns>
        public DeleteVcnResponse DeleteVcn(DeleteVcnRequest deleteRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.VCN, this.Region)}/{deleteRequest.VcnId}");

            try
            {
                var webResponse = this.RestClient.Delete(uri, deleteRequest.IfMatch);

                var response = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();

                return new DeleteVcnResponse()
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
        /// Deletes the specified internet gateway.
        /// The internet gateway does not have to be disabled, but there must not be a route table that lists it as a target.
        /// </summary>
        /// <param name="deleteRequest"></param>
        /// <returns></returns>
        public DeleteInternetGatewayResponse DeleteInternetGateway(DeleteInternetGatewayRequest deleteRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.InternetGateway, this.Region)}/{deleteRequest.IgId}");

            try
            {
                var webResponse = this.RestClient.Delete(uri, deleteRequest.IfMatch);

                var response = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();

                return new DeleteInternetGatewayResponse()
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
        /// Deletes the specified set of DHCP options, but only if it's not associated with a subnet.
        /// You can't delete a VCN's default set of DHCP options.
        /// </summary>
        /// <param name="deleteRequest"></param>
        /// <returns></returns>
        public DeleteDhcpOptionsResponse DeleteDhcpOptions(DeleteDhcpOptionsRequest deleteRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.DHCP, this.Region)}/{deleteRequest.DhcpId}");

            try
            {
                var webResponse = this.RestClient.Delete(uri, deleteRequest.IfMatch);

                var response = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();

                return new DeleteDhcpOptionsResponse()
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
        /// Deletes the specified security list, but only if it's not associated with a subnet.
        /// You can't delete a VCN's default security list.
        /// </summary>
        /// <param name="deleteRequest"></param>
        /// <returns></returns>
        public DeleteSecurityListResponse DeleteSecurityList(DeleteSecurityListRequest deleteRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.SecurityList, this.Region)}/{deleteRequest.SecurityListId}");

            try
            {
                var webResponse = this.RestClient.Delete(uri, deleteRequest.IfMatch);

                var response = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();

                return new DeleteSecurityListResponse()
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
        /// Deletes the specified subnet, but only if there are no instances in the subnet. 
        /// This is an asynchronous operation. The subnet's lifecycleState will change to TERMINATING 
        /// temporarily. If there are any instances in the subnet, the state will instead change back 
        /// to AVAILABLE.
        /// </summary>
        /// <param name="deleteRequest"></param>
        /// <returns></returns>
        public DeleteSubnetResponse DeleteSubnet(DeleteSubnetRequest deleteRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.Subnet, this.Region)}/{deleteRequest.SubnetId}");

            try
            {
                var webResponse = this.RestClient.Delete(uri, deleteRequest.IfMatch);

                var response = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();

                return new DeleteSubnetResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

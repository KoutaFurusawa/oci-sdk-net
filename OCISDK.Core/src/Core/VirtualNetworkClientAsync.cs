/// <summary>
/// VirtualNetwork Service Client
/// 
/// author: koutaro furusawa
/// </summary>

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using OCISDK.Core.src;
using OCISDK.Core.src.Common;
using OCISDK.Core.src.Core;
using OCISDK.Core.src.Core.Model.VirtualNetwork;
using OCISDK.Core.src.Core.Request.VirtualNetwork;
using OCISDK.Core.src.Core.Response.VirtualNetwork;

namespace OCISDK.Core
{
    public class VirtualNetworkClientAsync : ServiceClient, IVirtualNetworkClientAsync
    {
        /// <summary>
        /// Constructer
        /// </summary>
        public VirtualNetworkClientAsync(ClientConfig config) : base(config)
        {
            ServiceName = "core";
        }

        public VirtualNetworkClientAsync(ClientConfig config, OciSigner ociSigner) : base(config, ociSigner)
        {
            ServiceName = "core";
        }

        public VirtualNetworkClientAsync(ClientConfigStream config) : base(config)
        {
            ServiceName = "core";
        }

        public VirtualNetworkClientAsync(ClientConfigStream config, OciSigner ociSigner) : base(config, ociSigner)
        {
            ServiceName = "core";
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
        /// Lists the sets of DHCP options in the specified VCN and specified compartment.
        /// The response includes the default set of options that automatically comes with each VCN,
        /// plus any other sets you've created.
        /// </summary>
        /// <param name="listRequest"></param>
        /// <returns></returns>
        public async Task<ListDhcpResponse> ListDhcpOptions(ListDhcpOptionsRequest listRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.DHCP, this.Region)}?{listRequest.GetOptionQuery()}");
            
            var webResponse = await this.RestClientAsync.Get(uri);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListDhcpResponse()
                {
                    Items = JsonSerializer.Deserialize<List<DhcpOptions>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
        }

        /// <summary>
        /// Lists the route tables in the specified VCN and specified compartment.
        /// The response includes the default route table that automatically comes with each VCN, 
        /// plus any route tables you've created.
        /// </summary>
        /// <param name="listRequest"></param>
        /// <returns></returns>
        public async Task<ListRouteTableResponse> ListRouteTableOptions(ListRouteTableRequest listRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.RouteTable, this.Region)}?{listRequest.GetOptionQuery()}");
            
            var webResponse = await this.RestClientAsync.Get(uri);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListRouteTableResponse()
                {
                    Items = JsonSerializer.Deserialize<List<RouteTable>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
        }

        /// <summary>
        /// Lists the internet gateways in the specified VCN and the specified compartment.
        /// </summary>
        /// <param name="listRequest"></param>
        /// <returns></returns>
        public async Task<ListInternetGatewaysResponse> ListInternetGateways(ListInternetGatewaysRequest listRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.InternetGateway, this.Region)}?{listRequest.GetOptionQuery()}");
            
            var webResponse = await this.RestClientAsync.Get(uri);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListInternetGatewaysResponse()
                {
                    Items = JsonSerializer.Deserialize<List<InternetGateway>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
        }

        /// <summary>
        /// Lists the security lists in the specified VCN and compartment.
        /// </summary>
        /// <param name="listRequest"></param>
        /// <returns></returns>
        public async Task<ListSecurityListsResponse> ListSecurityLists(ListSecurityListsRequest listRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.SecurityList, this.Region)}?{listRequest.GetOptionQuery()}");
            
            var webResponse = await this.RestClientAsync.Get(uri);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListSecurityListsResponse()
                {
                    Items = JsonSerializer.Deserialize<List<SecurityList>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
        }

        /// <summary>
        /// Lists the virtual cloud networks (VCNs) in the specified compartment.
        /// </summary>
        /// <param name="listRequest"></param>
        /// <returns></returns>
        public async Task<ListVcnResponse> ListVcn(ListVcnRequest listRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.VCN, this.Region)}?{listRequest.GetOptionQuery()}");
            
            var webResponse = await this.RestClientAsync.Get(uri);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListVcnResponse()
                {
                    Items = JsonSerializer.Deserialize<List<Vcn>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
        }

        /// <summary>
        /// Lists the subnets in the specified VCN and the specified compartment.
        /// </summary>
        /// <param name="listRequest"></param>
        /// <returns></returns>
        public async Task<ListSubnetsResponse> ListSubnets(ListSubnetsRequest listRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.Subnet, this.Region)}?{listRequest.GetOptionQuery()}");
            
            var webResponse = await this.RestClientAsync.Get(uri);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListSubnetsResponse()
                {
                    Items = JsonSerializer.Deserialize<List<Subnet>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
        }

        /// <summary>
        /// Gets the specified set of DHCP options.
        /// </summary>
        /// <param name="getRequest"></param>
        /// <returns></returns>
        public async Task<GetDhcpResponse> GetDhcp(GetDhcpRequest getDhcpRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.DHCP, this.Region)}/{getDhcpRequest.DhcpId}");
            
            var webResponse = await this.RestClientAsync.Get(uri);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new GetDhcpResponse()
                {
                    DhcpOptions = JsonSerializer.Deserialize<DhcpOptions>(response),
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Gets the specified route table's information.
        /// </summary>
        /// <param name="getRtRequest"></param>
        /// <returns></returns>
        public async Task<GetRouteTableResponse> GetRouteTable(GetRouteTableRequest getRtRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.RouteTable, this.Region)}/{getRtRequest.RtId}");
            
            var webResponse = await this.RestClientAsync.Get(uri);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new GetRouteTableResponse()
                {
                    RouteTable = JsonSerializer.Deserialize<RouteTable>(response),
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Gets the specified internet gateway's information.
        /// </summary>
        /// <param name="getRequest"></param>
        /// <returns></returns>
        public async Task<GetInternetGatewayResponse> GetInternetGateway(GetInternetGatewayRequest getRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.InternetGateway, this.Region)}/{getRequest.IgId}");
            
            var webResponse = await this.RestClientAsync.Get(uri);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new GetInternetGatewayResponse()
                {
                    InternetGateway = JsonSerializer.Deserialize<InternetGateway>(response),
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Gets the specified security list's information.
        /// </summary>
        /// <param name="getSecurityListRequest"></param>
        /// <returns></returns>
        public async Task<GetSecurityListRespons> GetSecurityList(GetSecurityListRequest getSecurityListRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.SecurityList, this.Region)}/{getSecurityListRequest.SecurityListId}");
            
            var webResponse = await this.RestClientAsync.Get(uri);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new GetSecurityListRespons()
                {
                    SecurityList = JsonSerializer.Deserialize<SecurityList>(response),
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Gets the specified VCN's information.
        /// </summary>
        /// <param name="getRequest"></param>
        /// <returns></returns>
        public async Task<GetVcnResponse> GetVcn(GetVcnRequest getVcnRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.VCN, this.Region)}/{getVcnRequest.VcnId}");
            
            var webResponse = await this.RestClientAsync.Get(uri);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new GetVcnResponse()
                {
                    Vcn = JsonSerializer.Deserialize<Vcn>(response),
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Gets the information for the specified virtual network interface card (VNIC).
        /// You can get the VNIC OCID from the ListVnicAttachments operation.
        /// </summary>
        /// <param name="getVcnRequest"></param>
        /// <returns></returns>
        public async Task<GetVnicResponse> GetVnic(GetVnicRequest getRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.VNIC, this.Region)}/{getRequest.VnicId}");
            
            var webResponse = await this.RestClientAsync.Get(uri);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new GetVnicResponse()
                {
                    Vnic = JsonSerializer.Deserialize<Vnic>(response),
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Gets the specified subnet's information.
        /// </summary>
        /// <param name="getRequest"></param>
        /// <returns></returns>
        public async Task<GetSubnetResponse> GetSubnet(GetSubnetRequest getRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.Subnet, this.Region)}/{getRequest.SubnetId}");
            
            var webResponse = await this.RestClientAsync.Get(uri);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new GetSubnetResponse()
                {
                    Subnet = JsonSerializer.Deserialize<Subnet>(response),
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Moves a VCN into a different compartment within the same tenancy. 
        /// For information about moving resources between compartments, see Moving Resources to a Different Compartment.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<ChangeVcnCompartmentResponse> ChangeVcnCompartment(ChangeVcnCompartmentRequest param)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.VCN, this.Region)}/{param.VcnId}/actions/changeCompartment");

            var webResponse = await this.RestClientAsync.Post(uri, param.ChangeVcnCompartmentDetails, param.OpcRetryToken, param.OpcRequestId, "");

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ChangeVcnCompartmentResponse()
                {
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcWorkRequestId = webResponse.Headers.Get("opc-work-request-id")
                };
            }
        }

        /// <summary>
        /// Moves a subnet into a different compartment within the same tenancy. 
        /// For information about moving resources between compartments, see Moving Resources to a Different Compartment.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<ChangeSubnetCompartmentResponse> ChangeSubnetCompartment(ChangeSubnetCompartmentRequest param)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.Subnet, this.Region)}/{param.SubnetId}/actions/changeCompartment");

            var webResponse = await this.RestClientAsync.Post(uri, param.ChangeSubnetCompartmentDetails, param.OpcRetryToken, param.OpcRequestId, "");

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ChangeSubnetCompartmentResponse()
                {
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcWorkRequestId = webResponse.Headers.Get("opc-work-request-id")
                };
            }
        }

        /// <summary>
        /// Moves a security list into a different compartment within the same tenancy. 
        /// For information about moving resources between compartments, see Moving Resources to a Different Compartment.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<ChangeSecurityListCompartmentResponse> ChangeSecurityListCompartment(ChangeSecurityListCompartmentRequest param)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.SecurityList, this.Region)}/{param.SecurityListId}/actions/changeCompartment");

            var webResponse = await this.RestClientAsync.Post(uri, param.ChangeSecurityListCompartmentDetails, param.OpcRetryToken, param.OpcRequestId, "");

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ChangeSecurityListCompartmentResponse()
                {
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Moves a route table into a different compartment within the same tenancy. 
        /// For information about moving resources between compartments, see Moving Resources to a Different Compartment.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<ChangeRouteTableCompartmentResponse> ChangeRouteTableCompartment(ChangeRouteTableCompartmentRequest param)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.RouteTable, this.Region)}/{param.RtId}/actions/changeCompartment");

            var webResponse = await this.RestClientAsync.Post(uri, param.ChangeRouteTableCompartmentDetails, param.OpcRetryToken, param.OpcRequestId, "");

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ChangeRouteTableCompartmentResponse()
                {
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Creates a new internet gateway for the specified VCN. For more information, see Access to the Internet.
        /// </summary>
        /// <param name="createRequest"></param>
        /// <returns></returns>
        public async Task<CreateInternetGatewayResponse> CreateInternetGateway(CreateInternetGatewayRequest createRequest)
        {
            var uri = new Uri(GetEndPoint(CoreServices.InternetGateway, this.Region));
            
            var webResponse = await this.RestClientAsync.Post(uri, createRequest.CreateInternetGatewayDetails, createRequest.OpcRetryToken);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new CreateInternetGatewayResponse()
                {
                    InternetGateway = JsonSerializer.Deserialize<InternetGateway>(response),
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Creates a new set of DHCP options for the specified VCN. For more information, see DhcpOptions.
        /// </summary>
        /// <param name="createRequest"></param>
        /// <returns></returns>
        public async Task<CreateDhcpOptionsResponse> CreateDhcpOptions(CreateDhcpOptionsRequest createRequest)
        {
            var uri = new Uri(GetEndPoint(CoreServices.DHCP, this.Region));
            
            var webResponse = await this.RestClientAsync.Post(uri, createRequest.CreateDhcpDetails, createRequest.OpcRetryToken);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new CreateDhcpOptionsResponse()
                {
                    DhcpOptions = JsonSerializer.Deserialize<DhcpOptions>(response),
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Creates a new security list for the specified VCN. 
        /// For more information about security lists, see Security Lists. 
        /// For information on the number of rules you can have in a security list, see Service Limits.
        /// </summary>
        /// <param name="createRequest"></param>
        /// <returns></returns>
        public async Task<CreateSecurityListResponse> CreateSecurityList(CreateSecurityListRequest createRequest)
        {
            var uri = new Uri(GetEndPoint(CoreServices.SecurityList, this.Region));
            
            var webResponse = await this.RestClientAsync.Post(uri, createRequest.CreateSecurityListDetails, createRequest.OpcRetryToken);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new CreateSecurityListResponse()
                {
                    SecurityList = JsonSerializer.Deserialize<SecurityList>(response),
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Creates a new virtual cloud network (VCN). For more information, see VCNs and Subnets.
        /// </summary>
        /// <param name="createRequest">create VCN Request parameter</param>
        /// <returns></returns>
        public async Task<CreateVcnResponse> CreateVcn(CreateVcnRequest createRequest)
        {
            var uri = new Uri(GetEndPoint(CoreServices.VCN, this.Region));
            
            var webResponse = await this.RestClientAsync.Post(uri, createRequest.CreateVcnDetails, createRequest.OpcRetryToken?? createRequest.OpcRetryToken);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new CreateVcnResponse()
                {
                    Vcn = JsonSerializer.Deserialize<Vcn>(response),
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
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
        public async Task<CreateSubnetResponse> CreateSubnet(CreateSubnetRequest createRequest)
        {
            var uri = new Uri(GetEndPoint(CoreServices.Subnet, this.Region));
            
            var webResponse = await this.RestClientAsync.Post(uri, createRequest.CreateSubnetDetails, createRequest.OpcRetryToken);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new CreateSubnetResponse()
                {
                    Subnet = JsonSerializer.Deserialize<Subnet>(response),
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Creates a new route table for the specified VCN. In the request you must also include at least one route rule for the new route table. 
        /// For information on the number of rules you can have in a route table, see Service Limits. 
        /// For general information about route tables in your VCN and the types of targets you can use in route rules, see Route Tables.
        /// </summary>
        /// <param name="createRequest"></param>
        /// <returns></returns>
        public async Task<CreateRouteTableResponse> CreateRouteTable(CreateRouteTableRequest createRequest)
        {
            var uri = new Uri(GetEndPoint(CoreServices.RouteTable, this.Region));

            var webResponse = await this.RestClientAsync.Post(uri, createRequest.CreateRouteTableDetails, createRequest.OpcRetryToken);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new CreateRouteTableResponse()
                {
                    RouteTable = JsonSerializer.Deserialize<RouteTable>(response),
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Updates the specified VCN.
        /// </summary>
        /// <param name="updateRequest"></param>
        /// <returns></returns>
        public async Task<UpdateVcnResponse> UpdateVcn(UpdateVcnRequest updateRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.VCN, this.Region)}/{updateRequest.VcnId}");
            
            var webResponse = await this.RestClientAsync.Put(uri, updateRequest.UpdateVcnDetails, updateRequest.IfMatch);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new UpdateVcnResponse()
                {
                    Vcn = JsonSerializer.Deserialize<Vcn>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    ETag = webResponse.Headers.Get("etag")
                };
            }
        }

        /// <summary>
        /// Updates the specified VNIC.
        /// </summary>
        /// <param name="updateRequest"></param>
        /// <returns></returns>
        public async Task<UpdateVnicResponse> UpdateVnic(UpdateVnicRequest updateRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.VNIC, this.Region)}/{updateRequest.VnicId}");
            
            var webResponse = await this.RestClientAsync.Put(uri, updateRequest.UpdateVnicDetails, updateRequest.IfMatch);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new UpdateVnicResponse()
                {
                    Vnic = JsonSerializer.Deserialize<Vnic>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    ETag = webResponse.Headers.Get("etag")
                };
            }
        }

        /// <summary>
        /// Updates the specified internet gateway.
        /// You can disable/enable it, or change its display name or tags.
        /// Avoid entering confidential information.
        /// </summary>
        /// <param name="updateRequest"></param>
        /// <returns></returns>
        public async Task<UpdateInternetGatewayResponse> UpdateInternetGateway(UpdateInternetGatewayRequest updateRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.InternetGateway, this.Region)}/{updateRequest.IgId}");
            
            var webResponse = await this.RestClientAsync.Put(uri, updateRequest.UpdateInternetGatewayDetails, updateRequest.IfMatch);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new UpdateInternetGatewayResponse()
                {
                    InternetGateway = JsonSerializer.Deserialize<InternetGateway>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    ETag = webResponse.Headers.Get("etag")
                };
            }
        }

        /// <summary>
        /// Updates the specified set of DHCP options. 
        /// You can update the display name or the options themselves. Avoid entering confidential information.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<UpdateDhcpOptionsResponse> UpdateDhcpOptions(UpdateDhcpOptionsRequest updateRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.DHCP, this.Region)}/{updateRequest.DhcpId}");
            
            var webResponse = await this.RestClientAsync.Put(uri, updateRequest.UpdateDhcpDetails, updateRequest.IfMatch);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new UpdateDhcpOptionsResponse()
                {
                    DhcpOptions = JsonSerializer.Deserialize<DhcpOptions>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    ETag = webResponse.Headers.Get("etag")
                };
            }
        }

        /// <summary>
        /// Updates the specified security list's display name or rules. Avoid entering confidential information.
        /// </summary>
        /// <param name="updateRequest"></param>
        /// <returns></returns>
        public async Task<UpdateSecurityListResponse> UpdateSecurityList(UpdateSecurityListRequest updateRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.SecurityList, this.Region)}/{updateRequest.SecurityListId}");
            
            var webResponse = await this.RestClientAsync.Put(uri, updateRequest.UpdateSecurityListDetails, updateRequest.IfMatch);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new UpdateSecurityListResponse()
                {
                    SecurityList = JsonSerializer.Deserialize<SecurityList>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    ETag = webResponse.Headers.Get("etag")
                };
            }
        }

        /// <summary>
        /// Updates the specified subnet.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<UpdateSubnetResponse> UpdateSubnet(UpdateSubnetRequest updateRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.Subnet, this.Region)}/{updateRequest.SubnetId}");
            
            var webResponse = await this.RestClientAsync.Put(uri, updateRequest.UpdateSubnetDetails, updateRequest.IfMatch);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new UpdateSubnetResponse()
                {
                    Subnet = JsonSerializer.Deserialize<Subnet>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    ETag = webResponse.Headers.Get("etag")
                };
            }
        }

        /// <summary>
        /// Updates the specified route table's display name or route rules. Avoid entering confidential information.
        /// Note that the routeRules object you provide replaces the entire existing set of rules.
        /// </summary>
        /// <param name="updateRequest"></param>
        /// <returns></returns>
        public async Task<UpdateRouteTableResponse> UpdateRouteTable(UpdateRouteTableRequest updateRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.RouteTable, this.Region)}/{updateRequest.RtId}");

            var webResponse = await this.RestClientAsync.Put(uri, updateRequest.UpdateRouteTableDetails, updateRequest.IfMatch);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new UpdateRouteTableResponse()
                {
                    RouteTable = JsonSerializer.Deserialize<RouteTable>(response),
                    ETag = webResponse.Headers.Get("etag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Deletes the specified VCN. The VCN must be empty and have no attached gateways.
        /// This is an asynchronous operation.
        /// The VCN's lifecycleState will change to TERMINATING temporarily until the VCN is completely removed.
        /// </summary>
        /// <param name="deleteRequest"></param>
        /// <returns></returns>
        public async Task<DeleteVcnResponse> DeleteVcn(DeleteVcnRequest deleteRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.VCN, this.Region)}/{deleteRequest.VcnId}");
            
            var webResponse = await this.RestClientAsync.Delete(uri, deleteRequest.IfMatch);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new DeleteVcnResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Deletes the specified internet gateway.
        /// The internet gateway does not have to be disabled, but there must not be a route table that lists it as a target.
        /// </summary>
        /// <param name="deleteRequest"></param>
        /// <returns></returns>
        public async Task<DeleteInternetGatewayResponse> DeleteInternetGateway(DeleteInternetGatewayRequest deleteRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.InternetGateway, this.Region)}/{deleteRequest.IgId}");
            
            var webResponse = await this.RestClientAsync.Delete(uri, deleteRequest.IfMatch);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new DeleteInternetGatewayResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Deletes the specified set of DHCP options, but only if it's not associated with a subnet.
        /// You can't delete a VCN's default set of DHCP options.
        /// </summary>
        /// <param name="deleteRequest"></param>
        /// <returns></returns>
        public async Task<DeleteDhcpOptionsResponse> DeleteDhcpOptions(DeleteDhcpOptionsRequest deleteRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.DHCP, this.Region)}/{deleteRequest.DhcpId}");
            
            var webResponse = await this.RestClientAsync.Delete(uri, deleteRequest.IfMatch);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new DeleteDhcpOptionsResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Deletes the specified security list, but only if it's not associated with a subnet.
        /// You can't delete a VCN's default security list.
        /// </summary>
        /// <param name="deleteRequest"></param>
        /// <returns></returns>
        public async Task<DeleteSecurityListResponse> DeleteSecurityList(DeleteSecurityListRequest deleteRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.SecurityList, this.Region)}/{deleteRequest.SecurityListId}");
            
            var webResponse = await this.RestClientAsync.Delete(uri, deleteRequest.IfMatch);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new DeleteSecurityListResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
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
        public async Task<DeleteSubnetResponse> DeleteSubnet(DeleteSubnetRequest deleteRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.Subnet, this.Region)}/{deleteRequest.SubnetId}");
            
            var webResponse = await this.RestClientAsync.Delete(uri, deleteRequest.IfMatch);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new DeleteSubnetResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Deletes the specified route table, but only if it's not associated with a subnet. You can't delete a VCN's default route table.
        /// This is an asynchronous operation. The route table's lifecycleState will change to TERMINATING temporarily until the route table is completely removed.
        /// </summary>
        /// <param name="deleteRequest"></param>
        /// <returns></returns>
        public async Task<DeleteRouteTableResponse> DeleteRouteTable(DeleteRouteTableRequest deleteRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.RouteTable, this.Region)}/{deleteRequest.RtId}");

            var webResponse = await this.RestClientAsync.Delete(uri, deleteRequest.IfMatch);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new DeleteRouteTableResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }
    }
}

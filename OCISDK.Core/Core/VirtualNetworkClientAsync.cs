﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using OCISDK.Core;
using OCISDK.Core.Common;
using OCISDK.Core.Core;
using OCISDK.Core.Core.Model.VirtualNetwork;
using OCISDK.Core.Core.Request.VirtualNetwork;
using OCISDK.Core.Core.Response.VirtualNetwork;

namespace OCISDK.Core
{
    /// <summary>
    /// VirtualNetworkClientAsync
    /// </summary>
    public class VirtualNetworkClientAsync : ServiceClient, IVirtualNetworkClientAsync
    {
        /// <summary>
        /// Constructer
        /// </summary>
        public VirtualNetworkClientAsync(ClientConfig config) : base(config)
        {
            ServiceName = CoreServices.CoreServiceName;
        }

        /// <summary>
        /// Constructer
        /// </summary>
        public VirtualNetworkClientAsync(ClientConfig config, IOciSigner ociSigner) : base(config, ociSigner)
        {
            ServiceName = CoreServices.CoreServiceName;
        }

        /// <summary>
        /// Constructer
        /// </summary>
        public VirtualNetworkClientAsync(ClientConfigStream config) : base(config)
        {
            ServiceName = CoreServices.CoreServiceName;
        }

        /// <summary>
        /// Constructer
        /// </summary>
        public VirtualNetworkClientAsync(ClientConfigStream config, IOciSigner ociSigner) : base(config, ociSigner)
        {
            ServiceName = CoreServices.CoreServiceName;
        }

        /// <summary>
        /// Lists the customer-premises equipment objects (CPEs) in the specified compartment.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ListCpesResponse> ListCpes(ListCpesRequest request)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.CPE, this.Region)}?{request.GetOptionQuery()}");

            using (var webResponse = await this.RestClientAsync.Get(uri))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

                return new ListCpesResponse()
                {
                    Items = JsonSerializer.Deserialize<List<CpeDetails>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
        }

        /// <summary>
        /// Lists the CPE device types that the Networking service provides CPE configuration content for (example: Cisco ASA). 
        /// The content helps a network engineer configure the actual CPE device represented by a Cpe object.
        /// 
        /// If you want to generate CPE configuration content for one of the returned CPE device types, ensure that the Cpe 
        /// object's cpeDeviceShapeId attribute is set to the CPE device type's OCID (returned by this operation).
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ListCpeDeviceShapesResponse> ListCpeDeviceShapes(ListCpeDeviceShapesRequest request)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.CpeDeviceShapes, this.Region)}?{request.GetOptionQuery()}");

            using (var webResponse = await this.RestClientAsync.Get(uri, new HttpRequestHeaderParam { OpcRequestId = request.OpcRequestId }))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

                return new ListCpeDeviceShapesResponse()
                {
                    Items = JsonSerializer.Deserialize<List<CpeDeviceShapeSummary>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
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
            
            using(var webResponse = await this.RestClientAsync.Get(uri))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

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
            
            using(var webResponse = await this.RestClientAsync.Get(uri))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

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
            
            using(var webResponse = await this.RestClientAsync.Get(uri))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

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
            
            using(var webResponse = await this.RestClientAsync.Get(uri))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

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
            
            using(var webResponse = await this.RestClientAsync.Get(uri))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

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
            
            using(var webResponse = await this.RestClientAsync.Get(uri))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

                return new ListSubnetsResponse()
                {
                    Items = JsonSerializer.Deserialize<List<Subnet>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
        }

        /// <summary>
        /// Lists the DrgAttachment objects for the specified compartment. You can filter the results by VCN or DRG.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ListDrgAttachmentsResponse> ListDrgAttachments(ListDrgAttachmentsRequest request)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.DRGAttachment, this.Region)}?{request.GetOptionQuery()}");

            using(var webResponse = await this.RestClientAsync.Get(uri))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

                return new ListDrgAttachmentsResponse()
                {
                    Items = JsonSerializer.Deserialize<List<DrgAttachment>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
        }

        /// <summary>
        /// Lists the DRGs in the specified compartment.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ListDrgsResponse> ListDrgs(ListDrgsRequest request)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.DRG, this.Region)}?{request.GetOptionQuery()}");

            using(var webResponse = await this.RestClientAsync.Get(uri))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

                return new ListDrgsResponse()
                {
                    Items = JsonSerializer.Deserialize<List<DrgDetails>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
        }

        /// <summary>
        /// Lists the virtual circuits in the specified compartment.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ListVirtualCircuitsResponse> ListVirtualCircuits(ListVirtualCircuitsRequest request)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.VirtualCircuit, this.Region)}?{request.GetOptionQuery()}");

            using(var webResponse = await this.RestClientAsync.Get(uri))

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

                return new ListVirtualCircuitsResponse()
                {
                    Items = JsonSerializer.Deserialize<List<VirtualCircuit>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
        }

        /// <summary>
        /// The deprecated operation lists available bandwidth levels for virtual circuits. For the compartment ID, provide the OCID of your tenancy (the root compartment).
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ListVirtualCircuitBandwidthShapesResponse> ListVirtualCircuitBandwidthShapes(ListVirtualCircuitBandwidthShapesRequest request)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.VirtualCircuitBandwidthShape, this.Region)}?{request.GetOptionQuery()}");

            using(var webResponse = await this.RestClientAsync.Get(uri))

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

                return new ListVirtualCircuitBandwidthShapesResponse()
                {
                    Items = JsonSerializer.Deserialize<List<VirtualCircuitBandwidthShape>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
        }

        /// <summary>
        /// Lists the NAT gateways in the specified compartment. You may optionally specify a VCN OCID to filter the results by VCN.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ListNatGatewaysResponse> ListNatGateways(ListNatGatewaysRequest request)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.NatGateway, this.Region)}?{request.GetOptionQuery()}");

            using (var webResponse = await this.RestClientAsync.Get(uri))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

                return new ListNatGatewaysResponse()
                {
                    Items = JsonSerializer.Deserialize<List<NatGateway>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
        }

        /// <summary>
        /// Lists the VLANs in the specified VCN and the specified compartment.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ListVlansResponse> ListVlans(ListVlansRequest request)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.Vlans, this.Region)}?{request.GetOptionQuery()}");

            using (var webResponse = await this.RestClientAsync.Get(uri, new HttpRequestHeaderParam { OpcRequestId = request.OpcRequestId }))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

                return new ListVlansResponse()
                {
                    Items = JsonSerializer.Deserialize<List<VlanDetails>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
        }

        /// <summary>
        /// Gets the specified CPE's information.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<GetCpeResponse> GetCpe(GetCpeRequest request)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.CPE, this.Region)}/{request.CpeId}");

            using(var webResponse = await this.RestClientAsync.Get(uri))

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

                return new GetCpeResponse()
                {
                    Cpe = JsonSerializer.Deserialize<CpeDetails>(response),
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Gets the detailed information about the specified CPE device type. This might include a set of questions that are 
        /// specific to the particular CPE device type. The customer must supply answers to those questions (see 
        /// UpdateTunnelCpeDeviceConfig). The service merges the answers with a template of other information for the CPE 
        /// device type. 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<GetCpeDeviceShapeResponse> GetCpeDeviceShape(GetCpeDeviceShapeRequest request)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.CpeDeviceShapes, this.Region)}/{request.CpeDeviceShapeId}");

            using (var webResponse = await this.RestClientAsync.Get(uri, new HttpRequestHeaderParam { OpcRequestId = request.OpcRequestId }))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

                return new GetCpeDeviceShapeResponse()
                {
                    CpeDeviceShapeDetail = JsonSerializer.Deserialize<CpeDeviceShapeDetail>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Gets the specified set of DHCP options.
        /// </summary>
        /// <param name="getDhcpRequest"></param>
        /// <returns></returns>
        public async Task<GetDhcpResponse> GetDhcp(GetDhcpRequest getDhcpRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.DHCP, this.Region)}/{getDhcpRequest.DhcpId}");
            
            using(var webResponse = await this.RestClientAsync.Get(uri))

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

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
            
            using(var webResponse = await this.RestClientAsync.Get(uri))

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

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
            
            using(var webResponse = await this.RestClientAsync.Get(uri))

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

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
            
            using(var webResponse = await this.RestClientAsync.Get(uri))

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

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
        /// <param name="getVcnRequest"></param>
        /// <returns></returns>
        public async Task<GetVcnResponse> GetVcn(GetVcnRequest getVcnRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.VCN, this.Region)}/{getVcnRequest.VcnId}");
            
            using(var webResponse = await this.RestClientAsync.Get(uri))

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

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
        public async Task<GetVnicResponse> GetVnic(GetVnicRequest getVcnRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.VNIC, this.Region)}/{getVcnRequest.VnicId}");
            
            using(var webResponse = await this.RestClientAsync.Get(uri))

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

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
            
            using(var webResponse = await this.RestClientAsync.Get(uri))

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

                return new GetSubnetResponse()
                {
                    Subnet = JsonSerializer.Deserialize<Subnet>(response),
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Gets the information for the specified DrgAttachment.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<GetDrgAttachmentResponse> GetDrgAttachment(GetDrgAttachmentRequest request)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.DRGAttachment, this.Region)}/{request.DrgAttachmentId}");

            using(var webResponse = await this.RestClientAsync.Get(uri))

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

                return new GetDrgAttachmentResponse()
                {
                    DrgAttachment = JsonSerializer.Deserialize<DrgAttachment>(response),
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Gets the specified DRG's information.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<GetDrgResponse> GetDrg(GetDrgRequest request)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.DRG, this.Region)}/{request.DrgId}");

            using(var webResponse = await this.RestClientAsync.Get(uri))

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

                return new GetDrgResponse()
                {
                    Drg = JsonSerializer.Deserialize<DrgDetails>(response),
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Gets the specified virtual circuit's information.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<GetVirtualCircuitResponse> GetVirtualCircuit(GetVirtualCircuitRequest request)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.VirtualCircuit, this.Region)}/{request.VirtualCircuitId}");

            using(var webResponse = await this.RestClientAsync.Get(uri, new HttpRequestHeaderParam { IfMatch = request.IfMatch }))

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

                return new GetVirtualCircuitResponse()
                {
                    VirtualCircuit = JsonSerializer.Deserialize<VirtualCircuit>(response),
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Gets the specified NAT gateway's information.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<GetNatGatewayResponse> GetNatGateway(GetNatGatewayRequest request)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.NatGateway, this.Region)}/{request.NatGatewayId}");

            using (var webResponse = await this.RestClientAsync.Get(uri))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

                return new GetNatGatewayResponse()
                {
                    NatGateway = JsonSerializer.Deserialize<NatGateway>(response),
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Gets the specified VLAN's information.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<GetVlanResponse> GetVlan(GetVlanRequest request)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.Vlans, this.Region)}/{request.VlanId}");

            using (var webResponse = await this.RestClientAsync.Get(uri, new HttpRequestHeaderParam { OpcRequestId = request.OpcRequestId }))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

                return new GetVlanResponse()
                {
                    Vlan = JsonSerializer.Deserialize<VlanDetails>(response),
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Moves a CPE object into a different compartment within the same tenancy. 
        /// For information about moving resources between compartments, see Moving Resources to a Different Compartment.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ChangeCpeCompartmentResponse> ChangeCpeCompartment(ChangeCpeCompartmentRequest request)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.CPE, this.Region)}/{request.CpeId}/actions/changeCompartment");

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                OpcRetryToken = request.OpcRetryToken,
                OpcRequestId = request.OpcRequestId
            };
            using(var webResponse = await this.RestClientAsync.Post(uri, request.ChangeCpeCompartmentDetails, httpRequestHeaderParam))

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

                return new ChangeCpeCompartmentResponse()
                {
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

            var httpRequestHeaderParam = new HttpRequestHeaderParam() {
                OpcRetryToken = param.OpcRetryToken,
                OpcRequestId = param.OpcRequestId
            };
            using (var webResponse = await this.RestClientAsync.Post(uri, param.ChangeVcnCompartmentDetails, httpRequestHeaderParam))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

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

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                OpcRetryToken = param.OpcRetryToken,
                OpcRequestId = param.OpcRequestId
            };
            using (var webResponse = await this.RestClientAsync.Post(uri, param.ChangeSubnetCompartmentDetails, httpRequestHeaderParam))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

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

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                OpcRetryToken = param.OpcRetryToken,
                OpcRequestId = param.OpcRequestId
            };
            using (var webResponse = await this.RestClientAsync.Post(uri, param.ChangeSecurityListCompartmentDetails, httpRequestHeaderParam))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

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

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                OpcRetryToken = param.OpcRetryToken,
                OpcRequestId = param.OpcRequestId
            };
            using (var webResponse = await this.RestClientAsync.Post(uri, param.ChangeRouteTableCompartmentDetails, httpRequestHeaderParam))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

                return new ChangeRouteTableCompartmentResponse()
                {
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Moves a virtual circuit into a different compartment within the same tenancy. 
        /// For information about moving resources between compartments, see Moving Resources to a Different Compartment.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ChangeVirtualCircuitCompartmentResponse> ChangeVirtualCircuitCompartment(ChangeVirtualCircuitCompartmentRequest request)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.VirtualCircuit, this.Region)}/{request.VirtualCircuitId}/actions/changeCompartment");

            var headers = new HttpRequestHeaderParam
            {
                OpcRequestId = request.OpcRequestId,
                OpcRetryToken = request.OpcRetryToken
            };
            using (var webResponse = await this.RestClientAsync.Post(uri, request.ChangeVirtualCircuitCompartmentDetails, headers))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

                return new ChangeVirtualCircuitCompartmentResponse()
                {
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Moves a NAT gateway into a different compartment within the same tenancy. 
        /// For information about moving resources between compartments, see Moving Resources to a Different Compartment.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ChangeNatGatewayCompartmentResponse> ChangeNatGatewayCompartment(ChangeNatGatewayCompartmentRequest request)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.NatGateway, this.Region)}/{request.NatGatewayId}/actions/changeCompartment");

            var headers = new HttpRequestHeaderParam
            {
                OpcRequestId = request.OpcRequestId,
                OpcRetryToken = request.OpcRetryToken
            };
            using (var webResponse = await this.RestClientAsync.Post(uri, request.ChangeNatGatewayCompartmentDetails, headers))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

                return new ChangeNatGatewayCompartmentResponse()
                {
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Moves a VLAN into a different compartment within the same tenancy. For information about moving resources between compartments, 
        /// see Moving Resources to a Different Compartment.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ChangeVlanCompartmentResponse> ChangeVlanCompartment(ChangeVlanCompartmentRequest request)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.Vlans, this.Region)}/{request.VlanId}/actions/changeCompartment");

            var headers = new HttpRequestHeaderParam
            {
                IfMatch = request.IfMatch,
                OpcRequestId = request.OpcRequestId,
                OpcRetryToken = request.OpcRetryToken
            };
            using (var webResponse = await this.RestClientAsync.Post(uri, request.ChangeVlanCompartmentDetails, headers))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

                return new ChangeVlanCompartmentResponse()
                {
                    OpcWorkRequestId = webResponse.Headers.Get("opc-work-request-id"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Adds one or more customer public IP prefixes to the specified public virtual circuit. Use this operation 
        /// (and not UpdateVirtualCircuit) to add prefixes to the virtual circuit. Oracle must verify the customer's ownership 
        /// of each prefix before traffic for that prefix will flow across the virtual circuit.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<BulkAddVirtualCircuitPublicPrefixesResponse> BulkAddVirtualCircuitPublicPrefixes(BulkAddVirtualCircuitPublicPrefixesRequest request)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.VirtualCircuit, this.Region)}/{request.VirtualCircuitId}/actions/bulkAddPublicPrefixes");

            using (var webResponse = await this.RestClientAsync.Post(uri, request.BulkAddVirtualCircuitPublicPrefixesDetails))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

                return new BulkAddVirtualCircuitPublicPrefixesResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Removes one or more customer public IP prefixes from the specified public virtual circuit. Use this operation (and not UpdateVirtualCircuit) 
        /// to remove prefixes from the virtual circuit. When the virtual circuit's state switches back to PROVISIONED, Oracle stops advertising 
        /// the specified prefixes across the connection.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<BulkDeleteVirtualCircuitPublicPrefixesResponse> BulkDeleteVirtualCircuitPublicPrefixes(BulkDeleteVirtualCircuitPublicPrefixesRequest request)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.VirtualCircuit, this.Region)}/{request.VirtualCircuitId}/actions/bulkDeletePublicPrefixes");

            using (var webResponse = await this.RestClientAsync.Post(uri, request.BulkDeleteVirtualCircuitPublicPrefixesDetails))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

                return new BulkDeleteVirtualCircuitPublicPrefixesResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Creates a new virtual customer-premises equipment (CPE) object in the specified compartment. For more information, see IPSec VPNs.
        /// 
        /// For the purposes of access control, you must provide the OCID of the compartment where you want the CPE to reside. Notice that the CPE doesn't 
        /// have to be in the same compartment as the IPSec connection or other Networking Service components. If you're not sure which compartment to use, 
        /// put the CPE in the same compartment as the DRG. For more information about compartments and access control, see Overview of the IAM Service. 
        /// For information about OCIDs, see Resource Identifiers.
        /// 
        /// You must provide the public IP address of your on-premises router. See Configuring Your On-Premises Router for an IPSec VPN.
        /// 
        /// You may optionally specify a display name for the CPE, otherwise a default is provided. It does not have to be unique, and you can change it. 
        /// Avoid entering confidential information.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CreateCpeResponse> CreateCpe(CreateCpeRequest request)
        {
            var uri = new Uri(GetEndPoint(CoreServices.CPE, this.Region));

            using (var webResponse = await this.RestClientAsync.Post(uri, request.CreateCpeDetails, new HttpRequestHeaderParam() { OpcRetryToken = request.OpcRetryToken }))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

                return new CreateCpeResponse()
                {
                    Cpe = JsonSerializer.Deserialize<CpeDetails>(response),
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

            using (var webResponse = await this.RestClientAsync.Post(uri, createRequest.CreateInternetGatewayDetails, new HttpRequestHeaderParam() { OpcRetryToken = createRequest.OpcRetryToken }))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

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

            using (var webResponse = await this.RestClientAsync.Post(uri, createRequest.CreateDhcpDetails, new HttpRequestHeaderParam() { OpcRetryToken = createRequest.OpcRetryToken }))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

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

            using (var webResponse = await this.RestClientAsync.Post(uri, createRequest.CreateSecurityListDetails, new HttpRequestHeaderParam() { OpcRetryToken = createRequest.OpcRetryToken }))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

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

            using (var webResponse = await this.RestClientAsync.Post(uri, createRequest.CreateVcnDetails, new HttpRequestHeaderParam() { OpcRetryToken = createRequest.OpcRetryToken }))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

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

            using (var webResponse = await this.RestClientAsync.Post(uri, createRequest.CreateSubnetDetails, new HttpRequestHeaderParam() { OpcRetryToken = createRequest.OpcRetryToken }))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

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

            using (var webResponse = await this.RestClientAsync.Post(uri, createRequest.CreateRouteTableDetails, new HttpRequestHeaderParam() { OpcRetryToken = createRequest.OpcRetryToken }))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

                return new CreateRouteTableResponse()
                {
                    RouteTable = JsonSerializer.Deserialize<RouteTable>(response),
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Attaches the specified DRG to the specified VCN. A VCN can be attached to only one DRG at a time, and vice versa. 
        /// The response includes a DrgAttachment object with its own OCID. For more information about DRGs, see Dynamic Routing Gateways (DRGs).
        /// 
        /// You may optionally specify a display name for the attachment, otherwise a default is provided. 
        /// It does not have to be unique, and you can change it. Avoid entering confidential information.
        /// 
        /// For the purposes of access control, the DRG attachment is automatically placed into the same compartment as the VCN. 
        /// For more information about compartments and access control, see Overview of the IAM Service.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CreateDrgAttachmentResponse> CreateDrgAttachment(CreateDrgAttachmentRequest request)
        {
            var uri = new Uri(GetEndPoint(CoreServices.DRGAttachment, this.Region));

            using (var webResponse = await this.RestClientAsync.Post(uri, request.CreateDrgAttachmentDetails, new HttpRequestHeaderParam() { OpcRetryToken = request.OpcRetryToken }))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

                return new CreateDrgAttachmentResponse()
                {
                    DrgAttachment = JsonSerializer.Deserialize<DrgAttachment>(response),
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Creates a new dynamic routing gateway (DRG) in the specified compartment. For more information, see Dynamic Routing Gateways (DRGs).
        /// 
        /// For the purposes of access control, you must provide the OCID of the compartment where you want the DRG to reside. 
        /// Notice that the DRG doesn't have to be in the same compartment as the VCN, the DRG attachment, or other Networking Service components. 
        /// If you're not sure which compartment to use, put the DRG in the same compartment as the VCN. 
        /// For more information about compartments and access control, see Overview of the IAM Service. 
        /// For information about OCIDs, see Resource Identifiers.
        /// 
        /// You may optionally specify a display name for the DRG, otherwise a default is provided. 
        /// It does not have to be unique, and you can change it. Avoid entering confidential information.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CreateDrgResponse> CreateDrg(CreateDrgRequest request)
        {
            var uri = new Uri(GetEndPoint(CoreServices.DRG, this.Region));

            using (var webResponse = await this.RestClientAsync.Post(uri, request.CreateDrgDetails, new HttpRequestHeaderParam() { OpcRetryToken = request.OpcRetryToken }))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

                return new CreateDrgResponse()
                {
                    Drg = JsonSerializer.Deserialize<DrgDetails>(response),
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Creates a new virtual circuit to use with Oracle Cloud Infrastructure FastConnect. For more information, see FastConnect Overview.
        /// 
        /// For the purposes of access control, you must provide the OCID of the compartment where you want the virtual circuit to reside. 
        /// If you're not sure which compartment to use, put the virtual circuit in the same compartment with the DRG it's using. 
        /// For more information about compartments and access control, see Overview of the IAM Service. For information about OCIDs, see Resource Identifiers.
        /// 
        /// You may optionally specify a display name for the virtual circuit. It does not have to be unique, and you can change it. Avoid entering confidential information.
        /// 
        /// Important: When creating a virtual circuit, you specify a DRG for the traffic to flow through. Make sure you attach the DRG to your VCN and confirm the VCN's 
        /// routing sends traffic to the DRG. Otherwise traffic will not flow. For more information, see Route Tables.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CreateVirtualCircuitResponse> CreateVirtualCircuit(CreateVirtualCircuitRequest request)
        {
            var uri = new Uri(GetEndPoint(CoreServices.VirtualCircuit, this.Region));

            using (var webResponse = await this.RestClientAsync.Post(uri, request.CreateVirtualCircuitDetails, new HttpRequestHeaderParam { OpcRetryToken = request.OpcRetryToken }))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

                return new CreateVirtualCircuitResponse()
                {
                    VirtualCircuit = JsonSerializer.Deserialize<VirtualCircuit>(response),
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Creates a new NAT gateway for the specified VCN. You must also set up a route rule with the NAT gateway as the rule's target. See Route Table.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CreateNatGatewayResponse> CreateNatGateway(CreateNatGatewayRequest request)
        {
            var uri = new Uri(GetEndPoint(CoreServices.NatGateway, this.Region));

            using (var webResponse = await this.RestClientAsync.Post(uri, request.CreateNatGatewayDetails, new HttpRequestHeaderParam { OpcRetryToken = request.OpcRetryToken }))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

                return new CreateNatGatewayResponse()
                {
                    NatGateway = JsonSerializer.Deserialize<NatGateway>(response),
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Creates a VLAN in the specified VCN and the specified compartment.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CreateVlanResponse> CreateVlan(CreateVlanRequest request)
        {
            var uri = new Uri(GetEndPoint(CoreServices.Vlans, this.Region));

            var headers = new HttpRequestHeaderParam
            {
                OpcRequestId = request.OpcRequestId,
                OpcRetryToken = request.OpcRetryToken
            };
            using (var webResponse = await this.RestClientAsync.Post(uri, request.CreateVlanDetails, headers))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

                return new CreateVlanResponse()
                {
                    Vlan = JsonSerializer.Deserialize<VlanDetails>(response),
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Updates the specified CPE's display name or tags. Avoid entering confidential information.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<UpdateCpeResponse> UpdateCpe(UpdateCpeRequest request)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.CPE, this.Region)}/{request.CpeId}");

            using (var webResponse = await this.RestClientAsync.Put(uri, request.UpdateCpeDetails, new HttpRequestHeaderParam() { IfMatch = request.IfMatch }))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

                return new UpdateCpeResponse()
                {
                    Cpe = JsonSerializer.Deserialize<CpeDetails>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    ETag = webResponse.Headers.Get("etag")
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

            using (var webResponse = await this.RestClientAsync.Put(uri, updateRequest.UpdateVcnDetails, new HttpRequestHeaderParam() { IfMatch = updateRequest.IfMatch }))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

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

            using (var webResponse = await this.RestClientAsync.Put(uri, updateRequest.UpdateVnicDetails, new HttpRequestHeaderParam() { IfMatch = updateRequest.IfMatch }))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

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

            using (var webResponse = await this.RestClientAsync.Put(uri, updateRequest.UpdateInternetGatewayDetails, new HttpRequestHeaderParam() { IfMatch = updateRequest.IfMatch }))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

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
        /// <param name="updateRequest"></param>
        /// <returns></returns>
        public async Task<UpdateDhcpOptionsResponse> UpdateDhcpOptions(UpdateDhcpOptionsRequest updateRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.DHCP, this.Region)}/{updateRequest.DhcpId}");

            using (var webResponse = await this.RestClientAsync.Put(uri, updateRequest.UpdateDhcpDetails, new HttpRequestHeaderParam() { IfMatch = updateRequest.IfMatch }))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

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

            using (var webResponse = await this.RestClientAsync.Put(uri, updateRequest.UpdateSecurityListDetails, new HttpRequestHeaderParam() { IfMatch = updateRequest.IfMatch }))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

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
        /// <param name="updateRequest"></param>
        /// <returns></returns>
        public async Task<UpdateSubnetResponse> UpdateSubnet(UpdateSubnetRequest updateRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.Subnet, this.Region)}/{updateRequest.SubnetId}");

            using (var webResponse = await this.RestClientAsync.Put(uri, updateRequest.UpdateSubnetDetails, new HttpRequestHeaderParam() { IfMatch = updateRequest.IfMatch }))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

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

            using (var webResponse = await this.RestClientAsync.Put(uri, updateRequest.UpdateRouteTableDetails, new HttpRequestHeaderParam() { IfMatch = updateRequest.IfMatch }))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

                return new UpdateRouteTableResponse()
                {
                    RouteTable = JsonSerializer.Deserialize<RouteTable>(response),
                    ETag = webResponse.Headers.Get("etag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Updates the display name for the specified DrgAttachment. Avoid entering confidential information.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<UpdateDrgAttachmentResponse> UpdateDrgAttachment(UpdateDrgAttachmentRequest request)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.DRGAttachment, this.Region)}/{request.DrgAttachmentId}");

            using (var webResponse = await this.RestClientAsync.Put(uri, request.UpdateDrgAttachmentDetails, new HttpRequestHeaderParam() { IfMatch = request.IfMatch }))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

                return new UpdateDrgAttachmentResponse()
                {
                    DrgAttachment = JsonSerializer.Deserialize<DrgAttachment>(response),
                    ETag = webResponse.Headers.Get("etag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Updates the specified DRG's display name or tags. Avoid entering confidential information.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<UpdateDrgResponse> UpdateDrg(UpdateDrgRequest request)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.DRG, this.Region)}/{request.DrgId}");

            using (var webResponse = await this.RestClientAsync.Put(uri, request.UpdateDrgDetails, new HttpRequestHeaderParam() { IfMatch = request.IfMatch }))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

                return new UpdateDrgResponse()
                {
                    Drg = JsonSerializer.Deserialize<DrgDetails>(response),
                    ETag = webResponse.Headers.Get("etag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Updates the specified virtual circuit. This can be called by either the customer who owns the virtual circuit, or the provider 
        /// (when provisioning or de-provisioning the virtual circuit from their end). The documentation for UpdateVirtualCircuitDetails 
        /// indicates who can update each property of the virtual circuit.
        /// 
        /// Important: If the virtual circuit is working and in the PROVISIONED state, updating any of the network-related properties (such as 
        /// the DRG being used, the BGP ASN, and so on) will cause the virtual circuit's state to switch to PROVISIONING and the related BGP session 
        /// to go down. After Oracle re-provisions the virtual circuit, its state will return to PROVISIONED. Make sure you confirm that the associated 
        /// BGP session is back up. For more information about the various states and how to test connectivity, see FastConnect Overview.
        /// 
        /// To change the list of public IP prefixes for a public virtual circuit, use BulkAddVirtualCircuitPublicPrefixes and BulkDeleteVirtualCircuitPublicPrefixes. 
        /// Updating the list of prefixes does NOT cause the BGP session to go down. However, Oracle must verify the customer's ownership of each added prefix before 
        /// traffic for that prefix will flow across the virtual circuit.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<UpdateVirtualCircuitResponse> UpdateVirtualCircuit(UpdateVirtualCircuitRequest request)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.VirtualCircuit, this.Region)}/{request.VirtualCircuitId}");

            using (var webResponse = await this.RestClientAsync.Put(uri, request.UpdateVirtualCircuitDetails, new HttpRequestHeaderParam() { IfMatch = request.IfMatch }))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

                return new UpdateVirtualCircuitResponse()
                {
                    VirtualCircuit = JsonSerializer.Deserialize<VirtualCircuit>(response),
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Updates the specified NAT gateway.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<UpdateNatGatewayResponse> UpdateNatGateway(UpdateNatGatewayRequest request)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.NatGateway, this.Region)}/{request.NatGatewayId}");

            using (var webResponse = await this.RestClientAsync.Put(uri, request.UpdateNatGatewayDetails, new HttpRequestHeaderParam() { IfMatch = request.IfMatch }))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

                return new UpdateNatGatewayResponse()
                {
                    NatGateway = JsonSerializer.Deserialize<NatGateway>(response),
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Updates the specified VLAN. This could result in changes to all the VNICs in the VLAN, which can take time. During that transition period, the 
        /// VLAN will be in the UPDATING state.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<UpdateVlanResponse> UpdateVlan(UpdateVlanRequest request)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.Vlans, this.Region)}/{request.VlanId}");

            var headers = new HttpRequestHeaderParam()
            {
                IfMatch = request.IfMatch,
                OpcRequestId = request.OpcRequestId
            };
            using (var webResponse = await this.RestClientAsync.Put(uri, request.UpdateVlanDetails, headers))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

                return new UpdateVlanResponse()
                {
                    Vlan = JsonSerializer.Deserialize<VlanDetails>(response),
                    ETag = webResponse.Headers.Get("ETag"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Deletes the specified CPE object. The CPE must not be connected to a DRG. This is an asynchronous operation. The CPE's lifecycleState will change to 
        /// TERMINATING temporarily until the CPE is completely removed.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<DeleteCpeResponse> DeleteCpe(DeleteCpeRequest request)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.CPE, this.Region)}/{request.CpeId}");

            using (var webResponse = await this.RestClientAsync.Delete(uri, new HttpRequestHeaderParam() { IfMatch = request.IfMatch }))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

                return new DeleteCpeResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Deletes the specified VCN. The VCN must be empty and have no attached gateways.
        /// This is an asynchronous operation.
        /// The VCN's lifecycleState will change to TERMINATING temporarily until the VCN is completely removed.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<DeleteVcnResponse> DeleteVcn(DeleteVcnRequest request)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.VCN, this.Region)}/{request.VcnId}");

            using (var webResponse = await this.RestClientAsync.Delete(uri, new HttpRequestHeaderParam() { IfMatch = request.IfMatch }))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

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
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<DeleteInternetGatewayResponse> DeleteInternetGateway(DeleteInternetGatewayRequest request)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.InternetGateway, this.Region)}/{request.IgId}");

            using (var webResponse = await this.RestClientAsync.Delete(uri, new HttpRequestHeaderParam() { IfMatch = request.IfMatch }))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

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
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<DeleteDhcpOptionsResponse> DeleteDhcpOptions(DeleteDhcpOptionsRequest request)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.DHCP, this.Region)}/{request.DhcpId}");

            using (var webResponse = await this.RestClientAsync.Delete(uri, new HttpRequestHeaderParam() { IfMatch = request.IfMatch }))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

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
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<DeleteSecurityListResponse> DeleteSecurityList(DeleteSecurityListRequest request)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.SecurityList, this.Region)}/{request.SecurityListId}");

            using (var webResponse = await this.RestClientAsync.Delete(uri, new HttpRequestHeaderParam() { IfMatch = request.IfMatch }))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

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
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<DeleteSubnetResponse> DeleteSubnet(DeleteSubnetRequest request)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.Subnet, this.Region)}/{request.SubnetId}");

            using (var webResponse = await this.RestClientAsync.Delete(uri, new HttpRequestHeaderParam() { IfMatch = request.IfMatch }))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

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
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<DeleteRouteTableResponse> DeleteRouteTable(DeleteRouteTableRequest request)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.RouteTable, this.Region)}/{request.RtId}");

            using (var webResponse = await this.RestClientAsync.Delete(uri, new HttpRequestHeaderParam() { IfMatch = request.IfMatch }))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

                return new DeleteRouteTableResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Detaches a DRG from a VCN by deleting the corresponding DrgAttachment. This is an asynchronous operation. 
        /// The attachment's lifecycleState will change to DETACHING temporarily until the attachment is completely removed.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<DeleteDrgAttachmentResponse> DeleteDrgAttachment(DeleteDrgAttachmentRequest request)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.DRGAttachment, this.Region)}/{request.DrgAttachmentId}");

            using (var webResponse = await this.RestClientAsync.Delete(uri, new HttpRequestHeaderParam() { IfMatch = request.IfMatch }))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

                return new DeleteDrgAttachmentResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Deletes the specified virtual circuit.
        /// Important: If you're using FastConnect via a provider, make sure to also terminate the connection with the provider, or else the provider may continue to bill you.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<DeleteVirtualCircuitResponse> DeleteVirtualCircuit(DeleteVirtualCircuitRequest request)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.VirtualCircuit, this.Region)}/{request.VirtualCircuitId}");

            using (var webResponse = await this.RestClientAsync.Delete(uri, new HttpRequestHeaderParam() { IfMatch = request.IfMatch }))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

                return new DeleteVirtualCircuitResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Deletes the specified NAT gateway. The NAT gateway does not have to be disabled, but there must not be a route rule 
        /// that lists the NAT gateway as a target.
        /// 
        /// This is an asynchronous operation. The NAT gateway's lifecycleState will change to TERMINATING temporarily until 
        /// the NAT gateway is completely removed.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<DeleteNatGatewayResponse> DeleteNatGateway(DeleteNatGatewayRequest request)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.NatGateway, this.Region)}/{request.NatGatewayId}");

            using (var webResponse = await this.RestClientAsync.Delete(uri, new HttpRequestHeaderParam() { IfMatch = request.IfMatch }))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

                return new DeleteNatGatewayResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Deletes the specified VLAN, but only if there are no VNICs in the VLAN.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<DeleteVlanResponse> DeleteVlan(DeleteVlanRequest request)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.Vlans, this.Region)}/{request.VlanId}");

            var headers = new HttpRequestHeaderParam()
            {
                IfMatch = request.IfMatch,
                OpcRequestId = request.OpcRequestId
            };
            using (var webResponse = await RestClientAsync.Delete(uri, headers))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = await reader.ReadToEndAsync();

                return new DeleteVlanResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }
    }
}

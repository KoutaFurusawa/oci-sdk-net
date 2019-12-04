using System;
using System.Collections.Generic;
using System.IO;

using OCISDK.Core;
using OCISDK.Core.Common;
using OCISDK.Core.Core;
using OCISDK.Core.Core.Model.VirtualNetwork;
using OCISDK.Core.Core.Request.VirtualNetwork;
using OCISDK.Core.Core.Response.VirtualNetwork;

namespace OCISDK.Core
{
    /// <summary>
    /// VirtualNetworkClient
    /// </summary>
    public class VirtualNetworkClient : ServiceClient, IVirtualNetworkClient
    {
        /// <summary>
        /// Constructer
        /// </summary>
        public VirtualNetworkClient(ClientConfig config) : base(config)
        {
            ServiceName = "core";
        }

        /// <summary>
        /// Constructer
        /// </summary>
        public VirtualNetworkClient(ClientConfig config, OciSigner ociSigner) : base(config, ociSigner)
        {
            ServiceName = "core";
        }

        /// <summary>
        /// Constructer
        /// </summary>
        public VirtualNetworkClient(ClientConfigStream config) : base(config)
        {
            ServiceName = "core";
        }

        /// <summary>
        /// Constructer
        /// </summary>
        public VirtualNetworkClient(ClientConfigStream config, OciSigner ociSigner) : base(config, ociSigner)
        {
            ServiceName = "core";
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
            
            var webResponse = this.RestClient.Get(uri);

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
        public ListRouteTableResponse ListRouteTableOptions(ListRouteTableRequest listRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.RouteTable, this.Region)}?{listRequest.GetOptionQuery()}");
            
            var webResponse = this.RestClient.Get(uri);

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
        public ListInternetGatewaysResponse ListInternetGateways(ListInternetGatewaysRequest listRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.InternetGateway, this.Region)}?{listRequest.GetOptionQuery()}");
            
            var webResponse = this.RestClient.Get(uri);

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
        public ListSecurityListsResponse ListSecurityLists(ListSecurityListsRequest listRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.SecurityList, this.Region)}?{listRequest.GetOptionQuery()}");
            
            var webResponse = this.RestClient.Get(uri);

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
        /// Lists the DrgAttachment objects for the specified compartment. You can filter the results by VCN or DRG.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ListDrgAttachmentsResponse ListDrgAttachments(ListDrgAttachmentsRequest request)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.DRGAttachment, this.Region)}?{request.GetOptionQuery()}");

            var webResponse = this.RestClient.Get(uri);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

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
        public ListDrgsResponse ListDrgs(ListDrgsRequest request)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.DRG, this.Region)}?{request.GetOptionQuery()}");

            var webResponse = this.RestClient.Get(uri);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListDrgsResponse()
                {
                    Items = JsonSerializer.Deserialize<List<DrgDetails>>(response),
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
        public ListVcnResponse ListVcn(ListVcnRequest listRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.VCN, this.Region)}?{listRequest.GetOptionQuery()}");
            
            var webResponse = this.RestClient.Get(uri);

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
        public ListSubnetsResponse ListSubnets(ListSubnetsRequest listRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.Subnet, this.Region)}?{listRequest.GetOptionQuery()}");
            
            var webResponse = this.RestClient.Get(uri);

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
        /// Lists the virtual circuits in the specified compartment.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ListVirtualCircuitsResponse ListVirtualCircuits(ListVirtualCircuitsRequest request)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.VirtualCircuit, this.Region)}?{request.GetOptionQuery()}");

            var webResponse = this.RestClient.Get(uri);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

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
        public ListVirtualCircuitBandwidthShapesResponse ListVirtualCircuitBandwidthShapes(ListVirtualCircuitBandwidthShapesRequest request)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.VirtualCircuitBandwidthShape, this.Region)}?{request.GetOptionQuery()}");

            var webResponse = this.RestClient.Get(uri);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListVirtualCircuitBandwidthShapesResponse()
                {
                    Items = JsonSerializer.Deserialize<List<VirtualCircuitBandwidthShape>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
        }

        /// <summary>
        /// Gets the specified set of DHCP options.
        /// </summary>
        /// <param name="getDhcpRequest"></param>
        /// <returns></returns>
        public GetDhcpResponse GetDhcp(GetDhcpRequest getDhcpRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.DHCP, this.Region)}/{getDhcpRequest.DhcpId}");
            
            var webResponse = this.RestClient.Get(uri);

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
        public GetRouteTableResponse GetRouteTable(GetRouteTableRequest getRtRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.RouteTable, this.Region)}/{getRtRequest.RtId}");
            
            var webResponse = this.RestClient.Get(uri);

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
        public GetInternetGatewayResponse GetInternetGateway(GetInternetGatewayRequest getRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.InternetGateway, this.Region)}/{getRequest.IgId}");
            
            var webResponse = this.RestClient.Get(uri);

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
        public GetSecurityListRespons GetSecurityList(GetSecurityListRequest getSecurityListRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.SecurityList, this.Region)}/{getSecurityListRequest.SecurityListId}");
            
            var webResponse = this.RestClient.Get(uri);

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
        /// <param name="getVcnRequest"></param>
        /// <returns></returns>
        public GetVcnResponse GetVcn(GetVcnRequest getVcnRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.VCN, this.Region)}/{getVcnRequest.VcnId}");
            
            var webResponse = this.RestClient.Get(uri);

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
        public GetVnicResponse GetVnic(GetVnicRequest getVcnRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.VNIC, this.Region)}/{getVcnRequest.VnicId}");
            
            var webResponse = this.RestClient.Get(uri);

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
        public GetSubnetResponse GetSubnet(GetSubnetRequest getRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.Subnet, this.Region)}/{getRequest.SubnetId}");
            
            var webResponse = this.RestClient.Get(uri);

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
        /// Gets the information for the specified DrgAttachment.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public GetDrgAttachmentResponse GetDrgAttachment(GetDrgAttachmentRequest request)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.DRGAttachment, this.Region)}/{request.DrgAttachmentId}");

            var webResponse = this.RestClient.Get(uri);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

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
        public GetDrgResponse GetDrg(GetDrgRequest request)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.DRG, this.Region)}/{request.DrgId}");

            var webResponse = this.RestClient.Get(uri);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

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
        public GetVirtualCircuitResponse GetVirtualCircuit(GetVirtualCircuitRequest request)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.VirtualCircuit, this.Region)}/{request.VirtualCircuitId}");

            var webResponse = this.RestClient.Get(uri, new HttpRequestHeaderParam { IfMatch = request.IfMatch });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new GetVirtualCircuitResponse()
                {
                    VirtualCircuit = JsonSerializer.Deserialize<VirtualCircuit>(response),
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
        public ChangeVcnCompartmentResponse ChangeVcnCompartment(ChangeVcnCompartmentRequest param)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.VCN, this.Region)}/{param.VcnId}/actions/changeCompartment");

            var httpRequestHeaderParam = new HttpRequestHeaderParam() {
                OpcRetryToken = param.OpcRetryToken,
                OpcRequestId = param.OpcRequestId
            };
            var webResponse = this.RestClient.Post(uri, param.ChangeVcnCompartmentDetails, httpRequestHeaderParam);

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
        public ChangeSubnetCompartmentResponse ChangeSubnetCompartment(ChangeSubnetCompartmentRequest param)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.Subnet, this.Region)}/{param.SubnetId}/actions/changeCompartment");

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                OpcRetryToken = param.OpcRetryToken,
                OpcRequestId = param.OpcRequestId
            };
            var webResponse = this.RestClient.Post(uri, param.ChangeSubnetCompartmentDetails, httpRequestHeaderParam);

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
        public ChangeSecurityListCompartmentResponse ChangeSecurityListCompartment(ChangeSecurityListCompartmentRequest param)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.SecurityList, this.Region)}/{param.SecurityListId}/actions/changeCompartment");

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                OpcRetryToken = param.OpcRetryToken,
                OpcRequestId = param.OpcRequestId
            };
            var webResponse = this.RestClient.Post(uri, param.ChangeSecurityListCompartmentDetails, httpRequestHeaderParam);

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
        public ChangeRouteTableCompartmentResponse ChangeRouteTableCompartment(ChangeRouteTableCompartmentRequest param)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.RouteTable, this.Region)}/{param.RtId}/actions/changeCompartment");

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                OpcRetryToken = param.OpcRetryToken,
                OpcRequestId = param.OpcRequestId
            };
            var webResponse = this.RestClient.Post(uri, param.ChangeRouteTableCompartmentDetails, httpRequestHeaderParam);

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
        /// Moves a virtual circuit into a different compartment within the same tenancy. 
        /// For information about moving resources between compartments, see Moving Resources to a Different Compartment.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ChangeVirtualCircuitCompartmentResponse ChangeVirtualCircuitCompartment(ChangeVirtualCircuitCompartmentRequest request)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.VirtualCircuit, this.Region)}/{request.VirtualCircuitId}/actions/changeCompartment");

            var headers = new HttpRequestHeaderParam
            {
                OpcRequestId = request.OpcRequestId,
                OpcRetryToken = request.OpcRetryToken
            };
            var webResponse = this.RestClient.Post(uri, request.ChangeVirtualCircuitCompartmentDetails, headers);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ChangeVirtualCircuitCompartmentResponse()
                {
                    ETag = webResponse.Headers.Get("ETag"),
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
        public BulkAddVirtualCircuitPublicPrefixesResponse BulkAddVirtualCircuitPublicPrefixes(BulkAddVirtualCircuitPublicPrefixesRequest request)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.VirtualCircuit, this.Region)}/{request.VirtualCircuitId}/actions/bulkAddPublicPrefixes");
            
            var webResponse = this.RestClient.Post(uri, request.BulkAddVirtualCircuitPublicPrefixesDetails);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

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
        public BulkDeleteVirtualCircuitPublicPrefixesResponse BulkDeleteVirtualCircuitPublicPrefixes(BulkDeleteVirtualCircuitPublicPrefixesRequest request)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.VirtualCircuit, this.Region)}/{request.VirtualCircuitId}/actions/bulkDeletePublicPrefixes");

            var webResponse = this.RestClient.Post(uri, request.BulkDeleteVirtualCircuitPublicPrefixesDetails);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new BulkDeleteVirtualCircuitPublicPrefixesResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
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
            
            var webResponse = this.RestClient.Post(uri, createRequest.CreateInternetGatewayDetails, new HttpRequestHeaderParam() { OpcRetryToken= createRequest.OpcRetryToken });

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
        public CreateDhcpOptionsResponse CreateDhcpOptions(CreateDhcpOptionsRequest createRequest)
        {
            var uri = new Uri(GetEndPoint(CoreServices.DHCP, this.Region));
            
            var webResponse = this.RestClient.Post(uri, createRequest.CreateDhcpDetails, new HttpRequestHeaderParam() { OpcRetryToken = createRequest.OpcRetryToken });

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
        public CreateSecurityListResponse CreateSecurityList(CreateSecurityListRequest createRequest)
        {
            var uri = new Uri(GetEndPoint(CoreServices.SecurityList, this.Region));
            
            var webResponse = this.RestClient.Post(uri, createRequest.CreateSecurityListDetails, new HttpRequestHeaderParam() { OpcRetryToken = createRequest.OpcRetryToken });

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
        public CreateVcnResponse CreateVcn(CreateVcnRequest createRequest)
        {
            var uri = new Uri(GetEndPoint(CoreServices.VCN, this.Region));
            
            var webResponse = this.RestClient.Post(uri, createRequest.CreateVcnDetails, new HttpRequestHeaderParam() { OpcRetryToken = createRequest.OpcRetryToken });

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
        public CreateSubnetResponse CreateSubnet(CreateSubnetRequest createRequest)
        {
            var uri = new Uri(GetEndPoint(CoreServices.Subnet, this.Region));
            
            var webResponse = this.RestClient.Post(uri, createRequest.CreateSubnetDetails, new HttpRequestHeaderParam() { OpcRetryToken = createRequest.OpcRetryToken });

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
        public CreateRouteTableResponse CreateRouteTable(CreateRouteTableRequest createRequest)
        {
            var uri = new Uri(GetEndPoint(CoreServices.RouteTable, this.Region));

            var webResponse = this.RestClient.Post(uri, createRequest.CreateRouteTableDetails, new HttpRequestHeaderParam() { OpcRetryToken = createRequest.OpcRetryToken });

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
        public CreateDrgAttachmentResponse CreateDrgAttachment(CreateDrgAttachmentRequest request)
        {
            var uri = new Uri(GetEndPoint(CoreServices.DRGAttachment, this.Region));

            var webResponse = this.RestClient.Post(uri, request.CreateDrgAttachmentDetails, new HttpRequestHeaderParam() { OpcRetryToken = request.OpcRetryToken });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

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
        public CreateDrgResponse CreateDrg(CreateDrgRequest request)
        {
            var uri = new Uri(GetEndPoint(CoreServices.DRG, this.Region));

            var webResponse = this.RestClient.Post(uri, request.CreateDrgDetails, new HttpRequestHeaderParam() { OpcRetryToken = request.OpcRetryToken });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

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
        public CreateVirtualCircuitResponse CreateVirtualCircuit(CreateVirtualCircuitRequest request)
        {
            var uri = new Uri(GetEndPoint(CoreServices.VirtualCircuit, this.Region));

            var webResponse = this.RestClient.Post(uri, request.CreateVirtualCircuitDetails, new HttpRequestHeaderParam { OpcRetryToken = request.OpcRetryToken });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new CreateVirtualCircuitResponse()
                {
                    VirtualCircuit = JsonSerializer.Deserialize<VirtualCircuit>(response),
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
        public UpdateVcnResponse UpdateVcn(UpdateVcnRequest updateRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.VCN, this.Region)}/{updateRequest.VcnId}");
            
            var webResponse = this.RestClient.Put(uri, updateRequest.UpdateVcnDetails, new HttpRequestHeaderParam() { IfMatch = updateRequest.IfMatch });

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
        public UpdateVnicResponse UpdateVnic(UpdateVnicRequest updateRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.VNIC, this.Region)}/{updateRequest.VnicId}");
            
            var webResponse = this.RestClient.Put(uri, updateRequest.UpdateVnicDetails, new HttpRequestHeaderParam() { IfMatch = updateRequest.IfMatch });

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
        public UpdateInternetGatewayResponse UpdateInternetGateway(UpdateInternetGatewayRequest updateRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.InternetGateway, this.Region)}/{updateRequest.IgId}");
            
            var webResponse = this.RestClient.Put(uri, updateRequest.UpdateInternetGatewayDetails, new HttpRequestHeaderParam() { IfMatch = updateRequest.IfMatch });

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
        /// <param name="updateRequest"></param>
        /// <returns></returns>
        public UpdateDhcpOptionsResponse UpdateDhcpOptions(UpdateDhcpOptionsRequest updateRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.DHCP, this.Region)}/{updateRequest.DhcpId}");
            
            var webResponse = this.RestClient.Put(uri, updateRequest.UpdateDhcpDetails, new HttpRequestHeaderParam() { IfMatch = updateRequest.IfMatch });

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
        public UpdateSecurityListResponse UpdateSecurityList(UpdateSecurityListRequest updateRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.SecurityList, this.Region)}/{updateRequest.SecurityListId}");
            
            var webResponse = this.RestClient.Put(uri, updateRequest.UpdateSecurityListDetails, new HttpRequestHeaderParam() { IfMatch = updateRequest.IfMatch });

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
        /// <param name="updateRequest"></param>
        /// <returns></returns>
        public UpdateSubnetResponse UpdateSubnet(UpdateSubnetRequest updateRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.Subnet, this.Region)}/{updateRequest.SubnetId}");
            
            var webResponse = this.RestClient.Put(uri, updateRequest.UpdateSubnetDetails, new HttpRequestHeaderParam() { IfMatch = updateRequest.IfMatch });

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
        public UpdateRouteTableResponse UpdateRouteTable(UpdateRouteTableRequest updateRequest)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.RouteTable, this.Region)}/{updateRequest.RtId}");

            var webResponse = this.RestClient.Put(uri, updateRequest.UpdateRouteTableDetails, new HttpRequestHeaderParam() { IfMatch = updateRequest.IfMatch });

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
        /// Updates the display name for the specified DrgAttachment. Avoid entering confidential information.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public UpdateDrgAttachmentResponse UpdateDrgAttachment(UpdateDrgAttachmentRequest request)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.DRGAttachment, this.Region)}/{request.DrgAttachmentId}");

            var webResponse = this.RestClient.Put(uri, request.UpdateDrgAttachmentDetails, new HttpRequestHeaderParam() { IfMatch = request.IfMatch });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

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
        public UpdateDrgResponse UpdateDrg(UpdateDrgRequest request)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.DRG, this.Region)}/{request.DrgId}");

            var webResponse = this.RestClient.Put(uri, request.UpdateDrgDetails, new HttpRequestHeaderParam() { IfMatch = request.IfMatch });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

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
        public UpdateVirtualCircuitResponse UpdateVirtualCircuit(UpdateVirtualCircuitRequest request)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.VirtualCircuit, this.Region)}/{request.VirtualCircuitId}");

            var webResponse = this.RestClient.Put(uri, request.UpdateVirtualCircuitDetails, new HttpRequestHeaderParam() { IfMatch = request.IfMatch });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new UpdateVirtualCircuitResponse()
                {
                    VirtualCircuit = JsonSerializer.Deserialize<VirtualCircuit>(response),
                    ETag = webResponse.Headers.Get("ETag"),
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
        public DeleteVcnResponse DeleteVcn(DeleteVcnRequest request)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.VCN, this.Region)}/{request.VcnId}");
            
            var webResponse = this.RestClient.Delete(uri, new HttpRequestHeaderParam() { IfMatch = request.IfMatch });

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
        /// <param name="request"></param>
        /// <returns></returns>
        public DeleteInternetGatewayResponse DeleteInternetGateway(DeleteInternetGatewayRequest request)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.InternetGateway, this.Region)}/{request.IgId}");
            
            var webResponse = this.RestClient.Delete(uri, new HttpRequestHeaderParam() { IfMatch = request.IfMatch });

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
        /// <param name="request"></param>
        /// <returns></returns>
        public DeleteDhcpOptionsResponse DeleteDhcpOptions(DeleteDhcpOptionsRequest request)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.DHCP, this.Region)}/{request.DhcpId}");
            
            var webResponse = this.RestClient.Delete(uri, new HttpRequestHeaderParam() { IfMatch = request.IfMatch });

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
        /// <param name="request"></param>
        /// <returns></returns>
        public DeleteSecurityListResponse DeleteSecurityList(DeleteSecurityListRequest request)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.SecurityList, this.Region)}/{request.SecurityListId}");
            
            var webResponse = this.RestClient.Delete(uri, new HttpRequestHeaderParam() { IfMatch = request.IfMatch });

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
        /// <param name="request"></param>
        /// <returns></returns>
        public DeleteSubnetResponse DeleteSubnet(DeleteSubnetRequest request)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.Subnet, this.Region)}/{request.SubnetId}");
            
            var webResponse = this.RestClient.Delete(uri, new HttpRequestHeaderParam() { IfMatch = request.IfMatch });

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
        /// <param name="request"></param>
        /// <returns></returns>
        public DeleteRouteTableResponse DeleteRouteTable(DeleteRouteTableRequest request)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.RouteTable, this.Region)}/{request.RtId}");

            var webResponse = this.RestClient.Delete(uri, new HttpRequestHeaderParam() { IfMatch = request.IfMatch });

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

        /// <summary>
        /// Detaches a DRG from a VCN by deleting the corresponding DrgAttachment. This is an asynchronous operation. 
        /// The attachment's lifecycleState will change to DETACHING temporarily until the attachment is completely removed.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public DeleteDrgAttachmentResponse DeleteDrgAttachment(DeleteDrgAttachmentRequest request)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.DRGAttachment, this.Region)}/{request.DrgAttachmentId}");

            var webResponse = this.RestClient.Delete(uri, new HttpRequestHeaderParam() { IfMatch = request.IfMatch });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new DeleteDrgAttachmentResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Deletes the specified DRG. The DRG must not be attached to a VCN or be connected to your on-premise network. 
        /// Also, there must not be a route table that lists the DRG as a target. This is an asynchronous operation. 
        /// The DRG's lifecycleState will change to TERMINATING temporarily until the DRG is completely removed.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public DeleteDrgResponse DeleteDrg(DeleteDrgRequest request)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.DRG, this.Region)}/{request.DrgId}");

            var webResponse = this.RestClient.Delete(uri, new HttpRequestHeaderParam() { IfMatch = request.IfMatch });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new DeleteDrgResponse()
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
        public DeleteVirtualCircuitResponse DeleteVirtualCircuit(DeleteVirtualCircuitRequest request)
        {
            var uri = new Uri($"{GetEndPoint(CoreServices.VirtualCircuit, this.Region)}/{request.VirtualCircuitId}");

            var webResponse = this.RestClient.Delete(uri, new HttpRequestHeaderParam() { IfMatch = request.IfMatch });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new DeleteVirtualCircuitResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }
    }
}

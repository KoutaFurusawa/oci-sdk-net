using OCISDK.Core.Core.Request.VirtualNetwork;
using OCISDK.Core.Core.Response.VirtualNetwork;

namespace OCISDK.Core.Core
{
    /// <summary>
    /// VirtualNetwork Client interface
    /// </summary>
    public interface IVirtualNetworkClient : IClientSetting
    {
        /// <summary>
        /// Lists the sets of DHCP options in the specified VCN and specified compartment.
        /// The response includes the default set of options that automatically comes with each VCN,
        /// plus any other sets you've created.
        /// </summary>
        /// <param name="listRequest"></param>
        /// <returns></returns>
        ListDhcpResponse ListDhcpOptions(ListDhcpOptionsRequest listRequest);

        /// <summary>
        /// Lists the route tables in the specified VCN and specified compartment.
        /// The response includes the default route table that automatically comes with each VCN, 
        /// plus any route tables you've created.
        /// </summary>
        /// <param name="listRequest"></param>
        /// <returns></returns>
        ListRouteTableResponse ListRouteTableOptions(ListRouteTableRequest listRequest);

        /// <summary>
        /// Lists the internet gateways in the specified VCN and the specified compartment.
        /// </summary>
        /// <param name="listRequest"></param>
        /// <returns></returns>
        ListInternetGatewaysResponse ListInternetGateways(ListInternetGatewaysRequest listRequest);

        /// <summary>
        /// Lists the virtual cloud networks (VCNs) in the specified compartment.
        /// </summary>
        /// <param name="listRequest"></param>
        /// <returns></returns>
        ListVcnResponse ListVcn(ListVcnRequest listRequest);

        /// <summary>
        /// Lists the subnets in the specified VCN and the specified compartment.
        /// </summary>
        /// <param name="listRequest"></param>
        /// <returns></returns>
        ListSubnetsResponse ListSubnets(ListSubnetsRequest listRequest);
        
        /// <summary>
        /// Lists the security lists in the specified VCN and compartment.
        /// </summary>
        /// <param name="listRequest"></param>
        /// <returns></returns>
        ListSecurityListsResponse ListSecurityLists(ListSecurityListsRequest listRequest);

        /// <summary>
        /// Lists the DrgAttachment objects for the specified compartment. You can filter the results by VCN or DRG.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ListDrgAttachmentsResponse ListDrgAttachments(ListDrgAttachmentsRequest request);

        /// <summary>
        /// Lists the DRGs in the specified compartment.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ListDrgsResponse ListDrgs(ListDrgsRequest request);

        /// <summary>
        /// Lists the virtual circuits in the specified compartment.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ListVirtualCircuitsResponse ListVirtualCircuits(ListVirtualCircuitsRequest request);

        /// <summary>
        /// The deprecated operation lists available bandwidth levels for virtual circuits. For the compartment ID, provide the OCID of your tenancy (the root compartment).
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ListVirtualCircuitBandwidthShapesResponse ListVirtualCircuitBandwidthShapes(ListVirtualCircuitBandwidthShapesRequest request);

        /// <summary>
        /// Gets the specified set of DHCP options.
        /// </summary>
        /// <param name="getDhcpRequest"></param>
        /// <returns></returns>
        GetDhcpResponse GetDhcp(GetDhcpRequest getDhcpRequest);

        /// <summary>
        /// Gets the specified route table's information.
        /// </summary>
        /// <param name="getRtRequest"></param>
        /// <returns></returns>
        GetRouteTableResponse GetRouteTable(GetRouteTableRequest getRtRequest);

        /// <summary>
        /// Gets the specified internet gateway's information.
        /// </summary>
        /// <param name="getRequest"></param>
        /// <returns></returns>
        GetInternetGatewayResponse GetInternetGateway(GetInternetGatewayRequest getRequest);

        /// <summary>
        /// Gets the specified security list's information.
        /// </summary>
        /// <param name="getSecurityListRequest"></param>
        /// <returns></returns>
        GetSecurityListRespons GetSecurityList(GetSecurityListRequest getSecurityListRequest);

        /// <summary>
        /// Gets the specified VCN's information.
        /// </summary>
        /// <param name="getVcnRequest"></param>
        /// <returns></returns>
        GetVcnResponse GetVcn(GetVcnRequest getVcnRequest);

        /// <summary>
        /// Gets the information for the specified virtual network interface card (VNIC).
        /// You can get the VNIC OCID from the ListVnicAttachments operation.
        /// </summary>
        /// <param name="getRequest"></param>
        /// <returns></returns>
        GetVnicResponse GetVnic(GetVnicRequest getRequest);

        /// <summary>
        /// Gets the specified subnet's information.
        /// </summary>
        /// <param name="getRequest"></param>
        /// <returns></returns>
        GetSubnetResponse GetSubnet(GetSubnetRequest getRequest);

        /// <summary>
        /// Gets the information for the specified DrgAttachment.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        GetDrgAttachmentResponse GetDrgAttachment(GetDrgAttachmentRequest request);

        /// <summary>
        /// Gets the specified DRG's information.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        GetDrgResponse GetDrg(GetDrgRequest request);

        /// <summary>
        /// Gets the specified virtual circuit's information.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        GetVirtualCircuitResponse GetVirtualCircuit(GetVirtualCircuitRequest request);

        /// <summary>
        /// Moves a VCN into a different compartment within the same tenancy. 
        /// For information about moving resources between compartments, see Moving Resources to a Different Compartment.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        ChangeVcnCompartmentResponse ChangeVcnCompartment(ChangeVcnCompartmentRequest param);

        /// <summary>
        /// Moves a subnet into a different compartment within the same tenancy. 
        /// For information about moving resources between compartments, see Moving Resources to a Different Compartment.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        ChangeSubnetCompartmentResponse ChangeSubnetCompartment(ChangeSubnetCompartmentRequest param);

        /// <summary>
        /// Moves a security list into a different compartment within the same tenancy. 
        /// For information about moving resources between compartments, see Moving Resources to a Different Compartment.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        ChangeSecurityListCompartmentResponse ChangeSecurityListCompartment(ChangeSecurityListCompartmentRequest param);

        /// <summary>
        /// Moves a route table into a different compartment within the same tenancy. 
        /// For information about moving resources between compartments, see Moving Resources to a Different Compartment.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        ChangeRouteTableCompartmentResponse ChangeRouteTableCompartment(ChangeRouteTableCompartmentRequest param);

        /// <summary>
        /// Moves a virtual circuit into a different compartment within the same tenancy. 
        /// For information about moving resources between compartments, see Moving Resources to a Different Compartment.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ChangeVirtualCircuitCompartmentResponse ChangeVirtualCircuitCompartment(ChangeVirtualCircuitCompartmentRequest request);

        /// <summary>
        /// Adds one or more customer public IP prefixes to the specified public virtual circuit. Use this operation 
        /// (and not UpdateVirtualCircuit) to add prefixes to the virtual circuit. Oracle must verify the customer's ownership 
        /// of each prefix before traffic for that prefix will flow across the virtual circuit.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        BulkAddVirtualCircuitPublicPrefixesResponse BulkAddVirtualCircuitPublicPrefixes(BulkAddVirtualCircuitPublicPrefixesRequest request);

        /// <summary>
        /// Removes one or more customer public IP prefixes from the specified public virtual circuit. Use this operation (and not UpdateVirtualCircuit) 
        /// to remove prefixes from the virtual circuit. When the virtual circuit's state switches back to PROVISIONED, Oracle stops advertising 
        /// the specified prefixes across the connection.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        BulkDeleteVirtualCircuitPublicPrefixesResponse BulkDeleteVirtualCircuitPublicPrefixes(BulkDeleteVirtualCircuitPublicPrefixesRequest request);

        /// <summary>
        /// Creates a new internet gateway for the specified VCN. For more information, see Access to the Internet.
        /// </summary>
        /// <param name="createRequest"></param>
        /// <returns></returns>
        CreateInternetGatewayResponse CreateInternetGateway(CreateInternetGatewayRequest createRequest);

        /// <summary>
        /// Creates a new set of DHCP options for the specified VCN. For more information, see DhcpOptions.
        /// </summary>
        /// <param name="createRequest"></param>
        /// <returns></returns>
        CreateDhcpOptionsResponse CreateDhcpOptions(CreateDhcpOptionsRequest createRequest);

        /// <summary>
        /// Creates a new security list for the specified VCN. 
        /// For more information about security lists, see Security Lists. 
        /// For information on the number of rules you can have in a security list, see Service Limits.
        /// </summary>
        /// <param name="createRequest"></param>
        /// <returns></returns>
        CreateSecurityListResponse CreateSecurityList(CreateSecurityListRequest createRequest);

        /// <summary>
        /// Creates a new virtual cloud network (VCN). For more information, see VCNs and Subnets.
        /// </summary>
        /// <param name="createRequest">create VCN Request parameter</param>
        /// <returns></returns>
        CreateVcnResponse CreateVcn(CreateVcnRequest createRequest);

        /// <summary>
        /// Creates a new subnet in the specified VCN. You can't change the size of the subnet after creation,
        /// so it's important to think about the size of subnets you need before creating them. For more 
        /// information, see VCNs and Subnets. For information on the number of subnets you can have in a 
        /// VCN, see Service Limits.
        /// </summary>
        /// <param name="createRequest"></param>
        /// <returns></returns>
        CreateSubnetResponse CreateSubnet(CreateSubnetRequest createRequest);

        /// <summary>
        /// Creates a new route table for the specified VCN. In the request you must also include at least one route rule for the new route table. 
        /// For information on the number of rules you can have in a route table, see Service Limits. 
        /// For general information about route tables in your VCN and the types of targets you can use in route rules, see Route Tables.
        /// </summary>
        /// <param name="createRequest"></param>
        /// <returns></returns>
        CreateRouteTableResponse CreateRouteTable(CreateRouteTableRequest createRequest);

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
        CreateDrgAttachmentResponse CreateDrgAttachment(CreateDrgAttachmentRequest request);

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
        CreateDrgResponse CreateDrg(CreateDrgRequest request);

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
        CreateVirtualCircuitResponse CreateVirtualCircuit(CreateVirtualCircuitRequest request);

        /// <summary>
        /// Updates the specified VCN.
        /// </summary>
        /// <param name="updateRequest"></param>
        /// <returns></returns>
        UpdateVcnResponse UpdateVcn(UpdateVcnRequest updateRequest);

        /// <summary>
        /// Updates the specified VNIC.
        /// </summary>
        /// <param name="updateRequest"></param>
        /// <returns></returns>
        UpdateVnicResponse UpdateVnic(UpdateVnicRequest updateRequest);

        /// <summary>
        /// Updates the specified internet gateway.
        /// You can disable/enable it, or change its display name or tags.
        /// Avoid entering confidential information.
        /// </summary>
        /// <param name="updateRequest"></param>
        /// <returns></returns>
        UpdateInternetGatewayResponse UpdateInternetGateway(UpdateInternetGatewayRequest updateRequest);

        /// <summary>
        /// Updates the specified set of DHCP options. 
        /// You can update the display name or the options themselves. Avoid entering confidential information.
        /// </summary>
        /// <param name="updateRequest"></param>
        /// <returns></returns>
        UpdateDhcpOptionsResponse UpdateDhcpOptions(UpdateDhcpOptionsRequest updateRequest);

        /// <summary>
        /// Updates the specified security list's display name or rules. Avoid entering confidential information.
        /// </summary>
        /// <param name="updateRequest"></param>
        /// <returns></returns>
        UpdateSecurityListResponse UpdateSecurityList(UpdateSecurityListRequest updateRequest);

        /// <summary>
        /// Updates the specified subnet.
        /// </summary>
        /// <param name="updateRequest"></param>
        /// <returns></returns>
        UpdateSubnetResponse UpdateSubnet(UpdateSubnetRequest updateRequest);

        /// <summary>
        /// Updates the specified route table's display name or route rules. Avoid entering confidential information.
        /// Note that the routeRules object you provide replaces the entire existing set of rules.
        /// </summary>
        /// <param name="updateRequest"></param>
        /// <returns></returns>
        UpdateRouteTableResponse UpdateRouteTable(UpdateRouteTableRequest updateRequest);

        /// <summary>
        /// Updates the display name for the specified DrgAttachment. Avoid entering confidential information.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        UpdateDrgAttachmentResponse UpdateDrgAttachment(UpdateDrgAttachmentRequest request);

        /// <summary>
        /// Updates the specified DRG's display name or tags. Avoid entering confidential information.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        UpdateDrgResponse UpdateDrg(UpdateDrgRequest request);

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
        UpdateVirtualCircuitResponse UpdateVirtualCircuit(UpdateVirtualCircuitRequest request);

        /// <summary>
        /// Deletes the specified VCN. The VCN must be empty and have no attached gateways.
        /// This is an asynchronous operation.
        /// The VCN's lifecycleState will change to TERMINATING temporarily until the VCN is completely removed.
        /// </summary>
        /// <param name="deleteRequest"></param>
        /// <returns></returns>
        DeleteVcnResponse DeleteVcn(DeleteVcnRequest deleteRequest);

        /// <summary>
        /// Deletes the specified internet gateway.
        /// The internet gateway does not have to be disabled, but there must not be a route table that lists it as a target.
        /// </summary>
        /// <param name="deleteRequest"></param>
        /// <returns></returns>
        DeleteInternetGatewayResponse DeleteInternetGateway(DeleteInternetGatewayRequest deleteRequest);

        /// <summary>
        /// Deletes the specified set of DHCP options, but only if it's not associated with a subnet.
        /// You can't delete a VCN's default set of DHCP options.
        /// </summary>
        /// <param name="deleteRequest"></param>
        /// <returns></returns>
        DeleteDhcpOptionsResponse DeleteDhcpOptions(DeleteDhcpOptionsRequest deleteRequest);

        /// <summary>
        /// Deletes the specified security list, but only if it's not associated with a subnet.
        /// You can't delete a VCN's default security list.
        /// </summary>
        /// <param name="deleteRequest"></param>
        /// <returns></returns>
        DeleteSecurityListResponse DeleteSecurityList(DeleteSecurityListRequest deleteRequest);

        /// <summary>
        /// Deletes the specified subnet, but only if there are no instances in the subnet. 
        /// This is an asynchronous operation. The subnet's lifecycleState will change to TERMINATING 
        /// temporarily. If there are any instances in the subnet, the state will instead change back 
        /// to AVAILABLE.
        /// </summary>
        /// <param name="deleteRequest"></param>
        /// <returns></returns>
        DeleteSubnetResponse DeleteSubnet(DeleteSubnetRequest deleteRequest);

        /// <summary>
        /// Deletes the specified route table, but only if it's not associated with a subnet. You can't delete a VCN's default route table.
        /// This is an asynchronous operation. The route table's lifecycleState will change to TERMINATING temporarily until the route table is completely removed.
        /// </summary>
        /// <param name="deleteRequest"></param>
        /// <returns></returns>
        DeleteRouteTableResponse DeleteRouteTable(DeleteRouteTableRequest deleteRequest);

        /// <summary>
        /// Detaches a DRG from a VCN by deleting the corresponding DrgAttachment. This is an asynchronous operation. 
        /// The attachment's lifecycleState will change to DETACHING temporarily until the attachment is completely removed.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        DeleteDrgAttachmentResponse DeleteDrgAttachment(DeleteDrgAttachmentRequest request);

        /// <summary>
        /// Deletes the specified DRG. The DRG must not be attached to a VCN or be connected to your on-premise network. 
        /// Also, there must not be a route table that lists the DRG as a target. This is an asynchronous operation. 
        /// The DRG's lifecycleState will change to TERMINATING temporarily until the DRG is completely removed.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        DeleteDrgResponse DeleteDrg(DeleteDrgRequest request);

        /// <summary>
        /// Deletes the specified virtual circuit.
        /// Important: If you're using FastConnect via a provider, make sure to also terminate the connection with the provider, or else the provider may continue to bill you.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        DeleteVirtualCircuitResponse DeleteVirtualCircuit(DeleteVirtualCircuitRequest request);
    }
}

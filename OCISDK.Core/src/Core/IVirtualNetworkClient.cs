using OCISDK.Core.src.Core.Request.VirtualNetwork;
using OCISDK.Core.src.Core.Response.VirtualNetwork;

namespace OCISDK.Core.src.Core
{
    public interface IVirtualNetworkClient
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
        /// Gets the specified set of DHCP options.
        /// </summary>
        /// <param name="getRequest"></param>
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
        /// <param name="getRequest"></param>
        /// <returns></returns>
        GetVcnResponse GetVcn(GetVcnRequest getVcnRequest);

        /// <summary>
        /// Gets the information for the specified virtual network interface card (VNIC).
        /// You can get the VNIC OCID from the ListVnicAttachments operation.
        /// </summary>
        /// <param name="getVcnRequest"></param>
        /// <returns></returns>
        GetVnicResponse GetVnic(GetVnicRequest getRequest);

        /// <summary>
        /// Gets the specified subnet's information.
        /// </summary>
        /// <param name="getRequest"></param>
        /// <returns></returns>
        GetSubnetResponse GetSubnet(GetSubnetRequest getRequest);

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
        /// <param name="request"></param>
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
        /// <param name="request"></param>
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

    }
}

using OCISDK.Core;
using OCISDK.Core.Common;
using OCISDK.Core.Core.Model.VirtualNetwork;
using OCISDK.Core.Core.Request.VirtualNetwork;
using OCISDK.Core.Identity;
using OCISDK.Core.Identity.Request;
using System;

namespace Example
{
    class CoreVirtualNetworkExample
    {
        public static void VirtualNetworkExample(ClientConfig config)
        {
            Console.WriteLine();
            Console.WriteLine("VertualNetwork Example Menu");
            Console.WriteLine("[1]: Display List");
            Console.WriteLine("[2]: Create new VCN");
            Console.WriteLine("[ESC] or [E(e)] : Back Example Menu");
            Console.WriteLine();

            var presskey = Console.ReadKey(true);
            if (presskey.Key == ConsoleKey.Escape || presskey.KeyChar == 'E' || presskey.KeyChar == 'e')
            {
                Console.WriteLine("Back Example Menu");
                return;
            }
            var select = presskey.KeyChar;
            if (!int.TryParse(select.ToString(), out int mode))
            {
                Console.WriteLine("Incorrect input...");
                return;
            }
            
            if (mode == 1)
            {
                VirtualNetworkConsoleDisplay(config);
            }
            else if(mode == 2)
            {
                CreateVirtualNetwork(config);
            }
            else
            {
                Console.WriteLine("Incorrect input...");
                return;
            }
        }

        private static void VirtualNetworkConsoleDisplay(ClientConfig config)
        {
            // create client
            VirtualNetworkClient client = new VirtualNetworkClient(config)
            {
                Region = Regions.US_ASHBURN_1
            };

            Console.WriteLine("* List VCN------------------------");
            var listVcnRequest = new ListVcnRequest()
            {
                // target compartment is root compartment(tenancy)
                CompartmentId = config.TenancyId,
                Limit = 50,
                SortOrder = SortOrder.ASC
            };
            // get vcns
            var listVcn = client.ListVcn(listVcnRequest);
            listVcn.Items.ForEach(vcn =>
            {
                Console.WriteLine(" |-" + vcn.DisplayName);
                Console.WriteLine(" | " + vcn.Id);

                // get dhcps in vcn
                var listDhcpRequest = new ListDhcpOptionsRequest()
                {
                    // target is same compartment and VCN
                    CompartmentId = vcn.CompartmentId,
                    VcnId = vcn.Id,
                    Limit = 50,
                    SortOrder = SortOrder.ASC
                };
                var listDhcp = client.ListDhcpOptions(listDhcpRequest);
                listDhcp.Items.ForEach(dhcp =>
                {
                    Console.WriteLine(" |\t|- * DHCP");
                    Console.WriteLine(" |\t|\t" + dhcp.DisplayName);
                    Console.WriteLine(" |\t|\t" + dhcp.Id);

                });

                // get RouteTable in vcn
                var listRouteTableRequest = new ListRouteTableRequest()
                {
                    // target is same compartment and VCN
                    CompartmentId = vcn.CompartmentId,
                    VcnId = vcn.Id,
                    Limit = 50,
                    SortOrder = SortOrder.ASC
                };
                var listRouteTable = client.ListRouteTableOptions(listRouteTableRequest);
                listRouteTable.Items.ForEach(rt =>
                {
                    Console.WriteLine(" |\t|- * RouteTable");
                    Console.WriteLine(" |\t|\t" + rt.DisplayName);
                    Console.WriteLine(" |\t|\t" + rt.Id);

                    // RouteRules
                    rt.RouteRules.ForEach(rr =>
                    {
                        if (!string.IsNullOrEmpty(rr.DestinationType))
                        {
                            Console.WriteLine(" |\t|\t|- DestinationType:" + rr.DestinationType);
                        }
                        if (!string.IsNullOrEmpty(rr.CidrBlock))
                        {
                            Console.WriteLine(" |\t|\t|\tCidrBlock:" + rr.CidrBlock);
                        }
                        if (!string.IsNullOrEmpty(rr.Destination))
                        {
                            Console.WriteLine(" |\t|\t|\tDestination:" + rr.Destination);
                        }
                        if (!string.IsNullOrEmpty(rr.NetworkEntityId))
                        {
                            Console.WriteLine(" |\t|\t|\tNetworkEntityId:" + rr.NetworkEntityId);
                        }
                    });
                });

                // get RouteTable in vcn
                var listSecurityListRequest = new ListSecurityListsRequest()
                {
                    // target is same compartment and VCN
                    CompartmentId = vcn.CompartmentId,
                    VcnId = vcn.Id,
                    Limit = 50,
                    SortOrder = SortOrder.ASC
                };
                var listSecurityList = client.ListSecurityLists(listSecurityListRequest);
                listSecurityList.Items.ForEach(sl =>
                {
                    Console.WriteLine(" |\t|- * SecurityList");
                    Console.WriteLine(" |\t|\t" + sl.DisplayName);
                    Console.WriteLine(" |\t|\t" + sl.Id);
                    Console.WriteLine(" |\t|\t" + sl.LifecycleState);
                });

                // get Subnet in vcn
                var listSubnetRequest = new ListSubnetsRequest()
                {
                    // target is same compartment and VCN
                    CompartmentId = vcn.CompartmentId,
                    VcnId = vcn.Id,
                    Limit = 50,
                    SortOrder = SortOrder.ASC
                };
                var listSubnet = client.ListSubnets(listSubnetRequest);
                listSubnet.Items.ForEach(sl =>
                {
                    Console.WriteLine(" |\t|- * Subnet");
                    Console.WriteLine(" |\t|\t" + sl.DisplayName);
                    Console.WriteLine(" |\t|\t" + sl.Id);
                    Console.WriteLine(" |\t|\t" + sl.LifecycleState);
                });

                // get InternetGateway in vcn
                var listIGRequest = new ListInternetGatewaysRequest()
                {
                    // target is same compartment and VCN
                    CompartmentId = vcn.CompartmentId,
                    VcnId = vcn.Id,
                    Limit = 50,
                    SortOrder = SortOrder.ASC
                };
                var listIG = client.ListInternetGateways(listIGRequest);
                listDhcp.Items.ForEach(ig =>
                {
                    Console.WriteLine(" |\t|- * InternetGateway");
                    Console.WriteLine(" |\t|\t" + ig.DisplayName);
                    Console.WriteLine(" |\t|\t" + ig.Id);
                });
            });
            
            Console.WriteLine("* List DRG------------------------");

            var identityClient = new IdentityClient(config)
            {
                Region = Regions.US_ASHBURN_1
            };

            var listCompartmentRequest = new ListCompartmentRequest()
            {
                CompartmentId = config.TenancyId,
                CompartmentIdInSubtree = true,
                AccessLevel = ListCompartmentRequest.AccessLevels.ACCESSIBLE
            };
            var compartments = identityClient.ListCompartment(listCompartmentRequest).Items;

            foreach (var com in compartments)
            {
                var listDrgsRequest = new ListDrgsRequest() {
                    CompartmentId = com.Id
                };
                var drgs = client.ListDrgs(listDrgsRequest).Items;
                foreach (var drg in drgs)
                {
                    Console.WriteLine($" |-name: {drg.DisplayName}");
                    Console.WriteLine($" | state: {drg.LifecycleState}");
                    Console.WriteLine($" | timeCreate: {drg.TimeCreated}");
                    Console.WriteLine($" | compartment: {com.Name}");
                }
            }
        }
        
        private static void CreateVirtualNetwork(ClientConfig config)
        {
            // warning
            Console.WriteLine("Continuing this example, a new VCN will be created. The compartments are root fixed.");

            Console.Write("Are you sure you want to continue? (Y/N)");
            
            var presskey = Console.ReadKey();
            if (presskey.KeyChar != 'Y' && presskey.KeyChar != 'y')
            {
                Console.WriteLine("Exit CreateVirtualNetworkExample");
                return;
            }
            Console.WriteLine();

            // create client
            VirtualNetworkClient client = new VirtualNetworkClient(config)
            {
                Region = Regions.US_ASHBURN_1
            };

            // input VCN details
            var createVcnDetails = new CreateVcnDetails();

            Console.WriteLine("Create new VertualCloudNetwork(VCN)");
            Console.Write("VCN name: ");
            createVcnDetails.DisplayName = Console.ReadLine();
            Console.Write("CidrBlock: ");
            createVcnDetails.CidrBlock = Console.ReadLine();

            createVcnDetails.CompartmentId = config.TenancyId;

            var createVcnRequest = new CreateVcnRequest()
            {
                CreateVcnDetails = createVcnDetails
            };

            var newVCNRes = client.CreateVcn(createVcnRequest);
            var newVCN = newVCNRes.Vcn;
            Console.WriteLine("* Create new VCN--------------------------");
            Console.WriteLine(" name: " + newVCN.DisplayName);
            Console.WriteLine(" id: " + newVCN.Id);
            Console.WriteLine(" DNSlabel: " + newVCN.DnsLabel);
            Console.WriteLine(" domainName: " + newVCN.VcnDomainName);
            Console.WriteLine(" timeCreate: " + newVCN.TimeCreated);

            //get created default DHCP
            Console.WriteLine(" DefaultDHCP: ");
            Console.WriteLine("\t| id: " + newVCN.DefaultSecurityListId);
            var getDhcpRequest = new GetDhcpRequest()
            {
                DhcpId = newVCN.DefaultDhcpOptionsId
            };
            var defaultDHCP = client.GetDhcp(getDhcpRequest).DhcpOptions;
            Console.WriteLine("\t| name: " + defaultDHCP.DisplayName);
            Console.WriteLine("\t| id: " + defaultDHCP.Id);
            Console.WriteLine("\t| state: " + defaultDHCP.LifecycleState);
            Console.WriteLine("\t| timeCreate: " + defaultDHCP.TimeCreated);

            // get created default seculityList
            Console.WriteLine(" DefaultSeculityList: ");
            Console.WriteLine("\t| id: " + newVCN.DefaultSecurityListId);
            var getSecurityListRequest = new GetSecurityListRequest()
            {
                SecurityListId = newVCN.DefaultSecurityListId
            };
            var defaultSL = client.GetSecurityList(getSecurityListRequest).SecurityList;
            Console.WriteLine("\t| name: " + defaultSL.DisplayName);
            Console.WriteLine("\t| id: " + defaultSL.Id);
            Console.WriteLine("\t| state: " + defaultSL.LifecycleState);
            Console.WriteLine("\t| timeCreate: " + defaultSL.TimeCreated);

            // get craeted default 
            Console.WriteLine(" DefaultRouteTableId: ");
            Console.WriteLine("\t| id: " + newVCN.DefaultRouteTableId);
            var getRouteTableIdRequest = new GetRouteTableRequest()
            {
                RtId = newVCN.DefaultRouteTableId
            };
            var defaultRT = client.GetRouteTable(getRouteTableIdRequest).RouteTable;
            Console.WriteLine("\t| name: " + defaultRT.DisplayName);
            Console.WriteLine("\t| id: " + defaultRT.Id);
            Console.WriteLine("\t| state: " + defaultRT.LifecycleState);
            Console.WriteLine("\t| timeCreate: " + defaultRT.TimeCreated);
            
        }
    }
}

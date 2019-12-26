﻿using OCISDK.Core.Core.Request.ComputeManagement;
using OCISDK.Core.Core.Response.ComputeManagement;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core
{
    /// <summary>
    /// ComputeManagement client
    /// </summary>
    public interface IComputeManagementClient : IClientSetting
    {
        /// <summary>
        /// Moves a cluster network into a different compartment within the same tenancy. For information about 
        /// moving resources between compartments, see Moving Resources to a Different Compartment.
        /// 
        /// When you move a cluster network to a different compartment, associated resources such as the instances 
        /// in the cluster network, boot volumes, and VNICs are not moved.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ChangeClusterNetworkCompartmentResponse ChangeClusterNetworkCompartment(ChangeClusterNetworkCompartmentRequest request);

        /// <summary>
        /// Creates a cluster network. For more information about cluster networks, see Managing Cluster Networks.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        CreateClusterNetworkResponse CreateClusterNetwork(CreateClusterNetworkRequest request);

        /// <summary>
        /// Updates the specified cluster network. The OCID of the cluster network remains the same.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        UpdateClusterNetworkResponse UpdateClusterNetwork(UpdateClusterNetworkRequest request);

        /// <summary>
        /// Gets information about the specified cluster network.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        GetClusterNetworkResponse GetClusterNetwork(GetClusterNetworkRequest request);

        /// <summary>
        /// Lists the cluster networks in the specified compartment.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ListClusterNetworksResponse ListClusterNetworks(ListClusterNetworksRequest request);

        /// <summary>
        /// Lists the instances in the specified cluster network.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ListClusterNetworkInstancesResponse ListClusterNetworkInstances(ListClusterNetworkInstancesRequest request);

        /// <summary>
        /// Terminates the specified cluster network.
        /// 
        /// When you delete a cluster network, all of its resources are permanently deleted, including associated instances and instance pools.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        TerminateClusterNetworkResponse TerminateClusterNetwork(TerminateClusterNetworkRequest request);
    }
}

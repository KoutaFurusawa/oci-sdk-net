using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Model.ComputeManagement
{
    /// <summary>
    /// The configuration details for the move operation.
    /// </summary>
    public class ChangeClusterNetworkCompartmentDetails
    {
        /// <summary>
        /// The OCID of the compartment into which the resource should be moved.
        /// <para></para>
        /// </summary>
        public string CompartmentId { get; set; }
    }
}

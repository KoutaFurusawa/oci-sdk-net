using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Model.VirtualNetwork
{
    /// <summary>
    /// The configuration details for the move operation.
    /// </summary>
    public class ChangeCpeCompartmentDetails
    {
        /// <summary>
        /// The OCID of the compartment to move the CPE object to.
        /// <para>Required: yes</para>
        /// </summary>
        public string CompartmentId { get; set; }
    }
}

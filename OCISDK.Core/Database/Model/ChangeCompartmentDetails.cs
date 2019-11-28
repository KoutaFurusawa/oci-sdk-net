using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Database.Model
{
    /// <summary>
    /// The configuration details for moving the resource.
    /// </summary>
    public class ChangeCompartmentDetails
    {
        /// <summary>
        /// The OCID of the compartment to move the resource to.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string CompartmentId { get; set; }
    }
}

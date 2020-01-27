using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Notification.Model
{
    /// <summary>
    /// The configuration details for the move operation.
    /// </summary>
    public class ChangeCompartmentDetails
    {
        /// <summary>
        /// The OCID of the compartment to move the specified topic or subscription to.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string CompartmentId { get; set; }
    }
}

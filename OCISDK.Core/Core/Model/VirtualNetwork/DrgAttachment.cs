using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Model.VirtualNetwork
{
    /// <summary>
    /// A link between a DRG and VCN. For more information, see Overview of the Networking Service.
    /// 
    /// Warning: Oracle recommends that you avoid using any confidential information when you supply string values using the API.
    /// </summary>
    public class DrgAttachment
    {
        /// <summary>
        /// The OCID of the compartment containing the DRG attachment.
        /// <para>Required: yes</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// A user-friendly name. Does not have to be unique, and it's changeable. Avoid entering confidential information.
        /// <para>Required: no</para>
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The OCID of the DRG.
        /// <para>Required: yes</para>
        /// </summary>
        public string DrgId { get; set; }

        /// <summary>
        /// The DRG attachment's Oracle ID (OCID).
        /// <para>Required: yes</para>
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The DRG attachment's current state.
        /// <para>Required: yes</para>
        /// </summary>
        public string LifecycleState { get; set; }

        /// <summary>
        /// The OCID of the route table the DRG attachment is using.
        /// <para>Required: no</para>
        /// </summary>
        public string RouteTableId { get; set; }

        /// <summary>
        /// The date and time the DRG attachment was created, in the format defined by RFC3339.
        /// <para>Required: no</para>
        /// </summary>
        public string TimeCreated { get; set; }

        /// <summary>
        /// The OCID of the VCN.
        /// <para>Required: yes</para>
        /// </summary>
        public string VcnId { get; set; }
    }
}

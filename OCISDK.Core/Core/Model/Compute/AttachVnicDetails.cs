using OCISDK.Core.Core.Model.VirtualNetwork;

namespace OCISDK.Core.Core.Model.Compute
{
    /// <summary>
    /// AttachVnicDetails
    /// </summary>
    public class AttachVnicDetails
    {
        /// <summary>
        /// Details for creating a new VNIC.
        /// <para>Required: yes</para>
        /// </summary>
        public CreateVnicDetails CreateVnicDetails { get; set; }

        /// <summary>
        /// A user-friendly name. Does not have to be unique, and it cannot be changed. 
        /// Avoid entering confidential information.
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string InstanceId { get; set; }

        /// <summary>
        /// Which physical network interface card (NIC) the VNIC will use.
        /// Defaults to 0. Certain bare metal instance shapes have two active physical NICs (0 and 1).
        /// If you add a secondary VNIC to one of these instances, you can specify which NIC the VNIC 
        /// will use. For more information, see Virtual Network Interface Cards (VNICs).
        /// <para>Minimum: 0</para>
        /// <para>Maximum: 31</para>
        /// </summary>
        public int NicIndex { get; set; }
    }
}

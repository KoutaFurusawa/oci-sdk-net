/// <summary>
/// AttachVnicDetails Reference
/// 
/// author: koutaro furusawa
/// </summary>
using Newtonsoft.Json;
using OCISDK.Core.src.Core.Model.VirtualNetwork;

namespace OCISDK.Core.src.Core.Model.Compute
{
    public class AttachVnicDetails
    {
        /// <summary>
        /// Details for creating a new VNIC.
        /// <para>Required: yes</para>
        /// </summary>
        [JsonProperty("createVnicDetails")]
        public CreateVnicDetails CreateVnicDetails { get; set; }

        /// <summary>
        /// A user-friendly name. Does not have to be unique, and it cannot be changed. 
        /// Avoid entering confidential information.
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        /// <summary>
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        [JsonProperty("instanceId")]
        public string InstanceId { get; set; }

        /// <summary>
        /// Which physical network interface card (NIC) the VNIC will use.
        /// Defaults to 0. Certain bare metal instance shapes have two active physical NICs (0 and 1).
        /// If you add a secondary VNIC to one of these instances, you can specify which NIC the VNIC 
        /// will use. For more information, see Virtual Network Interface Cards (VNICs).
        /// <para>Minimum: 0</para>
        /// <para>Maximum: 31</para>
        /// </summary>
        [JsonProperty("nicIndex")]
        public int NicIndex { get; set; }
    }
}

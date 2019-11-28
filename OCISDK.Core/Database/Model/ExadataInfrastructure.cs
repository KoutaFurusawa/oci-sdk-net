using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Database.Model
{
    /// <summary>
    /// Details of the Exadata infrastructure.
    /// </summary>
    public class ExadataInfrastructure
    {
        /// <summary>
        /// The CIDR block for the Exadata administration network.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string AdminNetworkCIDR { get; set; }

        /// <summary>
        /// The IP address for the first control plane server.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string CloudControlPlaneServer1 { get; set; }

        /// <summary>
        /// The IP address for the second control plane server.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string CloudControlPlaneServer2 { get; set; }

        /// <summary>
        /// The OCID of the compartment.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// The corporate network proxy for access to the control plane network.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string CorporateProxy { get; set; }

        /// <summary>
        /// The number of enabled CPU cores.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 1024</para>
        /// </summary>
        public int? CpusEnabled { get; set; }

        /// <summary>
        /// Size, in terabytes, of the DATA disk group.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 1024</para>
        /// </summary>
        public int? DataStorageSizeInTBs { get; set; }

        /// <summary>
        /// The user-friendly name for the Exadata infrastructure. The name does not need to be unique.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The list of DNS server IP addresses. Maximum of 3 allowed.
        /// <para>Required: no</para>
        /// <para>Length: 1–1024</para>
        /// </summary>
        public List<string> DnsServer { get; set; }

        /// <summary>
        /// The gateway for the control plane network.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string Gateway { get; set; }

        /// <summary>
        /// The OCID of the Exadata infrastructure.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The CIDR block for the Exadata InfiniBand interconnect.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string InfiniBandNetworkCIDR { get; set; }

        /// <summary>
        /// Additional information about the current lifecycle state.
        /// <para>Required: no</para>
        /// </summary>
        public string LifecycleDetails { get; set; }

        /// <summary>
        /// The current lifecycle state of the Exadata infrastructure.
        /// <para>Required: yes</para>
        /// </summary>
        public string LifecycleState { get; set; }

        /// <summary>
        /// The netmask for the control plane network.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string Netmask { get; set; }

        /// <summary>
        /// The list of NTP server IP addresses. Maximum of 3 allowed.
        /// <para>Required: no</para>
        /// </summary>
        public List<string> NtpServer { get; set; }

        /// <summary>
        /// The shape of the Exadata infrastructure. The shape determines the amount of CPU, storage, and memory resources allocated to the instance.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string Shape { get; set; }

        /// <summary>
        /// The date and time the Exadata infrastructure was created.
        /// <para>Required: no</para>
        /// </summary>
        public string TimeCreated { get; set; }

        /// <summary>
        /// The time zone of the Exadata infrastructure. For details, see Exadata Infrastructure Time Zones.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string TimeZone { get; set; }
    }
}

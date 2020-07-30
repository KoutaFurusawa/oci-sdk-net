using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Model.VirtualNetwork
{
    /// <summary>
    /// Basic information about a particular CPE device type.
    /// </summary>
    public class CpeDeviceInfo
    {
        /// <summary>
        /// The platform or software version of the CPE device.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string PlatformSoftwareVersion { get; set; }

        /// <summary>
        /// The vendor that makes the CPE device.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string Vendor { get; set; }
    }
}

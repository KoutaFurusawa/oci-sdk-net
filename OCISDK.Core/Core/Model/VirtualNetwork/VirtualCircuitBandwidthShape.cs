using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Model.VirtualNetwork
{
    /// <summary>
    /// An individual bandwidth level for virtual circuits.
    /// </summary>
    public class VirtualCircuitBandwidthShape
    {
        /// <summary>
        /// The bandwidth in Mbps.
        /// <para>Required: no</para>
        /// </summary>
        public int? BandwidthInMbps { get; set; }

        /// <summary>
        /// The name of the bandwidth shape.
        /// <para>Required: yes</para>
        /// </summary>
        public string Name { get; set; }
    }
}

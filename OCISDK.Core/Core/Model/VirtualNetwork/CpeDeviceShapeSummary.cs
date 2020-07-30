using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Model.VirtualNetwork
{
    /// <summary>
    /// A summary of information about a particular CPE device type. Compare with CpeDeviceShapeDetail.
    /// </summary>
    public class CpeDeviceShapeSummary
    {
        /// <summary>
        /// Basic information about this particular CPE device type.
        /// <para>Required: no</para>
        /// </summary>
        public CpeDeviceInfo CpeDeviceInfo { get; set; }

        /// <summary>
        /// The OCID of the CPE device shape. This value uniquely identifies the type of CPE device.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string Id { get; set; }
    }
}

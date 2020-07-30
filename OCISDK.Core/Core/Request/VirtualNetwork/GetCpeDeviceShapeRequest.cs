using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Request.VirtualNetwork
{
    /// <summary>
    /// GetCpeDeviceShape request
    /// </summary>
    public class GetCpeDeviceShapeRequest
    {
        /// <summary>
        /// Unique identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.
        /// <para>Required: no</para>
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// The OCID of the CPE device shape.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string CpeDeviceShapeId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Model.VirtualNetwork
{
    /// <summary>
    /// The detailed information about a particular CPE device type. Compare with CpeDeviceShapeSummary.
    /// </summary>
    public class CpeDeviceShapeDetail
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
        public string CpeDeviceShapeId { get; set; }

        /// <summary>
        /// For certain CPE devices types, the customer can provide answers to 
        /// questions that are specific to the device type. This attribute contains a 
        /// list of those questions. The Networking service merges the answers 
        /// with other information and renders a set of CPE configuration 
        /// content. To provide the answers, use UpdateTunnelCpeDeviceConfig.
        /// <para>Required: no</para>
        /// </summary>
        public List<CpeDeviceConfigQuestion> Parameters { get; set; }

        /// <summary>
        /// A template of CPE device configuration information that will be 
        /// merged with the customer's answers to the questions to render the 
        /// final CPE device configuration content. 
        /// <para>Required: no</para>
        /// <para>Min Length: 1</para>
        /// </summary>
        public string Template { get; set; }
    }
}

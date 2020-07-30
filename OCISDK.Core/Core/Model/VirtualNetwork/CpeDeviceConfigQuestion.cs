using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Model.VirtualNetwork
{
    /// <summary>
    /// An individual question that the customer can answer about the CPE device.
    /// 
    /// The customer provides answers to these questions in UpdateTunnelCpeDeviceConfig.
    /// </summary>
    public class CpeDeviceConfigQuestion
    {
        /// <summary>
        /// A descriptive label for the question (for example, to display in a form in a graphical interface).
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// A description or explanation of the question, to help the customer answer accurately.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string Explanation { get; set; }

        /// <summary>
        /// A string that identifies the question.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string Key { get; set; }
    }
}

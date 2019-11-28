using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Request.VirtualNetwork
{
    /// <summary>
    /// GetDrg Request
    /// </summary>
    public class GetDrgRequest
    {
        /// <summary>
        /// The OCID of the DRG.
        /// <para>Required: yes</para>
        /// </summary>
        public string DrgId { get; set; }
    }
}

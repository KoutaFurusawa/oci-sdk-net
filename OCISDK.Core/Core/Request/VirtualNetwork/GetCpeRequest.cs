using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Request.VirtualNetwork
{
    /// <summary>
    /// GetCpe request
    /// </summary>
    public class GetCpeRequest
    {
        /// <summary>
        /// The OCID of the CPE.
        /// <para>Required: yes</para>
        /// </summary>
        public string CpeId { get; set; }
    }
}

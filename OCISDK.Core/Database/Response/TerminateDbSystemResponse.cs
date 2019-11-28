using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Database.Response
{
    /// <summary>
    /// TerminateDbSystem Response
    /// </summary>
    public class TerminateDbSystemResponse
    {
        /// <summary>
        /// Unique Oracle-assigned identifier for the request. 
        /// If you need to contact Oracle about a particular request, please provide the request ID.
        /// </summary>
        public string OpcRequestId { get; set; }
    }
}

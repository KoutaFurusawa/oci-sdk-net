/// <summary>
/// GetConfiguration Response
/// 
/// author: koutaro furusawa
/// </summary>
using System;
using System.Collections.Generic;
using System.Text;
using OCISDK.Core.src.Audit.Model;

namespace OCISDK.Core.src.Audit.Response
{
    public class UpdateConfigurationResponse
    {
        /// <summary>
        /// Unique Oracle-assigned identifier for the request. 
        /// If you need to contact Oracle about a particular request, please provide the request ID.
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// The OCID of the work request.
        /// </summary>
        public string OpcWorkRequestId { get; set; }
    }
}

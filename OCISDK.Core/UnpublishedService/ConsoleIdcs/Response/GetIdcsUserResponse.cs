using OCISDK.Core.UnpublishedService.ConsoleIdcs.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.UnpublishedService.ConsoleIdcs.Response
{
    /// <summary>
    /// GetIdcsUser response
    /// </summary>
    public class GetIdcsUserResponse
    {
        /// <summary>
        /// opc-request-id
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// IdcsUsers
        /// </summary>
        public List<IdcsUser> IdcsUsers { get; set; }
    }
}

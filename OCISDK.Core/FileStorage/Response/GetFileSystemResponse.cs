using OCISDK.Core.FileStorage.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.FileStorage.Response
{
    /// <summary>
    /// GetFileSystem request
    /// </summary>
    public class GetFileSystemResponse
    {
        /// <summary>
        /// For optimistic concurrency control. See if-match.
        /// </summary>
        public string ETag { get; set; }

        /// <summary>
        /// Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// The response body will contain a single FileSystem resource.
        /// </summary>
        public FileSystem FileSystem { get; set; }
    }
}

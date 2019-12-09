using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.FileStorage.Request
{
    /// <summary>
    /// GetFileSystem request
    /// </summary>
    public class GetFileSystemRequest
    {
        /// <summary>
        /// The OCID of the file system.
        /// <para>Required: yes</para>
        /// </summary>
        public string FileSystemId { get; set; }

        /// <summary>
        /// Unique identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.
        /// <para>Required: no</para>
        /// </summary>
        public string OpcRequestId { get; set; }
    }
}

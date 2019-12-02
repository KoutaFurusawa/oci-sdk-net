using System;
using System.Collections.Generic;
using System.Text;
using OCISDK.Core.FileStorage.Model;

namespace OCISDK.Core.FileStorage.Request
{
    /// <summary>
    /// ChangeFileSystemCompartment request
    /// </summary>
    public class ChangeFileSystemCompartmentRequest
    {
        /// <summary>
        /// Unique identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.
        /// <para>Required: no</para>
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// For optimistic concurrency control. In the PUT or DELETE call for a resource, 
        /// set the if-match parameter to the value of the etag from a previous GET or POST 
        /// response for that resource. The resource will be updated or deleted only if the 
        /// etag you provide matches the resource's current etag value.
        /// <para>Required: no</para>
        /// </summary>
        public string IfMatch { get; set; }

        /// <summary>
        /// The OCID of the file system.
        /// <para>Required: yes</para>
        /// </summary>
        public string FileSystemId { get; set; }

        /// <summary>
        /// The request body must contain a single ChangeFileSystemCompartmentDetails resource.
        /// </summary>
        public ChangeFileSystemCompartmentDetails ChangeFileSystemCompartmentDetails { get; set; }
    }
}

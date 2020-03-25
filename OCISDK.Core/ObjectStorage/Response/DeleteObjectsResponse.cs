using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.ObjectStorage.Response
{
    /// <summary>
    /// DeleteObjects response
    /// </summary>
    public class DeleteObjectsResponse
    {
        /// <summary>
        /// response delete objects.
        /// </summary>
        public List<DeletedObject> DeletedObjects { get; set; }
    }

    /// <summary>
    /// response class
    /// </summary>
    public class DeletedObject
    {
        /// <summary>
        /// response status code
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// error message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// delete name object.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Unique Oracle-assigned identifier for the request.
        /// If you need to contact Oracle about a particular request,
        /// please provide the request ID.
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// Echoes back the value passed in the opc-client-request-id header, for use by clients when debugging.
        /// </summary>
        public string OpcClientRequestId { get; set; }

        /// <summary>
        /// The time the object was deleted, as described in RFC 2616.
        /// </summary>
        public string LastModified { get; set; }
    }
}

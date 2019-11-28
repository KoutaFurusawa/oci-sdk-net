using OCISDK.Core.Core.Model.Blockstorage;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Request.Blockstorage
{
    /// <summary>
    /// ChangeVolumeCompartment Request
    /// </summary>
    public class ChangeVolumeCompartmentRequest
    {
        /// <summary>
        /// The OCID of the volume.
        /// <para>Required: yes</para>
        /// </summary>
        public string VolumeId { get; set; }

        /// <summary>
        /// Unique identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.
        /// <para>Required: no</para>
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// The request body must contain a single ChangeVolumeCompartmentDetails resource.
        /// </summary>
        public ChangeVolumeCompartmentDetails ChangeVolumeCompartmentDetails { get; set; }
    }
}

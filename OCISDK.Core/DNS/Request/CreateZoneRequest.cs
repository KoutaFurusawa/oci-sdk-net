using OCISDK.Core.DNS.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.DNS.Request
{
    /// <summary>
    /// CreateZone Request
    /// </summary>
    public class CreateZoneRequest
    {
        /// <summary>
        /// The OCID of the compartment the resource belongs to.
        /// <para>Required: no</para>
        /// <para>Default: nil</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// The request body must contain a single CreateZoneDetails resource.
        /// </summary>
        public CreateZoneDetails CreateZoneDetails { get; set; }
    }
}

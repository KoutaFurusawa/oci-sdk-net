using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.DNS.Model
{
    /// <summary>
    /// An external master name server used as the source of zone data.
    /// </summary>
    public class ExternalMasterDetails
    {
        /// <summary>
        /// The server's IP address (IPv4 or IPv6).
        /// <para>Required: yes</para>
        /// </summary>
        public string Addres { get; set; }

        /// <summary>
        /// The server's port. Port value must be a value of 53, otherwise omit the port value.
        /// <para>Required: no</para>
        /// <para>Default: 53</para>
        /// </summary>
        public int? Port { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public TSIGDetails tsig { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.DNS.Model
{
    /// <summary>
    /// A server that has been set up to answer DNS queries for a zone.
    /// </summary>
    public class NameserverDetails
    {
        /// <summary>
        /// The hostname of the nameserver.
        /// <para>Required: yes</para>
        /// </summary>
        public string Hostname { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Waas.Model
{
    /// <summary>
    /// An array of IP addresses that bypass the Web Application Firewall. Supports both single IP addresses or subnet masks (CIDR notation).
    /// </summary>
    public class WhitelistDetails
    {
        /// <summary>
        /// The unique name of the whitelist.
        /// <para>Required: yes</para>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A set of IP addresses or CIDR notations to include in the whitelist.An IP address or CIDR notation describing a subnet.
        /// <para>Required: yes</para>
        /// </summary>
        public List<string> Addresses { get; set; }
    }
}

namespace OCISDK.Core.Core.Model.VirtualNetwork
{
    /// <summary>
    /// A rule for allowing outbound IP packets.
    /// </summary>
    public class EgressSecurityRule
    {
        /// <summary>
        /// An optional description of your choice for the rule.
        /// <para>Required: no</para>
        /// </summary>
        public string Destination { get; set; }

        /// <summary>
        /// Conceptually, this is the range of IP addresses that a packet originating from the instance can go to.
        /// <para>Required: no</para>
        /// </summary>
        public string DestinationType { get; set; }

        /// <summary>
        /// Optional and valid only for ICMP and ICMPv6.
        /// <para>Required: no</para>
        /// </summary>
        public IcmpOption IcmpOptions { get; set; }

        /// <summary>
        /// A stateless rule allows traffic in one direction. Remember to add a corresponding stateless rule in the other direction if you 
        /// need to support bidirectional traffic. For example, if egress traffic allows TCP destination port 80, there should be an ingress 
        /// rule to allow TCP source port 80. Defaults to false, which means the rule is stateful and a corresponding rule is not necessary 
        /// for bidirectional traffic.
        /// <para>Required: no</para>
        /// </summary>
        public bool? IsStateless { get; set; }

        /// <summary>
        /// The transport protocol. Specify either all or an IPv4 protocol number as defined in Protocol Numbers. 
        /// Options are supported only for ICMP ("1"), TCP ("6"), UDP ("17"), and ICMPv6 ("58").
        /// <para>Required: yes</para>
        /// </summary>
        public string Protocol { get; set; }

        /// <summary>
        /// Optional and valid only for TCP. Use to specify particular destination ports for TCP rules. 
        /// If you specify TCP as the protocol but omit this object, then all destination ports are allowed.
        /// </summary>
        public TcpOption TcpOptions { get; set; }

        /// <summary>
        /// Optional and valid only for UDP. Use to specify particular destination ports for UDP rules. 
        /// If you specify UDP as the protocol but omit this object, then all destination ports are allowed.
        /// </summary>
        public UdpOption UdpOptions { get; set; }
    }
}

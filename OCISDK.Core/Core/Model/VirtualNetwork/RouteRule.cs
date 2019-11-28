namespace OCISDK.Core.Core.Model.VirtualNetwork
{
    /// <summary>
    /// A mapping between a destination IP address range and a virtual device to route matching packets to (a target).
    /// </summary>
    public class RouteRule
    {
        /// <summary>
        /// Deprecated. Instead use destination and destinationType. Requests that include both cidrBlock and destination will be rejected.
        /// <para>Required: no</para>
        /// </summary>
        public string CidrBlock { get; set; }

        /// <summary>
        /// Conceptually, this is the range of IP addresses used for matching when routing traffic. Required if you provide a destinationType.
        /// <para>Required: no</para>
        /// </summary>
        public string Destination { get; set; }

        /// <summary>
        /// Type of destination for the rule. Required if you provide a destination.
        /// <para>Required: no</para>
        /// </summary>
        public string DestinationType { get; set; }

        /// <summary>
        /// The OCID for the route rule's target. For information about the type of targets you can specify, see Route Tables.
        /// <para>Required: yes</para>
        /// </summary>
        public string NetworkEntityId { get; set; }
    }
}

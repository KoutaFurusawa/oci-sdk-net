namespace OCISDK.Core.Core.Model.VirtualNetwork
{
    /// <summary>
    /// An inclusive range of allowed destination ports.
    /// Use the same number for the min and max to indicate a single port.
    /// Defaults to all ports if not specified.
    /// </summary>
    public class PortRange
    {
        /// <summary>
        /// The maximum port number. Must not be lower than the minimum port number. To specify a single port number, set both the min and max to the same value.
        /// </summary>
        public int Max { get; set; }

        /// <summary>
        /// The minimum port number. Must not be greater than the maximum port number.
        /// </summary>
        public int Min { get; set; }
    }
}

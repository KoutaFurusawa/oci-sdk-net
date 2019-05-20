/// <summary>
/// PortRange Reference
/// 
/// author: koutaro furusawa
/// </summary>



namespace OCISDK.Core.src.Core.Model.VirtualNetwork
{
    /// <summary>
    /// An inclusive range of allowed destination ports.
    /// Use the same number for the min and max to indicate a single port.
    /// Defaults to all ports if not specified.
    /// </summary>
    public class PortRange
    {
        public int Max { get; set; }
        
        public int Min { get; set; }
    }
}

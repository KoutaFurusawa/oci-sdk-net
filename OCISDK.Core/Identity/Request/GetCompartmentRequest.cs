namespace OCISDK.Core.Identity.Request
{
    /// <summary>
    /// GetCompartment Request
    /// </summary>
    public class GetCompartmentRequest
    {
        /// <summary>
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string CompartmentId { get; set; }

    }
}

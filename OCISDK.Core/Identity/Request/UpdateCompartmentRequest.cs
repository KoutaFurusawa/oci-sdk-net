using OCISDK.Core.Identity.Model;

namespace OCISDK.Core.Identity.Request
{
    /// <summary>
    /// UpdateCompartment Request
    /// </summary>
    public class UpdateCompartmentRequest
    {
        /// <summary>
        /// The OCID of the compartment.
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// For optimistic concurrency control.
        /// In the PUT or DELETE call for a resource, set the if-match parameter to the 
        /// value of the etag from a previous GET or POST response for that resource. 
        /// The resource will be updated or deleted only if the etag you provide matches 
        /// the resource's current etag value.
        /// <para>Required: no</para>
        /// <para>if-match header parameter</para>
        /// </summary>
        public string IfMatch { get; set; }

        /// <summary>
        /// The request body must contain a single UpdateCompartmentDetails resource.
        /// </summary>
        public UpdateCompartmentDetails UpdateCompartmentDetails { get; set; }
    }
}

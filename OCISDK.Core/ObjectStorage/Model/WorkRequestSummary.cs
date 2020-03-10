using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.ObjectStorage.Model
{
    /// <summary>
    /// A summary of the status of a work request.
    /// </summary>
    public class WorkRequestSummary
    {
        /// <summary>
        /// The type of work request.
        /// <para>Required: no</para>
        /// </summary>
        public string OperationType { get; set; }

        /// <summary>
        /// The status of the specified work request.
        /// <para>Required: no</para>
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// The id of the work request.
        /// <para>Required: no</para>
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The OCID of the compartment that contains the work request. Work requests are scoped to the same compartment as the resource the work request affects.
        /// 
        /// If the work request affects multiple resources and those resources are not in the same compartment, the OCID of the primary resource is used. For example, 
        /// you can copy an object in a bucket in one compartment to a bucket in another compartment. In this case, the OCID of the source compartment is used.
        /// <para>Required: no</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public List<WorkRequestResource> Resources { get; set; }

        /// <summary>
        /// Percentage of the work request completed.
        /// <para>Required: no</para>
        /// </summary>
        public double? PercentComplete { get; set; }

        /// <summary>
        /// The date and time the work request was created, as described in RFC 3339.
        /// <para>Required: no</para>
        /// </summary>
        public string TimeAccepted { get; set; }

        /// <summary>
        /// The date and time the work request was started, as described in RFC 3339.
        /// <para>Required: no</para>
        /// </summary>
        public string TimeStarted { get; set; }

        /// <summary>
        /// The date and time the work request was finished, as described in RFC 3339.
        /// <para>Required: no</para>
        /// </summary>
        public string TimeFinished { get; set; }
    }
}

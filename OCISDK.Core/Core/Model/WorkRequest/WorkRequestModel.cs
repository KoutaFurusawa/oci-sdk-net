using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Model.WorkRequest
{
    /// <summary>
    /// WorkRequestModel
    /// </summary>
    public class WorkRequestModel
    {
        /// <summary>
        /// The asynchronous operation tracked by this work request.
        /// <para>Required: yes</para>
        /// </summary>
        public string OperationType { get; set; }

        /// <summary>
        /// The status of the work request.
        /// <para>Required: yes</para>
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// The OCID of the work request.
        /// <para>Required: yes</para>
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The OCID of the compartment that contains the work request.
        /// <para>Required: yes</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// The resources that are affected by this work request.
        /// <para>Required: yes</para>
        /// </summary>
        public List<WorkRequestResource> Resources { get; set; }

        /// <summary>
        /// The percentage complete of the operation tracked by this work request.
        /// <para>Required: yes</para>
        /// </summary>
        public double PercentComplete { get; set; }

        /// <summary>
        /// The date and time the work request was created, in the format defined by RFC3339.
        /// <para>Required: yes</para>
        /// </summary>
        public string TimeAccepted { get; set; }

        /// <summary>
        /// The date and time the work request transitioned from ACCEPTED to IN_PROGRESS, in the format defined by RFC3339.
        /// <para>Required: no</para>
        /// </summary>
        public string TimeStarted { get; set; }

        /// <summary>
        /// The date and time the work request reached a terminal state, either FAILED or SUCCEEDED. Format is defined by RFC3339.
        /// <para>Required: no</para>
        /// </summary>
        public string TimeFinished { get; set; }
    }
}

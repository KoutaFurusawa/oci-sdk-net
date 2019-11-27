using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.LoadBalancer.Model
{
    /// <summary>
    /// Many of the API requests you use to create and configure load balancing do not take effect immediately. In these cases, 
    /// the request spawns an asynchronous work flow to fulfill the request. WorkRequest objects provide visibility for in-progress 
    /// work flows. For more information about work requests, see Viewing the State of a Work Request.
    /// </summary>
    public class WorkRequest
    {
        /// <summary>
        /// The OCID of the work request.
        /// <para>Required: yes</para>
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The OCID of the load balancer with which the work request is associated.
        /// <para>Required: yes</para>
        /// </summary>
        public string LoadBalancerId { get; set; }

        /// <summary>
        /// The type of action the work request represents.
        /// <para>Required: yes</para>
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The current state of the work request.
        /// <para>Required: yes</para>
        /// </summary>
        public string LifecycleState { get; set; }

        /// <summary>
        /// A collection of data, related to the load balancer provisioning process, that helps with debugging in the event of failure.
        /// <para>Required: yes</para>
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// The date and time the work request was created, in the format defined by RFC3339.
        /// <para>Required: yes</para>
        /// </summary>
        public string TimeAccepted { get; set; }

        /// <summary>
        /// The date and time the work request was completed, in the format defined by RFC3339.
        /// </summary>
        public string TimeFinished { get; set; }

        /// <summary>
        /// <para>Required: yes</para>
        /// </summary>
        public List<WorkRequestError> ErrorDetails { get; set; }
    }
}

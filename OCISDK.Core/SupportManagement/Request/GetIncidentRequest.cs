using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.SupportManagement.Request
{
    /// <summary>
    /// GetIncident request
    /// </summary>
    public class GetIncidentRequest
    {
        /// <summary>
        /// Unique identifier for the support ticket.
        /// <para>Required: yes</para>
        /// </summary>
        public string IncidentKey { get; set; }

        /// <summary>
        /// Unique Oracle-assigned identifier for the request. If you need to contact Oracle about 
        /// a particular request, please provide the request ID.
        /// <para>Required: no</para>
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// The Customer Support Identifier associated with the support account.
        /// <para>Required: yes</para>
        /// </summary>
        public string Csi { get; set; }

        /// <summary>
        /// User OCID for Oracle Identity Cloud Service (IDCS) users who also have a federated Oracle Cloud Infrastructure account.
        /// <para>Required: yes</para>
        /// </summary>
        public string Ocid { get; set; }

        /// <summary>
        /// The region of the tenancy.
        /// <para>Required: no</para>
        /// </summary>
        public string Homeregion { get; set; }

    }
}

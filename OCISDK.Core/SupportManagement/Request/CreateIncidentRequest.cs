using OCISDK.Core.SupportManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.SupportManagement.Request
{
    /// <summary>
    /// CreateIncident request
    /// </summary>
    public class CreateIncidentRequest
    {
        /// <summary>
        /// A token that uniquely identifies a request so it can be retried in case of a timeout or 
        /// server error without risk of executing that same action again. Retry tokens expire after 
        /// 24 hours, but can be invalidated before then due to conflicting operations. For example, 
        /// if a resource has been deleted and purged from the system, then a retry of the original 
        /// creation request might be rejected.
        /// <para>Required: no</para>
        /// </summary>
        public string OpcRetryToken { get; set; }

        /// <summary>
        /// Unique Oracle-assigned identifier for the request. If you need to contact Oracle about 
        /// a particular request, please provide the request ID.
        /// <para>Required: no</para>
        /// </summary>
        public string OpcRequestId { get; set; }

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

        /// <summary>
        /// The request body must contain a single CreateIncident resource.
        /// </summary>
        public CreateIncident CreateIncident { get; set; }
    }
}

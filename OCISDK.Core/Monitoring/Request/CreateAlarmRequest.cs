using OCISDK.Core.Monitoring.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Monitoring.Request
{
    /// <summary>
    /// CreateAlarm Request
    /// </summary>
    public class CreateAlarmRequest
    {
        /// <summary>
        /// Customer part of the request identifier token. If you need to contact Oracle about a particular request, please provide the complete request ID.
        /// <para>Required: no</para>
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// A token that uniquely identifies a request so it can be retried in case of a 
        /// timeout or server error without risk of executing that same action again. 
        /// Retry tokens expire after 24 hours, but can be invalidated before then due to 
        /// conflicting operations (for example, if a resource has been deleted and purged 
        /// from the system, then a retry of the original creation request may be rejected).
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 64</para>
        /// </summary>
        public string OpcRetryToken { get; set; }

        /// <summary>
        /// The request body must contain a single CreateAlarmDetails resource.
        /// </summary>
        public CreateAlarmDetails CreateAlarmDetails { get; set; }
    }
}

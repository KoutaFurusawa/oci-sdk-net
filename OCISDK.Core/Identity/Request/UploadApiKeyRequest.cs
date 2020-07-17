﻿using OCISDK.Core.Identity.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Identity.Request
{
    /// <summary>
    /// UploadApiKey request
    /// </summary>
    public class UploadApiKeyRequest
    {
        /// <summary>
        /// The OCID of the user.
        /// <para>Required: yes</para>
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// A token that uniquely identifies a request so it can be retried in case of a timeout or 
        /// server error without risk of executing that same action again. Retry tokens expire after 
        /// 24 hours, but can be invalidated before then due to conflicting operations (e.g., 
        /// if a resource has been deleted and purged from the system, then a retry of the original 
        /// creation request may be rejected).
        /// </summary>
        public string OpcRetryToken { get; set; }

        /// <summary>
        /// The request body must contain a single CreateApiKeyDetails resource.
        /// </summary>
        public CreateApiKeyDetails CreateApiKeyDetails { get; set; }
    }
}

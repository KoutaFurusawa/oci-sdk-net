﻿using OCISDK.Core.LoadBalancer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.LoadBalancer.Response
{
    /// <summary>
    /// GetRuleSet Response
    /// </summary>
    public class GetRuleSetResponse
    {
        /// <summary>
        /// Unique Oracle-assigned identifier for the request.
        /// If you need to contact Oracle about a particular request, please provide the request ID.
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// The response body will contain a single RuleSet resource.
        /// </summary>
        public RuleSetDetails RuleSet { get; set; }
    }
}

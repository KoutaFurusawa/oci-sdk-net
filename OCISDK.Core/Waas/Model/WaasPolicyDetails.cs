﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Waas.Model
{
    /// <summary>
    /// The details of a Web Application Acceleration and Security (WAAS) policy. 
    /// A policy describes how the WAAS service should operate for the configured web application.
    /// 
    /// Warning: Oracle recommends that you avoid using any confidential information when you supply string values using the API.
    /// </summary>
    public class WaasPolicyDetails
    {
        /// <summary>
        /// The OCID of the WAAS policy.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The OCID of the WAAS policy's compartment.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// The user-friendly name of the WAAS policy. The name can be changed and does not need to be unique.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The web application domain that the WAAS policy protects.
        /// <para>Required: no</para>
        /// </summary>
        public string Domain { get; set; }

        /// <summary>
        /// An array of additional domains for this web application.
        /// <para>Required: no</para>
        /// </summary>
        public List<string> AdditionalDomains { get; set; }

        /// <summary>
        /// The CNAME record to add to your DNS configuration to route traffic for the domain, and all additional domains, through the WAF.
        /// <para>Required: no</para>
        /// </summary>
        public string Cname { get; set; }

        /// <summary>
        /// The current lifecycle state of the WAAS policy.
        /// <para>Required: no</para>
        /// </summary>
        public string LifecycleState { get; set; }

        /// <summary>
        /// The date and time the policy was created, expressed in RFC 3339 timestamp format.
        /// <para>Required: no</para>
        /// </summary>
        public string TimeCreated { get; set; }

        /// <summary>
        /// A mapping of strings to Origin objects.
        /// <para>Required: no</para>
        /// </summary>
        public OriginDetails Origins { get; set; }

        /// <summary>
        /// A mapping of strings to OriginGroup objects.
        /// <para>Required: no</para>
        /// </summary>
        public OriginGroupDetails OriginGroups { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public PolicyConfigDetails PolicyConfig { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public WafConfigDetails WafConfig { get; set; }

        /// <summary>
        /// Free-form tags for this resource. Each tag is a simple key-value pair with no predefined name, type, or namespace. 
        /// For more information, see Resource Tags.
        /// <para>Required: no</para>
        /// </summary>
        public IDictionary<string, string> FreeformTags { get; set; }

        /// <summary>
        /// Defined tags for this resource. Each key is predefined and scoped to a namespace. 
        /// For more information, see Resource Tags.
        /// <para>Required: no</para>
        /// </summary>
        public IDictionary<string, IDictionary<string, string>> DefinedTags { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.src.Identity.Model
{
    public class UpdatePolicyDetails
    {
        /// <summary>
        /// The description you assign to the policy during creation. Does not have to be unique, and it's changeable.
        /// <para>Required: no</para>
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// An array of policy statements written in the policy language. See How Policies Work and Common Policies.
        /// <para>Required: no</para>
        /// </summary>
        public List<string> Statements { get; set; }

        /// <summary>
        /// The version of the policy. If null or set to an empty string, when a request comes in for authorization, 
        /// the policy will be evaluated according to the current behavior of the services at that moment. 
        /// If set to a particular date (YYYY-MM-DD), the policy will be evaluated according to the behavior of the services on that date.
        /// <para>Required: no</para>
        /// </summary>
        public string VersionDate { get; set; }

        /// <summary>
        /// Free-form tags for this resource. 
        /// Each tag is a simple key-value pair with no predefined name, type, or namespace. 
        /// </summary>
        public IDictionary<string, string> FreeformTags { get; set; }

        /// <summary>
        /// Defined tags for this resource. Each key is predefined and scoped to a namespace. 
        /// </summary>
        public IDictionary<string, IDictionary<string, string>> DefinedTags { get; set; }
    }
}

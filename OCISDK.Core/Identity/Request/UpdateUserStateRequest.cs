﻿using OCISDK.Core.Identity.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Identity.Request
{
    /// <summary>
    /// UpdateUserState Request
    /// </summary>
    public class UpdateUserStateRequest
    {
        /// <summary>
        /// For optimistic concurrency control.
        /// In the PUT or DELETE call for a resource, set the if-match parameter to the 
        /// value of the etag from a previous GET or POST response for that resource. 
        /// The resource will be updated or deleted only if the etag you provide matches 
        /// the resource's current etag value.
        /// <para>Required: no</para>
        /// <para>if-match header parameter</para>
        /// </summary>
        public string IfMatch { get; set; }

        /// <summary>
        /// The OCID of the user.
        /// <para>Required: yes</para>
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// The request body must contain a single UpdateStateDetails resource.
        /// </summary>
        public UpdateStateDetails UpdateStateDetails { get; set; }
    }
}

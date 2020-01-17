using OCISDK.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Request.Compute
{
    /// <summary>
    /// InstanceAction request
    /// </summary>
    public class InstanceActionRequest
    {
        /// <summary>
        /// A token that uniquely identifies a request so it can be retried in case of a timeout or server error without risk of 
        /// executing that same action again. Retry tokens expire after 24 hours, but can be invalidated before then due to conflicting 
        /// operations (for example, if a resource has been deleted and purged from the system, then a retry of the original creation 
        /// request may be rejected).
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 64</para>
        /// </summary>
        public string OpcRetryToken { get; set; }

        /// <summary>
        /// For optimistic concurrency control. In the PUT or DELETE call for a resource, set the if-match parameter to the value of the etag from a 
        /// previous GET or POST response for that resource. The resource will be updated or deleted only if the etag you provide matches the resource's 
        /// current etag value.
        /// <para>Required: no</para>
        /// </summary>
        public string IfMatch { get; set; }

        /// <summary>
        /// The OCID of the instance.
        /// <para>Required: yes</para>
        /// </summary>
        public string InstanceId { get; set; }

        /// <summary>
        /// The action to perform on the instance.
        /// <para>Required: yes</para>
        /// </summary>
        public ActionParam Action { get; set; }

        /// <summary>
        /// SortBy ExpandableEnum
        /// </summary>
        public class ActionParam : ExpandableEnum<ActionParam>
        {
            /// <summary>
            /// SortBy ExpandableEnum
            /// </summary>
            /// <param name="value"></param>
            public ActionParam(string value) : base(value) { }

            /// <summary>
            /// parse
            /// </summary>
            /// <param name="value"></param>
            public static implicit operator ActionParam(string value)
            {
                return Parse(value);
            }

            /// <summary>
            /// STOP
            /// </summary>
            public static readonly ActionParam STOP = new ActionParam("STOP");

            /// <summary>
            /// START
            /// </summary>
            public static readonly ActionParam START = new ActionParam("START");

            /// <summary>
            /// SOFTRESET
            /// </summary>
            public static readonly ActionParam SOFTRESET = new ActionParam("SOFTRESET");

            /// <summary>
            /// RESET
            /// </summary>
            public static readonly ActionParam RESET = new ActionParam("RESET");

            /// <summary>
            /// SOFTSTOP
            /// </summary>
            public static readonly ActionParam SOFTSTOP = new ActionParam("SOFTSTOP");
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.ObjectStorage.Model
{
    /// <summary>
    /// To use any of the API operations, you must be authorized in an IAM policy. If you are not authorized, talk to an administrator. 
    /// If you are an administrator who needs to write policies to give users access, see Getting Started with Policies.
    /// </summary>
    public class ObjectLifecycleRuleDetails
    {
        /// <summary>
        /// The name of the lifecycle rule to be applied.
        /// <para>Required: yes</para>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The action of the object lifecycle policy rule. Rules using the action 'ARCHIVE' move objects into the Archive Storage tier. 
        /// Rules using the action 'DELETE' permanently delete objects from buckets. 'ARCHIVE' and 'DELETE' are the only two supported 
        /// actions at this time.
        /// <para>Required: yes</para>
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        /// Specifies the age of objects to apply the rule to. The timeAmount is interpreted in units defined by the timeUnit parameter, 
        /// and is calculated in relation to each object's Last-Modified time.
        /// <para>Required: yes</para>
        /// </summary>
        public long TimeAmount { get; set; }

        /// <summary>
        /// The unit that should be used to interpret timeAmount. Days are defined as starting and ending at midnight UTC. Years are defined as 
        /// 365.2425 days long and likewise round up to the next midnight UTC.
        /// <para>Required: yes</para>
        /// <para>Allowed values are: DAYS, YEARS</para>
        /// </summary>
        public string TimeUnit { get; set; }

        /// <summary>
        /// A Boolean that determines whether this rule is currently enabled.
        /// <para>Required: yes</para>
        /// </summary>
        public bool IsEnabled { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public ObjectNameFilterDetails ObjectNameFilter { get; set; }
    }
}

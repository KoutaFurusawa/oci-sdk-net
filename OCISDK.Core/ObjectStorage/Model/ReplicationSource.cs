using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.ObjectStorage.Model
{
    /// <summary>
    /// The details of a replication source bucket that replicates to a target destination bucket.
    /// </summary>
    public class ReplicationSource
    {
        /// <summary>
        /// The name of the policy.
        /// <para>Required: yes</para>
        /// </summary>
        public string PolicyName { get; set; }

        /// <summary>
        /// The source region replicating data from, for example "us-ashburn-1".
        /// <para>Required: yes</para>
        /// </summary>
        public string SourceRegionName { get; set; }

        /// <summary>
        /// The source bucket replicating data from.
        /// <para>Required: yes</para>
        /// </summary>
        public string SourceBucketName { get; set; }
    }
}

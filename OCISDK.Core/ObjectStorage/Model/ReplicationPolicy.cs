using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.ObjectStorage.Model
{
    /// <summary>
    /// The details of a replication policy.
    /// </summary>
    public class ReplicationPolicy
    {
        /// <summary>
        /// The id of the replication policy.
        /// <para>Required: yes</para>
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The name of the policy.
        /// <para>Required: yes</para>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The destination region to replicate to, for example "us-ashburn-1".
        /// <para>Required: yes</para>
        /// </summary>
        public string DestinationRegionName { get; set; }

        /// <summary>
        /// The bucket to replicate to in the destination region. Replication policy creation does not automatically create a 
        /// destination bucket. Create the destination bucket before creating the policy.
        /// <para>Required: yes</para>
        /// </summary>
        public string DestinationBucketName { get; set; }

        /// <summary>
        /// The date when the replication policy was created as per RFC 3339.
        /// <para>Required: yes</para>
        /// </summary>
        public string TimeCreated { get; set; }

        /// <summary>
        /// Changes made to the source bucket before this time has been replicated.
        /// <para>Required: yes</para>
        /// </summary>
        public string TimeLastSync { get; set; }

        /// <summary>
        /// The replication status of the policy. If the status is CLIENT_ERROR, once the user fixes the issue described in the status message, the status will become ACTIVE.
        /// <para>Required: yes</para>
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// A human-readable description of the status.
        /// <para>Required: yes</para>
        /// </summary>
        public string StatusMessage { get; set; }
    }
}

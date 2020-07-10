using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.ObjectStorage.Model
{
    /// <summary>
    /// The details to create a replication policy.
    /// </summary>
    public class CreateReplicationPolicyDetails
    {
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
        /// The bucket to replicate to in the destination region. Replication policy creation does not 
        /// automatically create a destination bucket. Create the destination bucket before creating the policy.
        /// <para>Required: yes</para>
        /// </summary>
        public string DestinationBucketName { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.ObjectStorage.Model
{
    /// <summary>
    /// Creates a new object lifecycle policy for a bucket.
    /// </summary>
    public class PutObjectLifecyclePolicyDetails
    {
        /// <summary>
        /// The bucket's set of lifecycle policy rules.
        /// <para>Required: no</para>
        /// </summary>
        public List<ObjectLifecycleRuleDetails> Items { get; set; }
    }
}

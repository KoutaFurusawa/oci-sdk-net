using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.ObjectStorage.Model
{
    /// <summary>
    /// The collection of lifecycle policy rules that together form the object lifecycle policy of a given bucket.
    /// </summary>
    public class ObjectLifecyclePolicyDetails
    {
        /// <summary>
        /// The date and time the object lifecycle policy was created, as described in RFC 3339.
        /// <para>Required: no</para>
        /// </summary>
        public string TimeCreated { get; set; }

        /// <summary>
        /// The live lifecycle policy on the bucket.
        /// For an example of this value, see the PutObjectLifecyclePolicy API documentation.
        /// <para>Required: no</para>
        /// </summary>
        public List<ObjectLifecycleRuleDetails> Items { get; set; }
    }
}

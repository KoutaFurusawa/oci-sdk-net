using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.ObjectStorage.Model
{
    /// <summary>
    /// The details of a retention rule.
    /// </summary>
    public class RetentionRule
    {
        /// <summary>
        /// Unique identifier for the retention rule.
        /// <para>Required: yes</para>
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// User specified name for the retention rule.
        /// <para>Required: yes</para>
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public Duration Duration { get; set; }

        /// <summary>
        /// The entity tag (ETag) for the retention rule.
        /// <para>Required: yes</para>
        /// </summary>
        public string Etag { get; set; }

        /// <summary>
        /// The date and time as per RFC 3339 after which this rule becomes locked. and can only be deleted by deleting the bucket.
        /// <para>Required: no</para>
        /// </summary>
        public string TimeRuleLocked { get; set; }

        /// <summary>
        /// The date and time that the retention rule was created as per RFC3339.
        /// <para>Required: yes</para>
        /// </summary>
        public string TimeCreated { get; set; }

        /// <summary>
        /// The date and time that the retention rule was modified as per RFC3339.
        /// <para>Required: yes</para>
        /// </summary>
        public string TimeModified { get; set; }
    }
}

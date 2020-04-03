using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.ObjectStorage.Model
{
    /// <summary>
    /// A filter that compares object names to a set of prefixes or patterns to determine if a rule applies to a given object. 
    /// The filter can contain include glob patterns, exclude glob patterns and inclusion prefixes. The inclusion prefixes property is 
    /// kept for backward compatibility. It is recommended to use inclusion patterns instead of prefixes. Exclusions take precedence 
    /// over inclusions.
    /// </summary>
    public class ObjectNameFilterDetails
    {
        /// <summary>
        /// An array of glob patterns to match the object names to include. An empty array includes all objects in the bucket. Exclusion patterns take precedence over 
        /// inclusion patterns. A Glob pattern is a sequence of characters to match text. Any character that appears in the pattern, other than the special pattern characters 
        /// described below, matches itself. Glob patterns must be between 1 and 1024 characters.
        /// <para>[string (length: 1–1024), ...]</para>
        /// <para>Max Items: 1000</para>
        /// <para>Required: no</para>
        /// </summary>
        public List<string> InclusionPatterns { get; set; }

        /// <summary>
        /// An array of glob patterns to match the object names to exclude. An empty array is ignored. Exclusion patterns take precedence over inclusion patterns. A Glob pattern is a 
        /// sequence of characters to match text. Any character that appears in the pattern, other than the special pattern characters described below, matches itself. Glob patterns must be 
        /// between 1 and 1024 characters.
        /// <para>[string (length: 1–1024), ...]</para>
        /// <para>Max Items: 1000</para>
        /// <para>Required: no</para>
        /// </summary>
        public List<string> ExclusionPatterns { get; set; }

        /// <summary>
        /// An array of object name prefixes that the rule will apply to. An empty array means to include all objects.
        /// <para>Required: no</para>
        /// </summary>
        public List<string> InclusionPrefixes { get; set; }
    }
}

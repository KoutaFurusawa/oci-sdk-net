using System.Collections.Generic;

namespace OCISDK.Core.ObjectStorage.Model
{
    /// <summary>
    /// To use any of the API operations, you must be authorized in an IAM policy. If you are not authorized, 
    /// talk to an administrator. If you are an administrator who needs to write policies to give users access, 
    /// see Getting Started with Policies.
    /// </summary>
    public class ListObjectDetails
    {
        /// <summary>
        /// An array of object summaries.
        /// <para>Required: yes</para>
        /// </summary>
        /// <example>[ObjectSummary, ...]</example>
        public List<ObjectSummary> Objects { get; set; }

        /// <summary>
        /// Prefixes that are common to the results returned by the request if the request specified a delimiter.
        /// <para>Required: no</para>
        /// </summary>
        public List<string> Prefixes { get; set; }

        /// <summary>
        /// The name of the object to use in the 'startWith' parameter to obtain the next page of a truncated ListObjects response. 
        /// Avoid entering confidential information.
        /// </summary>
        /// <example>test/object1.log</example>
        public string NextStartWith { get; set; }
    }
}

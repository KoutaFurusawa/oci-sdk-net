using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.ObjectStorage.Model
{
    /// <summary>
    /// To use any of the API operations, you must be authorized in an IAM policy. If you are not authorized, talk to 
    /// an administrator. If you are an administrator who needs to write policies to give users access, see Getting 
    /// Started with Policies.
    /// </summary>
    public class CommitMultipartUploadDetails
    {
        /// <summary>
        /// The part numbers and entity tags (ETags) for the parts to be committed.
        /// <para>Required: yes</para>
        /// </summary>
        public List<CommitMultipartUploadPartDetails> PartsToCommit { get; set; }

        /// <summary>
        /// The part numbers for the parts to be excluded from the completed object. 
        /// Each part created for this upload must be in either partsToExclude or partsToCommit, but cannot be in both.
        /// <para>Required: no</para>
        /// </summary>
        public List<long> PartsToExclude { get; set; }
    }
}

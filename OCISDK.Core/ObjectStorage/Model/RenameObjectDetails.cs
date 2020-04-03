using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.ObjectStorage.Model
{
    /// <summary>
    /// To use any of the API operations, you must be authorized in an IAM policy. If you are not authorized, talk to an administrator. 
    /// If you are an administrator who needs to write policies to give users access, see Getting Started with Policies.
    /// </summary>
    public class RenameObjectDetails
    {
        /// <summary>
        /// The name of the source object to be renamed.
        /// <para>Required: yes</para>
        /// </summary>
        public string SourceName { get; set; }

        /// <summary>
        /// The new name of the source object.
        /// <para>Required: yes</para>
        /// </summary>
        public string NewName { get; set; }

        /// <summary>
        /// The if-match entity tag (ETag) of the source object.
        /// <para>Required: no</para>
        /// </summary>
        public string SrcObjIfMatchETag { get; set; }

        /// <summary>
        /// The if-match entity tag (ETag) of the new object.
        /// <para>Required: no</para>
        /// </summary>
        public string NewObjIfMatchETag { get; set; }

        /// <summary>
        /// The if-none-match entity tag (ETag) of the new object.
        /// <para>Required: no</para>
        /// </summary>
        public string NewObjIfNoneMatchETag { get; set; }
    }
}

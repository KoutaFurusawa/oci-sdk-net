using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCISDK.Core.GeneralElement
{
    /// <summary>
    /// GetBucketLocation request
    /// </summary>
    public class GetBucketLocationRequest
    {
        /// <summary>
        /// NamespaceName
        /// <para>Required: no</para>
        /// </summary>
        public string NamespaceName { get; set; }

        /// <summary>
        /// BucketName
        /// <para>Required: yes</para>
        /// </summary>
        public string BucketName { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.ObjectStorage
{
    /// <summary>
    /// ObjectStorageServices
    /// </summary>
    public class ObjectStorageServices
    {
        /// <summary>
        /// namespace
        /// </summary>
        public readonly static string Namespace = "n";

        /// <summary>
        /// create bucket endpoint
        /// </summary>
        /// <param name="namespaceName"></param>
        /// <returns></returns>
        public static string Bucket(string namespaceName)
        {
            return $"n/{namespaceName}/b";
        }

        /// <summary>
        /// create bucket endpoint
        /// </summary>
        /// <param name="namespaceName"></param>
        /// <param name="bucketName"></param>
        /// <returns></returns>
        public static string Bucket(string namespaceName, string bucketName)
        {
            return $"n/{namespaceName}/b/{bucketName}";
        }

        /// <summary>
        /// create object endpoint
        /// </summary>
        /// <param name="namespaceName"></param>
        /// <param name="bucketName"></param>
        /// <returns></returns>
        public static string Object(string namespaceName, string bucketName)
        {
            return $"n/{namespaceName}/b/{bucketName}/o";
        }
    }
}

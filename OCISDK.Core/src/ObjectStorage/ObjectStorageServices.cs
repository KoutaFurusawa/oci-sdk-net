using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.src.ObjectStorage
{
    public class ObjectStorageServices
    {
        public readonly static string Namespace = "n";

        public static string Bucket(string namespaceName)
        {
            return $"n/{namespaceName}/b";
        }

        public static string Bucket(string namespaceName, string bucketName)
        {
            return $"n/{namespaceName}/b/{bucketName}";
        }

        public static string Object(string namespaceName, string bucketName)
        {
            return $"n/{namespaceName}/b/{bucketName}/o";
        }
    }
}

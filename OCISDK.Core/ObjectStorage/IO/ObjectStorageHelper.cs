using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCISDK.Core.ObjectStorage.IO
{
    internal static class ObjectStorageHelper
    {
        internal static string EncodeKey(string key)
        {
            return key.Replace('\\', '/');
        }
        internal static string DecodeKey(string key)
        {
            return key.Replace('/', '\\');
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.IO;
using System.Runtime.Serialization;
using System.Security.AccessControl;
using System.Net;

using OCISDK.Core.GeneralElement;
using OCISDK.Core.Identity.Request;
using OCISDK.Core.ObjectStorage;
using OCISDK.Core.ObjectStorage.Model;
using OCISDK.Core.ObjectStorage.Request;
using OCISDK.Core.ObjectStorage.Response;
using System.Globalization;
using System.Threading.Tasks;

namespace OCISDK.Core.ObjectStorage.IO
{
    /// <summary>
    /// DirectoryInfo
    /// </summary>
    public class ObjectStorageDirectoryInfo : IObjectStorageFileSystemInfo
    {
        private const int MULTIPLE_OBJECT_DELETE_LIMIT = 1000;

        internal IObjectStorageClient Client { get; }

        internal IObjectStorageClientAsync ClientAsync { get; }

        internal string NamespaceName { get; }

        internal string TenantId { get; }

        internal string BucketName { get; }

        internal string ObjectKey { get; }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="clinet">client</param>
        /// <param name="namespaceName">namespace name</param>
        /// <param name="bucket">bucket name</param>
        public ObjectStorageDirectoryInfo(IObjectStorageClient clinet, string namespaceName, string bucket)
            : this(clinet, namespaceName, bucket, null)
        {
        }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="client">client</param>
        /// <param name="namespaceName">namespace name</param>
        /// <param name="bucket">bucket name</param>
        /// <param name="key"></param>
        public ObjectStorageDirectoryInfo(IObjectStorageClient client, string namespaceName, string bucket, string key)
        {
            Client = client ?? throw new ArgumentNullException("client");

            if (String.IsNullOrEmpty(bucket) && !String.IsNullOrEmpty(key))
            {
                throw new ArgumentException("key cannot be specified if bucket isn't");
            }

            NamespaceName = namespaceName ?? throw new ArgumentNullException("namespaceName");
            BucketName = bucket ?? String.Empty;
            ObjectKey = key ?? String.Empty;

            if (string.IsNullOrEmpty(key))
            {
                ObjectKey = string.Empty;
            }
            else
            {
                var searchKey = key;
                if (searchKey[0] == '/')
                {
                    searchKey = searchKey.Remove(0, 1);
                }
                ObjectKey = searchKey;
            }
        }

        /// <summary>
        /// The ObjectStorageDirectoryInfo for the root of the bucket.
        /// </summary>
        public ObjectStorageDirectoryInfo Bucket
        {
            get
            {
                return new ObjectStorageDirectoryInfo(Client, BucketName, "");
            }
        }

        /// <summary>
        /// Checks with ObjectStorage to see if the directory exists and if so returns true.
        /// </summary>
        /// <exception cref="T:System.Net.WebException"></exception>
        public bool Exists
        {
            get
            {
                return ExistsWithBucketCheck(out _);
            }
        }

        internal bool ExistsWithBucketCheck(out bool bucketExists)
        {
            bucketExists = true;
            try
            {
                if (String.IsNullOrEmpty(BucketName))
                {
                    return true;
                }
                else if (String.IsNullOrEmpty(ObjectKey))
                {
                    var getBucketRequest = new HeadBucketRequest
                    {
                        NamespaceName = NamespaceName,
                        BucketName = BucketName
                    };

                    try
                    {
                        Client.HeadBucket(getBucketRequest);
                        return true;
                    }
                    catch (WebException we)
                    {
                        if (we.Status.Equals(WebExceptionStatus.ProtocolError) && ((HttpWebResponse)we.Response).StatusCode == HttpStatusCode.NotFound)
                        {
                            return false;
                        }
                        throw;
                    }
                }
                else
                {
                    var request = new ListObjectsRequest()
                    {
                        NamespaceName = NamespaceName,
                        BucketName = BucketName,
                        Delimiter = "/",
                        Prefix = ObjectStorageHelper.EncodeKey(ObjectKey),
                        Limit = 1
                    };
                    var response = Client.ListObjects(request);
                    return response.ListObjects.Objects.Count > 0 || response.ListObjects.Prefixes.Count > 0;
                }
            }
            catch (WebException we)
            {
                if (we.Status.Equals(WebExceptionStatus.ProtocolError) && ((HttpWebResponse)we.Response).StatusCode == HttpStatusCode.NotFound)
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
            catch (Exception e)
            {
                if (string.Equals(e.Message, "NoSuchBucket"))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Returns empty string for directories.
        /// </summary>
        string IObjectStorageFileSystemInfo.Extension
        {
            get
            {
                return String.Empty;
            }
        }

        /// <summary>
        /// The full path of the directory including bucket name.
        /// </summary>
        public string FullName
        {
            get
            {
                return string.Format(CultureInfo.InvariantCulture, "{0}:\\{1}", BucketName, ObjectKey);
            }
        }

        /// <summary>
        /// Returns the name of the folder.
        /// </summary>
        public string Name
        {
            get
            {
                string ret = String.Empty;
                if (!String.IsNullOrEmpty(BucketName))
                {
                    if (String.IsNullOrEmpty(ObjectKey))
                    {
                        ret = BucketName;
                    }
                    else
                    {
                        int end = ObjectKey.LastIndexOf('\\');
                        int start = ObjectKey.LastIndexOf('\\', end - 1);
                        return ObjectKey.Substring(start + 1, end - start - 1);
                    }
                }
                return ret;
            }
        }

        /// <summary>
        /// Return the ObjectStorageDirectoryInfo of the parent directory.
        /// </summary>
        public ObjectStorageDirectoryInfo Parent
        {
            get
            {
                ObjectStorageDirectoryInfo ret = null;
                if (!String.IsNullOrEmpty(BucketName) && !String.IsNullOrEmpty(ObjectKey))
                {
                    int last = ObjectKey.LastIndexOf('\\');
                    int secondlast = ObjectKey.LastIndexOf('\\', last - 1);
                    if (secondlast == -1)
                    {
                        ret = Bucket;
                    }
                    else
                    {
                        var bucketName = ObjectKey.Substring(0, secondlast);
                        ret = new ObjectStorageDirectoryInfo(Client, BucketName, bucketName);
                    }
                }
                if (ret == null)
                {
                    ret = Root;
                }
                return ret;
            }
        }

        /// <summary>
        /// Returns the ObjectStorageDirectroyInfo for the account.
        /// </summary>
        public ObjectStorageDirectoryInfo Root
        {
            get
            {
                return new ObjectStorageDirectoryInfo(Client, "", "");
            }
        }

        /// <summary>
        /// Returns the type of file system element.
        /// </summary>
        public FileSystemType Type
        {
            get
            {
                return FileSystemType.Directory;
            }
        }

        /// <summary>
        /// original key name.
        /// </summary>
        public string OriginalKey
        {
            get
            {
                return ObjectStorageHelper.EncodeKey(ObjectKey);
            }
        }

        /// <summary>
        /// Returns the files in the directory.
        /// </summary>
        /// <exception cref="T:System.Net.WebException"></exception>
        /// <returns>An enumerable collection of files.</returns>
        public IEnumerable<ObjectStorageFileInfo> EnumerateFiles()
        {
            return EnumerateFiles("*", SearchOption.TopDirectoryOnly);
        }

        /// <summary>
        /// returns files in a directory according to the specified search pattern
        /// </summary>
        /// <param name="searchPattern"></param>
        /// <returns></returns>
        public IEnumerable<ObjectStorageFileInfo> EnumerateFiles(string searchPattern)
        {
            return EnumerateFiles(searchPattern, SearchOption.TopDirectoryOnly);
        }

        /// <summary>
        /// returns files in a directory according to the specified search pattern
        /// </summary>
        /// <param name="searchPattern"></param>
        /// <param name="searchOption"></param>
        /// <returns></returns>
        public IEnumerable<ObjectStorageFileInfo> EnumerateFiles(string searchPattern, SearchOption searchOption)
        {
            IEnumerable<ObjectStorageFileInfo> files = null;
            if (String.IsNullOrEmpty(BucketName))
            {
                files = new List<ObjectStorageFileInfo>();
            }
            else
            {
                var metaFiles = GetOciObjects(ObjectKey, searchOption);

                files = new EnumerableConverter<ObjectSummary, ObjectStorageFileInfo>
                    (metaFiles, o => new ObjectStorageFileInfo(Client, NamespaceName, BucketName, ObjectStorageHelper.DecodeKey(o.Name)));
            }

            var regEx = WildcardToRegex(searchPattern);
            files = files.Where(o => Regex.IsMatch(o.Name, regEx, RegexOptions.IgnoreCase));
            return files;
        }

        internal class EnumerableConverter<T, U> : IEnumerable<U>
        {
            internal IEnumerable<T> baseEnum = null;
            internal Func<T, U> converter = null;

            internal EnumerableConverter(IEnumerable<T> start, Func<T, U> convert)
            {
                baseEnum = start;
                converter = convert;
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return (IEnumerator)GetEnumerator();
            }

            public IEnumerator<U> GetEnumerator()
            {
                return new ConvertingEnumerator<T, U>(this);
            }
        }

        internal class ConvertingEnumerator<T, U> : IEnumerator<U>
        {
            Func<T, U> convert;
            IEnumerator<T> getT;

            bool isConverted = false;
            U convertedCurrent = default(U);

            internal ConvertingEnumerator(EnumerableConverter<T, U> ec)
            {
                getT = ec.baseEnum.GetEnumerator();
                convert = ec.converter;
            }

            public bool MoveNext()
            {
                isConverted = false;
                convertedCurrent = default(U);
                return getT.MoveNext();
            }

            public void Reset()
            {
                isConverted = false;
                convertedCurrent = default(U);
                getT.Reset();
            }

            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }

            public U Current
            {
                get
                {
                    if (!isConverted)
                    {
                        convertedCurrent = convert(getT.Current);
                        isConverted = true;
                    }
                    return convertedCurrent;
                }
            }

            public void Dispose()
            {
            }
        }

        /// <summary>
        /// Returns the directory in the bucket.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ObjectStorageDirectoryInfo> EnumerateDirectories()
        {
            return EnumerateDirectories("*", SearchOption.TopDirectoryOnly);
        }

        /// <summary>
        /// Returns the directory in the s-bucket to the specified pattern
        /// </summary>
        /// <param name="searchPattern"></param>
        /// <returns></returns>
        public IEnumerable<ObjectStorageDirectoryInfo> EnumerateDirectories(string searchPattern)
        {
            return EnumerateDirectories(searchPattern, SearchOption.TopDirectoryOnly);
        }

        /// <summary>
        /// Returns the directory in the s-bucket to the specified pattern
        /// </summary>
        /// <param name="searchPattern"></param>
        /// <param name="searchOption"></param>
        /// <returns></returns>
        public IEnumerable<ObjectStorageDirectoryInfo> EnumerateDirectories(string searchPattern, SearchOption searchOption)
        {
            IEnumerable<ObjectStorageDirectoryInfo> folders = null;
            if (String.IsNullOrEmpty(BucketName))
            {
                var request = new ListBucketsRequest();
                folders = Client.ListBuckets(request).Items
                    .ConvertAll(bucket => new ObjectStorageDirectoryInfo(Client, NamespaceName, bucket.Name, ""));
            }
            else
            {
                var prefixs = GetOciPrefixs(ObjectKey, searchOption);

                folders = prefixs
                    .ConvertAll(f => new ObjectStorageDirectoryInfo(Client, NamespaceName, BucketName, ObjectStorageHelper.DecodeKey(f)));
            }

            //filter based on search pattern
            var regEx = WildcardToRegex(searchPattern);
            folders = folders.Where(f => Regex.IsMatch(f.Name, regEx, RegexOptions.IgnoreCase));
            return folders;
        }

        /// <summary>
        /// Enumerate the files of this directory.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IObjectStorageFileSystemInfo> EnumerateFileSystemInfos()
        {
            return EnumerateFileSystemInfos("*", SearchOption.TopDirectoryOnly);
        }

        /// <summary>
        /// Enumerate the files of this directory.
        /// </summary>
        /// <param name="searchPattern"></param>
        /// <returns></returns>
        public IEnumerable<IObjectStorageFileSystemInfo> EnumerateFileSystemInfos(string searchPattern)
        {
            return EnumerateFileSystemInfos(searchPattern, SearchOption.TopDirectoryOnly);
        }

        /// <summary>
        /// Enumerate the files of this directory.
        /// </summary>
        /// <param name="searchPattern"></param>
        /// <param name="searchOption"></param>
        /// <returns></returns>
        public IEnumerable<IObjectStorageFileSystemInfo> EnumerateFileSystemInfos(string searchPattern, SearchOption searchOption)
        {
            IEnumerable<IObjectStorageFileSystemInfo> files = EnumerateFiles(searchPattern, searchOption).Cast<IObjectStorageFileSystemInfo>();
            IEnumerable<IObjectStorageFileSystemInfo> folders = EnumerateDirectories(searchPattern, searchOption).Cast<IObjectStorageFileSystemInfo>();

            return files.Concat(folders);
        }

        /// <summary>
        /// Get the object in the bucket.
        /// </summary>
        /// <param name="prefix"></param>
        /// <param name="searchOption"></param>
        /// <param name="nextStartWith"></param>
        /// <returns></returns>
        private List<ObjectSummary> GetOciObjects(string prefix, SearchOption searchOption, string nextStartWith = "")
        {
            var res = new List<ObjectSummary>();

            string delimiter = "";
            var prefixReg = ObjectStorageHelper.EncodeKey(prefix);
            if (prefixReg.Contains("/"))
            {
                delimiter = "/";
            }

            var listObjectsRequest = new ListObjectsRequest()
            {
                NamespaceName = NamespaceName,
                BucketName = BucketName,
                Start = nextStartWith,
                Delimiter = delimiter,
                Prefix = prefixReg,
                Fields = new List<string> { "name", "size", "timeCreated", "md5" },
                Limit = 1000
            };

            var objects = Client.ListObjects(listObjectsRequest);

            if (searchOption == SearchOption.TopDirectoryOnly)
            {
                foreach (var o in objects.ListObjects.Objects)
                {
                    if (CheckAddObject(o, prefixReg))
                    {
                        res.Add(o);
                    }
                }
            }
            else
            {
                foreach (var o in objects.ListObjects.Objects)
                {
                    if (CheckAddObject(o, prefixReg))
                    {
                        res.Add(o);
                    }
                }
            }

            // next check
            if (!string.IsNullOrEmpty(objects.ListObjects.NextStartWith))
            {
                res.AddRange(GetOciObjects(ObjectStorageHelper.DecodeKey(prefix), searchOption, objects.ListObjects.NextStartWith));
            }

            if (objects.ListObjects.Prefixes != null && objects.ListObjects.Prefixes.Count > 0)
            {
                // all sub prefix
                if (searchOption == SearchOption.AllDirectories)
                {
                    foreach (var pre in objects.ListObjects.Prefixes)
                    {
                        res.AddRange(GetOciObjects(pre, searchOption));
                    }
                }
                else
                {
                    var newPrefix = objects.ListObjects.Prefixes.Where(p => p == prefixReg + "/");
                    if (newPrefix != null && newPrefix.Count() > 0)
                    {
                        foreach (var pre in newPrefix)
                        {
                            res.AddRange(GetOciObjects(pre, searchOption));
                        }
                    }
                }
            }

            return res;
        }

        private bool CheckAddObject(ObjectSummary o, string prefix)
        {
            // file
            if (!o.Name.Contains('/'))
            {
                return true;
            }
            else if (!string.IsNullOrEmpty(prefix))
            {
                // directory
                var dirPrefix = prefix;
                if (!dirPrefix.Contains("/"))
                {
                    dirPrefix += "/";
                }
                if (o.Name.Contains(dirPrefix))
                {
                    var length = o.Name.Replace(dirPrefix, "").Split('/').Length;
                    if (length >= 0 && length <= 1)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private List<string> GetOciPrefixs(string prefix, SearchOption searchOption, string nextStartWith = "")
        {
            var res = new List<string>();

            var listObjectsRequest = new ListObjectsRequest()
            {
                NamespaceName = NamespaceName,
                BucketName = BucketName,
                Start = nextStartWith,
                Delimiter = "/",
                Prefix = ObjectStorageHelper.EncodeKey(prefix),
                Fields = new List<string> { "name" },
                Limit = 1
            };

            var objects = Client.ListObjects(listObjectsRequest);

            res.AddRange(objects.ListObjects.Prefixes);

            if (!string.IsNullOrEmpty(objects.ListObjects.NextStartWith))
            {
                res.AddRange(GetOciPrefixs(ObjectStorageHelper.DecodeKey(prefix), searchOption, objects.ListObjects.NextStartWith));
            }

            if (objects.ListObjects.Prefixes != null && objects.ListObjects.Prefixes.Count > 0)
            {
                // all sub prefix
                if (searchOption == SearchOption.AllDirectories)
                {
                    foreach (var pre in objects.ListObjects.Prefixes)
                    {
                        res.AddRange(GetOciPrefixs(pre, searchOption));
                    }
                }
                else
                {
                    var newPrefix = objects.ListObjects.Prefixes.Where(p => p == ObjectStorageHelper.EncodeKey(prefix) + "/");
                    if (newPrefix != null && newPrefix.Count() > 0)
                    {
                        foreach (var pre in newPrefix)
                        {
                            res.AddRange(GetOciPrefixs(pre, searchOption));
                        }
                    }
                }
            }

            return res;
        }

        /// <summary>
        /// Deletes all the files in this directory as well as this directory.
        /// </summary>
        /// <exception cref="T:System.Net.WebException"></exception>
        public void Delete()
        {
            Delete(false);
        }

        /// <summary>
        /// Deletes all the files in this directory as well as this directory.  If recursive is set to true then all sub directories will be 
        /// deleted as well.
        /// </summary>
        /// <exception cref="T:System.Net.WebException"></exception>
        public void Delete(bool recursive)
        {
            if (String.IsNullOrEmpty(BucketName))
            {
                throw new NotSupportedException();
            }

            if (recursive)
            {
                ListObjectsRequest listRequest = new ListObjectsRequest
                {
                    NamespaceName = NamespaceName,
                    BucketName = BucketName,
                    Prefix = ObjectStorageHelper.EncodeKey(ObjectKey)
                };

                DeleteObjectsRequest deleteRequest = new DeleteObjectsRequest
                {
                    NamespaceName = NamespaceName,
                    BucketName = BucketName,
                    Objects = new List<TargetDelete>()
                };

                ListObjectsResponse listResponse;
                do
                {
                    listResponse = Client.ListObjects(listRequest);

                    foreach (var obj in listResponse.ListObjects.Objects)
                    {
                        deleteRequest.Objects.Add(new TargetDelete { ObjectName = obj.Name });
                        if (deleteRequest.Objects.Count >= MULTIPLE_OBJECT_DELETE_LIMIT)
                        {
                            Client.DeleteObjects(deleteRequest);
                            deleteRequest.Objects.Clear();
                        }
                    }

                    if (string.IsNullOrEmpty(listResponse.ListObjects.NextStartWith))
                    {
                        break;
                    }
                    else
                    {
                        listRequest.Start = listResponse.ListObjects.NextStartWith;
                    }

                } while (true);

                if (deleteRequest.Objects.Count > 0)
                {
                    Client.DeleteObjects(deleteRequest);
                }
            }

            if (String.IsNullOrEmpty(ObjectKey) && Exists)
            {
                var request = new DeleteBucketRequest { NamespaceName = NamespaceName, BucketName = BucketName };
                Client.DeleteBucket(request);
            }
            else
            {
                if (!EnumerateFileSystemInfos().GetEnumerator().MoveNext() && Exists)
                {
                    var request = new DeleteObjectRequest
                    {
                        NamespaceName = NamespaceName,
                        BucketName = BucketName,
                        ObjectName = ObjectStorageHelper.EncodeKey(ObjectKey)
                    };

                    Client.DeleteObject(request);
                }
            }
        }

        static string WildcardToRegex(string pattern)
        {
            string newPattern = Regex.Escape(pattern).
                Replace("\\*", ".*").
                Replace("\\?", ".");
            return "^" + newPattern + "$";
        }
    }
}

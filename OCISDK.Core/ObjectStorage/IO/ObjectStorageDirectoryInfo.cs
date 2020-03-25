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
        private const int EVENTUAL_CONSISTENCY_SUCCESS_IN_ROW = 10;
        private const int EVENTUAL_CONSISTENCY_POLLING_PERIOD = 1000;
        private const long EVENTUAL_CONSISTENCY_MAX_WAIT = 30000;
        private const int MULTIPLE_OBJECT_DELETE_LIMIT = 1000;

        private IObjectStorageClient client;
        private IObjectStorageClientAsync clientAsync;
        private string namespaceName;
        private string tenantId;
        private string bucket;
        private string key;

        internal IObjectStorageClient Client
        {
            get
            {
                return client;
            }
        }

        internal IObjectStorageClientAsync ClientAsync
        {
            get
            {
                return clientAsync;
            }
        }

        internal string NamespaceName
        {
            get
            {
                return namespaceName;
            }
        }

        internal string TenantId
        {
            get
            {
                return tenantId;
            }
        }

        internal string BucketName
        {
            get
            {
                return bucket;
            }
        }

        internal string ObjectKey
        {
            get
            {
                return key;
            }
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="clinet">クライアント</param>
        /// <param name="namespaceName">ネームスペース</param>
        /// <param name="bucket">バケット名</param>
        public ObjectStorageDirectoryInfo(IObjectStorageClient clinet, string namespaceName, string bucket)
            : this(clinet, namespaceName, bucket, null)
        {
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="client">クライアント</param>
        /// <param name="namespaceName">ネームスペース</param>
        /// <param name="bucket">バケット名</param>
        /// <param name="key"></param>
        public ObjectStorageDirectoryInfo(IObjectStorageClient client, string namespaceName, string bucket, string key)
        {
            this.client = client ?? throw new ArgumentNullException("client");

            if (String.IsNullOrEmpty(bucket) && !String.IsNullOrEmpty(key))
            {
                throw new ArgumentException("key cannot be specified if bucket isn't");
            }

            this.namespaceName = namespaceName;
            this.bucket = bucket ?? String.Empty;
            this.key = key ?? String.Empty;
        }

        /// <summary>
        /// The ObjectStorageDirectoryInfo for the root of the S3 bucket.
        /// </summary>
        public ObjectStorageDirectoryInfo Bucket
        {
            get
            {
                return new ObjectStorageDirectoryInfo(client, bucket, "");
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
                if (String.IsNullOrEmpty(bucket))
                {
                    return true;
                }
                else if (String.IsNullOrEmpty(key))
                {
                    var getBucketRequest = new GetBucketRequest
                    {
                        NamespaceName = this.namespaceName,
                        BucketName = this.bucket
                    };

                    try
                    {
                        client.GetBucket(getBucketRequest);
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
                        NamespaceName = this.namespaceName,
                        BucketName = this.bucket,
                        Delimiter = "/",
                        Prefix = ObjectStorageHelper.EncodeKey(key),
                        Limit = 1
                    };
                    var response = client.ListObjects(request);
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
                return string.Format(CultureInfo.InvariantCulture, "{0}:\\{1}", bucket, key);
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
                if (!String.IsNullOrEmpty(bucket))
                {
                    if (String.IsNullOrEmpty(key))
                    {
                        ret = bucket;
                    }
                    else
                    {
                        int end = key.LastIndexOf('\\');
                        int start = key.LastIndexOf('\\', end - 1);
                        return key.Substring(start + 1, end - start - 1);
                    }
                }
                return ret;
            }
        }

        /// <summary>
        /// Return the S3DirectoryInfo of the parent directory.
        /// </summary>
        public ObjectStorageDirectoryInfo Parent
        {
            get
            {
                ObjectStorageDirectoryInfo ret = null;
                if (!String.IsNullOrEmpty(bucket) && !String.IsNullOrEmpty(key))
                {
                    int last = key.LastIndexOf('\\');
                    int secondlast = key.LastIndexOf('\\', last - 1);
                    if (secondlast == -1)
                    {
                        ret = Bucket;
                    }
                    else
                    {
                        var bucketName = key.Substring(0, secondlast);
                        ret = new ObjectStorageDirectoryInfo(Client, bucket, bucketName);
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
        /// Returns the S3DirectroyInfo for the S3 account.
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
                return ObjectStorageHelper.EncodeKey(key);
            }
        }

        /// <summary>
        /// Enumerate the files of this directory.
        /// </summary>
        /// <exception cref="T:System.Net.WebException"></exception>
        /// <returns>An enumerable collection of files.</returns>
        public IEnumerable<ObjectStorageFileInfo> EnumerateFiles()
        {
            return EnumerateFiles("*", SearchOption.TopDirectoryOnly);
        }

        /// <summary>
        /// Enumerate the sub directories of this directory.
        /// </summary>
        /// <param name="searchPattern">The search string. The default pattern is "*", which returns all files.</param>
        /// <exception cref="T:System.Net.WebException"></exception>
        /// <returns>An enumerable collection of files that matches searchPattern.</returns>
        public IEnumerable<ObjectStorageFileInfo> EnumerateFiles(string searchPattern)
        {
            return EnumerateFiles(searchPattern, SearchOption.TopDirectoryOnly);
        }

        /// <summary>
        /// Enumerate the files of this directory.
        /// </summary>
        /// <param name="searchPattern">The search string. The default pattern is "*", which returns all files.</param>
        /// <param name="searchOption">One of the enumeration values that specifies whether the search operation should include only the current directory or all subdirectories. The default value is TopDirectoryOnly.</param>
        /// <exception cref="T:System.Net.WebException"></exception>
        /// <returns>An enumerable collection of files that matches searchPattern and searchOption.</returns>
        public IEnumerable<ObjectStorageFileInfo> EnumerateFiles(string searchPattern, SearchOption searchOption)
        {
            IEnumerable<ObjectStorageFileInfo> files = null;
            if (String.IsNullOrEmpty(bucket))
            {
                files = new List<ObjectStorageFileInfo>();
            }
            else
            {
                var metaFiles = GetOciObjects(key, searchOption);

                files = new EnumerableConverter<ObjectSummary, ObjectStorageFileInfo>
                    (metaFiles,
                    o => new ObjectStorageFileInfo(client, namespaceName, bucket, ObjectStorageHelper.DecodeKey(o.Name)));
            }

            //filter based on search pattern
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
        /// Enumerate the sub directories of this directory.
        /// </summary>
        /// <exception cref="T:System.Net.WebException"></exception>
        /// <exception cref="T:Amazon.S3.AmazonS3Exception"></exception>
        /// <returns>An enumerable collection of directories.</returns>
        public IEnumerable<ObjectStorageDirectoryInfo> EnumerateDirectories()
        {
            return EnumerateDirectories("*", SearchOption.TopDirectoryOnly);
        }

        /// <summary>
        /// Enumerate the sub directories of this directory.
        /// </summary>
        /// <param name="searchPattern">The search string. The default pattern is "*", which returns all directories.</param>
        /// <exception cref="T:System.Net.WebException"></exception>
        /// <exception cref="T:Amazon.S3.AmazonS3Exception"></exception>
        /// <returns>An enumerable collection of directories that matches searchPattern.</returns>
        public IEnumerable<ObjectStorageDirectoryInfo> EnumerateDirectories(string searchPattern)
        {
            return EnumerateDirectories(searchPattern, SearchOption.TopDirectoryOnly);
        }

        /// <summary>
        /// Enumerate the sub directories of this directory.
        /// </summary>
        /// <param name="searchPattern">The search string. The default pattern is "*", which returns all directories.</param>
        /// <param name="searchOption">One of the enumeration values that specifies whether the search operation should include only the current directory or all subdirectories. The default value is TopDirectoryOnly.</param>
        /// <exception cref="T:System.Net.WebException"></exception>
        /// <exception cref="T:Amazon.S3.AmazonS3Exception"></exception>
        /// <returns>An enumerable collection of directories that matches searchPattern and searchOption.</returns>
        public IEnumerable<ObjectStorageDirectoryInfo> EnumerateDirectories(string searchPattern, SearchOption searchOption)
        {
            IEnumerable<ObjectStorageDirectoryInfo> folders = null;
            if (String.IsNullOrEmpty(bucket))
            {
                var request = new ListBucketsRequest();
                folders = Client.ListBuckets(request).Items
                    .ConvertAll(bucket => new ObjectStorageDirectoryInfo(Client, NamespaceName, bucket.Name, ""));
            }
            else
            {
                var prefixs = GetOciPrefixs(key, searchOption);

                folders = prefixs
                    .ConvertAll(f => new ObjectStorageDirectoryInfo(Client, NamespaceName, bucket, ObjectStorageHelper.DecodeKey(f)));
            }

            //filter based on search pattern
            var regEx = WildcardToRegex(searchPattern);
            folders = folders.Where(f => Regex.IsMatch(f.Name, regEx, RegexOptions.IgnoreCase));
            return folders;
        }

        /// <summary>
        /// Enumerate the files of this directory.
        /// </summary>
        /// <exception cref="T:System.Net.WebException"></exception>
        public IEnumerable<IObjectStorageFileSystemInfo> EnumerateFileSystemInfos()
        {
            return EnumerateFileSystemInfos("*", SearchOption.TopDirectoryOnly);
        }

        /// <summary>
        /// Enumerate the files of this directory.
        /// </summary>
        /// <param name="searchPattern">The search string. The default pattern is "*", which returns all files.</param>
        /// <exception cref="T:System.Net.WebException"></exception>
        public IEnumerable<IObjectStorageFileSystemInfo> EnumerateFileSystemInfos(string searchPattern)
        {
            return EnumerateFileSystemInfos(searchPattern, SearchOption.TopDirectoryOnly);
        }

        /// <summary>
        /// Enumerate the files of this directory.
        /// </summary>
        /// <param name="searchPattern">The search string. The default pattern is "*", which returns all files.</param>
        /// <param name="searchOption">One of the enumeration values that specifies whether the search operation should include only the current directory or all subdirectories. The default value is TopDirectoryOnly.</param>
        /// <exception cref="T:System.Net.WebException"></exception>
        public IEnumerable<IObjectStorageFileSystemInfo> EnumerateFileSystemInfos(string searchPattern, SearchOption searchOption)
        {
            IEnumerable<IObjectStorageFileSystemInfo> files = EnumerateFiles(searchPattern, searchOption).Cast<IObjectStorageFileSystemInfo>();
            IEnumerable<IObjectStorageFileSystemInfo> folders = EnumerateDirectories(searchPattern, searchOption).Cast<IObjectStorageFileSystemInfo>();

            return files.Concat(folders);
        }

        /// <summary>
        /// バケット内のオブジェクトを得る
        /// </summary>
        /// <param name="prefix"></param>
        /// <param name="searchOption"></param>
        /// <param name="nextStartWith"></param>
        /// <returns></returns>
        private List<ObjectSummary> GetOciObjects(string prefix, SearchOption searchOption, string nextStartWith = "")
        {
            var res = new List<ObjectSummary>();

            var listObjectsRequest = new ListObjectsRequest()
            {
                NamespaceName = namespaceName,
                BucketName = bucket,
                Start = nextStartWith,
                Delimiter = "/",
                Prefix = ObjectStorageHelper.EncodeKey(prefix),
                Fields = new List<string> { "name", "size", "timeCreated", "md5" },
                Limit = 1000
            };

            var objects = Client.ListObjects(listObjectsRequest);

            res.AddRange(objects.ListObjects.Objects);

            // next check
            if (!string.IsNullOrEmpty(objects.ListObjects.NextStartWith))
            {
                res.AddRange(GetOciObjects(ObjectStorageHelper.DecodeKey(prefix), searchOption, objects.ListObjects.NextStartWith));
            }

            // all sub prefix
            if (searchOption == SearchOption.AllDirectories)
            {
                if (objects.ListObjects.Prefixes.Count > 0)
                {
                    foreach (var pre in objects.ListObjects.Prefixes)
                    {
                        res.AddRange(GetOciObjects(pre, searchOption));
                    }
                }
            }

            return res;
        }

        private List<string> GetOciPrefixs(string prefix, SearchOption searchOption, string nextStartWith = "")
        {
            var res = new List<string>();

            var listObjectsRequest = new ListObjectsRequest()
            {
                NamespaceName = namespaceName,
                BucketName = bucket,
                Start = nextStartWith,
                Delimiter = "/",
                Prefix = ObjectStorageHelper.EncodeKey(prefix),
                Fields = new List<string> { "name" },
                Limit = 1
            };

            var objects = Client.ListObjects(listObjectsRequest);

            res.AddRange(objects.ListObjects.Prefixes);

            // next check
            if (!string.IsNullOrEmpty(objects.ListObjects.NextStartWith))
            {
                res.AddRange(GetOciPrefixs(ObjectStorageHelper.DecodeKey(prefix), searchOption, objects.ListObjects.NextStartWith));
            }

            // all sub prefix
            if (searchOption == SearchOption.AllDirectories)
            {
                if (objects.ListObjects.Prefixes.Count > 0)
                {
                    foreach (var pre in objects.ListObjects.Prefixes)
                    {
                        res.AddRange(GetOciPrefixs(pre, searchOption));
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
            if (String.IsNullOrEmpty(bucket))
            {
                throw new NotSupportedException();
            }

            if (recursive)
            {
                ListObjectsRequest listRequest = new ListObjectsRequest
                {
                    NamespaceName = namespaceName,
                    BucketName = bucket,
                    Prefix = ObjectStorageHelper.EncodeKey(this.key)
                };

                DeleteObjectsRequest deleteRequest = new DeleteObjectsRequest
                {
                    NamespaceName = namespaceName,
                    BucketName = bucket,
                    Objects = new List<TargetDelete>()
                };

                ListObjectsResponse listResponse;
                do
                {
                    listResponse = client.ListObjects(listRequest);

                    foreach (var obj in listResponse.ListObjects.Objects)
                    {
                        deleteRequest.Objects.Add(new TargetDelete { ObjectName = obj.Name });
                        if (deleteRequest.Objects.Count >= MULTIPLE_OBJECT_DELETE_LIMIT)
                        {
                            client.DeleteObjects(deleteRequest);
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
                    client.DeleteObjects(deleteRequest);
                }
            }

            if (String.IsNullOrEmpty(key) && Exists)
            {
                var request = new DeleteBucketRequest { BucketName = bucket };
                client.DeleteBucket(request);
            }
            else
            {
                if (!EnumerateFileSystemInfos().GetEnumerator().MoveNext() && Exists)
                {
                    var request = new DeleteObjectRequest
                    {
                        NamespaceName = namespaceName,
                        BucketName = bucket,
                        ObjectName = ObjectStorageHelper.EncodeKey(key)
                    };

                    client.DeleteObject(request);
                }
            }
        }

        /// <summary>
        /// Creating and deleting buckets can sometimes take a little bit of time.  To make sure
        /// users of this API do not experience the side effects of the eventual consistency
        /// we block until the state change has happened.
        /// </summary>
        /// <param name="exists"></param>
        private async Task WaitTillBucketStateIsConsistent(bool exists)
        {
            int success = 0;
            bool currentState = false;
            DateTime start = DateTime.UtcNow;

            ListBucketsRequest listBucketsRequest = new ListBucketsRequest
            {
                NamespaceName = namespaceName,
                CompartmentId = client.GetTenancyId()
            };
            do
            {
                List<BucketSummary> buckets = (await clientAsync.ListBuckets(listBucketsRequest)).Items;
                currentState = buckets.FirstOrDefault(x => string.Equals(x.Name, bucket)) != null;

                if (currentState == exists)
                {
                    success++;

                    if (success == EVENTUAL_CONSISTENCY_SUCCESS_IN_ROW)
                    {
                        break;
                    }
                }
                else
                {
                    success = 0;
                }

                Thread.Sleep(EVENTUAL_CONSISTENCY_POLLING_PERIOD);

            } while ((DateTime.UtcNow - start).TotalMilliseconds < EVENTUAL_CONSISTENCY_MAX_WAIT);
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

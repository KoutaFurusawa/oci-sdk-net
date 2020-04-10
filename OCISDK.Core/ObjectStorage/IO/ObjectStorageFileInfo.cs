using OCISDK.Core.ObjectStorage.Request;
using OCISDK.Core.ObjectStorage.Response;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OCISDK.Core.ObjectStorage.IO
{
    /// <summary>
    /// ObjectStorageFileInfo
    /// </summary>
    public class ObjectStorageFileInfo : IObjectStorageFileSystemInfo
    {
        private IObjectStorageClient client;
        private string namespaceName;
        private string bucket;
        private string key;

        /// <summary>
        /// Initialize a new instance of the ObjectStorageFileInfo class for the specified ObjectStorage bucket and ObjectStorage object key.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="namespaceName"></param>
        /// <param name="bucket"></param>
        /// <param name="key"></param>
        public ObjectStorageFileInfo(IObjectStorageClient client, string namespaceName, string bucket, string key)
        {
            this.client = client ?? throw new ArgumentNullException("client");

            if (string.IsNullOrEmpty(namespaceName))
            {
                throw new ArgumentNullException("namespaceName");
            }
            if (string.IsNullOrEmpty(bucket))
            {
                throw new ArgumentNullException("bucket");
            }
            if (string.IsNullOrEmpty(key) || string.Equals(key, "\\"))
            {
                throw new ArgumentNullException("key");
            }

            if (key.EndsWith("\\", StringComparison.Ordinal))
            {
                throw new ArgumentException("key is a directory name");
            }

            this.namespaceName = namespaceName;
            this.bucket = bucket;
            this.key = key;
        }

        /// <summary>
        /// Returns the parent ObjectStorageDirectoryInfo.
        /// </summary>
        public ObjectStorageDirectoryInfo Directory
        {
            get
            {
                int index = key.LastIndexOf('\\');
                string directoryName = null;
                if (index >= 0)
                    directoryName = key.Substring(0, index);
                return new ObjectStorageDirectoryInfo(client, namespaceName, bucket, directoryName);
            }
        }

        /// <summary>
        /// The full name of parent directory.
        /// </summary>
        public string DirectoryName
        {
            get
            {
                return Directory.FullName;
            }
        }

        /// <summary>
        /// Checks ObjectStorage if the file exists in ObjectStorage and return true if it does.
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
                var request = new HeadObjectRequest
                {
                    NamespaceName = namespaceName,
                    BucketName = bucket,
                    ObjectName = ObjectStorageHelper.EncodeKey(key)
                };

                // If the object doesn't exist then a "NotFound" will be thrown
                client.HeadObject(request);
                return true;
            }
            catch (WebException we)
            {
                if (we.Status.Equals(WebExceptionStatus.ProtocolError) && ((HttpWebResponse)we.Response).StatusCode == HttpStatusCode.NotFound)
                {
                    bucketExists = false;
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Gets the file's extension.
        /// </summary>
        public string Extension
        {
            get
            {
                int index = Name.LastIndexOf('.');
                if (index == -1 || this.Name.Length <= (index + 1))
                    return null;

                return this.Name.Substring(index + 1);
            }
        }

        /// <summary>
        /// Returns the full path including the bucket.
        /// </summary>
        public string FullName
        {
            get
            {
                return string.Format(CultureInfo.InvariantCulture, "{0}:\\{1}", bucket, key);
            }
        }

        /// <summary>
        /// Returns the last time the file was modified.
        /// </summary>
        /// <exception cref="T:System.Net.WebException"></exception>
        public DateTime LastWriteTime
        {
            get
            {
                DateTime ret = DateTime.MinValue;
                if (Exists)
                {
                    var request = new GetObjectRequest
                    {
                        NamespaceName = namespaceName,
                        BucketName = bucket,
                        ObjectName = ObjectStorageHelper.EncodeKey(key)
                    };
                    var response = client.GetObject(request);
                    ret = DateTime.Parse(response.LastModified);
                }
                return ret;
            }
        }

        /// <summary>
        /// Returns the content length of the file.
        /// </summary>
        /// <exception cref="T:System.Net.WebException"></exception>
        public long Length
        {
            get
            {
                long ret = 0;
                if (Exists)
                {
                    var request = new GetObjectRequest
                    {
                        NamespaceName = namespaceName,
                        BucketName = bucket,
                        ObjectName = ObjectStorageHelper.EncodeKey(key)
                    };
                    var response = client.GetObject(request);
                    if (response.ContentLength.HasValue)
                    {
                        ret = response.ContentLength.Value;
                    }
                }
                return ret;
            }
        }

        /// <summary>
        /// Returns the file name without its directory name.
        /// </summary>
        public string Name
        {
            get
            {
                int index = key.LastIndexOf('\\');
                return key.Substring(index + 1);
            }
        }

        /// <summary>
        /// Returns the type of file system element.
        /// </summary>
        public FileSystemType Type
        {
            get
            {
                return FileSystemType.File;
            }
        }

        /// <summary>
        /// Copies from ObjectStorage to the local file system.  
        /// If the file already exists on the local file system than an ArgumentException is thrown.
        /// </summary>
        /// <param name="destFileName">The path where to copy the file to.</param>
        /// <exception cref="T:System.IO.IOException">If the file already exists locally.</exception>
        /// <exception cref="T:System.Net.WebException"></exception>
        /// <returns>FileInfo for the local file where file is copied to.</returns>
        public FileInfo CopyToLocal(string destFileName)
        {
            return CopyToLocal(destFileName, false);
        }

        /// <summary>
        /// Copies from ObjectStorage to the local file system.  
        /// If the file already exists on the local file system and overwrite is set to false than an ArgumentException is thrown.
        /// </summary>
        /// <param name="destFileName">The path where to copy the file to.</param>
        /// <param name="overwrite">Determines whether the file can be overwritten.</param>
        /// <exception cref="T:System.IO.IOException">If the file already exists locally and overwrite is set to false.</exception>
        /// <exception cref="T:System.Net.WebException"></exception>
        /// <returns>FileInfo for the local file where file is copied to.</returns>
        public FileInfo CopyToLocal(string destFileName, bool overwrite)
        {
            if (!overwrite)
            {
                if (new FileInfo(destFileName).Exists)
                {
                    throw new IOException("File already exists");
                }
            }

            var getObjectRequest = new GetObjectRequest
            {
                NamespaceName = namespaceName,
                BucketName = bucket,
                ObjectName = ObjectStorageHelper.EncodeKey(key)
            };

            client.DownloadObject(getObjectRequest, destFileName);

            return new FileInfo(destFileName);
        }

        /// <summary>
        /// Copies the file from the local file system to ObjectStorage.
        /// If the file already exists in ObjectStorage than an ArgumentException is thrown.
        /// </summary>
        /// <param name="srcFileName">Location of the file on the local file system to copy.</param>
        /// <exception cref="T:System.IO.IOException">If the file already exists in ObjectStorage.</exception>
        /// <exception cref="T:System.Net.WebException"></exception>
        public ObjectStorageFileInfo CopyFromLocal(string srcFileName)
        {
            return CopyFromLocal(srcFileName, false);
        }

        /// <summary>
        /// Copies the file from the local file system to ObjectStorage.
        /// If the file already exists in ObjectStorage and overwrite is set to false than an ArgumentException is thrown.
        /// </summary>
        /// <param name="srcFileName">Location of the file on the local file system to copy.</param>
        /// <param name="overwrite">Determines whether the file can be overwritten.</param>
        /// <exception cref="T:System.IO.IOException">If the file already exists in ObjectStorage and overwrite is set to false.</exception>
        /// <exception cref="T:System.Net.WebException"></exception>
        public ObjectStorageFileInfo CopyFromLocal(string srcFileName, bool overwrite)
        {
            if (!overwrite)
            {
                if (Exists)
                {
                    throw new IOException("File already exists");
                }
            }

            var putObjectRequest = new PutObjectRequest
            {
                NamespaceName = namespaceName,
                BucketName = bucket,
                ObjectName = ObjectStorageHelper.EncodeKey(key)
            };

            using (var stream = File.Open(srcFileName, FileMode.Open))
            {
                putObjectRequest.UploadPartBody = stream;
                var updateRes = client.PutObject(putObjectRequest);
            }

            return this;
        }

        /// <summary>
        /// Deletes the from ObjectStorage.
        /// </summary>
        /// <exception cref="T:System.Net.WebException"></exception>
        public void Delete()
        {
            if (Exists)
            {
                var deleteObjectRequest = new DeleteObjectRequest
                {
                    NamespaceName = namespaceName,
                    BucketName = bucket,
                    ObjectName = ObjectStorageHelper.EncodeKey(key)
                };
                try
                {
                    client.DeleteObject(deleteObjectRequest);
                }
                catch (WebException we)
                {
                    if (!(we.Status.Equals(WebExceptionStatus.ProtocolError) && ((HttpWebResponse)we.Response).StatusCode == HttpStatusCode.NotFound))
                    {
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Moves the file from ObjectStorage to the local file system in the location indicated by the path parameter.
        /// </summary>
        /// <param name="path">The location on the local file system to move the file to.</param>
        /// <exception cref="T:System.IO.IOException">If the file already exists locally.</exception>
        /// <exception cref="T:System.ArgumentException"></exception>
        /// <exception cref="T:System.Net.WebException"></exception>
        public FileInfo MoveToLocal(string path)
        {
            FileInfo ret = CopyToLocal(path, false);
            Delete();
            return ret;
        }

        /// <summary>
        /// Moves the file from the local file system to ObjectStorage in this directory.
        /// If the file already exists in ObjectStorage than an ArgumentException is thrown.
        /// </summary>
        /// <param name="path">The local file system path where the files are to be moved.</param>
        /// <exception cref="T:System.IO.IOException">If the file already exists locally.</exception>
        /// <exception cref="T:System.ArgumentException"></exception>
        /// <exception cref="T:System.Net.WebException"></exception>
        public ObjectStorageFileInfo MoveFromLocal(string path)
        {
            ObjectStorageFileInfo ret = CopyFromLocal(path, false);
            File.Delete(path);
            return ret;
        }

        /// <summary>
        /// Implement the ToString method.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return FullName;
        }

        internal IObjectStorageClient Client
        {
            get
            {
                return client;
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
        /// Original key string
        /// </summary>
        public string OriginalKey
        {
            get
            {
                return ObjectStorageHelper.EncodeKey(key);
            }
        }

        private bool SameClient(ObjectStorageFileInfo otherFile)
        {
            return client.Equals(otherFile.Client);
        }
    }
}

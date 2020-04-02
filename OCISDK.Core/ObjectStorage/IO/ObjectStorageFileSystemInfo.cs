using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCISDK.Core.ObjectStorage.IO
{
    /// <summary>
    /// Enumeration indicated whether a file system element is a file or directory.
    /// </summary>
    public enum FileSystemType
    {
        /// <summary>
        /// Type is a directory.
        /// </summary>
        Directory,
        /// <summary>
        /// Type is a file.
        /// </summary>
        File
    };

    /// <summary>
    /// Common interface for both ObjectStorageFileInfo and S3DirectoryInfo.
    /// </summary>
    public interface IObjectStorageFileSystemInfo
    {
        /// <summary>
        /// Returns true if the item exists in ObjectStorage.
        /// </summary>
        bool Exists
        {
            get;
        }

        /// <summary>
        /// Returns the extension of the item.
        /// </summary>
        string Extension
        {
            get;
        }

        /// <summary>
        /// Returns the fully qualified path to the item.
        /// </summary>
        string FullName
        {
            get;
        }

        /// <summary>
        /// Returns the name of the item without parent information.
        /// </summary>
        string Name
        {
            get;
        }

        /// <summary>
        /// Indicates what type of item this object represents.
        /// </summary>
        FileSystemType Type
        {
            get;
        }

        /// <summary>
        /// Deletes this item.
        /// </summary>
        void Delete();
    }
}

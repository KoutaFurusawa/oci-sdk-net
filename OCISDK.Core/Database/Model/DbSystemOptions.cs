using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace OCISDK.Core.Database.Model
{
    /// <summary>
    /// The DB system options.
    /// </summary>
    public class DbSystemOptions
    {
        /// <summary>
        /// The storage option used in DB system. For 1-node VM systems, you can specify either Automatic Storage Management (ASM) or Logical Volume Manager (LVM). 
        /// For more information, see Bare Metal and Virtual Machine DB Systems.
        /// <para>Required: no</para>
        /// </summary>
        public string StorageManagement { get; set; }
    }
}
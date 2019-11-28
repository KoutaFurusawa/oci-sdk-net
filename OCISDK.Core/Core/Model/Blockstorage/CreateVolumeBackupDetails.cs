using OCISDK.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace OCISDK.Core.Core.Model.Blockstorage
{
    /// <summary>
    /// CreateVolumeBackupDetails
    /// </summary>
    public class CreateVolumeBackupDetails
    {
        /// <summary>
        /// The OCID of the volume that needs to be backed up.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string VolumeId { get; set; }

        /// <summary>
        /// A user-friendly name for the volume backup. Does not have to be unique and it's changeable. 
        /// Avoid entering confidential information.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The type of backup to create. If omitted, defaults to INCREMENTAL.
        /// <para>Required: no</para>
        /// </summary>
        public TypeParam Type { get; set; }

        /// <summary>
        /// Type ExpandableEnum
        /// </summary>
        public class TypeParam : ExpandableEnum<TypeParam>
        {
            /// <summary>
            /// Type ExpandableEnum
            /// </summary>
            /// <param name="value"></param>
            public TypeParam(string value) : base(value) { }

            /// <summary>
            /// parse
            /// </summary>
            /// <param name="value"></param>
            public static implicit operator TypeParam(string value)
            {
                return Parse(value);
            }

            /// <summary>
            /// TIMECREATED
            /// </summary>
            public static readonly TypeParam FULL = new TypeParam("FULL");

            /// <summary>
            /// DISPLAYNAME
            /// </summary>
            public static readonly TypeParam INCREMENTAL = new TypeParam("INCREMENTAL");
        }

        /// <summary>
        /// Free-form tags for this resource. Each tag is a simple key-value pair with no predefined name, type, or namespace. 
        /// For more information, see Resource Tags.
        /// <para>Required: no</para>
        /// </summary>
        public IDictionary<string, string> FreeformTags { get; set; }

        /// <summary>
        /// Defined tags for this resource. Each key is predefined and scoped to a namespace. 
        /// For more information, see Resource Tags.
        /// <para>Required: no</para>
        /// </summary>
        public IDictionary<string, IDictionary<string, string>> DefinedTags { get; set; }
    }
}

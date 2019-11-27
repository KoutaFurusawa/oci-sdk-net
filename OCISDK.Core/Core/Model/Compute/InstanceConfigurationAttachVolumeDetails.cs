using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Model.Compute
{
    /// <summary>
    /// InstanceConfigurationIscsiAttachVolumeDetails
    /// </summary>
    public class InstanceConfigurationAttachVolumeDetails
    {
        /// <summary>
        /// A user-friendly name. Does not have to be unique, and it cannot be changed. Avoid entering confidential information.
        /// <para>Required: no</para>
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Whether the attachment should be created in read-only mode.
        /// <para>Required: no</para>
        /// </summary>
        public bool? IsReadOnly { get; set; }

        /// <summary>
        /// The type of volume. The only supported values are "iscsi" and "paravirtualized".
        /// <para>Required: yes</para>
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Whether to use CHAP authentication for the volume attachment. Defaults to false.
        /// <para>Required: no</para>
        /// </summary>
        public bool? UseChap { get; set; }
    }
}

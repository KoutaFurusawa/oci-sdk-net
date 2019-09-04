﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.src.Core.Request.Blockstorage
{
    public class GetVolumeBackupPolicyRequest
    {
        /// <summary>
        /// The OCID of the volume backup policy.
        /// <para>Required: yes</para>
        /// </summary>
        public string PolicyId { get; set; }
    }
}
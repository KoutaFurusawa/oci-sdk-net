﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.src.DNS.Model
{
    public class ChangeZoneCompartmentDetails
    {
        /// <summary>
        /// The OCID of the compartment into which the zone should be moved.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string CompartmentId{ get; set; }
    }
}
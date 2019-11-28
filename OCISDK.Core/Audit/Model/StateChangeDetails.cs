using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace OCISDK.Core.Audit.Model
{
    /// <summary>
    /// A container object for state change attributes.
    /// </summary>
    public class StateChangeDetails
    {
        /// <summary>
        /// Provides the previous state of fields that may have changed during an operation. 
        /// To determine how the current operation changed a resource, compare the information in this attribute to current.
        /// <para>Required: no</para>
        /// </summary>
        public object Previous { get; set; }

        /// <summary>
        /// Provides the current state of fields that may have changed during an operation. 
        /// To determine how the current operation changed a resource, compare the information in this attribute to previous.
        /// <para>Required: no</para>
        /// </summary>
        public object Current { get; set; }
    }
}
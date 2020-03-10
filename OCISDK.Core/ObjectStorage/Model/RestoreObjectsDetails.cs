using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.ObjectStorage.Model
{
    /// <summary>
    /// RestoreObjectsDetails Reference
    /// </summary>
    public class RestoreObjectsDetails
    {
        /// <summary>
        /// An object that is in an archive storage tier and needs to be restored.
        /// <para>Required: yes</para>
        /// </summary>
        public string ObjectName { get; set; }

        /// <summary>
        /// The number of hours for which this object will be restored. By default objects will be restored for 24 hours. 
        /// You can instead configure the duration using the hours parameter.
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 240</para>
        /// </summary>
        public int Hours { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.ObjectStorage.Model
{
    /// <summary>
    /// The amount of time that objects in the bucket should be preserved for and which is calculated in relation to each object's Last-Modified timestamp. 
    /// If duration is not present, then there is no time limit and the objects in the bucket will be preserved indefinitely.
    /// </summary>
    public class Duration
    {
        /// <summary>
        /// The timeAmount is interpreted in units defined by the timeUnit parameter, and is calculated in relation to each object's Last-Modified timestamp.
        /// <para>Required: yes</para>
        /// </summary>
        public int TimeAmount { get; set; }

        /// <summary>
        /// The unit that should be used to interpret timeAmount.
        /// <para>Required: yes</para>
        /// </summary>
        public string TimeUnit { get; set; }
    }
}

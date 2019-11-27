using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace OCISDK.Core.Database.Model
{
    /// <summary>
    /// The shape of the DB system. 
    /// The shape determines resources to allocate to the DB system - CPU cores and memory for VM shapes; CPU cores, memory and storage for non-VM (or bare metal) shapes. 
    /// For a description of shapes, see DB System Launch Options. To use any of the API operations, you must be authorized in an IAM policy. 
    /// If you're not authorized, talk to an administrator. If you're an administrator who needs to write policies to give users access, see Getting Started with Policies.
    /// </summary>
    public class DbSystemShapeSummary
    {
        /// <summary>
        /// The maximum number of CPU cores that can be enabled on the DB system for this shape.
        /// <para>Required: yes</para>
        /// </summary>
        public int AvailableCoreCount { get; set; }

        /// <summary>
        /// The discrete number by which the CPU core count for this shape can be increased or decreased.
        /// <para>Required: no</para>
        /// </summary>
        public int? CoreCountIncrement { get; set; }

        /// <summary>
        /// The maximum number of database nodes available for this shape.
        /// <para>Required: no</para>
        /// </summary>
        public int? MaximumNodeCount { get; set; }

        /// <summary>
        /// The minimum number of CPU cores that can be enabled on the DB system for this shape.
        /// <para>Required: no</para>
        /// </summary>
        public int? MinimumCoreCount { get; set; }

        /// <summary>
        /// The minimum number of database nodes available for this shape.
        /// <para>Required: no</para>
        /// </summary>
        public int? MinimumNodeCount { get; set; }

        /// <summary>
        /// The name of the shape used for the DB system.
        /// <para>Required: yes</para>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Deprecated. Use name instead of shape.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string Shape { get; set; }

        /// <summary>
        /// The family of the shape used for the DB system.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string ShapeFamily { get; set; }
    }
}
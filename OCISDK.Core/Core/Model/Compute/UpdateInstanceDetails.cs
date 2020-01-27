using System.Collections.Generic;

namespace OCISDK.Core.Core.Model.Compute
{
    /// <summary>
    /// UpdateInstanceDetails
    /// </summary>
    public class UpdateInstanceDetails
    {
        /// <summary>
        /// A user-friendly name. Does not have to be unique, and it's changeable.
        /// Avoid entering confidential information.
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Custom metadata key/value string pairs that you provide. Any set of key/value pairs provided here will 
        /// completely replace the current set of key/value pairs in the 'metadata' field on the instance.
        /// <para>Required: no</para>
        /// </summary>
        public object Metadata { get; set; }

        /// <summary>
        /// Additional metadata key/value pairs that you provide. They serve the same purpose and functionality as 
        /// fields in the 'metadata' object.
        /// <para>Required: no</para>
        /// </summary>
        public object ExtendedMetadata { get; set; }

        /// <summary>
        /// Instance agent configuration options to choose for updating the instance
        /// <para>Required: no</para>
        /// </summary>
        public UpdateInstanceAgentConfigDetails AgentConfig { get; set; }

        /// <summary>
        /// The shape of the instance. The shape determines the number of CPUs and the amount of 
        /// memory allocated to the instance. For more information about how to change shapes, 
        /// and a list of shapes that are supported, see Changing the Shape of an Instance.
        /// 
        /// For details about the CPUs, memory, and other properties of each shape, see Compute Shapes.
        /// 
        /// The new shape must be compatible with the image that was used to launch the instance. 
        /// You can enumerate all available shapes and determine image compatibility by calling ListShapes.
        /// 
        /// If the instance is running when you change the shape, the instance is rebooted.
        /// <para>Required: no</para>
        /// </summary>
        public string Shape { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public IDictionary<string, string> FreeformTags { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public IDictionary<string, IDictionary<string, string>> DefinedTags { get; set; }
    }
}

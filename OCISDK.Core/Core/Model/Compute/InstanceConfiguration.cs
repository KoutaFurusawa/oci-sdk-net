using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Model.Compute
{
    /// <summary>
    /// An instance configuration is a template that defines the settings to use when creating Compute instances. 
    /// For more information about instance configurations, see Managing Compute Instances.
    /// </summary>
    public class InstanceConfiguration
    {
        /// <summary>
        /// The OCID of the compartment containing the instance configuration.
        /// <para>Required: yes</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// A user-friendly name for the instance configuration.
        /// <para>Required: no</para>
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The OCID of the instance configuration.
        /// <para>Required: yes</para>
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public InstanceConfigurationInstanceDetails InstanceDetails { get; set; }

        /// <summary>
        /// Parameters that were not specified when the instance configuration was created, but that are required to launch an instance from the instance configuration. 
        /// See the LaunchInstanceConfiguration operation.
        /// <para>Required: no</para>
        /// </summary>
        public List<string> DeferredFields { get; set; }

        /// <summary>
        /// The date and time the instance configuration was created, in the format defined by RFC3339.
        /// <para>Required: yes</para>
        /// </summary>
        public string TimeCreated { get; set; }

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

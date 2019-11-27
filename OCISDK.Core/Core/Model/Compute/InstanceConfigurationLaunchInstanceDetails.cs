using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Model.Compute
{
    /// <summary>
    /// 
    /// </summary>
    public class InstanceConfigurationLaunchInstanceDetails
    {

        /// <summary>
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string AvailabilityDomain { get; set; }

        /// <summary>
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// Details for creating a new VNIC.
        /// <para>Required: no</para>
        /// </summary>
        public InstanceConfigurationCreateVnicDetails CreateVnicDetails { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public object ExtendedMetadata { get; set; }

        /// <summary>
        /// A fault domain is a grouping of hardware and infrastructure within an availability domain. 
        /// Each availability domain contains three fault domains. Fault domains let you distribute your 
        /// instances so that they are not on the same physical hardware within a single availability domain. 
        /// A hardware failure or Compute hardware maintenance that affects one fault domain does not affect 
        /// instances in other fault domains.
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string FaultDomain { get; set; }

        /// <summary>
        /// Deprecated. Instead use hostnameLabel in CreateVnicDetails. If you provide both, the values must match.
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 63</para>
        /// </summary>
        public string HostnameLabel { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string ImageId { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 10240</para>
        /// </summary>
        public string IpxeScript { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public object Metadata { get; set; }

        /// <summary>
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string Shape { get; set; }

        /// <summary>
        /// Details for creating an instance
        /// <para>Required: no</para>
        /// </summary>
        public InstanceConfigurationInstanceSourceDetails SourceDetails { get; set; }
        
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

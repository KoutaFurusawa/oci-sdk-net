using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.UnpublishedService.Commercial.Model
{
    /// <summary>
    /// serviceEntitlementRegistrations
    /// </summary>
    public class ServiceEntitlementRegistrations
    {
        /// <summary>
        /// id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// compartmentId
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// idcsInstanceId
        /// </summary>
        public string IdcsInstanceId { get; set; }

        /// <summary>
        /// dataCenters
        /// </summary>
        public List<DataCenters> DataCenters { get; set; }

        /// <summary>
        /// dataRegion
        /// </summary>
        public DataRegion DataRegion { get; set; }

        /// <summary>
        /// serviceDefinition
        /// </summary>
        public ServiceDefinitionGroups ServiceDefinition { get; set; }

        /// <summary>
        /// serviceInstanceEndPoints
        /// </summary>
        public List<ServiceInstanceEndPoint> ServiceInstanceEndPoints { get; set; }

        /// <summary>
        /// state
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// customAttributes
        /// </summary>
        public List<CustomAttribute> CustomAttributes { get; set; }
    }

    /// <summary>
    /// DataCenters
    /// </summary>
    public class DataCenters
    {
        /// <summary>
        /// id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// name
        /// </summary>
        public string Name { get; set; }
    }

    /// <summary>
    /// DataRegion
    /// </summary>
    public class DataRegion
    {
        /// <summary>
        /// id
        /// </summary>
        public string Id { get; set; }
    }

    /// <summary>
    /// ServiceDefinition
    /// </summary>
    public class ServiceDefinitionGroups
    {
        /// <summary>
        /// id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// displayName
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// shortDisplayName
        /// </summary>
        public string ShortDisplayName { get; set; }

        /// <summary>
        /// weight
        /// </summary>
        public int? Weight { get; set; }

        /// <summary>
        /// group
        /// </summary>
        public Group Group { get; set; }
    }

    /// <summary>
    /// Group
    /// </summary>
    public class Group
    {
        /// <summary>
        /// id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// displayName
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// weight
        /// </summary>
        public int? Weight { get; set; }
    }

    /// <summary>
    /// ServiceInstanceEndPoint
    /// </summary>
    public class ServiceInstanceEndPoint
    {
        /// <summary>
        /// type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// url
        /// </summary>
        public string Url { get; set; }
    }

    /// <summary>
    /// CustomAttribute
    /// </summary>
    public class CustomAttribute
    {
        /// <summary>
        /// name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// value
        /// </summary>
        public string Value { get; set; }
    }
}

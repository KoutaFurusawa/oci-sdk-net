using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.UnpublishedService.Commercial.Model
{
    /// purchaseEntitlements
    public class PurchaseEntitlements
    {
        /// <summary>
        /// subscription OCID
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// compartment OID
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// subscription name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// displayName
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// lifeCycleState
        /// </summary>
        public string LifeCycleState { get; set; }

        /// <summary>
        /// status
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// serviceDefinition
        /// </summary>
        public ServiceDefinition ServiceDefinition { get; set; }

        /// <summary>
        /// promotion
        /// </summary>
        public string Promotion { get; set; }

        /// <summary>
        /// operationItemsOverviews
        /// </summary>
        public string OperationItemsOverviews { get; set; }

        /// <summary>
        /// Account
        /// </summary>
        public Account Account { get; set; }

        /// <summary>
        /// CustomAttributes
        /// </summary>
        public List<CustomAttributes> CustomAttributes { get; set; }

        /// <summary>
        /// timeCreated
        /// </summary>
        public string TimeCreated { get; set; }

        /// <summary>
        /// timeModified
        /// </summary>
        public string TimeModified { get; set; }

        /// <summary>
        /// timeActivation
        /// </summary>
        public string TimeActivation { get; set; }

        /// <summary>
        /// timeTermination
        /// </summary>
        public string TimeTermination { get; set; }

        /// <summary>
        /// timeStart
        /// </summary>
        public string TimeStart { get; set; }

        /// <summary>
        /// timeOriginalStart
        /// </summary>
        public string TimeOriginalStart { get; set; }

        /// <summary>
        /// timeEnd
        /// </summary>
        public string TimeEnd { get; set; }

        /// <summary>
        /// csiNumber
        /// </summary>
        public string CsiNumber { get; set; }
    }

    /// <summary>
    /// serviceDefinition
    /// </summary>
    public class ServiceDefinition
    {
        /// <summary>
        /// serviceDefinition Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// serviceDefinition type
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
        public string Weight { get; set; }

        /// <summary>
        /// group
        /// </summary>
        public string Group { get; set; }
    }

    /// <summary>
    /// account
    /// </summary>
    public class Account
    {
        /// <summary>
        /// account name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// isSaaSCustomer
        /// </summary>
        public bool IsSaaSCustomer { get; set; }
    }

    /// <summary>
    /// CustomAttributes
    /// </summary>
    public class CustomAttributes
    {
        /// <summary>
        /// key name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// value
        /// </summary>
        public string Value { get; set; }
    }
}

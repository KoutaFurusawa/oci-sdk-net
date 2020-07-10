using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Usage.Model
{
    /// <summary>
    /// The usage store result.
    /// </summary>
    public class UsageSummary
    {
        /// <summary>
        /// The availability domain of the usage.
        /// <para>Required: no</para>
        /// </summary>
        public string Ad { get; set; }

        /// <summary>
        /// The compartment OCID.
        /// <para>Required: no</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// The compartment name.
        /// <para>Required: no</para>
        /// </summary>
        public string CompartmentName { get; set; }

        /// <summary>
        /// The compartment path, starting from root.
        /// <para>Required: no</para>
        /// </summary>
        public string CompartmentPath { get; set; }

        /// <summary>
        /// The computed cost.
        /// <para>Required: no</para>
        /// </summary>
        public string ComputedAmount { get; set; }

        /// <summary>
        /// The usage number.
        /// <para>Required: no</para>
        /// </summary>
        public double? ComputedQuantity { get; set; }

        /// <summary>
        /// The price currency.
        /// <para>Required: no</para>
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// The discretionary discount applied to the SKU.
        /// <para>Required: no</para>
        /// </summary>
        public double? Discount { get; set; }

        /// <summary>
        /// The SKU list rate (not discount).
        /// <para>Required: no</para>
        /// </summary>
        public double? ListRate { get; set; }

        /// <summary>
        /// The overage usage.
        /// <para>Required: no</para>
        /// </summary>
        public string Overage { get; set; }

        /// <summary>
        /// The SPM OverageFlag.
        /// <para>Required: no</para>
        /// </summary>
        public string OveragesFlag { get; set; }

        /// <summary>
        /// Platform for the cost.
        /// <para>Required: no</para>
        /// </summary>
        public string Platform { get; set; }

        /// <summary>
        /// The region of the usage.
        /// <para>Required: no</para>
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// The resource OCID that is incurring the cost.
        /// <para>Required: no</para>
        /// </summary>
        public string ResourceId { get; set; }

        /// <summary>
        /// The resource name that is incurring the cost.
        /// <para>Required: no</para>
        /// </summary>
        public string ResourceName { get; set; }

        /// <summary>
        /// The service name that is incurring the cost.
        /// <para>Required: no</para>
        /// </summary>
        public string Service { get; set; }

        /// <summary>
        /// The resource shape.
        /// <para>Required: no</para>
        /// </summary>
        public string Shape { get; set; }

        /// <summary>
        /// The SKU friendly name.
        /// <para>Required: no</para>
        /// </summary>
        public string SkuName { get; set; }

        /// <summary>
        /// The SKU part number.
        /// <para>Required: no</para>
        /// </summary>
        public string SkuPartNumber { get; set; }

        /// <summary>
        /// The subscription ID.
        /// <para>Required: no</para>
        /// </summary>
        public string SubscriptionId { get; set; }

        /// <summary>
        /// For grouping, a tag definition. For filtering, a definition and key.
        /// <para>Required: no</para>
        /// </summary>
        public List<TagDetails> Tags { get; set; }

        /// <summary>
        /// The usage end time.
        /// <para>Required: yes</para>
        /// </summary>
        public string TimeUsageEnded { get; set; }

        /// <summary>
        /// The usage start time.
        /// <para>Required: yes</para>
        /// </summary>
        public string TimeUsageStarted { get; set; }

        /// <summary>
        /// The usage unit.
        /// <para>Required: no</para>
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// The price per unit.
        /// <para>Required: no</para>
        /// </summary>
        public double? UnitPrice { get; set; }

        /// <summary>
        /// The resource size being metered.
        /// <para>Required: no</para>
        /// </summary>
        public double? Weight { get; set; }
    }
}

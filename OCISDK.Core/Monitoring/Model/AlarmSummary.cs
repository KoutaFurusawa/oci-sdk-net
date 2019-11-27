using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Monitoring.Model
{
    /// <summary>
    /// A summary of properties for the specified alarm. For information about alarms, see Alarms Overview.
    /// 
    /// To use any of the API operations, you must be authorized in an IAM policy. 
    /// If you're not authorized, talk to an administrator. 
    /// If you're an administrator who needs to write policies to give users access, see Getting Started with Policies.
    /// 
    /// For information about endpoints and signing API requests, 
    /// see About the API. For information about available SDKs and tools, see SDKS and Other Tools.
    /// </summary>
    public class AlarmSummary
    {
        /// <summary>
        /// The OCID of the alarm.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// A user-friendly name for the alarm. It does not have to be unique, and it's changeable. Avoid entering confidential information.
        /// 
        /// This name is sent as the title for notifications related to this alarm.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        /// <example>High CPU Utilization</example>
        public string DisplayName { get; set; }

        /// <summary>
        /// The OCID of the compartment containing the alarm.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// The OCID of the compartment containing the metric being evaluated by the alarm.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string MetricCompartmentId { get; set; }

        /// <summary>
        /// When true, the alarm evaluates metrics from all compartments and subcompartments. 
        /// The parameter can only be set to true when metricCompartmentId is the tenancy OCID (the tenancy is the root compartment). 
        /// A true value requires the user to have tenancy-level permissions. 
        /// If this requirement is not met, then the call is rejected. When false, the alarm evaluates metrics from only the compartment specified in metricCompartmentId. 
        /// Default is false.
        /// <para>Required: no</para>
        /// </summary>
        public bool? MetricCompartmentIdInSubtree { get; set; }

        /// <summary>
        /// The source service or application emitting the metric that is evaluated by the alarm.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string Namespace { get; set; }

        /// <summary>
        /// The Monitoring Query Language (MQL) expression to evaluate for the alarm. 
        /// The Alarms feature of the Monitoring service interprets results for each returned time series as Boolean values, where zero represents false and a non-zero value represents true. 
        /// A true value means that the trigger rule condition has been met. 
        /// The query must specify a metric, statistic, interval, and trigger rule (threshold or absence). Supported values for interval: 1m-60m (also 1h). 
        /// You can optionally specify dimensions and grouping functions. 
        /// Supported grouping functions: grouping(), groupBy(). 
        /// For details about Monitoring Query Language (MQL), see Monitoring Query Language (MQL) Reference. For available dimensions, review the metric definition for the supported service. 
        /// See Supported Services.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 1000</para>
        /// </summary>
        public string Query { get; set; }

        /// <summary>
        /// The perceived type of response required when the alarm is in the "FIRING" state.
        /// <para>Required: yes</para>
        /// </summary>
        /// <example>CRITICAL</example>
        public string Severity { get; set; }

        /// <summary>
        /// A list of destinations to which the notifications for this alarm will be delivered. 
        /// Each destination is represented by an OCID related to the supported destination service. 
        /// For example, a destination using the Notifications service is represented by a topic OCID. Supported destination services: Notifications Service. 
        /// Limit: One destination per supported destination service.
        /// <para>Required: yes</para>
        /// </summary>
        public List<string> Destinations { get; set; }

        /// <summary>
        /// The configuration details for suppressing an alarm.
        /// <para>Required: no</para>
        /// </summary>
        public SuppressionModel Suppression { get; set; }

        /// <summary>
        /// Whether the alarm is enabled.
        /// <para>Required: yes</para>
        /// </summary>
        public bool IsEnabled { get; set; }

        /// <summary>
        /// Simple key-value pair that is applied without any predefined name, type or scope. Exists for cross-compatibility only. 
        /// <para>Required: no</para>
        /// </summary>
        public IDictionary<string, string> FreeformTags { get; set; }

        /// <summary>
        /// Usage of predefined tag keys. These predefined keys are scoped to namespaces. 
        /// <para>Required: no</para>
        /// </summary>
        public IDictionary<string, IDictionary<string, string>> DefinedTags { get; set; }

        /// <summary>
        /// The current lifecycle state of the alarm.
        /// <para>Required: yes</para>
        /// </summary>
        public string LifecycleState { get; set; }

    }
}

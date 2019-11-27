using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Monitoring.Model
{
    /// <summary>
    /// The properties that define an alarm. For information about alarms, see Alarms Overview.
    /// 
    /// To use any of the API operations, you must be authorized in an IAM policy. 
    /// If you're not authorized, talk to an administrator. 
    /// If you're an administrator who needs to write policies to give users access, see Getting Started with Policies.
    /// 
    /// For information about endpoints and signing API requests, see About the API. For information about available SDKs and tools, see SDKS and Other Tools.
    /// </summary>
    public class AlarmModel
    {
        /// <summary>
        /// The OCID of the alarm.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// A user-friendly name for the alarm. It does not have to be unique, and it's changeable.
        /// Avoid entering confidential information.
        /// This name is sent as the title for notifications related to this alarm.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
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
        /// If this requirement is not met, then the call is rejected.
        /// When false, the alarm evaluates metrics from only the compartment specified in metricCompartmentId. Default is false.
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
        /// The Alarms feature of the Monitoring service interprets results for each returned time series as Boolean values,
        /// where zero represents false and a non-zero value represents true.
        /// A true value means that the trigger rule condition has been met.
        /// The query must specify a metric, statistic, interval, and trigger rule (threshold or absence).
        /// Supported values for interval: 1m-60m (also 1h). You can optionally specify dimensions and grouping functions.
        /// Supported grouping functions: grouping(), groupBy(). For details about Monitoring Query Language (MQL), see Monitoring Query Language (MQL) Reference.
        /// For available dimensions, review the metric definition for the supported service. See Supported Services.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 1000</para>
        /// </summary>
        /// <example>CpuUtilization[1m]{availabilityDomain="cumS:PHX-AD-1"}.groupBy(availabilityDomain).percentile(0.9) > 85</example>
        public string Query { get; set; }

        /// <summary>
        /// The time between calculated aggregation windows for the alarm. Supported value: 1m
        /// <para>Required: no</para>
        /// </summary>
        public string Resolution { get; set; }

        /// <summary>
        /// The period of time that the condition defined in the alarm must persist before the alarm state changes from "OK" to "FIRING".
        /// For example, a value of 5 minutes means that the alarm must persist in breaching the condition for five minutes before the alarm updates its state to "FIRING".
        /// The duration is specified as a string in ISO 8601 format (PT10M for ten minutes or PT1H for one hour). Minimum: PT1M. Maximum: PT1H. Default: PT1M.
        /// Under the default value of PT1M, the first evaluation that breaches the alarm updates the state to "FIRING".
        /// The alarm updates its status to "OK" when the breaching condition has been clear for the most recent minute.
        /// <para>Required: no</para>
        /// </summary>
        /// <example>PT5M</example>
        public string PendingDuration { get; set; }

        /// <summary>
        /// The perceived type of response required when the alarm is in the "FIRING" state.
        /// <para>Required: yes</para>
        /// </summary>
        public string Severity { get; set; }

        /// <summary>
        /// The human-readable content of the notification delivered. 
        /// Oracle recommends providing guidance to operators for resolving the alarm condition.
        /// Consider adding links to standard runbook practices. Avoid entering confidential information.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 1000</para>
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// A list of destinations to which the notifications for this alarm will be delivered. 
        /// Each destination is represented by an OCID related to the supported destination service. 
        /// For example, a destination using the Notifications service is represented by a topic OCID. 
        /// Supported destination services: Notifications Service. 
        /// Limit: One destination per supported destination service.
        /// <para>Required: yes</para>
        /// </summary>
        public List<string> Destinations { get; set; }

        /// <summary>
        /// The frequency at which notifications are re-submitted, if the alarm keeps firing without interruption. 
        /// Format defined by ISO 8601. For example, PT4H indicates four hours. Minimum: PT1M. Maximum: P30D.
        /// Default value: null (notifications are not re-submitted).
        /// <para>Required: no</para>
        /// </summary>
        /// <example>PT2H</example>
        public string RepeatNotificationDuration { get; set; }

        /// <summary>
        /// The configuration details for suppressing an alarm.
        /// <para>Required: yes</para>
        /// </summary>
        public SuppressionModel Suppression { get; set; }

        /// <summary>
        /// Whether the alarm is enabled.
        /// <para>Required: no</para>
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

        /// <summary>
        /// The date and time the alarm was created. Format defined by RFC3339.
        /// <para>Required: yes</para>
        /// </summary>
        public string TimeCreated { get; set; }

        /// <summary>
        /// The date and time the alarm was last updated. Format defined by RFC3339.
        /// <para>Required: yes</para>
        /// </summary>
        public string TimeUpdated { get; set; }
    }
}

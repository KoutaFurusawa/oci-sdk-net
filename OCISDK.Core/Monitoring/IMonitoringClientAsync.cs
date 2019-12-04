using OCISDK.Core.Monitoring.Request;
using OCISDK.Core.Monitoring.Response;
using System.Threading.Tasks;

namespace OCISDK.Core.Monitoring
{
    /// <summary>
    /// MonitoringClientAsync interface
    /// </summary>
    public interface IMonitoringClientAsync : IClientSetting
    {
        /// <summary>
        /// Returns metric definitions that match the criteria specified in the request. 
        /// Compartment OCID required. For information about metrics, see Metrics Overview. 
        /// For important limits information, see Limits on Monitoring.
        /// Transactions Per Second (TPS) per-tenancy limit for this operation: 1.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        Task<ListMetricsResponse> ListMetrics(ListMetricsRequest param);

        /// <summary>
        /// Returns aggregated data that match the criteria specified in the request. 
        /// Compartment OCID required. For information on metric queries, see Building Metric Queries. 
        /// For important limits information, see Limits on Monitoring.
        /// 
        /// Transactions Per Second (TPS) per-tenancy limit for this operation: 10.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        Task<SummarizeMetricsDataResponse> SummarizeMetricsData(SummarizeMetricsDataRequest param);

        /// <summary>
        /// Publishes raw metric data points to the Monitoring service. 
        /// For more information about publishing metrics, see Publishing Custom Metrics. For important limits information, see Limits on Monitoring.
        /// 
        /// Per-call limits information follows.
        /// * Dimensions per metric group*. Maximum: 20. Minimum: 1.
        /// * Unique metric streams*. Maximum: 50.
        /// * Transactions Per Second (TPS) per-tenancy limit for this operation: 50.
        /// 
        /// A metric group is the combination of a given metric, metric namespace, and tenancy for the purpose of determining limits. 
        /// A dimension is a qualifier provided in a metric definition. A metric stream is an individual set of aggregated data for a metric, 
        /// typically specific to a resource. For more information about metric-related concepts, see Monitoring Concepts.
        /// 
        /// The endpoints for this operation differ from other Monitoring operations. 
        /// Replace the string telemetry with telemetry-ingestion in the endpoint, as in the following example:
        /// https://telemetry-ingestion.eu-frankfurt-1.oraclecloud.com
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        Task<PostMetricDataResponse> PostMetricData(PostMetricDataRequest param);

        /// <summary>
        /// Lists the alarms for the specified compartment. For important limits information, see Limits on Monitoring.
        /// Transactions Per Second (TPS) per-tenancy limit for this operation: 1.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        Task<ListAlarmsResponse> ListAlarms(ListAlarmsRequest param);

        /// <summary>
        /// List the status of each alarm in the specified compartment. For important limits information, see Limits on Monitoring.
        /// 
        /// Transactions Per Second (TPS) per-tenancy limit for this operation: 1.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        Task<ListAlarmsStatusResponse> ListAlarmsStatus(ListAlarmsStatusRequest param);

        /// <summary>
        /// Get the history of the specified alarm. For important limits information, see Limits on Monitoring.
        /// Transactions Per Second (TPS) per-tenancy limit for this operation: 1.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        Task<GetAlarmHistoryResponse> GetAlarmHistory(GetAlarmHistoryRequest param);

        /// <summary>
        /// Gets the specified alarm. For important limits information, see Limits on Monitoring.
        /// 
        /// Transactions Per Second(TPS) per-tenancy limit for this operation: 1.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        Task<GetAlarmResponse> GetAlarm(GetAlarmRequest param);

        /// <summary>
        /// Creates a new alarm in the specified compartment. For important limits information, see Limits on Monitoring.
        /// Transactions Per Second (TPS) per-tenancy limit for this operation: 1.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        Task<CreateAlarmResponse> CreateAlarm(CreateAlarmRequest param);

        /// <summary>
        /// Updates the specified alarm. For important limits information, see Limits on Monitoring.
        /// Transactions Per Second (TPS) per-tenancy limit for this operation: 1.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        Task<UpdateAlarmResponse> UpdateAlarm(UpdateAlarmRequest param);

        /// <summary>
        /// Moves an alarm into a different compartment within the same tenancy.
        /// For information about moving resources between compartments, see Moving Resources Between Compartments.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        Task<ChangeAlarmCompartmentResponse> ChangeAlarmCompartment(ChangeAlarmCompartmentRequest param);

        /// <summary>
        /// Deletes the specified alarm. For important limits information, see Limits on Monitoring.
        /// Transactions Per Second (TPS) per-tenancy limit for this operation: 1.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        Task<DeleteAlarmResponse> DeleteAlarm(DeleteAlarmRequest param);

        /// <summary>
        /// Removes any existing suppression for the specified alarm. For important limits information, see Limits on Monitoring.
        /// Transactions Per Second (TPS) per-tenancy limit for this operation: 1.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        Task<RemoveAlarmSuppressionResponse> RemoveAlarmSuppression(RemoveAlarmSuppressionRequest param);
    }
}

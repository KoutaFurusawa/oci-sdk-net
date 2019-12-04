using OCISDK.Core.Common;
using OCISDK.Core.Monitoring.Model;
using OCISDK.Core.Monitoring.Request;
using OCISDK.Core.Monitoring.Response;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace OCISDK.Core.Monitoring
{
    /// <summary>
    /// MonitoringClientAsync
    /// </summary>
    public class MonitoringClientAsync : ServiceClient, IMonitoringClientAsync
    {
        private readonly string monitaringServiceName = "monitoring";
        private readonly string IngestionServiceName = "monitoring-ingestion";

        /// <summary>
        /// Constructer
        /// </summary>
        public MonitoringClientAsync(ClientConfig config) : base(config)
        {
            ServiceName = monitaringServiceName;
        }

        /// <summary>
        /// Constructer
        /// </summary>
        public MonitoringClientAsync(ClientConfig config, OciSigner ociSigner) : base(config, ociSigner)
        {
            ServiceName = monitaringServiceName;
        }

        /// <summary>
        /// Constructer
        /// </summary>
        public MonitoringClientAsync(ClientConfigStream config) : base(config)
        {
            ServiceName = monitaringServiceName;
        }

        /// <summary>
        /// Constructer
        /// </summary>
        public MonitoringClientAsync(ClientConfigStream config, OciSigner ociSigner) : base(config, ociSigner)
        {
            ServiceName = monitaringServiceName;
        }
        
        /// <summary>
        /// Returns metric definitions that match the criteria specified in the request. 
        /// Compartment OCID required. For information about metrics, see Metrics Overview. 
        /// For important limits information, see Limits on Monitoring.
        /// Transactions Per Second (TPS) per-tenancy limit for this operation: 1.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<ListMetricsResponse> ListMetrics(ListMetricsRequest param)
        {
            var uri = new Uri($"{GetEndPoint(MonitoringServices.Metrics, this.Region)}/actions/listMetrics?{param.GetOptionQuery()}");

            var webResponse = await this.RestClientAsync.Post(uri, param.ListMetricsDetails, new HttpRequestHeaderParam() { OpcRequestId = param.OpcRequestId });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListMetricsResponse()
                {
                    Items = JsonSerializer.Deserialize<List<MetricModel>>(response),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Returns aggregated data that match the criteria specified in the request. 
        /// Compartment OCID required. For information on metric queries, see Building Metric Queries. 
        /// For important limits information, see Limits on Monitoring.
        /// 
        /// Transactions Per Second (TPS) per-tenancy limit for this operation: 10.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<SummarizeMetricsDataResponse> SummarizeMetricsData(SummarizeMetricsDataRequest param)
        {
            var uri = new Uri($"{GetEndPoint(MonitoringServices.Metrics, this.Region)}/actions/summarizeMetricsData?{param.GetOptionQuery()}");

            var webResponse = await this.RestClientAsync.Post(uri, param.SummarizeMetricsDataDetails, new HttpRequestHeaderParam() { OpcRequestId = param.OpcRequestId });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new SummarizeMetricsDataResponse()
                {
                    Items = JsonSerializer.Deserialize<List<MetricData>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

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
        public async Task<PostMetricDataResponse> PostMetricData(PostMetricDataRequest param)
        {
            var uri = new Uri($"https://" +
                $"{Config.GetHostName(IngestionServiceName, this.Region)}/" +
                $"{Config.GetServiceVersion(ServiceName)}/" +
                $"{MonitoringServices.Metrics}");

            var webResponse = await this.RestClientAsync.Post(uri, param.PostMetricDataDetails, new HttpRequestHeaderParam() { OpcRequestId = param.OpcRequestId });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new PostMetricDataResponse()
                {
                    PostMetricDataResponseDetails = JsonSerializer.Deserialize<PostMetricDataResponseDetails>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Lists the alarms for the specified compartment. For important limits information, see Limits on Monitoring.
        /// Transactions Per Second (TPS) per-tenancy limit for this operation: 1.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<ListAlarmsResponse> ListAlarms(ListAlarmsRequest param)
        {
            var uri = new Uri($"{GetEndPoint(MonitoringServices.Alarms, this.Region)}?{param.GetOptionQuery()}");

            var webResponse = await this.RestClientAsync.Get(uri, new HttpRequestHeaderParam() { OpcRequestId = param.OpcRequestId });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListAlarmsResponse()
                {
                    Items = JsonSerializer.Deserialize<List<AlarmSummary>>(response),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// List the status of each alarm in the specified compartment. For important limits information, see Limits on Monitoring.
        /// 
        /// Transactions Per Second (TPS) per-tenancy limit for this operation: 1.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<ListAlarmsStatusResponse> ListAlarmsStatus(ListAlarmsStatusRequest param)
        {
            var uri = new Uri($"{GetEndPoint(MonitoringServices.Alarms, this.Region)}/status?{param.GetOptionQuery()}");

            var webResponse = await this.RestClientAsync.Get(uri, new HttpRequestHeaderParam() { OpcRequestId = param.OpcRequestId });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListAlarmsStatusResponse()
                {
                    Items = JsonSerializer.Deserialize<List<AlarmStatusSummary>>(response),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page"),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Get the history of the specified alarm. For important limits information, see Limits on Monitoring.
        /// Transactions Per Second (TPS) per-tenancy limit for this operation: 1.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<GetAlarmHistoryResponse> GetAlarmHistory(GetAlarmHistoryRequest param)
        {
            var uri = new Uri($"{GetEndPoint(MonitoringServices.Alarms, this.Region)}/{param.AlarmId}/history?{param.GetOptionQuery()}");

            var webResponse = await this.RestClientAsync.Get(uri, new HttpRequestHeaderParam() { OpcRequestId = param.OpcRequestId });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new GetAlarmHistoryResponse()
                {
                    AlarmHistoryCollection = JsonSerializer.Deserialize<AlarmHistoryCollection>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
        }

        /// <summary>
        /// Gets the specified alarm. For important limits information, see Limits on Monitoring.
        /// 
        /// Transactions Per Second(TPS) per-tenancy limit for this operation: 1.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<GetAlarmResponse> GetAlarm(GetAlarmRequest param)
        {
            var uri = new Uri($"{GetEndPoint(MonitoringServices.Alarms, this.Region)}/{param.AlarmId}");

            var webResponse = await this.RestClientAsync.Get(uri, new HttpRequestHeaderParam() { OpcRequestId = param.OpcRequestId });

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new GetAlarmResponse()
                {
                    AlarmModel = JsonSerializer.Deserialize<AlarmModel>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Creates a new alarm in the specified compartment. For important limits information, see Limits on Monitoring.
        /// Transactions Per Second (TPS) per-tenancy limit for this operation: 1.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<CreateAlarmResponse> CreateAlarm(CreateAlarmRequest param)
        {
            var uri = new Uri($"{GetEndPoint(MonitoringServices.Alarms, this.Region)}");

            var httpRequestHeaderParam = new HttpRequestHeaderParam() {
                OpcRetryToken = param.OpcRetryToken,
                OpcRequestId = param.OpcRequestId
            };
            var webResponse = await this.RestClientAsync.Post(uri, param.CreateAlarmDetails, httpRequestHeaderParam);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new CreateAlarmResponse()
                {
                    AlarmModel = JsonSerializer.Deserialize<AlarmModel>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    Etag = webResponse.Headers.Get("etag")
                };
            }
        }

        /// <summary>
        /// Updates the specified alarm. For important limits information, see Limits on Monitoring.
        /// Transactions Per Second (TPS) per-tenancy limit for this operation: 1.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<UpdateAlarmResponse> UpdateAlarm(UpdateAlarmRequest param)
        {
            var uri = new Uri($"{GetEndPoint(MonitoringServices.Alarms, this.Region)}/{param.AlarmId}");

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                IfMatch = param.IfMatch,
                OpcRequestId = param.OpcRequestId
            };
            var webResponse = await this.RestClientAsync.Put(uri, param.UpdateAlarmDetails, httpRequestHeaderParam);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new UpdateAlarmResponse()
                {
                    AlarmModel = JsonSerializer.Deserialize<AlarmModel>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    Etag = webResponse.Headers.Get("etag")
                };
            }
        }

        /// <summary>
        /// Moves an alarm into a different compartment within the same tenancy.
        /// For information about moving resources between compartments, see Moving Resources Between Compartments.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<ChangeAlarmCompartmentResponse> ChangeAlarmCompartment(ChangeAlarmCompartmentRequest param)
        {
            var uri = new Uri($"{GetEndPoint(MonitoringServices.Alarms, this.Region)}/{param.AlarmId}/actions/changeCompartment");

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                IfMatch = param.IfMatch,
                OpcRequestId = param.OpcRequestId,
                OpcRetryToken = param.OpcRetryToken
            };
            var webResponse = await this.RestClientAsync.Post(uri, param.ChangeAlarmCompartmentDetails, httpRequestHeaderParam);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ChangeAlarmCompartmentResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Deletes the specified alarm. For important limits information, see Limits on Monitoring.
        /// Transactions Per Second (TPS) per-tenancy limit for this operation: 1.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<DeleteAlarmResponse> DeleteAlarm(DeleteAlarmRequest param)
        {
            var uri = new Uri($"{GetEndPoint(MonitoringServices.Alarms, this.Region)}/{param.AlarmId}");

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                IfMatch = param.IfMatch,
                OpcRequestId = param.OpcRequestId
            };
            var webResponse = await this.RestClientAsync.Delete(uri, httpRequestHeaderParam);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new DeleteAlarmResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Removes any existing suppression for the specified alarm. For important limits information, see Limits on Monitoring.
        /// Transactions Per Second (TPS) per-tenancy limit for this operation: 1.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<RemoveAlarmSuppressionResponse> RemoveAlarmSuppression(RemoveAlarmSuppressionRequest param)
        {
            var uri = new Uri($"{GetEndPoint(MonitoringServices.Alarms, this.Region)}/{param.AlarmId}/actions/removeSuppression");

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                IfMatch = param.IfMatch,
                OpcRequestId = param.OpcRequestId
            };
            var webResponse = await this.RestClientAsync.Post(uri,null, httpRequestHeaderParam);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new RemoveAlarmSuppressionResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }
    }
}

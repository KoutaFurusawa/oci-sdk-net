﻿using OCISDK.Core.src.Monitoring.Model;
using OCISDK.Core.src.Monitoring.Request;
using OCISDK.Core.src.Monitoring.Response;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OCISDK.Core.src.Monitoring
{
    public class MonitoringClient : ServiceClient, IMonitoringClient
    {
        private readonly string IngestionServiceName = "monitoring-ingestion";

        /// <summary>
        /// Constructer
        /// </summary>
        public MonitoringClient(ClientConfig config) : base(config)
        {
            ServiceName = "monitoring";
        }

        public MonitoringClient(ClientConfig config, OciSigner ociSigner) : base(config, ociSigner)
        {
            ServiceName = "monitoring";
        }

        public MonitoringClient(ClientConfigStream config) : base(config)
        {
            ServiceName = "monitoring";
        }

        public MonitoringClient(ClientConfigStream config, OciSigner ociSigner) : base(config, ociSigner)
        {
            ServiceName = "monitoring";
        }
        
        /// <summary>
        /// setter Region
        /// </summary>
        /// <param name="region"></param>
        public void SetRegion(string region)
        {
            Region = region;
        }

        /// <summary>
        /// getter region
        /// </summary>
        /// <returns></returns>
        public string GetRegion()
        {
            return Region;
        }

        /// <summary>
        /// Returns metric definitions that match the criteria specified in the request. 
        /// Compartment OCID required. For information about metrics, see Metrics Overview. 
        /// For important limits information, see Limits on Monitoring.
        /// Transactions Per Second (TPS) per-tenancy limit for this operation: 1.
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public ListMetricsResponse ListMetrics(ListMetricsRequest param)
        {
            var uri = new Uri($"{GetEndPoint(MonitoringServices.Metrics, this.Region)}/actions/listMetrics?{param.GetOptionQuery()}");

            var webResponse = this.RestClient.Post(uri, param.ListMetricsDetails, null, param.OpcRequestId);

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
        public SummarizeMetricsDataResponse SummarizeMetricsData(SummarizeMetricsDataRequest param)
        {
            var uri = new Uri($"{GetEndPoint(MonitoringServices.Metrics, this.Region)}/actions/summarizeMetricsData?{param.GetOptionQuery()}");

            var webResponse = this.RestClient.Post(uri, param.SummarizeMetricsDataDetails, null, param.OpcRequestId);

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
        public PostMetricDataResponse PostMetricData(PostMetricDataRequest param)
        {
            var uri = new Uri($"https://" +
                $"{Config.GetHostName(IngestionServiceName, this.Region)}/" +
                $"{Config.GetServiceVersion(ServiceName)}/" +
                $"{MonitoringServices.Metrics}");

            var webResponse = this.RestClient.Post(uri, param.PostMetricDataDetails, null, param.OpcRequestId);

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
        public ListAlarmsResponse ListAlarms(ListAlarmsRequest param)
        {
            var uri = new Uri($"{GetEndPoint(MonitoringServices.Alarms, this.Region)}?{param.GetOptionQuery()}");

            var webResponse = this.RestClient.Get(uri, param.OpcRequestId);

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
        public ListAlarmsStatusResponse ListAlarmsStatus(ListAlarmsStatusRequest param)
        {
            var uri = new Uri($"{GetEndPoint(MonitoringServices.Alarms, this.Region)}/status?{param.GetOptionQuery()}");

            var webResponse = this.RestClient.Get(uri, param.OpcRequestId);

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
        public GetAlarmHistoryResponse GetAlarmHistory(GetAlarmHistoryRequest param)
        {
            var uri = new Uri($"{GetEndPoint(MonitoringServices.Alarms, this.Region)}/{param.AlarmId}/history?{param.GetOptionQuery()}");

            var webResponse = this.RestClient.Get(uri, param.OpcRequestId);

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
        public GetAlarmResponse GetAlarm(GetAlarmRequest param)
        {
            var uri = new Uri($"{GetEndPoint(MonitoringServices.Alarms, this.Region)}/{param.AlarmId}");

            var webResponse = this.RestClient.Get(uri, param.OpcRequestId);

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
        public CreateAlarmResponse CreateAlarm(CreateAlarmRequest param)
        {
            var uri = new Uri($"{GetEndPoint(MonitoringServices.Alarms, this.Region)}");

            var webResponse = this.RestClient.Post(uri, param.CreateAlarmDetails, param.OpcRetryToken, param.OpcRequestId);

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
        public UpdateAlarmResponse UpdateAlarm(UpdateAlarmRequest param)
        {
            var uri = new Uri($"{GetEndPoint(MonitoringServices.Alarms, this.Region)}/{param.AlarmId}");

            var webResponse = this.RestClient.Put(uri, param.UpdateAlarmDetails, param.IfMatch, param.OpcRequestId);

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
        public ChangeAlarmCompartmentResponse ChangeAlarmCompartment(ChangeAlarmCompartmentRequest param)
        {
            var uri = new Uri($"{GetEndPoint(MonitoringServices.Alarms, this.Region)}/{param.AlarmId}/actions/changeCompartment");

            var webResponse = this.RestClient.Post(uri, param.ChangeAlarmCompartmentDetails, param.OpcRetryToken, param.OpcRequestId, param.IfMatch);

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
        public DeleteAlarmResponse DeleteAlarm(DeleteAlarmRequest param)
        {
            var uri = new Uri($"{GetEndPoint(MonitoringServices.Alarms, this.Region)}/{param.AlarmId}");

            var webResponse = this.RestClient.Delete(uri, param.IfMatch, param.OpcRequestId);

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
    }
}

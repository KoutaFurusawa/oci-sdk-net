using OCISDK.Core.Budgets.Model;
using OCISDK.Core.Budgets.Request;
using OCISDK.Core.Budgets.Response;
using OCISDK.Core.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OCISDK.Core.Budgets
{
    /// <summary>
    /// Budgets Client
    /// </summary>
    public class BudgetsClient : ServiceClient, IBudgetsClient
    {
        private readonly string BudgetsServiceName = "budgets";

        /// <summary>
        /// Constructer
        /// </summary>
        public BudgetsClient(ClientConfig config) : base(config)
        {
            ServiceName = BudgetsServiceName;
        }

        /// <summary>
        /// Constructer
        /// </summary>
        public BudgetsClient(ClientConfig config, IOciSigner ociSigner) : base(config, ociSigner)
        {
            ServiceName = BudgetsServiceName;
        }

        /// <summary>
        /// Constructer
        /// </summary>
        public BudgetsClient(ClientConfigStream config) : base(config)
        {
            ServiceName = BudgetsServiceName;
        }

        /// <summary>
        /// Constructer
        /// </summary>
        public BudgetsClient(ClientConfigStream config, IOciSigner ociSigner) : base(config, ociSigner)
        {
            ServiceName = BudgetsServiceName;
        }

        /// <summary>
        /// Creates a new Alert Rule.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public CreateAlertRuleResponse CreateAlertRule(CreateAlertRuleRequest request)
        {
            var uri = new Uri($"{GetEndPoint(BudgetsServices.Budgets, this.Region, "oci.oraclecloud.com")}/{request.BudgetId}/alertRules");

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                OpcRetryToken = request.OpcRetryToken,
                OpcRequestId = request.OpcRequestId
            };
            using (var webResponse = this.RestClient.Post(uri, request.CreateAlertRuleDetails, httpRequestHeaderParam))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new CreateAlertRuleResponse()
                {
                    AlertRule = JsonSerializer.Deserialize<AlertRule>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    Etag = webResponse.Headers.Get("etag")
                };
            }
        }

        /// <summary>
        /// Creates a new Budget.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public CreateBudgetResponse CreateBudget(CreateBudgetRequest request)
        {
            var uri = new Uri($"{GetEndPoint(BudgetsServices.Budgets, this.Region, "oci.oraclecloud.com")}");

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                OpcRetryToken = request.OpcRetryToken,
                OpcRequestId = request.OpcRequestId
            };
            using (var webResponse = this.RestClient.Post(uri, request.CreateBudgetDetails, httpRequestHeaderParam))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new CreateBudgetResponse()
                {
                    Budget = JsonSerializer.Deserialize<BudgetDetails>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    Etag = webResponse.Headers.Get("etag")
                };
            }
        }

        /// <summary>
        /// Deletes a specified Alert Rule resource.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public DeleteAlertRuleResponse DeleteAlertRule(DeleteAlertRuleRequest request)
        {
            var uri = new Uri($"{GetEndPoint(BudgetsServices.Budgets, this.Region, "oci.oraclecloud.com")}/{request.BudgetId}/alertRules/{request.AlertRuleId}");

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                IfMatch = request.IfMatch,
                OpcRequestId = request.OpcRequestId
            };
            using (var webResponse = this.RestClient.Delete(uri, httpRequestHeaderParam))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new DeleteAlertRuleResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Deletes a specified Budget resource
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public DeleteBudgetResponse DeleteBudget(DeleteBudgetRequest request)
        {
            var uri = new Uri($"{GetEndPoint(BudgetsServices.Budgets, this.Region, "oci.oraclecloud.com")}/{request.BudgetId}");

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                IfMatch = request.IfMatch,
                OpcRequestId = request.OpcRequestId
            };
            using (var webResponse = this.RestClient.Delete(uri, httpRequestHeaderParam))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new DeleteBudgetResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Gets an Alert Rule for a specified Budget.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public GetAlertRuleResponse GetAlertRule(GetAlertRuleRequest request)
        {
            var uri = new Uri($"{GetEndPoint(BudgetsServices.Budgets, this.Region, "oci.oraclecloud.com")}/{request.BudgetId}/alertRules/{request.AlertRuleId}");

            using (var webResponse = this.RestClient.Get(uri, new HttpRequestHeaderParam() { OpcRequestId = request.OpcRequestId }))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new GetAlertRuleResponse()
                {
                    AlertRule = JsonSerializer.Deserialize<AlertRule>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Update an Alert Rule for the budget identified by the OCID.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public UpdateAlertRuleResponse UpdateAlertRule(UpdateAlertRuleRequest request)
        {
            var uri = new Uri($"{GetEndPoint(BudgetsServices.Budgets, this.Region, "oci.oraclecloud.com")}/{request.BudgetId}/alertRules/{request.AlertRuleId}");

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                IfMatch = request.IfMatch,
                OpcRequestId = request.OpcRequestId
            };
            using (var webResponse = this.RestClient.Put(uri, request.UpdateAlertRuleDetails, httpRequestHeaderParam))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new UpdateAlertRuleResponse()
                {
                    AlertRule = JsonSerializer.Deserialize<AlertRule>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    Etag = webResponse.Headers.Get("etag")
                };
            }
        }

        /// <summary>
        /// Returns a list of Alert Rules for a specified Budget.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ListAlertRulesResponse ListAlertRules(ListAlertRulesRequest request)
        {
            var uri = new Uri($"{GetEndPoint(BudgetsServices.Budgets, this.Region, "oci.oraclecloud.com")}/{request.BudgetId}/alertRules?{request.GetOptionQuery()}");

            using(var webResponse = this.RestClient.Get(uri))

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListAlertRulesResponse()
                {
                    Items = this.JsonSerializer.Deserialize<List<AlertRuleSummary>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
        }

        /// <summary>
        /// Lists budgets in the specified compartment.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ListBudgetsResponse ListBudgets(ListBudgetsRequest request)
        {
            var uri = new Uri($"{GetEndPoint(BudgetsServices.Budgets, this.Region, "oci.oraclecloud.com")}?{request.GetOptionQuery()}");

            using(var webResponse = this.RestClient.Get(uri))

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListBudgetsResponse()
                {
                    Items = this.JsonSerializer.Deserialize<List<BudgetSummary>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-next-page")
                };
            }
        }
    }
}

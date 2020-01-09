using OCISDK.Core.Common;
using OCISDK.Core.Notification.Model;
using OCISDK.Core.Notification.Request;
using OCISDK.Core.Notification.Response;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OCISDK.Core.Notification
{
    /// <summary>
    /// Notification Client
    /// </summary>
    public class NotificationClient : ServiceClient, INotificationClient
    {
        private readonly string NotificationServiceName = "notification";

        /// <summary>
        /// Constructer
        /// </summary>
        public NotificationClient(ClientConfig config) : base(config)
        {
            ServiceName = NotificationServiceName;
        }

        /// <summary>
        /// Constructer
        /// </summary>
        public NotificationClient(ClientConfig config, OciSigner ociSigner) : base(config, ociSigner)
        {
            ServiceName = NotificationServiceName;
        }

        /// <summary>
        /// Constructer
        /// </summary>
        public NotificationClient(ClientConfigStream config) : base(config)
        {
            ServiceName = NotificationServiceName;
        }

        /// <summary>
        /// Constructer
        /// </summary>
        public NotificationClient(ClientConfigStream config, OciSigner ociSigner) : base(config, ociSigner)
        {
            ServiceName = NotificationServiceName;
        }

        /// <summary>
        /// Moves a topic into a different compartment within the same tenancy.
        /// For information about moving resources between compartments, see Moving Resources to a Different Compartment.
        /// 
        /// Transactions Per Minute (TPM) per-tenancy limit for this operation: 60.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ChangeTopicCompartmentResponse ChangeTopicCompartment(ChangeTopicCompartmentRequest request)
        {
            var uri = new Uri($"{GetEndPoint(NotificationServices.Topics, this.Region)}/{request.TopicId}/actions/changeCompartment");

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                OpcRetryToken = request.OpcRetryToken,
                OpcRequestId = request.OpcRequestId,
                IfMatch = request.IfMatch
            };
            var webResponse = this.RestClient.Post(uri, request.ChangeCompartmentDetails, httpRequestHeaderParam);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ChangeTopicCompartmentResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }

        /// <summary>
        /// Lists topics in the specified compartment.
        /// Transactions Per Minute (TPM) per-tenancy limit for this operation: 120.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ListTopicsResponse ListTopics(ListTopicsRequest request)
        {
            var uri = new Uri($"{GetEndPoint(NotificationServices.Topics, this.Region)}?{request.GetOptionQuery()}");

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                OpcRequestId = request.OpcRequestId
            };
            var webResponse = this.RestClient.Get(uri, httpRequestHeaderParam);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListTopicsResponse()
                {
                    Items = this.JsonSerializer.Deserialize<List<NotificationTopicSummary>>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    OpcNextPage = webResponse.Headers.Get("opc-request-id")
                };
            }
        }
    }
}

using OCISDK.Core.Common;
using OCISDK.Core.Notification.Model;
using OCISDK.Core.Notification.Request;
using OCISDK.Core.Notification.Response;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace OCISDK.Core.Notification
{
    /// <summary>
    /// Notification Client
    /// </summary>
    public class NotificationClientAsync : ServiceClient, INotificationClientAsync
    {
        private readonly string NotificationServiceName = "notification";

        /// <summary>
        /// Constructer
        /// </summary>
        public NotificationClientAsync(ClientConfig config) : base(config)
        {
            ServiceName = NotificationServiceName;
        }

        /// <summary>
        /// Constructer
        /// </summary>
        public NotificationClientAsync(ClientConfig config, OciSigner ociSigner) : base(config, ociSigner)
        {
            ServiceName = NotificationServiceName;
        }

        /// <summary>
        /// Constructer
        /// </summary>
        public NotificationClientAsync(ClientConfigStream config) : base(config)
        {
            ServiceName = NotificationServiceName;
        }

        /// <summary>
        /// Constructer
        /// </summary>
        public NotificationClientAsync(ClientConfigStream config, OciSigner ociSigner) : base(config, ociSigner)
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
        public async Task<ChangeTopicCompartmentResponse> ChangeTopicCompartment(ChangeTopicCompartmentRequest request)
        {
            var uri = new Uri($"{GetEndPoint(NotificationServices.Topics, this.Region)}/{request.TopicId}/actions/changeCompartment");

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                OpcRetryToken = request.OpcRetryToken,
                OpcRequestId = request.OpcRequestId,
                IfMatch = request.IfMatch
            };
            var webResponse = await this.RestClientAsync.Post(uri, request.ChangeCompartmentDetails, httpRequestHeaderParam);

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
        /// Creates a topic in the specified compartment. For general information about topics, see Managing Topics and Subscriptions.
        /// For the purposes of access control, you must provide the OCID of the compartment where you want the topic to reside. 
        /// For information about access control and compartments, see Overview of the IAM Service.
        /// You must specify a display name for the topic.
        /// All Oracle Cloud Infrastructure resources, including topics, get an Oracle-assigned, unique ID called an Oracle Cloud Identifier (OCID). 
        /// When you create a resource, you can find its OCID in the response. You can also retrieve a resource's OCID by using a List API operation 
        /// on that resource type, or by viewing the resource in the Console. For more information, see Resource Identifiers.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CreateTopicResponse> CreateTopic(CreateTopicRequest request)
        {
            var uri = new Uri(GetEndPoint(NotificationServices.Topics, this.Region));

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                OpcRetryToken = request.OpcRetryToken,
                OpcRequestId = request.OpcRequestId
            };
            var webResponse = await this.RestClientAsync.Post(uri, request.CreateTopicDetails, httpRequestHeaderParam);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new CreateTopicResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    ETag = webResponse.Headers.Get("etag"),
                    NotificationTopic = this.JsonSerializer.Deserialize<NotificationTopicDetails>(response)
                };
            }
        }

        /// <summary>
        /// Publishes a message to the specified topic.
        /// The topic endpoint is required for this operation. To get the topic endpoint, use GetTopic and review the 
        /// apiEndpoint value in the response (NotificationTopic).
        /// Limits information follows.
        /// Message size limit per request: 64KB.
        /// Message delivery rate limit per endpoint: 60 messages per minute for HTTP-based protocols, 10 messages per 
        /// minute for the EMAIL protocol. HTTP-based protocols use URL endpoints that begin with "http:" or "https:".
        /// 
        /// Transactions Per Minute (TPM) per-tenancy limit for this operation: 60 per topic.
        /// 
        /// For more information about publishing messages, see Publishing Messages. For steps to request a limit increase, 
        /// see Requesting a Service Limit Increase.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<PublishMessageResponse> PublishMessage(PublishMessageRequest request)
        {
            var uri = new Uri($"{GetEndPoint(NotificationServices.Topics, this.Region)}/{request.TopicId}/messages");

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                MessageType = request.MessageType.Value,
                OpcRequestId = request.OpcRequestId
            };
            var webResponse = await this.RestClientAsync.Post(uri, request.MessageDetails, httpRequestHeaderParam);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new PublishMessageResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    PublishResult = this.JsonSerializer.Deserialize<PublishResult>(response)
                };
            }
        }

        /// <summary>
        /// Updates the specified topic's configuration.
        /// Transactions Per Minute (TPM) per-tenancy limit for this operation: 60.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<UpdateTopicResponse> UpdateTopic(UpdateTopicRequest request)
        {
            var uri = new Uri($"{GetEndPoint(NotificationServices.Topics, this.Region)}/{request.TopicId}");

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                OpcRequestId = request.OpcRequestId,
                IfMatch = request.IfMatch
            };
            var webResponse = await this.RestClientAsync.Put(uri, request.TopicAttributesDetails, httpRequestHeaderParam);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new UpdateTopicResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    ETag = webResponse.Headers.Get("etag"),
                    NotificationTopic = this.JsonSerializer.Deserialize<NotificationTopicDetails>(response)
                };
            }
        }

        /// <summary>
        /// Lists topics in the specified compartment.
        /// Transactions Per Minute (TPM) per-tenancy limit for this operation: 120.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ListTopicsResponse> ListTopics(ListTopicsRequest request)
        {
            var uri = new Uri($"{GetEndPoint(NotificationServices.Topics, this.Region)}?{request.GetOptionQuery()}");

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                OpcRequestId = request.OpcRequestId
            };
            var webResponse = await this.RestClientAsync.Get(uri, httpRequestHeaderParam);

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

        /// <summary>
        /// Gets the specified topic's configuration information.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<GetTopicResponse> GetTopic(GetTopicRequest request)
        {
            var uri = new Uri($"{GetEndPoint(NotificationServices.Topics, this.Region)}/{request.TopicId}");

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                OpcRequestId = request.OpcRequestId
            };
            var webResponse = await this.RestClientAsync.Get(uri, httpRequestHeaderParam);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new GetTopicResponse()
                {
                    NotificationTopic = this.JsonSerializer.Deserialize<NotificationTopicDetails>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    ETag = webResponse.Headers.Get("etag")
                };
            }
        }

        /// <summary>
        /// Deletes the specified topic.
        /// Transactions Per Minute (TPM) per-tenancy limit for this operation: 60.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<DeleteTopicResponse> DeleteTopic(DeleteTopicRequest request)
        {
            var uri = new Uri($"{GetEndPoint(NotificationServices.Topics, this.Region)}/{request.TopicId}");

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                OpcRequestId = request.OpcRequestId,
                IfMatch = request.IfMatch
            };
            var webResponse = await this.RestClientAsync.Delete(uri, httpRequestHeaderParam);

            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new DeleteTopicResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }
    }
}

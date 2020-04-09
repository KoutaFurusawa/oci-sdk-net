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
        public NotificationClientAsync(ClientConfig config, IOciSigner ociSigner) : base(config, ociSigner)
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
        public NotificationClientAsync(ClientConfigStream config, IOciSigner ociSigner) : base(config, ociSigner)
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
            using (var webResponse = await this.RestClientAsync.Post(uri, request.ChangeCompartmentDetails, httpRequestHeaderParam))
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
        /// Moves a subscription into a different compartment within the same tenancy. 
        /// For information about moving resources between compartments, see Moving Resources to a Different Compartment.
        /// 
        /// Transactions Per Minute (TPM) per-tenancy limit for this operation: 60.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ChangeSubscriptionCompartmentResponse> ChangeSubscriptionCompartment(ChangeSubscriptionCompartmentRequest request)
        {
            var uri = new Uri($"{GetEndPoint(NotificationServices.Subscriptions, this.Region)}/{request.SubscriptionId}/actions/changeCompartment");

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                OpcRetryToken = request.OpcRetryToken,
                OpcRequestId = request.OpcRequestId,
                IfMatch = request.IfMatch
            };
            using (var webResponse = await this.RestClientAsync.Post(uri, request.ChangeCompartmentDetails, httpRequestHeaderParam))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ChangeSubscriptionCompartmentResponse()
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
            using (var webResponse = await this.RestClientAsync.Post(uri, request.CreateTopicDetails, httpRequestHeaderParam))
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
        /// Creates a subscription for the specified topic and sends a subscription confirmation URL to the endpoint. The subscription remains in 
        /// "Pending" status until it has been confirmed. For information about confirming subscriptions, see To confirm a subscription.
        /// Transactions Per Minute (TPM) per-tenancy limit for this operation: 60.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CreateSubscriptionResponse> CreateSubscription(CreateSubscriptionRequest request)
        {
            var uri = new Uri(GetEndPoint(NotificationServices.Subscriptions, this.Region));

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                OpcRetryToken = request.OpcRetryToken,
                OpcRequestId = request.OpcRequestId
            };
            using (var webResponse = await this.RestClientAsync.Post(uri, request.CreateSubscriptionDetails, httpRequestHeaderParam))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new CreateSubscriptionResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    ETag = webResponse.Headers.Get("etag"),
                    Subscription = this.JsonSerializer.Deserialize<SubscriptionDetails>(response)
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
            using (var webResponse = await this.RestClientAsync.Post(uri, request.MessageDetails, httpRequestHeaderParam))
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
        /// Resends the confirmation details for the specified subscription.
        /// Transactions Per Minute (TPM) per-tenancy limit for this operation: 60.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ResendSubscriptionConfirmationResponse> ResendSubscriptionConfirmation(ResendSubscriptionConfirmationRequest request)
        {
            var uri = new Uri($"{GetEndPoint(NotificationServices.Subscriptions, this.Region)}/{request.Id}/resendConfirmation");

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                OpcRequestId = request.OpcRequestId
            };
            using (var webResponse = await this.RestClientAsync.Post(uri, null, httpRequestHeaderParam))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ResendSubscriptionConfirmationResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    Subscription = this.JsonSerializer.Deserialize<SubscriptionDetails>(response)
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
            using (var webResponse = await this.RestClientAsync.Put(uri, request.TopicAttributesDetails, httpRequestHeaderParam))
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
        /// Updates the specified subscription's configuration.
        /// Transactions Per Minute (TPM) per-tenancy limit for this operation: 60.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<UpdateSubscriptionResponse> UpdateSubscription(UpdateSubscriptionRequest request)
        {
            var uri = new Uri($"{GetEndPoint(NotificationServices.Subscriptions, this.Region)}/{request.SubscriptionId}");

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                OpcRequestId = request.OpcRequestId,
                IfMatch = request.IfMatch
            };
            using (var webResponse = await this.RestClientAsync.Put(uri, request.UpdateSubscriptionDetails, httpRequestHeaderParam))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new UpdateSubscriptionResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    ETag = webResponse.Headers.Get("etag"),
                    UpdateSubscriptionDetails = this.JsonSerializer.Deserialize<UpdateSubscriptionDetails>(response)
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
            using (var webResponse = await this.RestClientAsync.Get(uri, httpRequestHeaderParam))
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
        /// Lists the subscriptions in the specified compartment or topic.
        /// Transactions Per Minute (TPM) per-tenancy limit for this operation: 60.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ListSubscriptionsResponse> ListSubscriptions(ListSubscriptionsRequest request)
        {
            var uri = new Uri($"{GetEndPoint(NotificationServices.Subscriptions, this.Region)}?{request.GetOptionQuery()}");

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                OpcRequestId = request.OpcRequestId
            };
            using (var webResponse = await this.RestClientAsync.Get(uri, httpRequestHeaderParam))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new ListSubscriptionsResponse()
                {
                    Items = this.JsonSerializer.Deserialize<List<SubscriptionSummary>>(response),
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
            using (var webResponse = await this.RestClientAsync.Get(uri, httpRequestHeaderParam))
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
        /// Gets the confirmation details for the specified subscription.
        /// Transactions Per Minute (TPM) per-tenancy limit for this operation: 60.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<GetConfirmSubscriptionResponse> GetConfirmSubscription(GetConfirmSubscriptionRequest request)
        {
            var uri = new Uri($"{GetEndPoint(NotificationServices.Subscriptions, this.Region)}/{request.Id}/confirmation?{request.GetOptionQuery()}");

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                OpcRequestId = request.OpcRequestId
            };
            using (var webResponse = await this.RestClientAsync.Get(uri, httpRequestHeaderParam))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new GetConfirmSubscriptionResponse()
                {
                    ConfirmationResult = this.JsonSerializer.Deserialize<ConfirmationResult>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    ETag = webResponse.Headers.Get("etag")
                };
            }
        }

        /// <summary>
        /// Gets the specified subscription's configuration information.
        /// Transactions Per Minute (TPM) per-tenancy limit for this operation: 60.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<GetSubscriptionResponse> GetSubscription(GetSubscriptionRequest request)
        {
            var uri = new Uri($"{GetEndPoint(NotificationServices.Subscriptions, this.Region)}/{request.SubscriptionId}");

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                OpcRequestId = request.OpcRequestId
            };
            using (var webResponse = await this.RestClientAsync.Get(uri, httpRequestHeaderParam))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new GetSubscriptionResponse()
                {
                    Subscription = this.JsonSerializer.Deserialize<SubscriptionDetails>(response),
                    OpcRequestId = webResponse.Headers.Get("opc-request-id"),
                    ETag = webResponse.Headers.Get("etag")
                };
            }
        }

        /// <summary>
        /// Gets the unsubscription details for the specified subscription.
        /// Transactions Per Minute (TPM) per-tenancy limit for this operation: 60.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<GetUnsubscriptionResponse> GetUnsubscription(GetUnsubscriptionRequest request)
        {
            var uri = new Uri($"{GetEndPoint(NotificationServices.Subscriptions, this.Region)}/{request.Id}/unsubscription?{request.GetOptionQuery()}");

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                OpcRequestId = request.OpcRequestId
            };
            using (var webResponse = await this.RestClientAsync.Get(uri, httpRequestHeaderParam))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new GetUnsubscriptionResponse()
                {
                    Body = response,
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
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
            using (var webResponse = await this.RestClientAsync.Delete(uri, httpRequestHeaderParam))
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

        /// <summary>
        /// Deletes the specified subscription.
        /// Transactions Per Minute (TPM) per-tenancy limit for this operation: 60.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<DeleteSubscriptionResponse> DeleteSubscription(DeleteSubscriptionRequest request)
        {
            var uri = new Uri($"{GetEndPoint(NotificationServices.Subscriptions, this.Region)}/{request.SubscriptionId}");

            var httpRequestHeaderParam = new HttpRequestHeaderParam()
            {
                OpcRequestId = request.OpcRequestId,
                IfMatch = request.IfMatch
            };
            using (var webResponse = await this.RestClientAsync.Delete(uri, httpRequestHeaderParam))
            using (var stream = webResponse.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var response = reader.ReadToEnd();

                return new DeleteSubscriptionResponse()
                {
                    OpcRequestId = webResponse.Headers.Get("opc-request-id")
                };
            }
        }
    }
}

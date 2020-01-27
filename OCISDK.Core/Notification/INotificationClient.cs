using OCISDK.Core.Notification.Request;
using OCISDK.Core.Notification.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Notification
{
    /// <summary>
    /// NotificationClient Interface
    /// </summary>
    public interface INotificationClient
    {
        /// <summary>
        /// Moves a topic into a different compartment within the same tenancy.
        /// For information about moving resources between compartments, see Moving Resources to a Different Compartment.
        /// 
        /// Transactions Per Minute (TPM) per-tenancy limit for this operation: 60.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ChangeTopicCompartmentResponse ChangeTopicCompartment(ChangeTopicCompartmentRequest request);

        /// <summary>
        /// Moves a subscription into a different compartment within the same tenancy. 
        /// For information about moving resources between compartments, see Moving Resources to a Different Compartment.
        /// 
        /// Transactions Per Minute (TPM) per-tenancy limit for this operation: 60.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ChangeSubscriptionCompartmentResponse ChangeSubscriptionCompartment(ChangeSubscriptionCompartmentRequest request);

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
        CreateTopicResponse CreateTopic(CreateTopicRequest request);

        /// <summary>
        /// Creates a subscription for the specified topic and sends a subscription confirmation URL to the endpoint. The subscription remains in 
        /// "Pending" status until it has been confirmed. For information about confirming subscriptions, see To confirm a subscription.
        /// Transactions Per Minute (TPM) per-tenancy limit for this operation: 60.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        CreateSubscriptionResponse CreateSubscription(CreateSubscriptionRequest request);

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
        PublishMessageResponse PublishMessage(PublishMessageRequest request);

        /// <summary>
        /// Resends the confirmation details for the specified subscription.
        /// Transactions Per Minute (TPM) per-tenancy limit for this operation: 60.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ResendSubscriptionConfirmationResponse ResendSubscriptionConfirmation(ResendSubscriptionConfirmationRequest request);

        /// <summary>
        /// Updates the specified topic's configuration.
        /// Transactions Per Minute (TPM) per-tenancy limit for this operation: 60.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        UpdateTopicResponse UpdateTopic(UpdateTopicRequest request);

        /// <summary>
        /// Updates the specified subscription's configuration.
        /// Transactions Per Minute (TPM) per-tenancy limit for this operation: 60.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        UpdateSubscriptionResponse UpdateSubscription(UpdateSubscriptionRequest request);

        /// <summary>
        /// Lists topics in the specified compartment.
        /// Transactions Per Minute (TPM) per-tenancy limit for this operation: 120.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ListTopicsResponse ListTopics(ListTopicsRequest request);

        /// <summary>
        /// Lists the subscriptions in the specified compartment or topic.
        /// Transactions Per Minute (TPM) per-tenancy limit for this operation: 60.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ListSubscriptionsResponse ListSubscriptions(ListSubscriptionsRequest request);

        /// <summary>
        /// Gets the specified topic's configuration information.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        GetTopicResponse GetTopic(GetTopicRequest request);

        /// <summary>
        /// Gets the confirmation details for the specified subscription.
        /// Transactions Per Minute (TPM) per-tenancy limit for this operation: 60.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        GetConfirmSubscriptionResponse GetConfirmSubscription(GetConfirmSubscriptionRequest request);

        /// <summary>
        /// Gets the specified subscription's configuration information.
        /// Transactions Per Minute (TPM) per-tenancy limit for this operation: 60.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        GetSubscriptionResponse GetSubscription(GetSubscriptionRequest request);

        /// <summary>
        /// Gets the unsubscription details for the specified subscription.
        /// Transactions Per Minute (TPM) per-tenancy limit for this operation: 60.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        GetUnsubscriptionResponse GetUnsubscription(GetUnsubscriptionRequest request);

        /// <summary>
        /// Deletes the specified topic.
        /// Transactions Per Minute (TPM) per-tenancy limit for this operation: 60.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        DeleteTopicResponse DeleteTopic(DeleteTopicRequest request);

        /// <summary>
        /// Deletes the specified subscription.
        /// Transactions Per Minute (TPM) per-tenancy limit for this operation: 60.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        DeleteSubscriptionResponse DeleteSubscription(DeleteSubscriptionRequest request);
    }
}

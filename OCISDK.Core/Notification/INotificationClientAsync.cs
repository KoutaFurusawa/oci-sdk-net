﻿using OCISDK.Core.Notification.Request;
using OCISDK.Core.Notification.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OCISDK.Core.Notification
{
    /// <summary>
    /// NotificationClient Interface
    /// </summary>
    public interface INotificationClientAsync
    {
        /// <summary>
        /// Moves a topic into a different compartment within the same tenancy.
        /// For information about moving resources between compartments, see Moving Resources to a Different Compartment.
        /// 
        /// Transactions Per Minute (TPM) per-tenancy limit for this operation: 60.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ChangeTopicCompartmentResponse> ChangeTopicCompartment(ChangeTopicCompartmentRequest request);

        /// <summary>
        /// Lists topics in the specified compartment.
        /// Transactions Per Minute (TPM) per-tenancy limit for this operation: 120.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ListTopicsResponse> ListTopics(ListTopicsRequest request);
    }
}

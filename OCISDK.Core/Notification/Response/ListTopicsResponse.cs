using OCISDK.Core.Notification.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Notification.Response
{
    /// <summary>
    /// ListTopics response
    /// </summary>
    public class ListTopicsResponse
    {
        /// <summary>
        /// A unique Oracle-assigned identifier for the request.
        /// If you need to contact Oracle about a particular request, please provide the request ID.
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// For list pagination. When this header appears in the response, additional pages of results may remain.
        /// For important details about how pagination works, see List Pagination.
        /// </summary>
        public string OpcNextPage { get; set; }

        /// <summary>
        /// The response body will contain an array of NotificationTopicSummary resources.
        /// </summary>
        public List<NotificationTopicSummary> Items { get; set; }
    }
}

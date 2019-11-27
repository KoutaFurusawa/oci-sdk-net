using OCISDK.Core.Monitoring.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Monitoring.Response
{
    /// <summary>
    /// ListAlarms Response
    /// </summary>
    public class ListAlarmsResponse
    {
        /// <summary>
        /// response header parameter opcRequestId
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// For pagination of a list of items. When paging through a list, 
        /// if this header appears in the response, 
        /// then a partial list might have been returned. 
        /// Include this value as the page parameter for the subsequent GET request to get the next batch of items.
        /// </summary>
        public string OpcNextPage { get; set; }

        /// <summary>
        /// The response body will contain an array of AlarmSummary resources.
        /// </summary>
        public List<AlarmSummary> Items { get; set; }
    }
}

﻿/// <summary>
/// ListRegionSubscriptions Response
/// 
/// author: koutaro furusawa
/// </summary>

using OCISDK.Core.src.Identity.Model;
using System.Collections.Generic;

namespace OCISDK.Core.src.Identity.Response
{
    public class ListRegionSubscriptionsResponse
    {
        /// <summary>
        /// Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// The response body will contain an array of RegionSubscription resources.
        /// </summary>
        public List<RegionSubscription> Items { get; set; }
    }
}

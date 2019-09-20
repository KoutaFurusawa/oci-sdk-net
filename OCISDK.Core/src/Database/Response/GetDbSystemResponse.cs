﻿using OCISDK.Core.src.Database.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.src.Database.Response
{
    public class GetDbSystemResponse
    {
        /// <summary>
        /// For optimistic concurrency control. See if-match.
        /// </summary>
        public string ETag { get; set; }

        /// <summary>
        /// Unique Oracle-assigned identifier for the request.
        /// If you need to contact Oracle about a particular request,
        /// please provide the request ID.
        /// </summary>
        public string OpcRequestId { get; set; }

        public DbSystemDetails DbSystem { get; set; }
    }
}
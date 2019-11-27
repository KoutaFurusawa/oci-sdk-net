using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.LoadBalancer.Model
{
    /// <summary>
    /// The health checker's configuration details.
    /// </summary>
    public class UpdateHealthCheckerDetails
    {
        /// <summary>
        /// The protocol the health check must use; either HTTP or TCP.
        /// <para>Required: yes</para>
        /// </summary>
        public string Protocol { get; set; }

        /// <summary>
        /// The path against which to run the health check.
        /// <para>Required: no</para>
        /// </summary>
        public string UrlPath { get; set; }

        /// <summary>
        /// The backend server port against which to run the health check. 
        /// If the port is not specified, the load balancer uses the port information from the Backend object.
        /// <para>Required: yes</para>
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// The status code a healthy backend server should return. 
        /// If you configure the health check policy to use the HTTP protocol, you can use common HTTP status codes such as "200".
        /// <para>Required: yes</para>
        /// </summary>
        public int ReturnCode { get; set; }

        /// <summary>
        /// The number of retries to attempt before a backend server is considered "unhealthy". 
        /// This number also applies when recovering a server to the "healthy" state. Defaults to 3.
        /// <para>Required: yes</para>
        /// </summary>
        public int Retries { get; set; }

        /// <summary>
        /// The maximum time, in milliseconds, to wait for a reply to a health check. 
        /// A health check is successful only if a reply returns within this timeout period. Defaults to 3000 (3 seconds).
        /// <para>Required: yes</para>
        /// </summary>
        public int TimeoutInMillis { get; set; }

        /// <summary>
        /// The interval between health checks, in milliseconds. The default is 10000 (10 seconds).
        /// <para>Required: yes</para>
        /// </summary>
        public int IntervalInMillis { get; set; }

        /// <summary>
        /// A regular expression for parsing the response body from the backend server.
        /// <para>Required: yes</para>
        /// </summary>
        public string ResponseBodyRegex { get; set; }
    }
}

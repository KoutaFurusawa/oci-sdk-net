using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.LoadBalancer.Model
{
    /// <summary>
    /// The configuration details for updating a load balancer backend set. For more information on backend set configuration, see Managing Backend Sets.
    /// 
    /// Warning: Oracle recommends that you avoid using any confidential information when you supply string values using the API.
    /// </summary>
    public class UpdateBackendSetDetails
    {
        /// <summary>
        /// The load balancer policy for the backend set. To get a list of available policies, use the ListPolicies operation.
        /// <para>Required: yes</para>
        /// </summary>
        public string Policy { get; set; }

        /// <summary>
        /// <para>Required: yes</para>
        /// </summary>
        public List<BackendDetails> Backends { get; set; }

        /// <summary>
        /// <para>Required: yes</para>
        /// </summary>
        public HealthChecker HealthChecker { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public SSLConfiguration SslConfiguration { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public SessionPersistenceConfigurationDetails SessionPersistenceConfiguration { get; set; }
    }
}

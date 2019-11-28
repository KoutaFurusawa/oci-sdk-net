using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.LoadBalancer.Model
{
    /// <summary>
    /// The configuration details for creating a backend set in a load balancer. For more information on backend set configuration, see Managing Backend Sets.
    /// 
    /// Warning: Oracle recommends that you avoid using any confidential information when you supply string values using the API.
    /// </summary>
    public class CreateBackendSetDetails
    {
        /// <summary>
        /// A friendly name for the backend set. It must be unique and it cannot be changed.
        /// 
        /// Valid backend set names include only alphanumeric characters, dashes, and underscores. 
        /// Backend set names cannot contain spaces. Avoid entering confidential information.
        /// <para>Required: yes</para>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The load balancer policy for the backend set. To get a list of available policies, use the ListPolicies operation.
        /// <para>Required: yes</para>
        /// </summary>
        public string Policy { get; set; }

        /// <summary>
        /// <para>Required: no</para>
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

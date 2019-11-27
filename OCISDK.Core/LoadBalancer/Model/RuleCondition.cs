using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.LoadBalancer.Model
{
    /// <summary>
    /// A condition to apply to an access control rule.
    /// 
    /// This resource has one or more subtypes based on the value of the attributeName attribute:
    /// </summary>
    public class RuleCondition
    {
        /// <summary>
        /// Required value: SOURCE_IP_ADDRESS
        /// <para>Required: yes</para>
        /// </summary>
        public string AttributeName { get; set; }

        /// <summary>
        /// An IPv4 address range that the source IP address of an incoming packet must match.
        /// 
        /// The service accepts only classless inter-domain routing (CIDR) format (x.x.x.x/y) strings.
        /// <para>Required: yes</para>
        /// </summary>
        public string AttributeValue { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.DNS.Model
{
    /// <summary>
    /// DNS record data with metadata for processing in a steering policy.
    /// Warning: Oracle recommends that you avoid using any confidential information when you supply string values using the API.
    /// </summary>
    public class SteeringPolicyAnswer
    {
        /// <summary>
        /// A user-friendly name for the answer, unique within the steering policy.
        /// An answer's name property can be referenced in answerCondition properties of rules using answer.name.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The canonical name for the record's type. Only A, AAAA, and CNAME are supported. 
        /// For more information, see Supported DNS Resource Record Types.
        /// <para>Required: yes</para>
        /// </summary>
        public string Rtype { get; set; }

        /// <summary>
        /// The record's data, as whitespace-delimited tokens in type-specific presentation format.
        /// All RDATA is normalized and the returned presentation of your RDATA may differ from its initial input.
        /// For more information about RDATA, see Supported DNS Resource Record Types.
        /// <para>Required: yes</para>
        /// </summary>
        public string Rdata { get; set; }

        /// <summary>
        /// The freeform name of a group of one or more records in which this record is included, such as "LAX data center".
        /// An answer's pool property can be referenced in answerCondition properties of rules using answer.pool.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string Pool { get; set; }

        /// <summary>
        /// Set this property to true to indicate that the answer is administratively disabled, such as when the corresponding server is down for maintenance. 
        /// An answer's isDisabled property can be referenced in answerCondition properties in rules using answer.isDisabled.
        /// <para>Required: no</para>
        /// </summary>
        public bool? IsDisabled { get; set; }
    }
}

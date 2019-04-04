/// <summary>
/// CreateVcnDetails Reference
/// 
/// author: koutaro furusawa
/// </summary>


using System.Collections.Generic;

namespace OCISDK.Core.src.Core.Model.VirtualNetwork
{
    public class CreateVcnDetails
    {
        /// <summary>
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 32</para>
        /// </summary>
        public string CidrBlock { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 15</para>
        /// </summary>
        public string DnsLabel { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public IDictionary<string, string> FreeformTags { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public IDictionary<string, IDictionary<string, string>> DefinedTags { get; set; }
    }
}

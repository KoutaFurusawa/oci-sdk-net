using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.src.Waas.Model
{
    public class OriginGroupDetails
    {
        /// <summary>
        /// The list of objects containing origin references and additional properties.
        /// <para>Required: no</para>
        /// </summary>
        public List<OriginDetails> Origins { get; set; }
    }
}

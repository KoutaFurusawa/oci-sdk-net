using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.src.Identity.Request
{
    public class ListRegionSubscriptionsRequest
    {
        /// <summary>
        /// The OCID of the tenancy.
        /// <para>Required: yes</para>
        /// </summary>
        public string TenancyId { get; set; }
    }
}

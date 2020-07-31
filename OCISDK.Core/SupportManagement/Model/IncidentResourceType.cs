using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.SupportManagement.Model
{
    /// <summary>
    /// Details about the resource associated with the support request.
    /// </summary>
    public class IncidentResourceType
    {
        /// <summary>
        /// The description of the resource.
        /// <para>Required: no</para>
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The label associated with the resource.
        /// <para>Required: yes</para>
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// The display name of the resource.
        /// <para>Required: no</para>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Unique identifier of the resource.
        /// <para>Required: no</para>
        /// </summary>
        public string ResourceTypeKey { get; set; }

        /// <summary>
        /// The service category list.
        /// <para>Required: no</para>
        /// </summary>
        public List<ServiceCategoryDetails> ServiceCategoryList { get; set; }
    }
}

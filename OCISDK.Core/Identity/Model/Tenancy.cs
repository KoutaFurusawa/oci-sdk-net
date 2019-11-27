using System.Collections.Generic;

namespace OCISDK.Core.Identity.Model
{
    /// <summary>
    /// The root compartment that contains all of your organization's compartments and other Oracle Cloud Infrastructure cloud resources. When you sign up for Oracle Cloud Infrastructure, 
    /// Oracle creates a tenancy for your company, which is a secure and isolated partition where you can create, organize, and administer your cloud resources.
    /// </summary>
    public class Tenancy
    {
        /// <summary>
        /// The OCID of the tenancy.
        /// <para>Required: no</para>
        /// </summary>
        public virtual string Id { get; set; }

        /// <summary>
        /// The name of the tenancy.
        /// <para>Required: no</para>
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// The description of the tenancy.
        /// <para>Required: no</para>
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        /// The region key for the tenancy's home region. For more information about regions, see Regions and Availability Domains.
        /// <para>Required: no</para>
        /// </summary>
        public virtual string HomeRegionKey { get; set; }

        /// <summary>
        /// Free-form tags for this resource. Each tag is a simple key-value pair with no predefined name, type, or namespace. 
        /// <para>Required: no</para>
        /// </summary>
        public virtual IDictionary<string, string> FreeformTags { get; set; }

        /// <summary>
        /// Defined tags for this resource. Each key is predefined and scoped to a namespace. 
        /// <para>Required: no</para>
        /// </summary>
        public virtual IDictionary<string, IDictionary<string, string>> DefinedTags { get; set; }
    }
}

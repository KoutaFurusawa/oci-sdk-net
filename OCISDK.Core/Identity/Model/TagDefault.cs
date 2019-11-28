namespace OCISDK.Core.Identity.Model
{
    /// <summary>
    /// TagDefault Reference
    /// Tag defaults let you specify a default tag (tagnamespace.tag="value") to apply to all resource types 
    /// in a specified compartment. The tag default is applied at the time the resource is created. Resources 
    /// that exist in the compartment before you create the tag default are not tagged. The TagDefault object 
    /// specifies the tag and compartment details.
    /// 
    /// To use any of the API operations, you must be authorized in an IAM policy. If you're not authorized, 
    /// talk to an administrator.
    /// </summary>
    public class TagDefault
    {
        /// <summary>
        /// The OCID of the tag namespace.
        /// <para>Required: yes</para>
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The OCID of the compartment. The tag default applies to all new resources that get 
        /// created in the compartment. Resources that existed before the tag default was created 
        /// are not tagged.
        /// <para>Required: yes</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// The OCID of the tag namespace that contains the tag definition.
        /// <para>Required: yes</para>
        /// </summary>
        public string TagNamespaceId { get; set; }

        /// <summary>
        /// The OCID of the tag definition. The tag default will always assign a default value for this tag definition.
        /// <para>Required: yes</para>
        /// </summary>
        public string TagDefinitionId { get; set; }

        /// <summary>
        /// The default value for the tag definition. This will be applied to all resources created in the compartment.
        /// <para>Required: yes</para>
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Date and time the tag namespace was created, in the format defined by RFC3339. Example: 2016-08-25T21:10:29.600Z
        /// <para>Required: yes</para>
        /// </summary>
        public string TimeCreated { get; set; }

        /// <summary>
        /// The tag default's current state. After creating a TagDefault, make sure its lifecycleState is ACTIVE before using it.
        /// <para>Required: no</para>
        /// <para>Allowed values are: 
        /// ACTIVE
        /// </para>
        /// </summary>
        public string LifecycleState { get; set; }
    }
}

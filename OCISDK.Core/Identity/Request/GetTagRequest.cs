namespace OCISDK.Core.Identity.Request
{
    /// <summary>
    /// GetTag Request
    /// </summary>
    public class GetTagRequest
    {
        /// <summary>
        /// The OCID of the tag namespace.
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 100</para>
        /// </summary>
        public string TagNamespaceId { get; set; }

        /// <summary>
        /// The name of the tag.
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 100</para>
        /// </summary>
        public string TagName { get; set; }
    }
}

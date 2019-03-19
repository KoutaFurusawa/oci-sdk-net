/// <summary>
/// ListTags Request
/// 
/// author: koutaro furusawa
/// </summary>

namespace OCISDK.Core.src.Identity.Request
{
    public class ListTagsRequest
    {
        /// <summary>
        /// The OCID of the tag namespace.
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 100</para>
        /// </summary>
        public string TagNamespaceId { get; set; }

        /// <summary>
        /// The value of the opc-next-page response header from the previous "List" call.
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 512</para>
        /// </summary>
        public string Page { get; set; }

        /// <summary>
        /// The maximum number of items to return in a paginated "List" call.
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 1000</para>
        /// </summary>
        public int? Limit { get; set; }

        public string GetOptionQuery()
        {
            var options = $"tagNamespaceId={this.TagNamespaceId}";
            if (!string.IsNullOrEmpty(this.Page))
            {
                options += $"&page={this.Page}";
            }
            if (this.Limit.HasValue)
            {
                options += $"&limit={this.Limit.Value}";
            }

            return options;
        }
    }
}

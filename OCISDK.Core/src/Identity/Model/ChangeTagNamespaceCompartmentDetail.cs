/// <summary>
/// ChangeTagNamespaceCompartmentDetail Reference
/// Details of the compartment the resource is being moved to.
/// 
/// author: koutaro furusawa
/// </summary>
using Newtonsoft.Json;
namespace OCISDK.Core.src.Identity.Model
{
    public class ChangeTagNamespaceCompartmentDetail
    {
        /// <summary>
        /// The OCID of the tenancy.
        /// </summary>
        [JsonProperty("compartmentId")]
        public string CompartmentId { get; set; }
    }
}

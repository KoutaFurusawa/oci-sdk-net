/// <summary>
/// Tenancy Reference
/// 
/// author: koutaro furusawa
/// </summary>


using System.Collections.Generic;

namespace OCISDK.Core.src.Identity.Model
{
    public class Tenancy
    {
        public virtual string Id { get; set; }
        
        public virtual string Name { get; set; }
        
        public virtual string Description { get; set; }
        
        public virtual string HomeRegionKey { get; set; }
        
        public virtual IDictionary<string, string> FreeformTags { get; set; }
        
        public virtual IDictionary<string, IDictionary<string, string>> DefinedTags { get; set; }
    }
}

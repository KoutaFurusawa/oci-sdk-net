/// <summary>
/// Compartment Reference
/// A collection of related resources. Compartments are a fundamental component of 
/// Oracle Cloud Infrastructure for organizing and isolating your cloud resources. 
/// You use them to clearly separate resources for the purposes of measuring usage 
/// and billing, access (through the use of IAM Service policies), and isolation 
/// (separating the resources for one project or business unit from another). A common 
/// approach is to create a compartment for each major part of your organization. 
/// For more information, see Overview of the IAM Service and also Setting Up Your 
/// Tenancy.
/// 
/// author: koutaro furusawa
/// </summary>


using System.Collections.Generic;

namespace OCISDK.Core.src.Identity.Model
{
    public class Compartment
    {
        public string Id { get; set; }
        
        public string CompartmentId { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public string TimeCreated { get; set; }
        
        public string LifecycleState { get; set; }
        
        public int InactiveStatus { get; set; }
        
        public bool IsAccessible { get; set; }
        
        public IDictionary<string, string> FreeformTags { get; set; }
        
        public IDictionary<string, IDictionary<string, string>> DefinedTags { get; set; }
    }
}

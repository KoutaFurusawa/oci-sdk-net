namespace OCISDK.Core.Identity.Model
{
    /// <summary>
    /// An object that represents your tenancy's access to a particular region 
    /// (i.e., a subscription), the status of that access, and whether that region is the home region. For more information, see Managing Regions.
    /// To use any of the API operations, you must be authorized in an IAM policy.If you're not authorized, talk to an administrator. 
    /// If you're an administrator who needs to write policies to give users access, see Getting Started with Policies.
    /// </summary>
    public class RegionSubscription
    {
        /// <summary>
        /// The region's key.
        /// </summary>
        public string RegionKey { get; set; }

        /// <summary>
        /// The region's name.
        /// </summary>
        public string RegionName { get; set; }

        /// <summary>
        /// The region subscription status.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Indicates if the region is the home region or not.
        /// </summary>
        public bool IsHomeRegion { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Search.Model
{
    /// <summary>
    /// Search Details
    /// </summary>
    public class SearchDetails
    {
        /// <summary>
        /// The type of SearchDetails, whether FreeText or Structured.
        /// <para>Required: yes</para>
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The type of matching context returned in the response. 
        /// If you specify HIGHLIGHTS, then the service will highlight fragments in its response. 
        /// (See ResourceSummary.searchContext and SearchContext for more information.) The default setting is NONE.
        /// <para>Required: no</para>
        /// </summary>
        public string MatchingContextType { get; set; }

        /// <summary>
        /// The text to search for.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// The structured query describing which resources to search for.
        /// </summary>
        public string Query { get; set; }
    }
}

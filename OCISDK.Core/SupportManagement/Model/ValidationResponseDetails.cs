using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.SupportManagement.Model
{
    /// <summary>
    /// The validation response returned when checking whether the requested user is valid.
    /// </summary>
    public class ValidationResponseDetails
    {
        /// <summary>
        /// Boolean value that indicates whether the requested user is valid.
        /// <para>Required: no</para>
        /// </summary>
        public bool? IsValidUser { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace OCISDK.Core.Waas.Model
{
    /// <summary>
    /// ChangeWaasPolicyCompartment Details
    /// </summary>
    public class ChangeWaasPolicyCompartmentDetails
    {
        /// <summary>
        /// The OCID of the compartment into which the resource should be moved. 
        /// For information about moving resources between compartments, see Moving Resources to a Different Compartment.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string CompartmentId { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.SupportManagement.Model
{
    /// <summary>
    /// Details about creation of user.
    /// </summary>
    public class CreateUserDetails
    {
        /// <summary>
        /// The OCID of the tenacy.
        /// <para>Required: yes</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// Country of the user.
        /// <para>Required: yes</para>
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// CSI to be associated to the user.
        /// <para>Required: yes</para>
        /// </summary>
        public string Csi { get; set; }

        /// <summary>
        ///First name of the user.
        /// <para>Required: yes</para>
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last name of the user.
        /// <para>Required: yes</para>
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Organization of the user.
        /// <para>Required: yes</para>
        /// </summary>
        public string OrganizationName { get; set; }

        /// <summary>
        /// Contact number of the user.
        /// <para>Required: yes</para>
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Timezone of the user.
        /// <para>Required: yes</para>
        /// </summary>
        public string Timezone { get; set; }
    }
}

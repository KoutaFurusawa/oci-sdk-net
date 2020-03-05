using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.UnpublishedService.ConsoleIdcs.Model
{
    /// <summary>
    /// IDCS users
    /// </summary>
    public class IdcsUser
    {
        /// <summary>
        /// id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// deleteInProgress
        /// </summary>
        public string DeleteInProgress { get; set; }

        /// <summary>
        /// meta
        /// </summary>
        public MetaDetails Meta { get; set; }

        /// <summary>
        /// active
        /// </summary>
        public bool? Active { get; set; }

        /// <summary>
        /// userName
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// name
        /// </summary>
        public NameDetails Name { get; set; }

        /// <summary>
        /// emails
        /// </summary>
        public List<EmailDetails> Emails { get; set; }

        /// <summary>
        /// phoneNumbers
        /// </summary>
        public string PhoneNumbers { get; set; }

        /// <summary>
        /// user meta
        /// </summary>
        public class MetaDetails
        {
            /// <summary>
            /// Created
            /// </summary>
            public string Created { get; set; }

            /// <summary>
            /// LastModified
            /// </summary>
            public string LastModified { get; set; }
        }
        
        /// <summary>
        /// name set
        /// </summary>
        public class NameDetails
        {
            /// <summary>
            /// familyName
            /// </summary>
            public string FamilyName { get; set; }

            /// <summary>
            /// givenName
            /// </summary>
            public string GivenName { get; set; }
        }

        /// <summary>
        /// email set
        /// </summary>
        public class EmailDetails
        {
            /// <summary>
            /// type
            /// </summary>
            public string Type { get; set; }

            /// <summary>
            /// value
            /// </summary>
            public string Value { get; set; }

            /// <summary>
            /// primary
            /// </summary>
            public bool? Primary { get; set; }

            /// <summary>
            /// secondary
            /// </summary>
            public bool? Secondary { get; set; }

            /// <summary>
            /// verified
            /// </summary>
            public bool? Verified { get; set; }
        }
    }

}

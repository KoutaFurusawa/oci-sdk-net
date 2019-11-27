using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Database.Request
{
    /// <summary>
    /// DeleteDbHome Request
    /// </summary>
    public class DeleteDbHomeRequest
    {
        /// <summary>
        /// The database home OCID.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string DbHomeId { get; set; }

        /// <summary>
        /// Whether to perform a final backup of the database or not. 
        /// Default is false. If you previously used RMAN or dbcli to configure backups and then you switch to using the Console or the API for backups, 
        /// a new backup configuration is created and associated with your database. 
        /// This means that you can no longer rely on your previously configured unmanaged backups to work.
        /// <para>Required: no</para>
        /// <para>Default: false</para>
        /// </summary>
        public bool? PerformFinalBackup { get; set; }

        /// <summary>
        /// For optimistic concurrency control. 
        /// In the PUT or DELETE call for a resource, set the if-match parameter to the value of the etag from a previous GET or POST response for that resource. 
        /// The resource will be updated or deleted only if the etag you provide matches the resource's current etag value.
        /// <para>Required: no</para>
        /// <para>if-match header parameter</para>
        /// </summary>
        public string IfMatch { get; set; }
    }
}

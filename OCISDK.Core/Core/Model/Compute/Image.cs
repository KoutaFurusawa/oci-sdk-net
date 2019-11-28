using System.Collections.Generic;

namespace OCISDK.Core.Core.Model.Compute
{
    /// <summary>
    /// Image Reference
    /// A boot disk image for launching an instance. For more information, see Overview of the Compute Service.
    /// 
    /// Warning: Oracle recommends that you avoid using any confidential information when you supply string values using the API.
    /// </summary>
    public class Image
    {
        /// <summary>
        /// The OCID of the image originally used to launch the instance.
        /// <para>Min Length: 1</para>
        /// <para>Max Length: 255</para>
        /// </summary>
        public string BaseImageId { get; set; }

        /// <summary>
        /// The OCID of the compartment containing the instance you want to use as the basis for the image.
        /// <para>Min Length: 1</para>
        /// <para>Max Length: 255</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// Whether instances launched with this image can be used to create new images.
        /// For example, you cannot create an image of an Oracle Database instance. 
        /// <para></para>
        /// </summary>
        public bool CreateImageAllowed { get; set; }

        /// <summary>
        /// <para>Min Length: 1</para>
        /// <para>Max Length: 255</para>
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// <para>Min Length: 1</para>
        /// <para>Max Length: 255</para>
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Specifies the configuration mode for launching virtual machine (VM) instances. 
        /// <para>Allowed values are:
        /// NATIVE, 
        /// EMULATED, 
        /// CUSTOM</para>
        /// </summary>
        public string LaunchMode { get; set; }
        
        /// <summary>
        /// LaunchOptions
        /// </summary>
        public LaunchOptions LaunchOptions { get; set; }

        /// <summary>
        /// LifecycleState
        /// </summary>
        public string LifecycleState { get; set; }

        /// <summary>
        /// The image's operating system.
        /// <para>Min Length: 1</para>
        /// <para>Max Length: 255</para>
        /// </summary>
        public string OperatingSystem { get; set; }

        /// <summary>
        /// The image's operating system version.
        /// <para>Min Length: 1</para>
        /// <para>Max Length: 255</para>
        /// </summary>
        public string OperatingSystemVersion { get; set; }
        
        /// <summary>
        /// Image size (1 MB = 1048576 bytes)
        /// </summary>
        public int SizeInMBs { get; set; }

        /// <summary>
        /// The date and time the image was created, in the format defined by RFC3339.
        /// </summary>
        public string TimeCreated { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public IDictionary<string, string> FreeformTags { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public IDictionary<string, IDictionary<string, string>> DefinedTags { get; set; }
    }
}

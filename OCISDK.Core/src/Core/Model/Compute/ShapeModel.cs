/// <summary>
/// Shape Reference
/// A compute instance shape that can be used in LaunchInstance. 
/// For more information, see Overview of the Compute Service.
/// 
/// author: koutaro furusawa
/// </summary>
namespace OCISDK.Core.src.Core.Model.Compute
{
    public class ShapeModel
    {
        /// <summary>
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string AvailabilityDomain { get; set; }

        /// <summary>
        /// The name of the shape. You can enumerate all available shapes by calling ListShapes.
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string Shape { get; set; }
    }
}

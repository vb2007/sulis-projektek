namespace Shapes_VB_Lib
{
    public interface IShape
    {
        /// <summary>
        /// Gets the name of the shape.
        /// </summary>
        string ShapeName { get; }

        /// <summary>
        /// Gets the calculated area of the shape.
        /// </summary>
        double Area { get; }

        /// <summary>
        /// Gets a string containing detailed information about the shape.
        /// </summary>
        /// <returns>A formatted string with shape details.</returns>
        string GetDetails();
    }
}

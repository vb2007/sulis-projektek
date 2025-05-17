namespace Shapes_VB_Lib
{
    /// <summary>
    /// Represents a rectangle shape.
    /// </summary>
    public class Rectangle : IShape
    {
        /// <summary>
        /// Gets the width of the rectangle.
        /// </summary>
        public double Width { get; private set; }

        /// <summary>
        /// Gets the height of the rectangle.
        /// </summary>
        public double Height { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle"/> class
        /// with specified width and height.
        /// </summary>
        /// <param name="width">The width of the rectangle. Must be positive.</param>
        /// <param name="height">The height of the rectangle. Must be positive.</param>
        /// <exception cref="InvalidDimensionException">
        /// Thrown if width or height are not positive.
        /// </exception>
        public Rectangle(double width, double height)
        {
            if (width <= 0)
            {
                throw new InvalidDimensionException(nameof(width), width);
            }
            if (height <= 0)
            {
                throw new InvalidDimensionException(nameof(height), height);
            }

            Width = width;
            Height = height;
        }

        /// <summary>
        /// Gets the name of the shape.
        /// </summary>
        public string ShapeName => "Rectangle";

        /// <summary>
        /// Gets the calculated area of the rectangle.
        /// </summary>
        public double Area => Width * Height;

        /// <summary>
        /// Gets a string containing detailed information about the rectangle.
        /// </summary>
        /// <returns>A formatted string with the rectangle's width, height, and area.</returns>
        public string GetDetails()
        {
            // Using F2 to format numbers to two decimal places.
            return $"{ShapeName}: Width = {Width:F2}, Height = {Height:F2}, Area = {Area:F2}";
        }
    }
}

namespace Shapes_VB_Lib
{
    /// <summary>
    /// Represents errors that occur due to invalid dimension values for a shape.
    /// </summary>
    public class InvalidDimensionException : Exception
    {
        public InvalidDimensionException(string dimensionName, double value)
            : base($"Invalid dimension: The '{dimensionName}' cannot be {value}. It must be a positive value.")
        {
        }

        public InvalidDimensionException(string message)
            : base(message)
        {
        }

        public InvalidDimensionException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}

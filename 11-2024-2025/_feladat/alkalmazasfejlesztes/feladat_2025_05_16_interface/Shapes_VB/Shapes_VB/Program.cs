using Shapes_VB_Lib;

namespace Shapes_VB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Shape Interface Demonstration ---");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine();

            try
            {
                // 1. Create an instance of a class from the library
                // This is the "fő változó" (main variable) based on the library class
                Rectangle rectangle = new Rectangle(10.5, 5.25);

                Console.WriteLine("Created a specific Rectangle object:");
                Console.WriteLine($"  - Type: {rectangle.GetType().Name}");
                Console.WriteLine($"  - Width: {rectangle.Width:F2}");
                Console.WriteLine($"  - Height: {rectangle.Height:F2}");
                Console.WriteLine($"  - Details via class method: {rectangle.GetDetails()}");
                Console.WriteLine();

                // 2. Use the object through its interface
                IShape shapeReference = rectangle; // Polymorphism: Rectangle is an IShape

                Console.WriteLine("Using the same object via IShape interface reference:");
                Console.WriteLine($"  - Shape Name (from interface): {shapeReference.ShapeName}");
                Console.WriteLine($"  - Area (from interface): {shapeReference.Area:F2}");
                Console.WriteLine($"  - Details (from interface): {shapeReference.GetDetails()}");
                Console.WriteLine();

                // 3. Demonstrate polymorphism with a list of IShape
                Console.WriteLine("Demonstrating a list of IShape objects:");
                List<IShape> shapes = new List<IShape>
                {
                    new Rectangle(7.0, 3.0),
                    rectangle,
                    new Rectangle(4.5, 6.2)
                };

                int shapeCounter = 1;
                foreach (IShape currentShape in shapes)
                {
                    Console.WriteLine($"  --- Shape {shapeCounter} ({currentShape.ShapeName}) ---");
                    Console.WriteLine($"      Details: {currentShape.GetDetails()}");
                    Console.WriteLine($"      Area: {currentShape.Area:F2}");
                    shapeCounter++;
                }
                Console.WriteLine();

                // 4. Demonstrate error handling with custom exception
                Console.WriteLine("Attempting to create a rectangle with invalid dimensions (error handling demonstration):");
                try
                {
                    IShape invalidShape = new Rectangle(-5.0, 10.0);
                    // This line should not be reached
                    Console.WriteLine($"\tInvalid shape details (should not print): {invalidShape.GetDetails()}");
                }
                catch (InvalidDimensionException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\tCAUGHT ERROR: {ex.Message}");
                    Console.ResetColor();
                }

                try
                {
                    IShape anotherInvalidShape = new Rectangle(5.0, 0);
                    // This line should not be reached
                    Console.WriteLine($"\tInvalid shape details (should not print): {anotherInvalidShape.GetDetails()}");
                }
                catch (InvalidDimensionException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\tCAUGHT ERROR: {ex.Message}");
                    Console.ResetColor();
                }
            }
            catch (InvalidDimensionException ex) // Catch exceptions from initial creation if any
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"An unexpected error occurred during shape creation: {ex.Message}");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"An unexpected general error occurred: {ex.Message}");
                Console.ResetColor();
            }

            Console.WriteLine();
            Console.WriteLine("-------------------------------------");
        }
    }
}

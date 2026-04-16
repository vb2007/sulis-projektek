using Matrixok_VB_Lib;

namespace Matrixok_VB;

class Program
{
    static void Main(string[] args)
    {
        int[,] nullMatrix = Matrix.CreateNullMatrix();
        Matrix.WriteMatrix("Nullmátrix", nullMatrix);

        int[,] unitMatrix = Matrix.CreateUnitMatrix();
        Matrix.WriteMatrix("Egységmátrix", unitMatrix);

        int[,] diagonalMatrix = Matrix.CreateDiagonalMatrix();
        Matrix.WriteMatrix("Diagonálismátrix", diagonalMatrix);

        int[,] upperTriangularMatrix = Matrix.CreateUpperTriangularMatrix();
        Matrix.WriteMatrix("Felső háromszögmátrix", upperTriangularMatrix);

        int[,] lowerTriangularMatrix = Matrix.CreateLowerTriangularMatrix();
        Matrix.WriteMatrix("Alsó háromszögmátrix", lowerTriangularMatrix);

        int[,] symmetriMatrix = Matrix.CreateSymmetricMatrix();
        Matrix.WriteMatrix("Szimmetrikusmátrix", symmetriMatrix);
        
        //Programozási tételek mátrixokra

        int[,] upperTriangularMatrixSample = Matrix.CreateUpperTriangularMatrix();
        Matrix.WriteMatrix("Teszt felső háromszögmátrix tételekhez", upperTriangularMatrixSample);
        
        Console.WriteLine($"Elemeinek összege: {Matrix.MatrixSum(upperTriangularMatrixSample)}");
        
        Console.WriteLine($"Elemeinek átlaga: {Matrix.MatrixAverage(upperTriangularMatrixSample)}");
        
        Console.WriteLine($"Páros elemek száma: {Matrix.MatrixEvenNumbersCount(upperTriangularMatrixSample)}");
        
        (int number, int i, int j) maxNumber = Matrix.MatrixMaxNumber(upperTriangularMatrixSample);
        Console.WriteLine($"Legnagyobb elem értéke: {maxNumber.number}");
        Console.WriteLine($"Legnagyobb elem helye: [{maxNumber.i}, {maxNumber.j}]");
        
        (int number, int i, int j) minNumber = Matrix.MatrixMinNumber(upperTriangularMatrixSample);
        Console.WriteLine($"Legkisebb elem értéke: {minNumber.number}");
        Console.WriteLine($"Legkisebb elem helye: [{minNumber.i}, {minNumber.j}]");

        bool containsDividableBy3 = Matrix.DoesContainNumberDividedBy(upperTriangularMatrix, 3);
        if (containsDividableBy3)
        {
            Console.WriteLine("A mátrix tartalmaz 3-mal osztható számot.");
            
            (int number, int i, int j) divideBy3 = Matrix.MatrixDivideByNumber(upperTriangularMatrixSample, 3);
            Console.WriteLine($"3-mal osztható szám értéke: {divideBy3.number}");
            Console.WriteLine($"3-mal osztható szám helye: [{divideBy3.i}, {divideBy3.j}]");
        }
        else
        {
            Console.WriteLine("A mátrix NEM tartalmaz 3-mal osztható számot.");   
        } 
    }
}
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
    }
}
using Matrixok_VB_Lib;

namespace Matrixok_VB;

class Program
{
    static void Main(string[] args)
    {
        int[,] nullMatrix = Matrix.CreateNullmatrix();
        Matrix.WriteMatrix("Nullmátrix", nullMatrix);
    }
}
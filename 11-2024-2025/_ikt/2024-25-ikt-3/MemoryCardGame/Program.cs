using MemoryCardGame.Core;
using MemoryCardGame.Other;

namespace MemoryCardGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Memóriakártya Játék";
            Game game = new Game();
            game.Start();
        }
    }
}
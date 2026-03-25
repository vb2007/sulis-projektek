using ByteFriend_Lib.Entities;
using ByteFriend_Lib.Helpers;

namespace ByteFriend_Lib.UI.Menu;

public static class DeathScreen
{
    private static readonly CustomColors DeathColor = new("#FF4444");
    private static readonly CustomColors InfoColor = new("#AAAAAA");

    private static readonly string[] Tombstone =
    [
        "       _____      ",
        "      /     \\     ",
        "     | R.I.P |    ",
        "     |       |    ",
        "     |       |    ",
        "    *|_______|*   "
    ];

    public static void Show(IAnimal animal, string deathMessage)
    {
        Console.CursorVisible = false;
        Render.ClearScreen();

        int centerY = Console.WindowHeight / 2 - 5;

        for (int i = 0; i < Tombstone.Length; i++)
        {
            Render.WriteAtCenter(centerY + i, DeathColor.Colorize(Tombstone[i]));
        }

        int msgTop = centerY + Tombstone.Length + 2;
        Render.WriteAtCenter(msgTop, DeathColor.Colorize(deathMessage));

        string stats = $"Életkor: {animal.Age} | Szakasz: {TimeManager.GetStateName(animal.State)}";
        Render.WriteAtCenter(msgTop + 2, InfoColor.Colorize(stats));

        Render.WriteAtCenter(Console.WindowHeight - 3, InfoColor.Colorize("Nyomj meg egy gombot a visszalépéshez..."));

        Console.ReadKey(true);
    }
}
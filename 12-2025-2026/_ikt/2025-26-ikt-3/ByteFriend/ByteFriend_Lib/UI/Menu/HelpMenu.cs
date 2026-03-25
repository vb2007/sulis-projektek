using ByteFriend_Lib.Helpers;

namespace ByteFriend_Lib.UI.Menu;

public static class HelpMenu
{
    private static readonly CustomColors TitleColor = new("#00D9FF");
    private static readonly CustomColors SectionNameColor = new("#FFD700");
    private static readonly CustomColors TextColor = new("#FFFFFF");
    private static readonly CustomColors HighlightColor = new("#00FF7F");

    private static readonly string SectionTitle1 = "Üdvözlünk a ByteFriend-ben!";
    private static readonly string[] Section1 =
    [
        "",
        "Válassz egy állatot a listából és igyekezz nem megölni!",
        "Az állatod a rendszeridőhöz relevánsan \"él\" és változik!",
        ""
    ];

    private static readonly string SectionTitle2 = "Statisztikák:";
    private static readonly string[] Section2 =
    [
        "  Éhség  -  Ha eléri a 100-at, az állat éhen hal.",
        "  Boldogság  -  Tartsd minél magasabban!",
        "  Egészség  -  Beteg állatot gyógyítani kell.",
        ""
    ];
    
    private static readonly string SectionTitle3 = "Életszakaszok:";
    private static readonly string[] Section3 =
    [
        "  Gyerek -> Felnőtt -> Idős -> Természetes halál",
        ""
    ];
    
    private static readonly string SectionTitle4 = "Vezérlés (játék közben):";
    private static readonly string[] Section4 =
    [
        "  ◄ ►       - Akció kiválasztása",
        "  ENTER     - Akció végrehajtása",
        "  ESC       - Mentés és kilépés"
    ];

    public static void Show()
    {
        Console.CursorVisible = false;
        Render.ClearScreen();

        int totalSectionsLength = 4 * 1 + Section1.Length + Section2.Length + Section3.Length + Section4.Length;
        int startTop = Math.Max(1, Console.WindowHeight / 2 - totalSectionsLength / 2 - 1);

        Render.WriteAtCenter(startTop, TitleColor.Colorize("--- Segítség ---"));

        int currentLine = startTop + 2;

        Render.WriteAtCenter(currentLine++, SectionNameColor.Colorize(SectionTitle1));
        foreach (string line in Section1)
        {
            Render.WriteAtCenter(currentLine++, TextColor.Colorize(line));
        }
        
        Render.WriteAtCenter(currentLine++, SectionNameColor.Colorize(SectionTitle2));
        foreach (string line in Section2)
        {
            Render.WriteAtCenter(currentLine++, TextColor.Colorize(line));
        }
        
        Render.WriteAtCenter(currentLine++, SectionNameColor.Colorize(SectionTitle3));
        foreach (string line in Section3)
        {
            Render.WriteAtCenter(currentLine++, TextColor.Colorize(line));
        }
        
        Render.WriteAtCenter(currentLine++, SectionNameColor.Colorize(SectionTitle4));
        foreach (string line in Section4)
        {
            Render.WriteAtCenter(currentLine++, TextColor.Colorize(line));
        }

        Render.WriteAtCenter(
            Console.WindowHeight - 2,
            HighlightColor.Colorize("Nyomj bármilyen gombot a visszalépéshez...")
        );

        Console.ReadKey(true);
    }
}
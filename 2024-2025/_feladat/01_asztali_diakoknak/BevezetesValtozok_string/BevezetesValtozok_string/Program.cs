Console.WriteLine("Üdvözöllek!"); //egy sort ír ki, és sort emel
Console.WriteLine(); //üres sort ír ki, és sort emel
Console.Write("Kérem adja meg a nevét: "); //kiírja a szöveget, de nem történik sor emelés
                                           //  Console.ReadLine(); egy sor beolvasása
string nev = Console.ReadLine(); // változónév = kifejezés vagy érték

Console.BackgroundColor = ConsoleColor.White; //háttérszín megadása
Console.ForegroundColor = ConsoleColor.Blue; //betűszín megadása
Console.Clear(); //ablak tartalmának törlése

string tigris = "tigris";

string nemHasznalom="";

Console.WriteLine("Szia " + nev); //string típusú változók esetén + konkatenáció, magyarul összefűzés
Console.WriteLine("Szia {0}, a {1} szép! {0}", nev, tigris); //helyörzős kiírás, a helyörző helyére behelyettesíti a szöveg után felsorolt értékeket. 0-tól számol
Console.WriteLine($"Szia {nev}"); //a kapcsoszárójelben lévő kifejezést / változót kiértékeli, és úgy írja ki
Console.ReadKey();

Console.ResetColor(); //alapértelmezett szín visszaállítása
Console.Clear();

Console.WriteLine("\tSzép napunk van!");  // '\t' tabulátor   '\n' soremelés



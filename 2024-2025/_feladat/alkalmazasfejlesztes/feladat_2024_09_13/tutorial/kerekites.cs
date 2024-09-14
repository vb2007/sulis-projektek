
double pozitiv = 6.2345;
double negativ = -3.9876;
Console.WriteLine($"Pozitív érték: {pozitiv}\tnegatív érték: {negativ}");
Console.WriteLine("Felfelé kerekítés egészre");
Console.WriteLine($"Pozitív érték: {Math.Ceiling(pozitiv)}\tnegatív érték {Math.Ceiling(negativ)}");
Console.WriteLine("Lefelé kerekítés egészre");
Console.WriteLine($"Pozitív érték: {Math.Floor(pozitiv)}\tnegatív érték {Math.Floor(negativ)}");
Console.WriteLine("Matematikai kerekítés egészre");
Console.WriteLine($"Pozitív érték: {Math.Round(pozitiv)}\tnegatív érték {Math.Round(negativ)}");
Console.WriteLine("Matematikai kerekítés 3 tizedesjegyre"); //Számábrázolási hiba miatt kerekítési hiba lehet!
Console.WriteLine($"Pozitív érték: {Math.Round(pozitiv, 3)}\tnegatív érték {Math.Round(negativ, 3)}");
Console.WriteLine("Kerekítés 3 tizedesjegyre pontosság megadással");
Console.WriteLine("MidpointRounding.ToEven"); //legközelebbi páros felé
Console.WriteLine($"Pozitív érték: {Math.Round(pozitiv, 3, MidpointRounding.ToEven)}" +
    $"\tnegatív érték {Math.Round(negativ, 3, MidpointRounding.ToEven)}");
Console.WriteLine("MidpointRounding.ToPositiveInfinity"); //legközelebbi felfelé
Console.WriteLine($"Pozitív érték: {Math.Round(pozitiv, 3, MidpointRounding.ToPositiveInfinity)}" +
    $"\tnegatív érték {Math.Round(negativ, 3, MidpointRounding.ToPositiveInfinity)}");
Console.WriteLine("MidpointRounding.ToNegativeInfinity"); //legközelebbi lefelé
Console.WriteLine($"Pozitív érték: {Math.Round(pozitiv, 3, MidpointRounding.ToNegativeInfinity)}" +
    $"\tnegatív érték {Math.Round(negativ, 3, MidpointRounding.ToNegativeInfinity)}");
Console.WriteLine("MidpointRounding.ToZero"); //0 felé
Console.WriteLine($"Pozitív érték: {Math.Round(pozitiv, 3, MidpointRounding.ToZero)}" +
    $"\tnegatív érték {Math.Round(negativ, 3, MidpointRounding.ToZero)}");
Console.WriteLine("MidpointRounding.AwayFromZero"); //0-tól távolabbi felé
Console.WriteLine($"Pozitív érték: {Math.Round(pozitiv, 3, MidpointRounding.AwayFromZero)}" +
    $"\tnegatív érték {Math.Round(negativ, 3, MidpointRounding.AwayFromZero)}");